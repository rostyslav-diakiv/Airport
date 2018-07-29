namespace ClientLight.Requests
{
    using System.Collections.Generic;
    using System.Linq;

    using ClientLight.Model;

    public class CrewRequest
    {
        public CrewRequest(CrewDto dto)
        {
            PilotId = dto.Pilot.Id;
            StewardessesIds = dto.Stewardesses.Select(s => s.Id);
        }

        public int PilotId { get; set; }

        public IEnumerable<int> StewardessesIds { get; set; }
    }
}
