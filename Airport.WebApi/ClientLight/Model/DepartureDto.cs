namespace ClientLight.Model
{
    using System;
    
    using ClientLight.Interfaces;

    public class DepartureDto : IEntity<int>
    {
        public int Id { get; set; }
        
        public DateTime DepartureTime { get; set; }

        public FlightDto Flight { get; set; } = new FlightDto();

        public int CrewId { get; set; }

        public PlaneDto Plane { get; set; } = new PlaneDto();
    }
}
