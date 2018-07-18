namespace AirportEf.BLL.Mapper
{
    using Airport.Common.Dtos;

    using AirportEf.DAL.Entities;

    using AutoMapper;

    public class PlanesProfile : Profile
    {
        public PlanesProfile()
        {
            CreateMap<Plane, Plane>().ForMember(d => d.Departures, o => o.Ignore()); // Don't Map Crews because in new obj the are empty!!!

            CreateMap<Plane, PlaneDto>().ForMember(d => d.PlaneType, o => o.MapFrom(s => s.PlaneType));
        }
    }
}
