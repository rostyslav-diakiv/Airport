namespace ClientLight.ViewModel
{
    using System.Collections.ObjectModel;

    using ClientLight.Model;
    using ClientLight.Services;

    using GalaSoft.MvvmLight;

    public class PilotsViewModel : ViewModelBase
    {
        private readonly PilotService _pilotService;
        public PilotsViewModel()
        {
            _pilotService = new PilotService();
            DisplayText = "MY PAGE!!!!!!!!!!!!!!";
        }

        public string DisplayText { get; private set; }

        public string SomeText { get; set; } = "WERWETWERTWERTWE";

        private string _title = "Countries with code";

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        private ObservableCollection<PilotDto> _pilots;

        public ObservableCollection<PilotDto> Pilots
        {
            get { return _pilots; }
            set { _pilots = value; }
        }
    }
}
