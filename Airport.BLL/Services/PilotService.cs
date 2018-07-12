namespace Airport.BLL.Services
{
    using System.Collections.Generic;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public class PilotService : BaseService<PilotDto, PilotRequest, int>, IPilotService
    {
        public PilotService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public override IEnumerable<PilotDto> GetAllEntity()
        {
            var entities = uow.PilotRepository.GetRange();

            var dtos = mapper.Map<List<Pilot>, List<PilotDto>>(entities);

            return dtos;
        }

        public override PilotDto GetEntityById(int id)
        {
            var entity = uow.PilotRepository.GetFirstOrDefault(s => s.Id == id);

            return MapEntity(entity);
        }

        public override PilotDto CreateEntity(PilotRequest request)
        {
            var entity = mapper.Map<PilotRequest, Pilot>(request);

            entity = uow.PilotRepository.Create(entity);

            return MapEntity(entity);
        }

        public override PilotDto UpdateEntityById(PilotRequest request, int id)
        {
            var entity = new Pilot(request, id);

            var updated = uow.PilotRepository.Update(entity);

            // Updates automatically in Crews
            //var crewsToUpdate = uow.CrewRepository.GetRange(count: int.MaxValue, filter: c => c.PilotId == id);
            //foreach (var c in crewsToUpdate)
            //{
            //    c.Pilot = mapper.Map<Pilot>(updated);
            //}

            return MapEntity(updated);
        }

        public override bool DeleteEntityById(int id)
        {
            var crewsToUpdate = uow.CrewRepository.GetRange(count: int.MaxValue, filter: c => c.PilotId == id);
            //foreach (var c in crewsToUpdate)
            //{
            //    c.Pilot = null;
            //    c.PilotId = 0;
            //}

            return uow.PilotRepository.Delete(id);
        }

        private PilotDto MapEntity(Pilot entity)
        {
            if (entity == null)
            {
                return null;
            }

            var dto = mapper.Map<Pilot, PilotDto>(entity);

            return dto;
        }
    }
}
