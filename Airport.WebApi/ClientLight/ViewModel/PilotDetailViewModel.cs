namespace ClientLight.ViewModel
{
    using System.Windows.Input;

    using Windows.UI.Xaml;

    using ClientLight.Model;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Views;

    public class PilotDetailViewModel : ViewModelBase
    {

        //public NavigationServiceEx NavigationService
        //{
        //    get
        //    {
        //        return Microsoft.Practices.ServiceLocation.ServiceLocator.Current.GetInstance<NavigationServiceEx>();
        //    }
        //}

        //const string NarrowStateName = "NarrowState";
        //const string WideStateName = "WideState";

        public ICommand StateChangedCommand { get; private set; }

        private PilotDto _item;
        public PilotDto Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }

        private readonly INavigationService _navigationService;
        public PilotDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
        }

        private void OnStateChanged(VisualStateChangedEventArgs args)
        {
            //if (args?.OldState?.Name == NarrowStateName && args.NewState?.Name == WideStateName)
            //{
               // _navigationService.GoBack();
            //}
        }
    }
}
