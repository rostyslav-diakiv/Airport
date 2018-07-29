namespace ClientLight.ViewModel
{
    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    public class FlightsViewModel : BaseViewModel<FlightDto, string>
    {
        public FlightsViewModel(IFlightsService service) : base(service)
        {
            Title = "Flights Page";
        }
    }
}
