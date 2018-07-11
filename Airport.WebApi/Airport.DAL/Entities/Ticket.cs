namespace Airport.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Ticket : Entity<int>
    {
        public override int Id { get; set; }

        public decimal Price { get; set; }

        [Column("FlightNumber")]
        public Guid FlightId { get; set; }

        public Flight Flight { get; set; }
    }
}
