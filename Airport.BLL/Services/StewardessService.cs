namespace Airport.BLL.Services
{
    using System.Collections.Generic;
    using System.Linq;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public class StewardessService : BaseService<StewardessDto, StewardessRequest, int>, IStewardessService
    {
        public StewardessService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public override IEnumerable<StewardessDto> GetAllEntity()
        {
            var s = uow.StewardessRepository.GetRange();
            //                              source destination
            var dtos = mapper.Map<List<Stewardess>, List<StewardessDto>>(s);

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
            var e = uow.StewardessRepository.GetFirstOrDefault(s => s.Id == id);
            var res = uow.StewardessRepository.Delete(e);
            if (!res)
            {
                return false;
            }

            var crewsToEdit = uow.CrewRepository.GetRange(count: int.MaxValue, filter: c => c.Stewardesses.Contains(e));
            foreach (var c in crewsToEdit)
            {
                c.Stewardesses.Remove(e);
            }

            return true;
        }

        private StewardessDto MapEntity(Stewardess entity)
        {
            if (entity == null)
            {
                return null;
            }
            //                      source     destination
            var dto = mapper.Map<Stewardess, StewardessDto>(entity);

            return dto;
        }
    }
}
