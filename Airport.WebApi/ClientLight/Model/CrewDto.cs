namespace ClientLight.Model
{
    using System.Collections.Generic;
    using ClientLight.Interfaces;

    public class CrewDto : IEntity<int>
    {
        public CrewDto() { }

        public int Id { get; set; }

        public PilotDto Pilot { get; set; } = new PilotDto();

        public IEnumerable<StewardessDto> Stewardesses { get; set; } = new List<StewardessDto>();
    }
}
