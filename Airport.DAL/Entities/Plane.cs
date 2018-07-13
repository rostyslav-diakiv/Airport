using System;

namespace Airport.DAL.Entities
{
    using System.Collections.Generic;
    using System.Threading;

    using Airport.Common.Requests;

    public class Plane : Entity<int>
    {
        public override int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public TimeSpan LifeTime { get; set; }

        public int PlaneTypeId { get; set; }

        public PlaneType PlaneType { get; set; }

        public ICollection<Departure> Departures { get; set; }

        public Plane() { }

        private static int nextId;

        public Plane(PlaneRequest request, PlaneType planeType, int id = 0)
        {
            Id = id;
            CreationDate = request.CreationDate;
            LifeTime = request.LifeTime;
            PlaneTypeId = request.PlaneTypeId;
            PlaneType = planeType;
        }

        public override int GetGeneratedId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}
