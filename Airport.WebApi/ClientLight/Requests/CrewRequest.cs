namespace ClientLight.Requests
{
    using System.Collections.Generic;

    public class CrewRequest
    {
        public int PilotId { get; set; }

        public IEnumerable<int> StewardessesIds { get; set; }
    }
}
