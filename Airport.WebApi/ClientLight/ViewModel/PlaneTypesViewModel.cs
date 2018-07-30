namespace ClientLight.ViewModel
{
    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    public class PlaneTypesViewModel : BaseViewModel<PlaneTypeDto, int>
    {
        public PlaneTypesViewModel(IPlaneTypesService service) : base(service)
        {
            Title = "Plane Types";
        }
    }
}
