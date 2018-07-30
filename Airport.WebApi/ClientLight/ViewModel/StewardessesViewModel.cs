namespace ClientLight.ViewModel
{
    using ClientLight.Interfaces.Services;
    using ClientLight.Model;

    public class StewardessesViewModel : BaseViewModel<StewardessDto, int>
    {
        public StewardessesViewModel(IStewardessesService service) : base(service)
        {
            Title = "Stewardesses";
        }
    }
}
