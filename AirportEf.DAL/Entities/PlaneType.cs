namespace AirportEf.DAL.Entities
{
    public class PlaneType : Entity<int>
    {
        public override int Id { get; set; }

        public string PlaneModel { get; set; }

        public int MaxNumberOfPlaces { get; set; }

        public int MaxCarryingCapacityKg { get; set; }
    }
}
