namespace AirportEf.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Flight : Entity<Guid>
    {
        [Column("Number")]
        public override Guid Id { get; set; }

        public string DeparturePoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public string Destination { get; set; }

        public DateTime DestinationArrivalTime { get; set; }

        public ICollection<Ticket> Tickets { get; set; }
    }
}
