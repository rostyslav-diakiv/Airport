namespace ClientLight.Requests
{
    using System;

    public class PilotRequest
    {
        public string Name { get; set; }

        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public TimeSpan Experience { get; set; }
    }
}
