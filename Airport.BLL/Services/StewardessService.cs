namespace Airport.BLL.Services
{
    using System.Collections.Generic;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public class StewardessService : BaseService<Stewardess, StewardessDto, StewardessRequest, int>, IStewardessService
    {
        public StewardessService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public override IEnumerable<StewardessDto> GetAllEntity()
        {
            var stewardesses = uow.StewardessRepository.GetRange();

            var dtos = mapper.Map<List<Stewardess>, List<StewardessDto>>(stewardesses);

            return dtos;
        }

        public override StewardessDto GetEntityById(int id)
        {
            var entity = uow.StewardessRepository.GetFirstOrDefault(s => s.Id == id);

            return MapEntity(entity);
        }

        public override StewardessDto CreateEntity(StewardessRequest request)
        {
            var entity = mapper.Map<StewardessRequest, Stewardess>(request);

            entity = uow.StewardessRepository.Create(entity);

            return MapEntity(entity);
        }

        public override StewardessDto UpdateEntityById(StewardessRequest request, int id)
        {
            var entity = new Stewardess(request, id);

            var updated = uow.StewardessRepository.Update(entity);

            return MapEntity(updated);
        }

        public override bool DeleteEntityById(int id)
        {
            var entity = uow.StewardessRepository.GetFirstOrDefault(s => s.Id == id);
            var res = uow.StewardessRepository.Delete(entity);
            if (!res)
            {
                return false;
            }
            
            foreach (var c in entity.Crews)
            {
                c.Stewardesses.Remove(entity);
            }

            return true;
        }
    }
}
