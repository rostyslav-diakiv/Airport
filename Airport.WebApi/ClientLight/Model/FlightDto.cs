namespace ClientLight.Model
{
    using System;
    
    public class FlightDto
    {
        public string Number { get; set; }

        public string PointOfDeparture { get; set; }

        public DateTime DepartureTime { get; set; }

        public string Destination { get; set; }

        public DateTime DestinationArrivalTime { get; set; }
    }
}
