namespace Airport.DAL.Interfaces
{
    using Airport.DAL.Interfaces.Repositories;

    public interface IUnitOfWork
    {
        IStewardessRepository StewardessRepository { get; }
        IPilotRepository PilotRepository { get; }

        ICrewRepository CrewRepository { get; }
    }
}