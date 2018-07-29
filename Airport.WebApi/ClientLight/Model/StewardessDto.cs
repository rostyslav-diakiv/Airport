namespace ClientLight.Model
{
    using System;

    using ClientLight.Interfaces;

    public class StewardessDto : IEntity<int>
    {
        public int Id { get; set; } = 0;

        public string Name { get; set; } = string.Empty;

        public string FamilyName { get; set; } = string.Empty;

        public DateTime DateOfBirth { get; set; } = DateTime.Now;

        public Age Age { get; set; } = new Age();
    }
}
