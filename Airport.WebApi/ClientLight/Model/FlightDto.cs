namespace ClientLight.Model
{
    using System;

    using ClientLight.Interfaces;

    public class FlightDto : IEntity<string>
    {
        public string Id
        {
            get => Number;
            set => Number = value;
        }

        public string Number { get; set; } = string.Empty;

        public string PointOfDeparture { get; set; }

        public DateTime DepartureTime { get; set; }

        public string Destination { get; set; }

        public DateTime DestinationArrivalTime { get; set; }
    }
}
