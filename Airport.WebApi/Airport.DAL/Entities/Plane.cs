using System;

namespace Airport.DAL.Entities
{
    public class Plane : Entity<int>
    {
        public override int Id { get; set; }

        public int PlaneTypeId { get; set; }

        public PlaneType PlaneType { get; set; }

        public DateTime CreationDate { get; set; }

        public TimeSpan LifeTime { get; set; }
    }
}
