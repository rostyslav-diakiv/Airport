namespace ClientLight.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.Threading.Tasks;

    using ClientLight.Model;
    using ClientLight.Services;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Views;

    public class MyPageViewModel : ViewModelBase
    {
        private readonly IDataService _dataService;
        private readonly INavigationService _navigationService;
        private PilotService _pilotService;

        public MyPageViewModel(
            IDataService dataService,
            INavigationService navigationService)
        {
            _dataService = dataService;
            _navigationService = navigationService;
             Initialize();
        }

        private async Task Initialize()
        {
            try
            {
                _pilotService = new PilotService();

                var pilots = await _pilotService.GetAllPilots();
                Pilots = new ObservableCollection<PilotDto>();

                foreach (var p in pilots)
                {
                    Pilots.Add(p);
                }

                Countries = new ObservableCollection<Country>();
                Countries.Add(new Country() { CountryCode = "1", CountryName = "Canada" });
                Countries.Add(new Country() { CountryCode = "1", CountryName = "United States" });
                Countries.Add(new Country() { CountryCode = "44", CountryName = "United Kingdom" });
                Countries.Add(new Country() { CountryCode = "91", CountryName = "India" });

                var item = await _dataService.GetData();
                Title = item.Title;
            }
            catch (Exception ex)
            {
                // Report error here
                Title = ex.Message;
            }
        }

        private string _title = "Countries with code";
        public string Title
        {
            get { return _title; }
            set
            {
                Set(ref _title, value);
            }
        }


        private ObservableCollection<Country> _countries;

        public ObservableCollection<Country> Countries
        {
            get { return _countries; }
            set
            {
                Set(ref _countries, value);
            }
        }

        private ObservableCollection<PilotDto> _pilots;

        public ObservableCollection<PilotDto> Pilots
        {
            get { return _pilots; }
            set
            {
                Set(ref _pilots, value);
            }
        }
    }
}
