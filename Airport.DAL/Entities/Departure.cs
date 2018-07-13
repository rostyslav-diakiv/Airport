namespace Airport.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Threading;

    using Airport.Common.Requests;

    public class Departure : Entity<int>
    {
        public override int Id { get; set; }

        public DateTime DepartureTime { get; set; }

        [Column("FlightNumber")]
        public string FlightId { get; set; }

        public Flight Flight { get; set; }

        public int CrewId { get; set; }

        public Crew Crew { get; set; }

        public int PlaneId { get; set; }

        public Plane Plane { get; set; }

        public Departure() { }

        private static int nextId;

        public Departure(DepartureRequest request, Flight flight, Crew crew, Plane plane, int id)
        {
            Id = id;
            DepartureTime = request.DepartureTime;
            FlightId = flight.Id;
            Flight = flight;
            CrewId = crew.Id;
            Crew = crew;
            PlaneId = plane.Id;
            Plane = plane;
        }

        public override int GetGeneratedId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}
