using GalaSoft.MvvmLight.Ioc;

using Microsoft.Practices.ServiceLocation;

namespace ClientLight.ViewModel
{
    using ClientLight.Interfaces.Services;
    using ClientLight.Model;
    using ClientLight.Services;
    using ClientLight.Services.Data;
    using ClientLight.Views;

    using GalaSoft.MvvmLight;
    using GalaSoft.MvvmLight.Views;

    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// <para>
    /// See http://www.mvvmlight.net
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        NavigationServiceEx _navigationService = new NavigationServiceEx();

        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<IDialogService, DialogService>();

            if (ViewModelBase.IsInDesignModeStatic)
            {
                SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
            }
            else
            {
                SimpleIoc.Default.Register<IDataService, DataService>();

                SimpleIoc.Default.Register<ICrewsService, CrewsService>();
                SimpleIoc.Default.Register<IDeparturesService, DeparturesService>();
                SimpleIoc.Default.Register<IFlightsService, FlightsService>();
                SimpleIoc.Default.Register<IPilotsService, PilotService>();

                SimpleIoc.Default.Register<IPlanesService, PlanesService>();
                SimpleIoc.Default.Register<IPlaneTypesService, PlaneTypesService>();
                SimpleIoc.Default.Register<IStewardessesService, StewardessesService>();
                SimpleIoc.Default.Register<ITicketsService, TicketsService>();
            }

            SimpleIoc.Default.Register(() => _navigationService);
            SimpleIoc.Default.Register<ShellViewModel>();

            Register<CrewsViewModel, CrewsPage>();
            Register<DeparturesViewModel, DeparturesPage>();
            Register<FlightsViewModel, FlightsPage>();
            Register<PilotDetailViewModel, PilotDetailPage>();
            Register<PilotsViewModel, PilotsPage>();
            Register<PlanesViewModel, PlanesPage>();
            Register<PlaneTypesViewModel, PlaneTypesPage>();
            Register<StewardessesViewModel, StewardessesPage>();
            Register<TicketsViewModel, TicketsPage>();

            Register<CustomerViewModel, CustomerPage>();
            Register<CustomerDetailViewModel, CustomerDetailPage>();
            Register<SettingsViewModel, SettingsPage>();
        }

        public CrewsViewModel CrewsViewModel => ServiceLocator.Current.GetInstance<CrewsViewModel>();
        public DeparturesViewModel DeparturesViewModel => ServiceLocator.Current.GetInstance<DeparturesViewModel>();
        public FlightsViewModel FlightsViewModel => ServiceLocator.Current.GetInstance<FlightsViewModel>();
        public PilotDetailViewModel PilotDetailViewModel => ServiceLocator.Current.GetInstance<PilotDetailViewModel>();
        public PilotsViewModel PilotsViewModel => ServiceLocator.Current.GetInstance<PilotsViewModel>();
        public PlanesViewModel PlanesViewModel => ServiceLocator.Current.GetInstance<PlanesViewModel>();
        public PlaneTypesViewModel PlaneTypesViewModel => ServiceLocator.Current.GetInstance<PlaneTypesViewModel>();
        public StewardessesViewModel StewardessesViewModel => ServiceLocator.Current.GetInstance<StewardessesViewModel>();
        public TicketsViewModel TicketsViewModel => ServiceLocator.Current.GetInstance<TicketsViewModel>();



        public CustomerDetailViewModel CustomerDetailViewModel => ServiceLocator.Current.GetInstance<CustomerDetailViewModel>();
        public CustomerViewModel CustomerViewModel => ServiceLocator.Current.GetInstance<CustomerViewModel>();
        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();


        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public void Register<VM, V>() where VM : class
        {
            SimpleIoc.Default.Register<VM>();
            _navigationService.Configure(typeof(VM).FullName, typeof(V));
        }
    }
}
