namespace Airport.Common.Requests
{
    using System;

    public class FlightRequest
    {
        public string Number { get; set; }

        public string PointOfDeparture { get; set; }

        public DateTime DepartureTime { get; set; }

        public string Destination { get; set; }

        public DateTime DestinationArrivalTime { get; set; }
    }
}
