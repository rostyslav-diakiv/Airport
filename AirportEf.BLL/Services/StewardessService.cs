namespace AirportEf.BLL.Services
{
    using System;
    using System.Collections.Generic;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.BLL.Interfaces;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;

    using AutoMapper;

    public class StewardessService : BaseService<StewardessDto, StewardessRequest, int>, IStewardessService
    {
        public StewardessService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public override IEnumerable<StewardessDto> GetAllEntity()
        {
            throw new NotImplementedException();
            // var s = _uow.StewardessRepository.GetRange();
            //                      source            destination
            //var dtos = mapper.Map<List<Stewardess>, List<StewardessDto>>(s);

            //return dtos;
        }

        public override StewardessDto GetEntityById(int id)
        {
            throw new NotImplementedException();
            //var entity = _uow.StewardessRepository.GetFirstOrDefault(s => s.Id == id);

            //return MapEntity(entity);
        }

        public override StewardessDto CreateEntity(StewardessRequest request)
        {
            throw new NotImplementedException();
            //var entity = mapper.Map<StewardessRequest, Stewardess>(request);

            //entity = _uow.StewardessRepository.Create(entity);

            //return MapEntity(entity);
        }

        public override StewardessDto UpdateEntityById(StewardessRequest request, int id)
        {
            throw new NotImplementedException();
            //var entity = new Stewardess(request, id);

            //var updated = _uow.StewardessRepository.Update(entity);

            //return MapEntity(updated);
        }

        public override bool DeleteEntityById(int id)
        {
            throw new NotImplementedException();
            //return _uow.StewardessRepository.Delete(id);
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
