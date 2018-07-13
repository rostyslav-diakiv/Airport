namespace Airport.DAL.Entities
{
    using System;
    using System.Collections.Generic;
    using System.Threading;

    using Airport.Common.Requests;

    public sealed class Pilot : Human<int>
    {
        private static int nextId;

        public override int Id { get; set; }

        public TimeSpan Experience { get; set; }

        public Pilot() { }

        public Pilot(PilotRequest request, int id)
        {
            Id = id;
            FirstName = request.Name;
            FamilyName = request.FamilyName;
            DateOfBirth = request.DateOfBirth;
            Experience = request.Experience;
            Crews = new List<Crew>();
        }

        public override int GetGeneratedId()
        {
            return Interlocked.Increment(ref nextId);
        }
    }
}
