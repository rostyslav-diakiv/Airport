namespace Airport.Common.Dtos
{
    using System;

    using Airport.Common.Interfaces.Entities;

    public class StewardessDto : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Age Age => new Age(DateOfBirth);
    }
}
