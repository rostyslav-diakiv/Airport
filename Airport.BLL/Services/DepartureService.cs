namespace Airport.BLL.Services
{
    using System.Collections.Generic;
    using System.Net;

    using Airport.BLL.Interfaces;
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.Common.Services;
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces;

    using AutoMapper;

    public class DepartureService : BaseService<Departure, DepartureDto, DepartureRequest, int>, IDepartureService
    {
        public DepartureService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override IEnumerable<DepartureDto> GetAllEntity()
        {
            var tickets = uow.DepartureRepository.GetRange();

            var dtos = mapper.Map<List<Departure>, List<DepartureDto>>(tickets);

            return dtos;
        }

        public override DepartureDto GetEntityById(int id)
        {
            var entity = uow.DepartureRepository.GetFirstOrDefault(s => s.Id == id);

            return MapEntity(entity);
        }

        public override DepartureDto CreateEntity(DepartureRequest request)
        {
            var entity = InstantiateDeparture(request);

            entity = uow.DepartureRepository.Create(entity);

            return MapEntity(entity);
        }

        public override DepartureDto UpdateEntityById(DepartureRequest request, int id)
        {
            var entity = InstantiateDeparture(request, id);

            var updated = uow.DepartureRepository.Update(entity);

            return MapEntity(updated);
        }

        public override bool DeleteEntityById(int id)
        {
            var e = uow.DepartureRepository.GetFirstOrDefault(s => s.Id == id);
            var res = uow.DepartureRepository.Delete(e);
            if (!res)
            {
                return false;
            }

            e.Flight.Departures.Remove(e);
            e.Crew.Departures.Remove(e);
            e.Plane.Departures.Remove(e);

            return true;
        }

        public Departure InstantiateDeparture(DepartureRequest request, int id = 0)
        {
            var flight = uow.FlightRepository.GetFirstOrDefault(f => f.Id == request.FlightNumber);
            if (flight == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Flight with number: {request.FlightNumber} doesn't exist");
            }

            var crew = uow.CrewRepository.GetFirstOrDefault(c => c.Id == request.CrewId);
            if (crew == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Crew with id: {request.CrewId} doesn't exist");
            }

            var plane = uow.PlaneRepository.GetFirstOrDefault(f => f.Id == request.PlaneId);
            if (plane == null)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Plane with id: {request.PlaneId} doesn't exist");
            }

            return new Departure(request, flight, crew, plane, id);
        }
    }
}
