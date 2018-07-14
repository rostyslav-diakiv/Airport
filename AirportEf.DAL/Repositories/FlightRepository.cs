namespace AirportEf.DAL.Repositories
{
    using AirportEf.DAL.Data;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class FlightRepository : Repository<Flight, string>, IFlightRepository
    {
        public FlightRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
