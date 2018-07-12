using System;

namespace Airport.DAL.Entities
{
    using System.Threading;

    public class Plane : Entity<int>
    {
        public override int Id { get; set; }

        public int PlaneTypeId { get; set; }

        public PlaneType PlaneType { get; set; }

        public DateTime CreationDate { get; set; }

        public TimeSpan LifeTime { get; set; }

        private static int nextId;

        public override int GetGeneratedId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}
