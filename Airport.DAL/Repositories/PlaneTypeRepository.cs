using System.Collections.Generic;

namespace Airport.DAL.Repositories
{
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces.Repositories;
    using AutoMapper;

    public class PlaneTypeRepository : Repository<PlaneType, int>, IPlaneTypeRepository
    {
        public PlaneTypeRepository(List<PlaneType> entities, IMapper mapper) : base(entities, mapper)
        {
        }
    }
}
