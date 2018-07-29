namespace ClientLight.Model
{
    using System.Collections.Generic;
    using ClientLight.Interfaces;

    public class CrewDto : IEntity<int>
    {
        public CrewDto() { }

        public int Id { get; set; }

        public PilotDto Pilot { get; set; }

        public IEnumerable<StewardessDto> Stewardesses{ get; set; }
    }
}
