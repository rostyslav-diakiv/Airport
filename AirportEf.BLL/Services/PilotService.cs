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

    public class PilotService : BaseService<PilotDto, PilotRequest, int>, IPilotService
    {
        public PilotService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public override IEnumerable<PilotDto> GetAllEntity()
        {
            throw new NotImplementedException();
            //var entities = _uow.PilotRepository.GetRange();

            //var dtos = mapper.Map<List<Pilot>, List<PilotDto>>(entities);

            //return dtos;
        }

        public override PilotDto GetEntityById(int id)
        {
            throw new NotImplementedException();
            //var entity = _uow.PilotRepository.GetFirstOrDefault(s => s.Id == id);

            //return MapEntity(entity);
        }

        public override PilotDto CreateEntity(PilotRequest request)
        {
            throw new NotImplementedException();
            //var entity = mapper.Map<PilotRequest, Pilot>(request);

            //entity = _uow.PilotRepository.Create(entity);

            //return MapEntity(entity);
        }

        public override PilotDto UpdateEntityById(PilotRequest request, int id)
        {
            throw new NotImplementedException();
            //var entity = new Pilot(request, id);

            //var updated = _uow.PilotRepository.Update(entity);

            //return MapEntity(updated);
        }

        public override bool DeleteEntityById(int id)
        {
            throw new NotImplementedException();
            // return _uow.PilotRepository.Delete(id);
        }

        private PilotDto MapEntity(Pilot entity)
        {
            if (entity == null)
            {
                return null;
            }

            var dto = _mapper.Map<Pilot, PilotDto>(entity);

            return dto;
        }
    }
}
