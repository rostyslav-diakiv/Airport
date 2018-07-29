namespace ClientLight.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Services;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    using Microsoft.Practices.ServiceLocation;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class PilotsViewModel : ViewModelBase
    {
        public NavigationServiceEx NavigationService => ServiceLocator.Current.GetInstance<NavigationServiceEx>();

        const string NarrowStateName = "NarrowState";
        const string WideStateName = "WideState";

        private VisualState _currentState;

        public ICommand ItemClickCommand { get; private set; }
        public ICommand StateChangedCommand { get; private set; }
        public ICommand AddCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand UpdateCustomerCommand { get; }

        public PilotsViewModel(IPilotsService service)
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
            if (args?.ClickedItem is PilotDto item)
            {
                if (_currentState.Name == NarrowStateName)
                {
                    NavigationService.Navigate(typeof(CustomerDetailViewModel).FullName, item);
                }
                else
                {
                    Selected = item;
                }
            }
        }

        private readonly IPilotsService _pilotService;
        private PilotDto _selected;

        private string _title = "Pilots Page";
        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private ObservableCollection<PilotDto> _customers;
        public ObservableCollection<PilotDto> Customers
        {
            get => _customers;
            set => Set(ref _customers, value);
        }

        public PilotDto Selected
        {
            get => _selected;
            set => Set(ref _selected, value);
        }

        private async Task Initialize(int selectedId = 0)
        {
            try
            {
                Customers = new ObservableCollection<PilotDto>();
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
            var pilot = new PilotDto();
            Customers.Add(pilot);
            Selected = pilot;
        }

        private async void DoUpdateCustomer()
        {
            if (Selected == null) return;
            if (Selected.Id == 0)
            {
                var dto = await _pilotService.CreatePilotAsync(Selected);
                if (dto != null)
                {
                    await Initialize(dto.Id);
                }
            }
            else
            {
                var result = await _pilotService.UpdatePilotByIdAsync(Selected);
                if (result)
                {
                    await Initialize(Selected.Id);
                }
            }
        }
    }
}
