namespace ClientLight.Requests
{
    using System;
    using ClientLight.Model;

    public class FlightRequest
    {
        public FlightRequest() { }

        public FlightRequest(FlightDto dto)
        {
            Number = dto.Number;
            PointOfDeparture = dto.PointOfDeparture;
            DepartureTime = dto.DepartureTime;
            Destination = dto.Destination;
            DestinationArrivalTime = dto.DestinationArrivalTime;
        }

        public string Number { get; set; }
        
        public string PointOfDeparture { get; set; }
        
        public DateTime DepartureTime { get; set; }

        public string Destination { get; set; }

        public DateTime DestinationArrivalTime { get; set; }
    }
}
