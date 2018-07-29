namespace ClientLight.ViewModel
{
    using System.Windows.Input;

    using Windows.UI.Xaml;

    using ClientLight.Model;
    using ClientLight.Views;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;
    using GalaSoft.MvvmLight.Views;

    public class TicketDetailViewModel : ViewModelBase
    {
        //public ICommand StateChangedCommand { get; private set; }

        //private PilotDto _item;

        //public PilotDto Item
        //{
        //    get
        //    {
        //        return _item;
        //    }
        //    set
        //    {
        //        Set(ref _item, value);
        //    }
        //}


        public TicketDetailViewModel(INavigationService navigationService)
        {
            //StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
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
