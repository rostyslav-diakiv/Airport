namespace ClientLight.ViewModel
{
    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    public class CrewsViewModel : BaseViewModel<CrewVmDto, int>
    {
        public CrewsViewModel(ICrewsService service) : base(service)
        {
            Title = "Crews Page";
        }
    }
}
