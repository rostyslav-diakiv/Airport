namespace Airport.Common.Dtos
{
    using System.Collections.Generic;

    public class CrewApiDto
    {
        public string Id { get; set; }

        public List<PilotApiDto> Pilot { get; set; }

        public List<StewardessApiDto> Stewardess { get; set; }

        /// <summary>Initializes a new instance of the <see cref="T:System.Object"></see> class.</summary>
        public CrewApiDto()
        {
        }
        /*
         * [{"id":"1",
         * "pilot":[{"id":"1","crewId":"1","birthDate":"2017-10-30T04:09:45.179Z","firstName":"Kody","lastName":"Oberbrunner","exp":26}],
         * "stewardess":[{"id":"1","crewId":"1","birthDate":"2018-07-04T20:20:33.347Z","firstName":"Alyson","lastName":"Koelpin"},
         *               {"id":"76","crewId":"1","birthDate":"2017-12-05T14:19:49.439Z","firstName":"Sheila","lastName":"Jacobs"}]}
         */
    }
}
