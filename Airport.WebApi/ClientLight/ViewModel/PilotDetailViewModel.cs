namespace ClientLight.ViewModel
{
    using System.Windows.Input;

    using Windows.UI.Xaml;

    using ClientLight.Model;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Command;

    public class PilotDetailViewModel : ViewModelBase
    {
        public ICommand StateChangedCommand { get; }

        private PilotDto _item;
        public PilotDto Item
        {
            get { return _item; }
            set { Set(ref _item, value); }
        }
        
        public PilotDetailViewModel()
        {
            StateChangedCommand = new RelayCommand<VisualStateChangedEventArgs>(OnStateChanged);
        }

        private void OnStateChanged(VisualStateChangedEventArgs args) { }
    }
}
