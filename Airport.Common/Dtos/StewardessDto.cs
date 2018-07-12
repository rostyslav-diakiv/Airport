namespace Airport.Common.Dtos
{
    using System;

    public class StewardessDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Age Age => new Age(DateOfBirth);
    }
}
