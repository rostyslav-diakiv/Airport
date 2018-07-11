namespace Airport.Common.Dtos
{
    using System;

    public class PilotDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string SecondName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public TimeSpan Experience { get; set; }

        public Age Age => new Age(DateOfBirth);
    }
}
