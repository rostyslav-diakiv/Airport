﻿namespace ClientLight.ViewModel
{
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Windows.Input;

    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Views;

    public class ShellViewModel : ViewModelBase
    {
        //private const string PanoramicStateName = "PanoramicState";
        //private const string WideStateName = "WideState";
        //private const string NarrowStateName = "NarrowState";

        //public NavigationServiceEx NavigationService
        //{
        //    get
        //    {
        //        return Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<NavigationServiceEx>();
        //    }
        //}

        private readonly INavigationService _navigationService;
        public ShellViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        private bool _isPaneOpen;
        public bool IsPaneOpen
        {
            get { return _isPaneOpen; }
            set { Set(ref _isPaneOpen, value); }
        }

        private SplitViewDisplayMode _displayMode = SplitViewDisplayMode.CompactInline;
        public SplitViewDisplayMode DisplayMode
        {
            get { return _displayMode; }
            set { Set(ref _displayMode, value); }
        }

        private object _lastSelectedItem;

        private ObservableCollection<ShellNavigationItem> _primaryItems = new ObservableCollection<ShellNavigationItem>();
        public ObservableCollection<ShellNavigationItem> PrimaryItems
        {
            get { return _primaryItems; }
            set { Set(ref _primaryItems, value); }
        }

        private ObservableCollection<ShellNavigationItem> _secondaryItems = new ObservableCollection<ShellNavigationItem>();
        public ObservableCollection<ShellNavigationItem> SecondaryItems
        {
            get { return _secondaryItems; }
            set { Set(ref _secondaryItems, value); }
        }

        private ICommand _openPaneCommand;
        public ICommand OpenPaneCommand
        {
            get
            {
                if (_openPaneCommand == null)
                {
                    _openPaneCommand = new RelayCommand(() => IsPaneOpen = !_isPaneOpen);
                }

                return _openPaneCommand;
            }
        }

        private ICommand _itemSelected;
        public ICommand ItemSelectedCommand
        {
            get
            {
                if (_itemSelected == null)
                {
                    _itemSelected = new RelayCommand<ShellNavigationItem>(ItemSelected);
                }

                return _itemSelected;
            }
        }

        private ICommand _stateChangedCommand;
        public ICommand StateChangedCommand
        {
            get
            {
                if (_stateChangedCommand == null)
                {
                    _stateChangedCommand = new RelayCommand<Windows.UI.Xaml.VisualStateChangedEventArgs>(OnStateChanged);
                }

                return _stateChangedCommand;
            }
        }

        private void OnStateChanged(VisualStateChangedEventArgs args)
        {
            switch (args.NewState.Name)
            {
                //case PanoramicStateName:
                //    DisplayMode = SplitViewDisplayMode.CompactInline;
                //    break;
                //case WideStateName:
                //    DisplayMode = SplitViewDisplayMode.CompactInline;
                //    IsPaneOpen = false;
                //    break;
                //case NarrowStateName:
                //    DisplayMode = SplitViewDisplayMode.Overlay;
                //    IsPaneOpen = false;
                //    break;
                default:
                    break;
            }
        }

        public void Initialize(Frame frame)
        {
            // _navigationService.Frame = frame;
            // NavigationService.Frame.Navigated += NavigationService_Navigated;
            PopulateNavItems();
        }

        private void PopulateNavItems()
        {
            _primaryItems.Clear();
            _secondaryItems.Clear();

            // More on Segoe UI Symbol icons: https://docs.microsoft.com/windows/uwp/style/segoe-ui-symbol-font
            // Edit String/en-US/Resources.resw: Add a menu item title for each page
            _primaryItems.Add(new ShellNavigationItem("Shell_Customer", Symbol.People, ViewModelLocator.PilotsPagePageKey));
            _secondaryItems.Add(new ShellNavigationItem("Shell_Settings", Symbol.Setting, ViewModelLocator.MyPageKey));
        }

        private void ItemSelected(ShellNavigationItem e)
        {
            if (DisplayMode == SplitViewDisplayMode.CompactOverlay || DisplayMode == SplitViewDisplayMode.Overlay)
            {
                IsPaneOpen = false;
            }
            Navigate(e);
        }

        private void NavigationService_Navigated(object sender, NavigationEventArgs e)
        {
            if (e != null)
            {
                //var vm = _navigationService.GetNameOfRegisteredPage(e.SourcePageType);
                //var item = PrimaryItems?.FirstOrDefault(i => i.ViewModelName == vm);
                //if (item == null)
                //{
                //    item = SecondaryItems?.FirstOrDefault(i => i.ViewModelName == vm);
                //}

                //if (item != null)
                //{
                //    ChangeSelected(_lastSelectedItem, item);
                //    _lastSelectedItem = item;
                //}
            }
        }

        private void ChangeSelected(object oldValue, object newValue)
        {
            if (oldValue != null)
            {
                (oldValue as ShellNavigationItem).IsSelected = false;
            }
            if (newValue != null)
            {
                (newValue as ShellNavigationItem).IsSelected = true;
            }
        }

        private void Navigate(object item)
        {
            var navigationItem = item as ShellNavigationItem;
            if (navigationItem != null)
            {
                _navigationService.NavigateTo(navigationItem.ViewModelName);
            }
        }
    }
}
