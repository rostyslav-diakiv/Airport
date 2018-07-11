namespace Airport.DAL.Entities
{
    using System.Collections.Generic;
    using System.Threading;

    public class Crew : Entity<int>
    {
        public override int Id { get; set; }

        public int PilotId { get; set; }

        public Pilot Pilot { get; set; }

        public ICollection<Stewardess> Stewardesses { get; set; }

        private static int nextId;
        public static int GetGeneratedId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}