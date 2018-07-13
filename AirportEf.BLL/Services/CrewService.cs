namespace AirportEf.BLL.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.Common.Services;

    using AirportEf.BLL.Interfaces;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces;

    using AutoMapper;

    public class CrewService : BaseService<CrewDto, CrewRequest, int>, ICrewService
    {
        public CrewService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public override IEnumerable<CrewDto> GetAllEntity()
        {
            throw new NotImplementedException();
            //var entity = _uow.CrewRepository.GetRange();
            //var dtos = mapper.Map<List<Crew>, List<CrewDto>>(entity);

            //return dtos;
        }

        public override CrewDto GetEntityById(int id)
        {
            throw new NotImplementedException();
            //var entity = _uow.CrewRepository.GetFirstOrDefault(s => s.Id == id);

            //return MapEntity(entity);
        }

        public override CrewDto CreateEntity(CrewRequest request)
        {
            throw new NotImplementedException();
            //var entity = InstantiateCrew(request);

            //entity = _uow.CrewRepository.Create(entity);

            //return MapEntity(entity);
        }

        public override CrewDto UpdateEntityById(CrewRequest request, int id)
        {
            throw new NotImplementedException();
            //var entity = InstantiateCrew(request, id);

            //var updated = _uow.CrewRepository.Update(entity);

            //return MapEntity(updated);
        }

        public override bool DeleteEntityById(int id)
        {
            throw new NotImplementedException();
            //return _uow.CrewRepository.Delete(id);
        }

        private CrewDto MapEntity(Crew entity)
        {
            if (entity == null)
            {
                return null;
            }

            var dto = _mapper.Map<Crew, CrewDto>(entity);
            return dto;
        }

        private Crew InstantiateCrew(CrewRequest request, int id = 0)
        {
            throw new NotImplementedException();
            //var sts = _uow.StewardessRepository.GetRange(
            //    count: request.StewardessesIds.Count(),
            //    filter: s => request.StewardessesIds.Contains(s.Id));

            //if (sts.Count < request.StewardessesIds.Count())
            //{
            //    throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "One or more Stewardesses with such id not found");
            //}

            //var entity = new Crew()
            //                 {
            //                     Id = id,
            //                     Stewardesses = sts
            //                 };

            //return entity;
        }
    }
}
