using System;
using System.Linq;
using System.Threading.Tasks;

namespace ClientLight.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Windows.Input;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Services;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    using Microsoft.Practices.ServiceLocation;

    public class TicketsViewModel : ViewModelBase
    {
        private readonly ITicketsService _ticketsService;
        private TicketDto _selected;
        private ObservableCollection<TicketDto> tickets;
        private string _title = "Tickets Page";

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        private VisualState _currentState;

        public ICommand ItemClickCommand { get; private set; }
        public ICommand StateChangedCommand { get; private set; }
        public ICommand AddTicketCommand { get; }
        public ICommand DeleteTicketCommand { get; }
        public ICommand UpdateTicketCommand { get; }

        public TicketsViewModel(ITicketsService service)
        {
            _ticketsService = service;
            ItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
            AddTicketCommand = new RelayCommand(DoAddTicket);
            DeleteTicketCommand = new RelayCommand(DoDeleteTicket);
            UpdateTicketCommand = new RelayCommand(DoUpdateTicket);
        }

        public async Task LoadDataAsync(VisualState currentState)
        {
            await Initialize();
            _currentState = currentState;
        }

        private void OnStateChanged(VisualStateChangedEventArgs args)
        {
            _currentState = args.NewState;
        }

        private void OnItemClick(ItemClickEventArgs args)
        {
            if (args?.ClickedItem is TicketDto item)
            {
                //if (_currentState.Name == NarrowStateName)
                //{
                //    NavigationService.Navigate(typeof(CustomerDetailViewModel).FullName, item);
                //}
                //else
                //{
                    Selected = item;
                //}
            }
        }
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        public ObservableCollection<TicketDto> Tickets
        {
            get => tickets;
            set => Set(ref tickets, value);
        }

        public TicketDto Selected
        {
            get => _selected;
            set => Set(ref _selected, value);
        }

        private async Task Initialize(int selectedId = 0)
        {
            try
            {
                Tickets = new ObservableCollection<TicketDto>();
                var pilots = await _ticketsService.GetAllTicketsAsync();

                foreach (var p in pilots)
                {
                    Tickets.Add(p);
                }

                Selected = Tickets.FirstOrDefault(p => p.Id == selectedId);
            }
            catch (Exception ex)
            {
                // Report error here
                Title = ex.Message;
            }
        }

        private async void DoDeleteTicket()
        {
            if (Selected == null) return;
            var result = await _ticketsService.DeleteTicketByIdAsync(Selected.Id);
            if (result)
            {
                await Initialize();
            }
        }

        private async void DoAddTicket()
        {
            var s = new TicketDto();
            Tickets.Add(s);
            Selected = s;
            //if (Selected == null) return;

            //var pilot = await _ticketsService.CreateTicketAsync(Selected);
            //if (pilot != null)
            //{
            //    await Initialize(pilot.Id);
            //    //Tickets.Add(pilot);
            //    //Selected = pilot;
            //}
        }

        private async void DoUpdateTicket()
        {
            if (Selected == null) return;
            var result = await _ticketsService.UpdateTicketByIdAsync(Selected);
            if (result)
            {
                await Initialize(Selected.Id);
            }
        }
    }
}
