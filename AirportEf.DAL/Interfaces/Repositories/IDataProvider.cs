namespace AirportEf.DAL.Interfaces.Repositories
{
    using System.Collections.Generic;

    using AirportEf.DAL.Entities;

    public interface IDataProvider
    {
        List<Crew> Crews { get; set; }
        List<Pilot> Pilots { get; set; }
        List<Stewardess> Stewardesses { get; set; }
    }
}