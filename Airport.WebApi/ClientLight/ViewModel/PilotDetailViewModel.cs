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
        public ICommand StateChangedCommand { get; }

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
        }
    }
}
