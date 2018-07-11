namespace Airport.DAL.Repositories
{
    using System.Collections.Generic;

    using Airport.DAL.Entities;
    using Airport.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class StewardessRepository : Repository<Stewardess, int>, IStewardessRepository
    {
        public StewardessRepository(List<Stewardess> stewardesses, IMapper mapper) : base(stewardesses, mapper)
        {
        }

        public override Stewardess Create(Stewardess entity)
        {
            entity.Id = Stewardess.GetIncrementedId();
            return base.Create(entity);
        }
    }
}
