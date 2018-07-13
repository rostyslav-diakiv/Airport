namespace Airport.BLL.Mapper
{
    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.DAL.Entities;

    using AutoMapper;

    public class FlightsProfile : Profile
    {
        public FlightsProfile()
        {
            // Flights
            CreateMap<Flight, Flight>()
                .ForMember(d => d.Tickets, o => o.Ignore()) // Don't Map Crews because in new obj the are empty!!!
                .ForMember(d => d.Departures, o => o.Ignore()); // Don't Map Crews because in new obj the are empty!!!

            CreateMap<FlightRequest, Flight>()
                .ForMember(d => d.Tickets, o => o.Ignore()) // Don't Map Crews because in new obj the are empty!!!
                .ForMember(d => d.Departures, o => o.Ignore()) // Don't Map Crews because in new obj the are empty!!!;
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Number))
                .ForMember(d => d.DeparturePoint, o => o.MapFrom(s => s.PointOfDeparture));

            CreateMap<Flight, FlightDto>()
                .ForMember(d => d.PointOfDeparture, o => o.MapFrom(s => s.DeparturePoint));
        }
    }
}
