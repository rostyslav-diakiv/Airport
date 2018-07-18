namespace AirportEf.BLL.Mapper
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Airport.Common.Dtos;

    using AirportEf.DAL.Entities;

    using AutoMapper;

    public class CrewsProfile : Profile
    {
        public CrewsProfile()
        {
            CreateMap<Crew, Crew>();
            CreateMap<Crew, CrewDto>()
                .ForMember(d => d.Pilot, o => o.MapFrom(s => s.Pilot))
                .ForMember(d => d.Stewardesses, o => o.MapFrom(s => s.CrewStewardess));

            CreateMap<CrewStewardess, CrewStewardess>();
            CreateMap<CrewStewardess, StewardessDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Stewardess.Id))
                .ForMember(d => d.Name, o => o.MapFrom(s => s.Stewardess.FirstName))
                .ForMember(d => d.FamilyName, o => o.MapFrom(s => s.Stewardess.FamilyName))
                .ForMember(d => d.DateOfBirth, o => o.MapFrom(s => s.Stewardess.DateOfBirth));

            CreateMap<CrewStewardess, CrewDto>()
                .ForMember(d => d.Id, o => o.MapFrom(s => s.Crew.Id))
                .ForMember(d => d.Pilot, o => o.MapFrom(s => s.Crew.Pilot)) // If not Included - will be null
                .ForMember(d => d.Stewardesses, o => o.MapFrom(s => s.Crew.CrewStewardess)); // If not Included - will be null

            CreateMap<StewardessApiDto, Stewardess>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(d => d.FamilyName, o => o.MapFrom(s => s.LastName))
                .ForMember(d => d.DateOfBirth, o => o.MapFrom(s => s.BirthDate))
                .ForMember(d => d.CrewStewardess, o => o.UseValue(new List<CrewStewardess>()));

            CreateMap<StewardessApiDto, CrewStewardess>()
                .ForMember(d => d.Crew, o => o.UseValue<Crew>(null))
                .ForMember(d => d.CrewId, o => o.UseValue(0))
                .ForMember(d => d.Stewardess, o => o.MapFrom(s => s))
                .ForMember(d => d.StewardessId, o => o.UseValue(0));

            CreateMap<PilotApiDto, Pilot>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.FirstName))
                .ForMember(d => d.FamilyName, o => o.MapFrom(s => s.LastName))
                .ForMember(d => d.DateOfBirth, o => o.MapFrom(s => s.BirthDate))
                .ForMember(d => d.Experience, o => o.MapFrom(s => new TimeSpan(s.Exp * 365, 0, 0, 0, 0)))
                .ForMember(d => d.Crews, o => o.UseValue(new List<Crew>()));

            CreateMap<CrewApiDto, Crew>()
                .ForMember(d => d.Id, o => o.UseValue(0))
                .ForMember(d => d.Pilot, o => o.MapFrom(s => s.Pilot.FirstOrDefault()))
                .ForMember(d => d.PilotId, o => o.UseValue(0))
                .ForMember(d => d.CrewStewardess, o => o.MapFrom(s => s.Stewardess));


            // TODO: Create Map for Crew Stewardess to Crew, Stewardess
            /*
             * new PilotDto
                {
                    Id = s.Pilot.Id,
                    DateOfBirth = s.Pilot.DateOfBirth,
                    Name = s.Pilot.FirstName,
                    FamilyName = s.Pilot.FamilyName,
                    Experience = s.Pilot.Experience,
                }))


            s.Stewardesses.Select(st => new StewardessDto
                {
                    Id = st.Id,
                    Name = st.FirstName,
                    FamilyName = st.FamilyName,
                    DateOfBirth = st.DateOfBirth
                })));
             */
        }
    }
}
