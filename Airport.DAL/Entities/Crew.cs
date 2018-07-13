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

        public ICollection<Departure> Departures { get; set; }

        public Crew() { }

        private static int nextId;

        public override int GetGeneratedId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}