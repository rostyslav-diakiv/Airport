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

        public string PointOfDeparture { get; set; } = string.Empty;

        public DateTime DepartureTime { get; set; } = DateTime.Now;

        public string Destination { get; set; } = string.Empty;

        public DateTime DestinationArrivalTime { get; set; } = DateTime.Now.AddDays(4);
    }
}
