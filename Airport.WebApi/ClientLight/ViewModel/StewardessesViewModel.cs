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

    public class StewardessesViewModel : ViewModelBase
    {
        public ICommand ItemClickCommand { get; private set; }

        public ICommand StateChangedCommand { get; private set; }

        public ICommand AddStewardessCommand { get; }

        public ICommand DeleteStewardessCommand { get; }

        public ICommand UpdateStewardessCommand { get; }

        public StewardessesViewModel(IStewardessesService service)
        {
            _stewService = service;
            ItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
            AddStewardessCommand = new RelayCommand(DoAddStewardess);
            DeleteStewardessCommand = new RelayCommand(DoDeleteStewardess);
            UpdateStewardessCommand = new RelayCommand(DoUpdateStewardess);
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
            if (args?.ClickedItem is StewardessDto item)
            {
                    Selected = item;
            }
        }

        private readonly IStewardessesService _stewService;

        private StewardessDto _selected;

        private string _title = "Stewardesses Page";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private ObservableCollection<StewardessDto> stewardesses;

        public ObservableCollection<StewardessDto> Stewardesses
        {
            get => stewardesses;
            set => Set(ref stewardesses, value);
        }

        public StewardessDto Selected
        {
            get => _selected;
            set => Set(ref _selected, value);
        }

        private async Task Initialize(int selectedId = 0)
        {
            try
            {
                Stewardesses = new ObservableCollection<StewardessDto>();
                var pilots = await _stewService.GetAllEntities();

                foreach (var p in pilots)
                {
                    Stewardesses.Add(p);
                }

                Selected = Stewardesses.FirstOrDefault(p => p.Id == selectedId);
            }
            catch (Exception ex)
            {
                Title = ex.Message;
            }
        }

        private async void DoDeleteStewardess()
        {
            if (Selected == null) return;
            var result = await _stewService.DeleteEntitiesByIdAsync(Selected.Id);
            if (result)
            {
                await Initialize();
            }
        }

        private void DoAddStewardess()
        {
            var s = new StewardessDto();
            Stewardesses.Add(s);
            Selected = s;

            //if (Selected == null) return;

            //var pilot = await _stewService.CreateEntitiesAsync(Selected);
            //if (pilot != null)
            //{
            //    await Initialize(pilot.Id);
            //}
        }

        private async void DoUpdateStewardess()
        {
            if (Selected == null) return;
            if (Selected.Id == 0)
            {
                var dto = await _stewService.CreateEntitiesAsync(Selected);
                if (dto != null)
                {
                    await Initialize(dto.Id);
                }
            }
            else
            {
                var result = await _stewService.UpdateEntitiesByIdAsync(Selected);
                if (result)
                {
                    await Initialize(Selected.Id);
                }
            }
        }
    }
}
