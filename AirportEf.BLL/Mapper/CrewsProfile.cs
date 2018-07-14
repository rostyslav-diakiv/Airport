namespace AirportEf.BLL.Mapper
{
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
