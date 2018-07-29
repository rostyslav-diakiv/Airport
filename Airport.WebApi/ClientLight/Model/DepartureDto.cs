namespace ClientLight.Model
{
    using System;
    
    using ClientLight.Interfaces;

    public class DepartureDto : IEntity<int>
    {
        public int Id { get; set; } = 0;
        
        public DateTime DepartureTime { get; set; } = DateTime.Now;

        public FlightDto Flight { get; set; } = new FlightDto();

        public int CrewId { get; set; } = 0;

        public PlaneDto Plane { get; set; } = new PlaneDto();
    }
}
