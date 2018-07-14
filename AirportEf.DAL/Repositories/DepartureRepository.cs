namespace AirportEf.DAL.Repositories
{
    using AirportEf.DAL.Data;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class DepartureRepository : Repository<Departure, int>, IDepartureRepository
    {
        public DepartureRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
