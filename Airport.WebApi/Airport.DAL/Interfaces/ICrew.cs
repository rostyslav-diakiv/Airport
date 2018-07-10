using System.Collections.Generic;

namespace Airport.DAL.Interfaces
{
    using Airport.DAL.Entities;

    public interface ICrew : IEntity<int>
    {
        int PilotId { get; set; }

        IPilot Pilot { get; set; }

        ICollection<IStewardess> Stewardesses { get; set; }
    }
}
