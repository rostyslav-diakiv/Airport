namespace Airport.DAL.Entities
{
    using System;

    using Airport.DAL.Interfaces;

    public class Pilot : Human<int>, IPilot
    {
        public override int Id { get; set; }

        public TimeSpan Experience { get; set; }
    }
}
