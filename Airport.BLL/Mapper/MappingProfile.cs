using AutoMapper;

namespace Airport.BLL.Mapper
{
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
            CreateMap<Stewardess, Stewardess>()
                .ForMember(d => d.Crews, o => o.Ignore());
            CreateMap<Stewardess, StewardessDto>()
                .ForMember(d => d.Name, o => o.MapFrom(s => s.FirstName));
            CreateMap<StewardessRequest, Stewardess>()
                .ForMember(d => d.FirstName, o => o.MapFrom(s => s.Name));
        }
    }
}
