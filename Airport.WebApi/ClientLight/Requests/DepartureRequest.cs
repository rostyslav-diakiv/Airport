namespace ClientLight.Requests
{
    using System;

    public class DepartureRequest
    {
        public DateTime DepartureTime { get; set; }

        public string FlightNumber { get; set; }

        public int CrewId { get; set; }

        public int PlaneId { get; set; }
    }
}
