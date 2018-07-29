namespace ClientLight.ViewModel
{
    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    public class PlanesViewModel : BaseViewModel<PlaneDto, int>
    {
        public PlanesViewModel(IPlanesService service) : base(service)
        {
            Title = "Planes Page";
        }
    }
}
