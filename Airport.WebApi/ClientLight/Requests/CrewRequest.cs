namespace ClientLight.Requests
{
    using System;
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

        public CrewRequest(CrewVmDto dto)
        {
            PilotId = dto.Pilot.Id;
            try
            {
                StewardessesIds = dto.StewardessesIds.Split(',').Select(s => Convert.ToInt32(s));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public int PilotId { get; set; }

        public IEnumerable<int> StewardessesIds { get; set; }
    }
}
