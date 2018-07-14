namespace AirportEf.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Airport.Common.Requests;

    public class Departure : Entity<int>
    {
        public override int Id { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [StringLength(10, MinimumLength = 5)]
        [Column("FlightNumber")]
        public string FlightId { get; set; }

        public Flight Flight { get; set; }

        public int? CrewId { get; set; }

        public Crew Crew { get; set; }

        public int? PlaneId { get; set; }

        public Plane Plane { get; set; }

        public Departure() { }

        public Departure(DepartureRequest request, Flight flight, Crew crew, Plane plane, int id = 0)
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

        public Departure(DepartureRequest request, int id)
        {
            Id = id;
            DepartureTime = request.DepartureTime;
            FlightId = request.FlightNumber;
            CrewId = request.CrewId;
            PlaneId = request.PlaneId;
        }
    }
}
