namespace AirportEf.BLL.Mapper
{
    using System.Collections.Generic;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.DAL.Entities;

    using AutoMapper;

    public class StewardessProfile : Profile
    {
        public StewardessProfile() // +
        {
            // src // dest
            CreateMap<Stewardess, Stewardess>()
                .ForMember(d => d.Id, o => o.Ignore()) // Don't Map Id because It is useless for Ids when updating
                .ForMember(d => d.CrewStewardess, o => o.Ignore()); // Don't Map Crews because in new obj the are empty!!!

            CreateMap<Stewardess, StewardessDto>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.FirstName));

            CreateMap<StewardessRequest, Stewardess>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.CrewStewardess, o => o.UseValue(new List<CrewStewardess>())) // Crews won't be null when we create new Stewardess
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.Name));
        }
    }
}
