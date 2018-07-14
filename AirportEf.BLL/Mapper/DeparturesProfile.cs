namespace AirportEf.BLL.Mapper
{
    using Airport.Common.Dtos;

    using AirportEf.DAL.Entities;

    using AutoMapper;

    public class DeparturesProfile : Profile
    {
        public DeparturesProfile()
        {
            // Flights
            CreateMap<Departure, Departure>();

            CreateMap<Departure, DepartureDto>()
                .ForMember(d => d.Flight, o => o.MapFrom(s => s.Flight))
                .ForMember(d => d.Plane, o => o.MapFrom(s => s.Plane));
        }
    }
}
