namespace Airport.DAL.Entities
{
    using Airport.DAL.Interfaces;

    public class Stewardess : Human<int>, IStewardess
    {
        public override int Id { get; set; }
    }
}
