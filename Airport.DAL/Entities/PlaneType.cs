namespace Airport.DAL.Entities
{
    using System.Threading;

    public class PlaneType : Entity<int>
    {
        public override int Id { get; set; }

        public string PlaneModel { get; set; }

        public int MaxNumberOfPlaces { get; set; }

        public int MaxCarryingCapacityKg { get; set; }

        private static int nextId;

        public override int GetGeneratedId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}
