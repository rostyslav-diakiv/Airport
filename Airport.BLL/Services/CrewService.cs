namespace Airport.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.Common.Services;
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public class CrewService : BaseService<CrewDto, CrewRequest, int>, ICrewService
    {
        public CrewService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override IEnumerable<CrewDto> GetAllEntity()
        {
            var entity = uow.CrewRepository.GetRange();
            var dtos = mapper.Map<List<Crew>, List<CrewDto>>(entity);

            return dtos;
        }

        public override CrewDto GetEntityById(int id)
        {
            var entity = uow.CrewRepository.GetFirstOrDefault(s => s.Id == id);

            return MapEntity(entity);
        }

        public override CrewDto CreateEntity(CrewRequest request)
        {
            var entity = InstantiateCrew(request);

            entity = uow.CrewRepository.Create(entity);

            return MapEntity(entity);
        }

        public override CrewDto UpdateEntityById(CrewRequest request, int id)
        {
            var entity = InstantiateCrew(request, id);

            var updated = uow.CrewRepository.Update(entity);

            return MapEntity(updated);
        }

        public override bool DeleteEntityById(int id)
        {
            return uow.CrewRepository.Delete(id);
        }

        private CrewDto MapEntity(Crew entity)
        {
            if (entity == null)
            {
                return null;
            }

            var dto = mapper.Map<Crew, CrewDto>(entity);
            return dto;
        }

        private Crew InstantiateCrew(CrewRequest request, int id = 0)
        {
            // Remove identical Ids from collection
            request.StewardessesIds = request.StewardessesIds.Distinct().ToList();

            var sts = uow.StewardessRepository.GetRange(
                count: request.StewardessesIds.Count(),
                filter: s => request.StewardessesIds.Contains(s.Id));

            if (sts.Count < request.StewardessesIds.Count())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "One or more Stewardesses with such id not found");
            }

            var pilot = uow.PilotRepository.GetFirstOrDefault(p => p.Id == request.PilotId);
            if (pilot == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Pilot with such id not found");
            }

            var entity = new Crew()
            {
                Id = id,
                Pilot = pilot,
                PilotId = pilot.Id,
                Stewardesses = sts
            };

            return entity;
        }
    }
}
