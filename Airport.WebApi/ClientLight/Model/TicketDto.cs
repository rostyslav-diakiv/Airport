﻿namespace ClientLight.Model
{
    public class TicketDto
    {
        public int Id { get; set; }

        public decimal Price { get; set; }

        public FlightDto Flight { get; set; }
    }
}
