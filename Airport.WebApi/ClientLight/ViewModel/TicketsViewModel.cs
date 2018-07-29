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
        private readonly IPilotsService _pilotService;
        private TicketDto _selected;
        private ObservableCollection<TicketDto> _customers;
        private string _title = "Tickets Page";

        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        private VisualState _currentState;

        public ICommand ItemClickCommand { get; private set; }
        public ICommand StateChangedCommand { get; private set; }
        public ICommand AddCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand UpdateCustomerCommand { get; }

        public TicketsViewModel(IPilotsService service)
        {
            _pilotService = service; // new PilotService();
            ItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
            AddCustomerCommand = new RelayCommand(DoAddCustomer);
            DeleteCustomerCommand = new RelayCommand(DoDeleteCustomer);
            UpdateCustomerCommand = new RelayCommand(DoUpdateCustomer);
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

        public ObservableCollection<TicketDto> Customers
        {
            get => _customers;
            set => Set(ref _customers, value);
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
                Customers = new ObservableCollection<TicketDto>();
                var pilots = await _pilotService.GetAllPilots();

                foreach (var p in pilots)
                {
                    Customers.Add(p);
                }

                Selected = Customers.FirstOrDefault(p => p.Id == selectedId);
            }
            catch (Exception ex)
            {
                // Report error here
                Title = ex.Message;
            }
        }

        private async void DoDeleteCustomer()
        {
            if (Selected == null) return;
            var result = await _pilotService.DeletePilotByIdAsync(Selected.Id);
            if (result)
            {
                await Initialize();
            }
        }

        private async void DoAddCustomer()
        {
            if (Selected == null) return;

            var pilot = await _pilotService.CreatePilotAsync(Selected);
            if (pilot != null)
            {
                await Initialize(pilot.Id);
                //Customers.Add(pilot);
                //Selected = pilot;
            }
        }

        private async void DoUpdateCustomer()
        {
            if (Selected == null) return;
            var result = await _pilotService.UpdatePilotByIdAsync(Selected);
            if (result)
            {
                await Initialize(Selected.Id);
            }
        }
    }
}
