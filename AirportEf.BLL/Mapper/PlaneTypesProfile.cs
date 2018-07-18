namespace AirportEf.BLL.Mapper
{
    using System.Collections.Generic;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.DAL.Entities;

    using AutoMapper;

    public class PlaneTypesProfile : Profile
    {
        public PlaneTypesProfile()
        {
            CreateMap<PlaneType, PlaneType>().ForMember(d => d.Planes, o => o.Ignore()); // Don't Map Planes because in update objects they are empty!!!
            CreateMap<PlaneType, PlaneTypeDto>()
                .ForMember(d => d.MaximalCarryingCapacityKg, o => o.MapFrom(s => s.MaxCarryingCapacityKg))
                .ForMember(d => d.MaximalNumberOfPlaces, o => o.MapFrom(s => s.MaxNumberOfPlaces));

            CreateMap<PlaneTypeRequest, PlaneType>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.Planes, o => o.UseValue(new List<Plane>())) // Crews won't be null when we create new PlaneType
                .ForMember(d => d.MaxCarryingCapacityKg, o => o.MapFrom(s => s.MaximalCarryingCapacityKg))
                .ForMember(d => d.MaxNumberOfPlaces, o => o.MapFrom(s => s.MaximalNumberOfPlaces));
        }
    }
}
