namespace ClientLight.ViewModel
{
    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    public class DeparturesViewModel : BaseViewModel<DepartureDto, int>
    {
        public DeparturesViewModel(IDeparturesService service)
            : base(service)
        {
            Title = "Departures Page";
        }
    }
}
