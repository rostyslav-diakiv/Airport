namespace AirportEf.DAL.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Airport.Common.Requests;

    public class Ticket : Entity<int>
    {
        public override int Id { get; set; }

        [Required]
        [Range(5, 100000)]
        public decimal Price { get; set; }
        
        [Column("FlightNumber")]
        [StringLength(10, MinimumLength = 5)]
        public string FlightId { get; set; }

        public Flight Flight { get; set; }

        public Ticket() { }

        public Ticket(TicketRequest request, Flight flight, int id = 0)
        {
            Id = id;
            Price = request.Price;
            FlightId = flight.Id;
            Flight = flight;
        }

        public Ticket(TicketRequest request, int id)
        {
            Id = id;
            Price = request.Price;
            FlightId = request.FlightNumber;
        }
    }
}
