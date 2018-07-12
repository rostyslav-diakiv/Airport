namespace AirportEf.DAL.Interfaces
{
    using AirportEf.DAL.Interfaces.Repositories;

    public interface IUnitOfWork
    {
        IStewardessRepository StewardessRepository { get; }

        IPilotRepository PilotRepository { get; }

        ICrewRepository CrewRepository { get; }
    }
}