namespace Airport.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Flight : Entity<Guid>
    {
        [Column("Number")]
        public override Guid Id { get; set; }

        public string DeparturePoint { get; set; }

        public DateTime DepartureTime { get; set; }

        public string Destination { get; set; }

        public DateTime DestinationArrivalTime { get; set; }
    }
}
