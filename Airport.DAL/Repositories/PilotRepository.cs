using System.Collections.Generic;

namespace Airport.DAL.Repositories
{
    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces.Repositories;

    using AutoMapper;

    class PilotRepository : Repository<Pilot, int>, IPilotRepository
    {
        public PilotRepository(List<Pilot> entities, IMapper mapper)
            : base(entities, mapper)
        {
        }
    }
}
