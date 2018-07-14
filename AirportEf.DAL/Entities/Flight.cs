namespace AirportEf.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Airport.Common.Requests;

    public class Flight : Entity<string>
    {
        [Column("Number")]
        [StringLength(10, MinimumLength = 5)]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public override string Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string DeparturePoint { get; set; }

        [Required]
        public DateTime DepartureTime { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Destination { get; set; }

        [Required]
        public DateTime DestinationArrivalTime { get; set; }

        public ICollection<Ticket> Tickets { get; set; }

        public ICollection<Departure> Departures { get; set; }

        public Flight() { }

        public Flight(FlightRequest request, string number)
        {
            Id = number;
            DeparturePoint = request.PointOfDeparture;
            DepartureTime = request.DepartureTime;
            Destination = request.Destination;
            DestinationArrivalTime = request.DestinationArrivalTime;
        }
    }
}
