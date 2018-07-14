namespace AirportEf.DAL.Entities
{
    using System.Collections.Generic;

    public class Crew : Entity<int>
    {
        public override int Id { get; set; }

        public int? PilotId { get; set; }

        public Pilot Pilot { get; set; }

        public ICollection<CrewStewardess> CrewStewardess { get; set; }

        public ICollection<Departure> Departures { get; set; }

        public Crew() { }
    }
}