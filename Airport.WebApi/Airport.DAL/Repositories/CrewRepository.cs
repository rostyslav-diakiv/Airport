namespace Airport.DAL.Repositories
{
    using System.Collections.Generic;

    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class CrewRepository : Repository<Crew, int>, ICrewRepository
    {
        public CrewRepository(List<Crew> entities, IMapper mapper) : base(entities, mapper)
        {
        }

        public override Crew Create(Crew entity)
        {
            entity.Id = Crew.GetGeneratedId();
            return base.Create(entity);
        }
    }
}
