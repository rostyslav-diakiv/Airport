namespace AirportEf.DAL.Repositories
{
    using AirportEf.DAL.Data;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class CrewRepository : Repository<Crew, int>, ICrewRepository
    {
        public CrewRepository(AirportDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
