namespace Airport.Common.Dtos
{
    using System;

    public class HumanApiDto
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int CrewId { get; set; } // TODO: After deserialization convert to Int

        public DateTime BirthDate { get; set; }

        public HumanApiDto() { }
    }
}
