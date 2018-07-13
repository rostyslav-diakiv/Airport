namespace Airport.DAL.Data
{
    using System.Collections.Generic;

    using Airport.DAL.Entities;

    /// <summary>
    /// It is like DbContext with a bunch of a Collections(tables)
    /// </summary>
    public interface IDataProvider
    {
        List<Stewardess> Stewardesses { get; set; }

        List<PlaneType> PlaneTypes { get; set; }

        List<Pilot> Pilots { get; set; }

        List<Crew> Crews { get; set; }

        List<Plane> Planes { get; set; }

        List<Flight> Flights { get; set; }

        List<Ticket> Tickets { get; set; }

        List<Departure> Departures { get; set; }
    }
}