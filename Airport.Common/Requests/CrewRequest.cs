namespace Airport.Common.Requests
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class CrewRequest
    {
        [Required]
        public int PilotId { get; set; }

        [Required]
        [MinLength(1)]
        [MaxLength(20)]
        public IEnumerable<int> StewardessesIds { get; set; }
    }
}
