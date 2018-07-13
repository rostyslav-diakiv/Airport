namespace Airport.DAL.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Threading;

    using Airport.Common.Requests;

    public class Ticket : Entity<int>
    {
        public override int Id { get; set; }

        public decimal Price { get; set; }

        [Column("FlightNumber")]
        public string FlightId { get; set; }

        public Flight Flight { get; set; }

        public Ticket() { }

        private static int nextId;

        public Ticket(TicketRequest request, Flight flight, int id)
        {
            Id = id;
            Price = request.Price;
            FlightId = flight.Id;
            Flight = flight;
        }

        public override int GetGeneratedId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}
