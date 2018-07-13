namespace Airport.Common.Dtos
{
    using System.Collections.Generic;

    using Airport.Common.Interfaces.Entities;

    public class CrewDto : IEntity<int>
    {
        public CrewDto() { }

        public int Id { get; set; }

        public PilotDto Pilot { get; set; }

        public IEnumerable<StewardessDto> Stewardesses{ get; set; }
    }
}
