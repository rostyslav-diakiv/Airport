namespace Airport.DAL.Interfaces.Repositories
{
    using Airport.DAL.Entities;

    public interface IFlightRepository : IRepository<Flight, string>
    {
    }
}