namespace AirportEf.BLL.Mapper
{
    using System.Collections.Generic;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.DAL.Entities;

    using AutoMapper;

    public class PilotsProfile : Profile
    {
        public PilotsProfile() // +
        {
            CreateMap<Pilot, Pilot>()
                .ForMember(d => d.Id, o => o.Ignore()) // Don't Map Id because It is useless for Ids when updating
                .ForMember(d => d.Crews, o => o.Ignore()); // Don't Map Crews because in new update objects they are empty!!!

            CreateMap<Pilot, PilotDto>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.FirstName));

            CreateMap<PilotRequest, Pilot>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.Crews, o => o.UseValue(new List<Crew>())) // Crews won't be null when we create new Pilot
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.Name));
        }
    }
}
