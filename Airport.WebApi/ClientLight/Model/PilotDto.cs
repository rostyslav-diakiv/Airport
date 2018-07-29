namespace ClientLight.Model
{
    using System;

    using ClientLight.Interfaces;

    using GalaSoft.MvvmLight;

    public class PilotDto : IEntity<int>
    {
        public PilotDto() { }

        public int Id { get; set; } = 0;
  
        public Age ExperienceAge { get; set; } = new Age();

        public DateTime DateOfBirth { get; set; } = DateTime.Now.AddYears(-20);

        public string FamilyName { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public Age Age { get; set; } = new Age();
    }
}
