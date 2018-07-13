namespace Airport.DAL.Repositories
{
    using System.Collections.Generic;

    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class DepartureRepository : Repository<Departure, int>, IDepartureRepository
    {
        public DepartureRepository(List<Departure> entities, IMapper mapper)
            : base(entities, mapper)
        {
        }
    }
}
