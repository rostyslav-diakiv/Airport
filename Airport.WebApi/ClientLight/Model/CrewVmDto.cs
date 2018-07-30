namespace ClientLight.Model
{
    using System.Linq;

    using ClientLight.Interfaces;

    public class CrewVmDto : IEntity<int>
    {
        public CrewVmDto() { }

        public CrewVmDto(CrewDto dto)
        {
            Id = dto.Id;
            Pilot = dto.Pilot;
            StewardessesIds = string.Join(",", dto.Stewardesses.Select(s => s.Id));
        }

        public int Id { get; set; } = 0;

        public PilotDto Pilot { get; set; } = new PilotDto();

        public string StewardessesIds { get; set; } = string.Empty;
    }
}
