namespace Airport.Common.Dtos
{
    using System.Collections.Generic;

    public class CrewDto
    {
        public CrewDto() { }

        public int Id { get; set; }

        public PilotDto Pilot { get; set; }

        public IEnumerable<StewardessDto> Stewardesses{ get; set; }
    }
}
