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

    public class CrewService : BaseService<Crew, CrewDto, CrewRequest, int>, ICrewService
    {
        public CrewService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override IEnumerable<CrewDto> GetAllEntity()
        {
            var entity = uow.CrewRepository.GetRange();
            var dtos = mapper.Map<List<Crew>, List<CrewDto>>(entity);

            return dtos;
        }

        public override CrewDto GetEntityById(int id)
        {
            var entity = uow.CrewRepository.GetFirstOrDefault(s => s.Id == id);

            return MapEntity(entity);
        }

        public override CrewDto CreateEntity(CrewRequest request)
        {
            var entity = InstantiateCrew(request);

            entity = uow.CrewRepository.Create(entity);

            return MapEntity(entity);
        }

        public override Crew UpdateEntityById(CrewRequest request, int id)
        {
            var entity = InstantiateCrew(request, id);

            var updated = uow.CrewRepository.Update(entity);

            return updated;
        }

        public override bool DeleteEntityById(int id)
        {
            var e = uow.CrewRepository.GetFirstOrDefault(s => s.Id == id);
            var res = uow.CrewRepository.Delete(e);
            if (!res)
            {
                return false;
            }

            ClearDependencies(e);

            return true;
        }

        // Remove Crew from Linked Entities
        private void ClearDependencies(Crew crew)
        {
            crew.Pilot?.Crews?.Remove(crew);

            if (crew.Stewardesses != null)
            {
                foreach (var s in crew.Stewardesses)
                {
                    s.Crews.Remove(crew);
                }
            }

            if (crew.Departures == null) return;
            foreach (var d in crew.Departures)
            {
                d.Crew = null;
                d.CrewId = 0;
            }
        }

        private Crew InstantiateCrew(CrewRequest request, int id = 0)
        {
            // Remove identical Ids from collection
            request.StewardessesIds = request.StewardessesIds.Distinct().ToList();

            var sts = uow.StewardessRepository.GetRange(
                count: request.StewardessesIds.Count(),
                filter: s => request.StewardessesIds.Contains(s.Id));

            if (sts.Count < request.StewardessesIds.Count())
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "One or more Stewardesses with such id not found");
            }

            var pilot = uow.PilotRepository.GetFirstOrDefault(p => p.Id == request.PilotId);
            if (pilot == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, "Pilot with such id not found");
            }

            var entity = new Crew()
            {
                Id = id,
                Pilot = pilot,
                PilotId = pilot.Id,
                Stewardesses = sts
            };

            // Add Crew to Linked Entities
            pilot.Crews.Add(entity);
            foreach (var s in sts)
            {
                s.Crews.Add(entity);
            }

            return entity;
        }
    }
}
