namespace AirportEf.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.Common.Services;

    using AirportEf.BLL.Interfaces;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    public class CrewService : BaseService<Crew, CrewDto, CrewRequest, int>, ICrewService
    {
        public CrewService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override async Task<IEnumerable<CrewDto>> GetAllEntitiesAsync()
        {
            var entity = await uow.CrewRepository.GetRangeAsync(include: cr => cr.Include(c => c.Pilot)
                                                                                 .Include(c => c.CrewStewardess)
                                                                                       .ThenInclude(c => c.Stewardess));
            var dtos = mapper.Map<List<Crew>, List<CrewDto>>(entity);

            return dtos;
        }

        public override async Task<CrewDto> GetEntityByIdAsync(int id)
        {
            var entity = await uow.CrewRepository.GetFirstOrDefaultAsync(
                                                    s => s.Id == id, 
                                                    include: cr => cr.Include(c => c.Pilot)
                                                                     .Include(c => c.CrewStewardess)
                                                                        .ThenInclude(c => c.Stewardess));

            return MapEntity(entity);
        }

        public override async Task<CrewDto> CreateEntityAsync(CrewRequest request)
        {
            var entity = await InstantiateCrewAsync(request);

            entity = await uow.CrewRepository.CreateAsync(entity);
            var result = await uow.SaveAsync();
            if (!result)
            {
                return null;
            }

            return MapEntity(entity);
        }

        public override async Task<bool> UpdateEntityByIdAsync(CrewRequest request, int id)
        {
            var entity = await InstantiateCrewAsync(request, id);

            var updated = await uow.CrewRepository.UpdateAsync(entity, include: crews => crews.Include(c => c.CrewStewardess));
            var result = await uow.SaveAsync();

            return result;
        }

        public override async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await uow.CrewRepository.DeleteAsync(id);
            var result = await uow.SaveAsync();

            return result;
        }

        private async Task<Crew> InstantiateCrewAsync(CrewRequest request, int id = 0)
        {
            // Remove identical Ids from collection
            request.StewardessesIds = request.StewardessesIds.Distinct().ToList();

            // TODO: Change Linq to return bool if all stews exists
            var sts = await uow.StewardessRepository.GetRangeAsync(
                          count: request.StewardessesIds.Count(),
                          filter: s => request.StewardessesIds.Contains(s.Id),
                          disableTracking: false);

            if (sts.Count < request.StewardessesIds.Count())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "One or more Stewardesses with such id not found");
            }

            var pilotEx = await uow.PilotRepository.ExistAsync(p => p.Id == request.PilotId);
            if (!pilotEx)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Pilot with such id not found");
            }

            var entity = new Crew()
            {
                Id = id,
                PilotId = request.PilotId,
                Departures = new List<Departure>(),
                CrewStewardess = new List<CrewStewardess>()
            };

            foreach (var s in sts)
            {
                entity.CrewStewardess.Add(new CrewStewardess()
                {
                    Crew = entity,
                    Stewardess = s
                });
            }

            return entity;
        }
    }
}
