﻿namespace AirportEf.DAL.Entities
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

        // [Required]
        [StringLength(10, MinimumLength = 5)]
        [Column("FlightNumber")]
        public string FlightId { get; set; }

        public Flight Flight { get; set; }

       // [Required]
        public int? CrewId { get; set; }

        public Crew Crew { get; set; }

        //[Required]
        public int? PlaneId { get; set; }

        public Plane Plane { get; set; }

        public Departure() { }

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
    }
}
