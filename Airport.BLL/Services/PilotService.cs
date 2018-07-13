namespace Airport.BLL.Services
{
    using System.Collections.Generic;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public class PilotService : BaseService<Pilot, PilotDto, PilotRequest, int>, IPilotService
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

        public override IEnumerable<PilotDto> GetAllEntity(Filter filter)
        {

            // TODO

            return base.GetAllEntity(filter);
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

        public override Pilot UpdateEntityById(PilotRequest request, int id)
        {
            var entity = new Pilot(request, id);

            var updated = uow.PilotRepository.Update(entity);

            return updated;
        }

        public override bool DeleteEntityById(int id)
        {
            var e = uow.PilotRepository.GetFirstOrDefault(s => s.Id == id);
            var res = uow.PilotRepository.Delete(e);
            if (!res)
            {
                return false;
            }

            if (e.Crews == null) return true;

            foreach (var c in e.Crews)
            {
                c.Pilot = null;
                c.PilotId = 0;
            }

            return true;
        }
    }
}
