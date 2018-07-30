namespace ClientLight.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using ClientLight.Interfaces.Services;
    using ClientLight.Model;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using ClientLight.Exceptions;

    using GalaSoft.MvvmLight.Views;

    using Microsoft.Practices.ServiceLocation;

    public class PilotsViewModel : ViewModelBase
    {
        public ICommand ItemClickCommand { get; private set; }
        public ICommand StateChangedCommand { get; private set; }
        public ICommand AddCustomerCommand { get; }
        public ICommand DeleteCustomerCommand { get; }
        public ICommand UpdateCustomerCommand { get; }

        public PilotsViewModel(IPilotsService service)
        {
            _pilotService = service;
            ItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
            AddCustomerCommand = new RelayCommand(DoAddCustomer);
            DeleteCustomerCommand = new RelayCommand(DoDeleteCustomer);
            UpdateCustomerCommand = new RelayCommand(DoUpdateCustomer);
        }

        public async Task LoadDataAsync(VisualState currentState)
        {
            await Initialize();
        }

        private void OnStateChanged(VisualStateChangedEventArgs args)
        {
        }

        private void OnItemClick(ItemClickEventArgs args)
        {
            if (args?.ClickedItem is PilotDto item)
            {
                Selected = item;
            }
        }

        private readonly IPilotsService _pilotService;
        private PilotDto _selected;

        private string _title = "Pilots";
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
                await ShowMessageAsync(ex.Message, "Error occurred");
            }
        }

        private async void DoDeleteCustomer()
        {
            if (Selected == null) return;

            var result = await _pilotService.DeletePilotByIdAsync(Selected.Id);
            if (result)
            {
                await ShowMessageAsync("Pilot was deleted successful", "Success!!!");
                await Initialize();
            }
            else
            {
                await ShowMessageAsync();
            }
        }

        private void DoAddCustomer()
        {
            var pilot = new PilotDto();
            Customers.Add(pilot);
            Selected = pilot;
        }

        private async void DoUpdateCustomer()
        {
            if (Selected == null) return;

            try
            {
                if (Selected.Id == 0)
                {
                    var dto = await _pilotService.CreatePilotAsync(Selected);
                    if (dto != null)
                    {
                        await ShowMessageAsync("Pilot was successfully created", "Success!!!");
                        await Initialize(dto.Id);
                    }
                    else
                    {
                        await ShowMessageAsync();
                    }
                }
                else
                {
                    var result = await _pilotService.UpdatePilotByIdAsync(Selected);
                    if (result)
                    {
                        await ShowMessageAsync("Pilot was updated successful", "Success!!!");
                        await Initialize(Selected.Id);
                    }
                    else
                    {
                        await ShowMessageAsync();
                    }
                }
            }
            catch (ModelStateException modelStateException)
            {
                var mess = string.Empty;
                foreach (var key in modelStateException.ModelErrors.Keys)
                {
                    mess += $"{key}: {string.Join(", \n", modelStateException.ModelErrors[key])} \n";
                }

                await ShowMessageAsync(mess, "Model state invalid!");
            }
            catch (HttpStatusCodeException httpException)
            {
                await ShowMessageAsync($"{httpException.StatusCode}\n {httpException.Message}", "Model state invalid!");
            }
            catch (Exception e)
            {
                await ShowMessageAsync(e.Message, "Validation Error");
            }
        }

        protected Task ShowMessageAsync(string message = "Model is invalid! Try again with right data!", string title = "Error occurred")
        {
            var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
            return dialog.ShowMessage(message, title);
        }
    }
}
