namespace Airport.Common.Requests
{
    using System;

    public class PlaneRequest
    {
        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public TimeSpan LifeTime { get; set; }

        public int PlaneTypeId { get; set; }
    }
}
