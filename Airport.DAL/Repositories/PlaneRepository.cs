using System.Collections.Generic;

namespace Airport.DAL.Repositories
{
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class PlaneRepository : Repository<Plane, int>, IPlaneRepository
    {
        public PlaneRepository(List<Plane> entities, IMapper mapper)
            : base(entities, mapper)
        {
        }
    }
}
