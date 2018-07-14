namespace AirportEf.DAL.Interfaces
{
    using System;
    using System.Threading.Tasks;

    using AirportEf.DAL.Interfaces.Repositories;

    public interface IUnitOfWork : IDisposable
    {
        IStewardessRepository StewardessRepository { get; }

        IPilotRepository PilotRepository { get; }

        ICrewRepository CrewRepository { get; }

        IPlaneTypeRepository PlaneTypeRepository { get; }

        IPlaneRepository PlaneRepository { get; }

        IFlightRepository FlightRepository { get; }

        ITicketRepository TicketRepository { get; }

        IDepartureRepository DepartureRepository { get; }

        Task<bool> SaveAsync();
    }
}