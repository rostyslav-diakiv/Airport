namespace Airport.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Departure : Entity<int>
    {
        public override int Id { get; set; }

        public DateTime DepartureTime { get; set; }

        [Column("FlightNumber")]
        public Guid FlightId { get; set; }

        public Flight Flight { get; set; }

        public int CrewId { get; set; }

        public Crew Crew { get; set; }

        public int PlaneId { get; set; }

        public Plane Plane { get; set; }
    }
}
