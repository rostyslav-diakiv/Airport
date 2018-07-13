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

    public class FlightService : BaseService<Flight, FlightDto, FlightRequest, string>, IFlightService
    {
        public FlightService(IUnitOfWork uow, IMapper mapper)
            : base(uow, mapper)
        {
        }

        public override IEnumerable<FlightDto> GetAllEntity()
        {
            var s = uow.FlightRepository.GetRange();

            var dtos = mapper.Map<List<Flight>, List<FlightDto>>(s);

            return dtos;
        }

        public override FlightDto GetEntityById(string id)
        {
            var entity = uow.FlightRepository.GetFirstOrDefault(s => s.Id == id);

            return MapEntity(entity);
        }

        public override FlightDto CreateEntity(FlightRequest request)
        {
            var exists = uow.FlightRepository.Exist(f => f.Id == request.Number);
            if (exists)
            {
                throw new HttpStatusCodeException(HttpStatusCode.BadRequest, $"Flight with number: {request.Number} already exists");
            }

            var entity = mapper.Map<FlightRequest, Flight>(request);

            entity = uow.FlightRepository.Create(entity);

            return MapEntity(entity);
        }

        public override Flight UpdateEntityById(FlightRequest request, string id)
        {
            var entity = new Flight(request, id);

            var updated = uow.FlightRepository.Update(entity);

            return updated;
        }

        public override bool DeleteEntityById(string id)
        {
            var e = uow.FlightRepository.GetFirstOrDefault(s => s.Id == id);
            var res = uow.FlightRepository.Delete(e);
            if (!res)
            {
                return false;
            }

            ClearDependencies(e);

            return true;
        }

        // Remove Crew from Linked Entities
        private void ClearDependencies(Flight flight)
        {
            if (flight.Departures != null)
            {
                foreach (var d in flight.Departures)
                {
                    d.Flight = null;
                    d.FlightId = null;
                }
            }

            if (flight.Tickets == null) return;

            foreach (var d in flight.Tickets)
            {
                d.Flight = null;
                d.FlightId = null;
            }
        }
    }
}
