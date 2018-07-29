namespace ClientLight.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Threading.Tasks;
    using System.Windows.Input;

    using ClientLight.Interfaces;
    using ClientLight.Interfaces.Services;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Views;

    using Microsoft.Practices.ServiceLocation;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    public class BaseViewModel<TDto, TKey> : ViewModelBase where TDto : IEntity<TKey>, new()
    {
        public virtual ICommand ItemClickCommand { get; private set; }

        public virtual ICommand StateChangedCommand { get; private set; }

        public virtual ICommand AddEntityCommand { get; }

        public virtual ICommand DeleteEntityCommand { get; }

        public virtual ICommand UpdateEntityCommand { get; }

        public BaseViewModel(IService<TDto, TKey> service)
        {
            _service = service;
            ItemClickCommand = new RelayCommand<ItemClickEventArgs>(OnItemClick);
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
            AddEntityCommand = new RelayCommand(DoAddStewardess);
            DeleteEntityCommand = new RelayCommand(DoDeleteStewardess);
            UpdateEntityCommand = new RelayCommand(DoUpdateStewardess);
        }

        public virtual Task LoadDataAsync(VisualState currentState)
        {
            return Initialize();
        }

        protected virtual void OnStateChanged(VisualStateChangedEventArgs args)
        {
        }

        protected virtual void OnItemClick(ItemClickEventArgs args)
        {
            if (args?.ClickedItem is TDto item)
            {
                Selected = item;
            }
        }

        protected readonly IService<TDto, TKey> _service;

        protected TDto _selected;

        private string _title = "Page";

        public string Title
        {
            get => _title;
            set => Set(ref _title, value);
        }

        protected ObservableCollection<TDto> entities;

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

        protected virtual async Task Initialize(TKey selectedId = default(TKey))
        {
            try
            {
                Entities = new ObservableCollection<TDto>();
                var en = await _service.GetAllEntitiesAsync();

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

        protected virtual async void DoDeleteStewardess()
        {
            if (Selected == null) return;
            var result = await _service.DeleteEntityByIdAsync(Selected.Id);
            if (result)
            {
                await Initialize();
            }
            else
            {
                await ShowErrorAsync();
            }
        }

        protected virtual void DoAddStewardess()
        {
            var e = new TDto();
            Entities.Add(e);
            Selected = e;
        }

        protected virtual async void DoUpdateStewardess()
        {
            if (Selected == null) return;

            if (Selected.Id.Equals(0) || Selected.Id.Equals(string.Empty))
            {
                var pilot = await _service.CreateEntityAsync(Selected);
                if (pilot != null)
                {
                    await Initialize(pilot.Id);
                }
                else
                {
                    await ShowErrorAsync();
                }
            }
            else
            {
                var result = await _service.UpdateEntityByIdAsync(Selected);
                if (result)
                {
                    await Initialize(Selected.Id);
                }
                else
                {
                    await ShowErrorAsync();
                }
            }
        }

        protected Task ShowErrorAsync(string message = "Model is invalid! Try again with right data!", string title = "Error occurred")
        {
            var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
            return dialog.ShowMessage(message, title);
        }
    }
}
