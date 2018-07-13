namespace Airport.Common.Dtos
{
    using Airport.Common.Interfaces.Entities;

    public class TicketDto : IEntity<int>
    {
        public int Id { get; set; }

        public decimal Price { get; set; }
        
        public FlightDto Flight { get; set; }
    }
}
