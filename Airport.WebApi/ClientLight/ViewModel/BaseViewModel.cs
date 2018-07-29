namespace ClientLight.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    using ClientLight.Interfaces;
    using ClientLight.Interfaces.Services;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Views;

    using Microsoft.Practices.ServiceLocation;

    public class BaseViewModel<TDto, TKey> : ViewModelBase where TDto : IEntity<TKey>
    {
        public ICommand ItemClickCommand { get; private set; }

        public ICommand StateChangedCommand { get; private set; }

        public ICommand AddEntityCommand { get; }

        public ICommand DeleteEntityCommand { get; }

        public ICommand UpdateEntityCommand { get; }

        public BaseViewModel(IService<TDto, TKey> service)
        {
            _service = service;
            ItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
            AddEntityCommand = new RelayCommand(DoAddStewardess);
            DeleteEntityCommand = new RelayCommand(DoDeleteStewardess);
            UpdateEntityCommand = new RelayCommand(DoUpdateStewardess);
        }

        public Task LoadDataAsync(VisualState currentState)
        {
            return Initialize();
        }

        private void OnStateChanged(VisualStateChangedEventArgs args)
        {
        }

        private void OnItemClick(ItemClickEventArgs args)
        {
            if (args?.ClickedItem is TDto item)
            {
                Selected = item;
            }
        }

        private readonly IService<TDto, TKey> _service;

        private TDto _selected;

        private string _title = "Page";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        private ObservableCollection<TDto> entities;

        public ObservableCollection<TDto> Entities
        {
            get => entities;
            set => Set(ref entities, value);
        }

        public TDto Selected
        {
            get => _selected;
            set => Set(ref _selected, value);
        }

        private async Task Initialize(TKey selectedId = default(TKey))
        {
            try
            {
                Entities = new ObservableCollection<TDto>();
                var en = await _service.GetAllEntities();

                foreach (var e in en)
                {
                    Entities.Add(e);
                }

                Selected = Entities.FirstOrDefault(p => Equals(p.Id, selectedId));
            }
            catch (Exception ex)
            {
                var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                await dialog.ShowMessage(ex.Message, "Error occurred");
                Title = ex.Message;
            }
        }

        private async void DoDeleteStewardess()
        {
            if (Selected == null) return;
            var result = await _service.DeleteEntitiesByIdAsync(Selected.Id);
            if (result)
            {
                await Initialize();
            }
            else
            {
                await ShowErrorAsync();
            }
        }

        private async void DoAddStewardess()
        {
            if (Selected == null) return;

            var pilot = await _service.CreateEntitiesAsync(Selected);
            if (pilot != null)
            {
                await Initialize(pilot.Id);
            }
            else
            {
                await ShowErrorAsync();
            }
        }

        private async void DoUpdateStewardess()
        {
            if (Selected == null) return;
            var result = await _service.UpdateEntitiesByIdAsync(Selected);
            if (result)
            {
                await Initialize(Selected.Id);
            }
            else
            {
                await ShowErrorAsync();
            }
        }

        protected Task ShowErrorAsync(string message = "Model is invalid! Try again with right data!", string title = "Error occurred")
        {
            var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
            return dialog.ShowMessage(message, title);
        }
    }
}
