namespace Airport.Common.Dtos
{
    using System;

    using Airport.Common.Interfaces.Entities;

    using Newtonsoft.Json;

    public class PilotDto : IEntity<int>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string FamilyName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [JsonIgnore]
        public TimeSpan Experience { get; set; }

        public Age ExperienceAge => new Age(Experience);


        public Age Age => new Age(DateOfBirth);
    }
}
