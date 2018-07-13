namespace Airport.Common.Requests
{
    using System;

    public class StewardessRequest
    {
        public string Name { get; set; }

        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }
    }
}
