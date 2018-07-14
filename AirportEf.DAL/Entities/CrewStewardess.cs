namespace AirportEf.DAL.Entities
{
    public class CrewStewardess
    {
        public int CrewId { get; set; }
        public Crew Crew { get; set; }
        public int StewardessId { get; set; }
        public Stewardess Stewardess { get; set; }
    }
}
