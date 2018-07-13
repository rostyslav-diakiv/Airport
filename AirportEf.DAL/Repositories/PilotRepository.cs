namespace AirportEf.DAL.Repositories
{
    using AirportEf.DAL.Data;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class PilotRepository : Repository<Pilot, int>, IPilotRepository
    {
        public PilotRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
