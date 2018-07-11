namespace Airport.BLL.Services
{
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

    public class CrewService : BaseService, ICrewService
    {
        public CrewService(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }

        public IEnumerable<CrewDto> GetAllCrews()
        {
            var entity = _uow.CrewRepository.GetRange();
            var dtos = _mapper.Map<List<Crew>, List<CrewDto>>(entity);

            return dtos;
        }

        public CrewDto GetCrewById(int id)
        {
            var entity = _uow.CrewRepository.GetFirstOrDefault(s => s.Id == id);

            return MapEntity(entity);
        }

        public CrewDto CreateCrew(CrewRequest request)
        {
            var entity = InstantiateCrew(request);

            entity = _uow.CrewRepository.Create(entity);

            return MapEntity(entity);
        }

        public CrewDto UpdateCrewById(CrewRequest request, int id)
        {
            var entity = InstantiateCrew(request, id);

            var updated = _uow.CrewRepository.Update(entity);

            return MapEntity(updated);
        }

        public bool DeleteCrewById(int id)
        {
            return _uow.CrewRepository.Delete(id);
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
            var sts = _uow.StewardessRepository.GetRange(
                count: request.StewardessesIds.Count(),
                filter: s => request.StewardessesIds.Contains(s.Id));

            if (sts.Count < request.StewardessesIds.Count())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "One or more Stewardesses with such id not found");
            }

            var entity = new Crew()
                             {
                                 Id = id,
                                 Stewardesses = sts
                             };

            return entity;
        }
    }
}
