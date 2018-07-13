namespace Airport.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Threading;

    public class Ticket : Entity<int>
    {
        public override int Id { get; set; }

        public decimal Price { get; set; }

        [Column("FlightNumber")]
        public string FlightId { get; set; }

        public Flight Flight { get; set; }

        public Ticket() { }

        private static int nextId;

        public override int GetGeneratedId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}
