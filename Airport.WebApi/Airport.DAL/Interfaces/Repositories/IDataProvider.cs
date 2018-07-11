namespace Airport.DAL.Interfaces.Repositories
{
    using System.Collections.Generic;

    using Airport.DAL.Entities;

    public interface IDataProvider
    {
        List<Crew> Crews { get; set; }
        List<Pilot> Pilots { get; set; }
        List<Stewardess> Stewardesses { get; set; }
    }
}