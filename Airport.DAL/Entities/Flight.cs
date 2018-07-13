namespace Airport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    using Airport.Common.Requests;

    public class Flight : Entity<string>
    {
        [Column("Number")]
        public override string Id { get; set; }

        public string DeparturePoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public string Destination { get; set; }

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

        private static Random random = new Random();

        public override string GetGeneratedId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 7) // Length of number = 7
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
