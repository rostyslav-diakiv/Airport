namespace Airport.DAL.Repositories
{
    using System.Collections.Generic;

    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class FlightRepository : Repository<Flight, string>, IFlightRepository
    {
        public FlightRepository(List<Flight> entities, IMapper mapper)
            : base(entities, mapper)
        {
        }

        public override Flight Create(Flight entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public override ICollection<Flight> CreateMany(ICollection<Flight> items)
        {
            _entities.AddRange(items);
            return items;
        }
    }
}
