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

    using ClientLight.Exceptions;

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
            AddEntityCommand = new RelayCommand(DoAddEntity);
            DeleteEntityCommand = new RelayCommand(DoDeleteEntity);
            UpdateEntityCommand = new RelayCommand(DoUpdateEntity);
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
            }
        }

        protected virtual async void DoDeleteEntity()
        {
            if (Selected == null) return;
            var result = await _service.DeleteEntityByIdAsync(Selected.Id);
            if (result)
            {
                await ShowMessageAsync("Entity was deleted successful", "Success!!!");
                await Initialize();
            }
            else
            {
                await ShowMessageAsync();
            }
        }

        protected virtual void DoAddEntity()
        {
            var e = new TDto();
            Entities.Add(e);
            Selected = e;
        }

        protected virtual async void DoUpdateEntity()
        {
            if (Selected == null) return;

            try
            {
                if (Selected.Id.Equals(0) || Selected.Id.Equals(string.Empty))
                {
                    var pilot = await _service.CreateEntityAsync(Selected);
                    if (pilot != null)
                    {
                        await ShowMessageAsync("Entity was successfully created", "Success!!!");
                        await Initialize(pilot.Id);
                    }
                    else
                    {
                        await ShowMessageAsync();
                    }
                }
                else
                {
                    var result = await _service.UpdateEntityByIdAsync(Selected);
                    if (result)
                    {
                        await ShowMessageAsync("Entity was update successful", "Success!!!");
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
