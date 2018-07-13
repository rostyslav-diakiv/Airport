using AutoMapper;

namespace Airport.BLL.Mapper
{
    using System.Linq;

    using Airport.Common.Dtos;
    using Airport.Common.Requests;
    using Airport.DAL.Entities;

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

            CreateMap<PlaneType, PlaneType>().ForMember(d => d.Planes, o => o.Ignore()); // Don't Map Planes because in new obj the are empty!!!
            CreateMap<PlaneType, PlaneTypeDto>()
                .ForMember(d => d.MaximalCarryingCapacityKg, o => o.MapFrom(s => s.MaxCarryingCapacityKg))
                .ForMember(d => d.MaximalNumberOfPlaces, o => o.MapFrom(s => s.MaxNumberOfPlaces));

            CreateMap<PlaneTypeRequest, PlaneType>()
                .ForMember(d => d.MaxCarryingCapacityKg, o => o.MapFrom(s => s.MaximalCarryingCapacityKg))
                .ForMember(d => d.MaxNumberOfPlaces, o => o.MapFrom(s => s.MaximalNumberOfPlaces));

            CreateMap<Crew, Crew>();
            CreateMap<Crew, CrewDto>()
                .ForMember(d => d.Pilot, o => o.MapFrom(s => new PilotDto
                {
                    Id = s.Pilot.Id,
                    DateOfBirth = s.Pilot.DateOfBirth,
                    Name = s.Pilot.FirstName,
                    FamilyName = s.Pilot.FamilyName,
                    Experience = s.Pilot.Experience,
                }))
                .ForMember(d => d.Stewardesses, o => o.MapFrom(s => s.Stewardesses.Select(st => new StewardessDto
                {
                    Id = st.Id,
                    Name = st.FirstName,
                    FamilyName = st.FamilyName,
                    DateOfBirth = st.DateOfBirth
                })));
        }
    }
}
