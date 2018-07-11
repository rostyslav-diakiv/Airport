namespace Airport.BLL.Services
{
    using System.Collections.Generic;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public class StewardessService : BaseService, IStewardessService
    {
        public StewardessService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public IEnumerable<StewardessDto> GetAllStewardesses()
        {
            var s = _uow.StewardessRepository.GetRange();
            //                      source            destination
            var dtos = _mapper.Map<List<Stewardess>, List<StewardessDto>>(s);

            return dtos;
        }

        public StewardessDto GetStewardessById(int id)
        {
            var entity = _uow.StewardessRepository.GetFirstOrDefault(s => s.Id == id);

            return MapEntity(entity);
        }

        public StewardessDto CreateStewardess(StewardessRequest request)
        {
            var entity = _mapper.Map<StewardessRequest, Stewardess>(request);

            entity = _uow.StewardessRepository.Create(entity);

            return MapEntity(entity);
        }

        public StewardessDto UpdateStewardessById(StewardessRequest request, int id)
        {
            var entity = Stewardess.FromRequest(request, id);

            var updated = _uow.StewardessRepository.Update(entity);

            return MapEntity(updated);
        }

        public bool DeleteStewardessById(int id)
        {
            return _uow.StewardessRepository.Delete(id);
        }

        private StewardessDto MapEntity(Stewardess entity)
        {
            if (entity == null)
            {
                return null;
            }
            //                      source     destination
            var dto = _mapper.Map<Stewardess, StewardessDto>(entity);

            return dto;
        }
    }
}
