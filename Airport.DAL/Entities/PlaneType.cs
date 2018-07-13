namespace Airport.DAL.Entities
{
    using System.Collections.Generic;
    using System.Threading;

    using Airport.Common.Requests;

    public class PlaneType : Entity<int>
    {
        public override int Id { get; set; }

        public string PlaneModel { get; set; }

        public int MaxNumberOfPlaces { get; set; }

        public int MaxCarryingCapacityKg { get; set; }

        public ICollection<Plane> Planes { get; set; }

        public PlaneType() { }

        public PlaneType(PlaneTypeRequest request, int id)
        {
            Id = id;
            PlaneModel = request.PlaneModel;
            MaxNumberOfPlaces = request.MaximalNumberOfPlaces;
            MaxCarryingCapacityKg = request.MaximalCarryingCapacityKg;
        }

        private static int nextId;

        public override int GetGeneratedId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}
