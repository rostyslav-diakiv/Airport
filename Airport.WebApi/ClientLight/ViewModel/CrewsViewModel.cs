namespace ClientLight.ViewModel
{
    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    public class CrewsViewModel : BaseViewModel<CrewDto, int>
    {
        public CrewsViewModel(ICrewsService service) : base(service)
        {
            Title = "Crews Page";
        }
    }
}
