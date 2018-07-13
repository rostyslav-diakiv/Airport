namespace AirportEf.DAL.Repositories
{
    using AirportEf.DAL.Data;
    using AirportEf.DAL.Entities;
    using AirportEf.DAL.Interfaces.Repositories;

    using AutoMapper;

    public class PlaneTypeRepository : Repository<PlaneType, int>, IPlaneTypeRepository
    {
        protected PlaneTypeRepository(AirportDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
