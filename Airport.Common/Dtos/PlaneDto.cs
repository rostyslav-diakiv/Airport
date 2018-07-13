namespace Airport.Common.Dtos
{
    using System;

    using Airport.Common.Interfaces.Entities;

    public class PlaneDto : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public TimeSpan LifeTime { get; set; }
        
        public PlaneTypeDto PlaneType { get; set; }
    }
}
