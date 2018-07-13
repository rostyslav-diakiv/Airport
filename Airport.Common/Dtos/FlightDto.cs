namespace Airport.Common.Dtos
{
    using System;

    using Airport.Common.Interfaces.Entities;

    using Newtonsoft.Json;

    public class FlightDto : IEntity<string>
    {
        [JsonIgnore]
        public string Id { get; set; }

        public string Number => Id;

        public string PointOfDeparture { get; set; }

        public DateTime DepartureTime { get; set; }

        public string Destination { get; set; }

        public DateTime DestinationArrivalTime { get; set; }
    }
}
