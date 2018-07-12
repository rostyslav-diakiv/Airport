namespace AirportEf.DAL.Repositories
{
    using AirportEf.DAL.Data;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class PlaneRepository : Repository<Plane, int>, IPlaneRepository
    {
        public PlaneRepository(AirportDbContext context, IMapper mapper)
            : base(context, mapper)
        {
        }
    }
}
