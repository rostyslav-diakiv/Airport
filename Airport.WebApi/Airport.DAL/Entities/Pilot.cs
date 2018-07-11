namespace Airport.DAL.Entities
{
    using System;

    public sealed class Pilot : Human<int>
    {
        private static int nextId;

        public override int Id { get; set; }

        public TimeSpan Experience { get; set; }

        public Pilot() { }
    }
}
