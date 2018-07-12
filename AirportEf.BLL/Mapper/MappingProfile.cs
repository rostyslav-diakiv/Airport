namespace AirportEf.BLL.Mapper
{
    using System.Linq;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;

    using AirportEf.DAL.Entities;

    using AutoMapper;

    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            // src // dest
            CreateMap<Stewardess, Stewardess>().ForMember(d => d.Crews, o => o.Ignore()); // Don't Map Crews because in new obj the are empty!!!
            CreateMap<Stewardess, StewardessDto>().ForMember(d => d.Name, o => o.MapFrom(s => s.FirstName));
            CreateMap<StewardessRequest, Stewardess>().ForMember(d => d.FirstName, o => o.MapFrom(s => s.Name));

            CreateMap<Pilot, Pilot>().ForMember(d => d.Crews, o => o.Ignore()); // Don't Map Crews because in new obj the are empty!!!
            CreateMap<Pilot, PilotDto>().ForMember(d => d.Name, o => o.MapFrom(s => s.FirstName));
            CreateMap<PilotRequest, Pilot>().ForMember(d => d.FirstName, o => o.MapFrom(s => s.Name));

            CreateMap<Crew, Crew>();
            CreateMap<Crew, CrewDto>().ForMember(
                d => d.Pilot,
                o => o.MapFrom(s => new PilotDto { Id = s.Pilot.Id,
                                                   DateOfBirth = s.Pilot.DateOfBirth,
                                                   Name = s.Pilot.FirstName,
                                                   Experience = s.Pilot.Experience,
                                                   FamilyName = s.Pilot.FamilyName
                                                     }))
                .ForMember(d => d.Stewardesses, o => o.MapFrom(s => s.Stewardesses.Select(st => new StewardessDto()
                                                                                                    {
                                                                                                        Id = st.Id,
                                                                                                        Name = st.FirstName,
                                                                                                        FamilyName = st.FamilyName,
                                                                                                        DateOfBirth = st.DateOfBirth
                                                                                                    })));
        }
    }
}
