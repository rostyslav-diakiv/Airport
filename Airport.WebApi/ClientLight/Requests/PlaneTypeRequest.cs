namespace ClientLight.Requests
{
    public class PlaneTypeRequest
    {
        public string PlaneModel { get; set; }

        public int MaximalNumberOfPlaces { get; set; }

        public int MaximalCarryingCapacityKg { get; set; }
    }
}
