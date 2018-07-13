namespace Airport.Common.Dtos
{
    using Airport.Common.Interfaces.Entities;

    public class PlaneTypeDto : IEntity<int>
    {
        public int Id { get; set; }

        public string PlaneModel { get; set; }

        public int MaximalNumberOfPlaces { get; set; }

        public int MaximalCarryingCapacityKg { get; set; }
    }
}
