namespace ClientLight.Requests
{
    using System;

    using ClientLight.Model;

    public class DepartureRequest
    {
        public DepartureRequest() { }

        public DepartureRequest(DepartureDto dto)
        {
            FlightNumber = dto.Flight.Number;
            PlaneId = dto.Plane.Id;
            CrewId = dto.CrewId;
            DepartureTime = dto.DepartureTime;
        }

        public DateTime DepartureTime { get; set; }

        public string FlightNumber { get; set; }

        public int CrewId { get; set; }

        public int PlaneId { get; set; }
    }
}
