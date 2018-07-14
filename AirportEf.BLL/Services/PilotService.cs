namespace AirportEf.BLL.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.BLL.Interfaces;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;

    using AutoMapper;

    using Microsoft.EntityFrameworkCore;

    public class PilotService : BaseService<Pilot, PilotDto, PilotRequest, int>, IPilotService
    {
        public PilotService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public override async Task<IEnumerable<PilotDto>> GetAllEntitiesAsync()
        {
            var entities = await uow.PilotRepository.GetRangeAsync().ConfigureAwait(false);

            var dtos = mapper.Map<List<Pilot>, List<PilotDto>>(entities);

            return dtos;
        }

        public override async Task<IEnumerable<PilotDto>> GetAllEntitiesAsync(Filter filter)
        {

            // TODO

            return await base.GetAllEntitiesAsync(filter).ConfigureAwait(false);
        }

        public override async Task<PilotDto> GetEntityByIdAsync(int id)
        {
            var entity = await uow.PilotRepository.GetFirstOrDefaultAsync(
                             s => s.Id == id, 
                             include: pilots => pilots.Include(p => p.Crews)
                                                        .ThenInclude(c => c.CrewStewardess)
                                                          .ThenInclude(cs => cs.Stewardess)).ConfigureAwait(false);

            return MapEntity(entity);
        }

        public override async Task<PilotDto> CreateEntityAsync(PilotRequest request)
        {
            var entity = mapper.Map<PilotRequest, Pilot>(request);

            entity = await uow.PilotRepository.CreateAsync(entity);
            var result = await uow.SaveAsync();
            if (!result) return null;

            return MapEntity(entity);
        }

        public override async Task<bool> UpdateEntityByIdAsync(PilotRequest request, int id)
        {
            var entity = new Pilot(request, id);

            var updated = await uow.PilotRepository.UpdateAsync(entity);
            var result = await uow.SaveAsync();

            return result;
        }

        public override async Task<bool> DeleteEntityByIdAsync(int id)
        {
            await uow.PilotRepository.DeleteAsync(id);
            var result = await uow.SaveAsync();

            return result;
        }
    }
}
