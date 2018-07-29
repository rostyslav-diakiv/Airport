namespace ClientLight.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using ClientLight.Model;
    using ClientLight.Services;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Views;

    public class PilotsViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly PilotService _pilotService;
        private VisualState _currentState;
        private PilotDto _selected;

        private string _title = "Countries with code";
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
            get { return _selected; }
            set
            {
                Set(ref _selected, value);
                // SaveSettings();
            }
        }

        public ICommand ItemClickCommand { get; private set; }
        public ICommand StateChangedCommand { get; private set; }
        public ICommand AddCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand UpdateCustomerCommand { get; }

        public PilotsViewModel(INavigationService navigationService)
        {
            _pilotService = new PilotService();
            _navigationService = navigationService;
            Title = "Pilots Page";
            ItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
            AddCustomerCommand = new RelayCommand(DoAddCustomer);
            DeleteCustomerCommand = new RelayCommand(DoDeleteCustomer);
            UpdateCustomerCommand = new RelayCommand(DoUpdateCustomer);
            Initialize();
        }

        private async Task Initialize()
        {
            try
            {
                Customers = new ObservableCollection<PilotDto>();
                var pilots = await _pilotService.GetAllPilots();

                foreach (var p in pilots)
                {
                    Customers.Add(p);
                }

                Selected = Customers.FirstOrDefault();
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
                Customers.Add(pilot);
                Selected = pilot;
            }
        }

        private async void DoUpdateCustomer()
        {
            if (Selected == null) return;
            var result = await _pilotService.UpdatePilotByIdAsync(Selected);
            if (result)
            {
                await Initialize();
            }
        }

        private void OnStateChanged(VisualStateChangedEventArgs args)
        {
            _currentState = args.NewState;
        }

        private void OnItemClick(ItemClickEventArgs args)
        {
            if (args?.ClickedItem is PilotDto item)
            {
                Selected = item;
            }
        }

        //public NavigationServiceEx NavigationService
        //{
        //    get
        //    {
        //        return Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<NavigationServiceEx>();
        //    }
        //}

        //const string NarrowStateName = "NarrowState";
        //const string WideStateName = "WideState";

        //public async Task LoadDataAsync(VisualState currentState)
        //{
        //    _currentState = currentState;
        //    Customers.Clear();

        //    var service = new PilotService();
        //    var data = await service.GetAllPilots();

        //    foreach (var item in data)
        //    {
        //        Customers.Add(item);
        //    }
        //    await LoadSettingsAsync();

        //    //Singleton<ToastNotificationsService>.Instance.ShowToastNotificationSample($"Loaded {Customers.Count} customers");
        //    //Singleton<LiveTileService>.Instance.SampleUpdate($"{Customers.Count} customers in the database");
        //}

        //private async void SaveSettings()
        //{
        //    if (Selected != null)
        //    {
        //        var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        //        var container =
        //            localSettings.CreateContainer("CustSettings",
        //                Windows.Storage.ApplicationDataCreateDisposition.Always);
        //        await container.SaveAsync("LastCust", Selected.Id);
        //    }
        //}

        //private async Task LoadSettingsAsync()
        //{
        //    var localSettings = Windows.Storage.ApplicationData.Current.LocalSettings;

        //    var container =
        //        localSettings.CreateContainer("CustSettings",
        //            Windows.Storage.ApplicationDataCreateDisposition.Always);
        //    var lastCust = await container.ReadAsync<string>("LastCust");
        //    Selected = !string.IsNullOrEmpty(lastCust) ?
        //        Customers.FirstOrDefault(c => c.Id == lastCust) :
        //        Customers.FirstOrDefault();
        //}
    }
}
