namespace ClientLight.ViewModel
{
    using ClientLight.Interfaces.Services;
    using ClientLight.Model;

    public class TicketsViewModel : BaseViewModel<TicketDto, int>
    {
        public TicketsViewModel(ITicketsService service) : base(service)
        {
            Title = "Tickets Page";
        }
    }
}
