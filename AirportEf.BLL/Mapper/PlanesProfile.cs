namespace AirportEf.BLL.Mapper
{
    using System.Collections.Generic;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.DAL.Entities;

    using AutoMapper;

    public class PlanesProfile : Profile
    {
        public PlanesProfile()
        {
            CreateMap<Plane, Plane>().ForMember(d => d.Departures, o => o.Ignore()); // Don't Map Crews because in new obj the are empty!!!

            //CreateMap<PlaneRequest, Plane>()
            //    .ForMember(d => d.Id, o => o.UseValue(0))
            //    .ForMember(d => d.PlaneType, o => o.UseDestinationValue())
            //    .ForMember(d => d.Departures, o => o.UseValue(new List<Departure>())); // Crews won't be null when we create new Pilot;

            CreateMap<Plane, PlaneDto>().ForMember(d => d.PlaneType, o => o.MapFrom(s => s.PlaneType));
            /*
             * new PlaneTypeDto()
                {
                    Id = s.PlaneType.Id,
                    PlaneModel = s.PlaneType.PlaneModel,
                    MaximalNumberOfPlaces = s.PlaneType.MaxNumberOfPlaces,
                    MaximalCarryingCapacityKg = s.PlaneType.MaxCarryingCapacityKg,
                }));
             */
        }
    }
}
