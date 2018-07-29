namespace ClientLight.Model
{
    using ClientLight.Interfaces;

    public class PlaneTypeDto : IEntity<int>
    {
        public int Id { get; set; } = 0;

        public string PlaneModel { get; set; } = string.Empty;

        public int MaximalNumberOfPlaces { get; set; } = 0;

        public int MaximalCarryingCapacityKg { get; set; } = 0;
    }
}
