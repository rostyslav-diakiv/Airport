namespace Airport.Common.Dtos
{
    using System;

    using Airport.Common.Interfaces.Entities;

    using Newtonsoft.Json;

    public class PlaneDto : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public TimeSpan LifeTime { get; set; }

        public Age LifeTimeAge => new Age(LifeTime);

        public PlaneTypeDto PlaneType { get; set; }
    }
}
