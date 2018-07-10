using AutoMapper;

namespace Airport.BLL.Mapper
{
    using Airport.DAL.Entities;

    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
                        // src // dest
            CreateMap<Stewardess, Stewardess>();
        }
    }
}
