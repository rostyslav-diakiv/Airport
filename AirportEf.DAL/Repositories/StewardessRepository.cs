namespace AirportEf.DAL.Repositories
{
    using AirportEf.DAL.Data;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class StewardessRepository : Repository<Stewardess, int>, IStewardessRepository
    {
        public StewardessRepository(AirportDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
