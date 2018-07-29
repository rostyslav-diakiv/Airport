namespace ClientLight.Model
{
    using System;

    using ClientLight.Interfaces;

    public class StewardessDto : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public Age Age { get; set; }
    }
}
