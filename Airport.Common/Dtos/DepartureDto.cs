namespace Airport.Common.Dtos
{
    using System;

    using Airport.Common.Interfaces.Entities;
    public class DepartureDto : IEntity<int>
    {
        public int Id { get; set; }
        
        public DateTime DepartureTime { get; set; }

        public FlightDto Flight { get; set; }

        public int CrewId { get; set; }

        // public CrewDto Crew { get; set; } - Don't need to know all crew (pilot, stewardesses)

        // public int PlaneId { get; set; }

        public PlaneDto Plane { get; set; }
    }
}
