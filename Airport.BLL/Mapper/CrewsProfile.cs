﻿namespace Airport.BLL.Mapper
{
    using Airport.Common.Dtos;
    using Airport.DAL.Entities;

    using AutoMapper;

    public class CrewsProfile : Profile
    {
        public CrewsProfile()
        {
            CreateMap<Crew, Crew>();
            CreateMap<Crew, CrewDto>()
                .ForMember(d => d.Pilot, o => o.MapFrom(s => s.Pilot))
                .ForMember(d => d.Stewardesses, o => o.MapFrom(s => s.Stewardesses));

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
