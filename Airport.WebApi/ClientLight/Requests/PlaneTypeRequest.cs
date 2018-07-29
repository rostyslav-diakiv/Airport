using ClientLight.Model;

namespace ClientLight.Requests
{
    public class PlaneTypeRequest
    {
        public PlaneTypeRequest() { }

        public PlaneTypeRequest(PlaneTypeDto dto)
        {
            PlaneModel = dto.PlaneModel;
            MaximalNumberOfPlaces = dto.MaximalNumberOfPlaces;
            MaximalCarryingCapacityKg = dto.MaximalCarryingCapacityKg;
        }

        public string PlaneModel { get; set; }

        public int MaximalNumberOfPlaces { get; set; }

        public int MaximalCarryingCapacityKg { get; set; }
    }
}
