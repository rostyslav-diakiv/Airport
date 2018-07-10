namespace Airport.DAL.Entities
{
    using System.Collections.Generic;

    using Airport.DAL.Interfaces;

    public class Crew : Entity<int>, ICrew
    {
        public override int Id { get; set; }

        public int PilotId { get; set; }

        public IPilot Pilot { get; set; }

        public ICollection<IStewardess> Stewardesses { get; set; }
    }
}
