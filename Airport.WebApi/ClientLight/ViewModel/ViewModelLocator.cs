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
                SimpleIoc.Default.Register<IPilotsService, PilotService>();
                SimpleIoc.Default.Register<ITicketsService, TicketsService>();
                SimpleIoc.Default.Register<IStewardessesService, StewardessesService>();
                SimpleIoc.Default.Register<IDeparturesService, DeparturesService>();
            }

            SimpleIoc.Default.Register(() => _navigationService);
            SimpleIoc.Default.Register<ShellViewModel>();

            Register<TicketsViewModel, TicketsPage>();

            Register<StewardessesViewModel, StewardessesPage>();
            Register<DeparturesViewModel, DeparturesPage>();




            Register<PilotsViewModel, PilotsPage>();
            Register<PilotDetailViewModel, PilotDetailPage>();

            Register<CustomerViewModel, CustomerPage>();
            Register<CustomerDetailViewModel, CustomerDetailPage>();
            Register<SettingsViewModel, SettingsPage>();
        }

        public PilotDetailViewModel PilotDetailViewModel => ServiceLocator.Current.GetInstance<PilotDetailViewModel>();
        public PilotsViewModel PilotsViewModel => ServiceLocator.Current.GetInstance<PilotsViewModel>();

        public TicketsViewModel TicketsViewModel => ServiceLocator.Current.GetInstance<TicketsViewModel>();
        public StewardessesViewModel StewardessesViewModel => ServiceLocator.Current.GetInstance<StewardessesViewModel>();
        public DeparturesViewModel DeparturesViewModel => ServiceLocator.Current.GetInstance<DeparturesViewModel>();


        public CustomerDetailViewModel CustomerDetailViewModel => ServiceLocator.Current.GetInstance<CustomerDetailViewModel>();
        public CustomerViewModel CustomerViewModel => ServiceLocator.Current.GetInstance<CustomerViewModel>();
        public SettingsViewModel SettingsViewModel => ServiceLocator.Current.GetInstance<SettingsViewModel>();


        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();

        public void Register<VM, V>() where VM : class
        {
            SimpleIoc.Default.Register<VM>();
            _navigationService.Configure(typeof(VM).FullName, typeof(V));
        }

        ///// <summary>
        ///// This property can be used to force the application to run with design time data.
        ///// </summary>
        //public static bool UseDesignTimeData
        //{
        //    get
        //    {
        //        return false;
        //    }
        //}

        //static ViewModelLocator()
        //{
        //    ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

        //    var nav = new NavigationService();
        //    nav.Configure(SecondPageKey, typeof(SecondPage));
        //    nav.Configure(MyPageKey, typeof(MyPage));
        //    nav.Configure(PilotsPagePageKey, typeof(PilotsPage));
        //    nav.Configure(PilotDetailPageKey, typeof(PilotDetailPage));
        //    nav.Configure(ShellPageKey, typeof(ShellPage));

        //    SimpleIoc.Default.Register<INavigationService>(() => nav);

        //    SimpleIoc.Default.Register<IDialogService, DialogService>();

        //    if (ViewModelBase.IsInDesignModeStatic
        //            || UseDesignTimeData)
        //    {
        //        SimpleIoc.Default.Register<IDataService, Design.DesignDataService>();
        //    }
        //    else
        //    {
        //        SimpleIoc.Default.Register<IDataService, DataService>();
        //    }

        //    SimpleIoc.Default.Register<MainViewModel>();
        //    SimpleIoc.Default.Register<MyPageViewModel>();
        //    SimpleIoc.Default.Register<PilotsViewModel>();
        //    SimpleIoc.Default.Register<PilotDetailViewModel>();
        //    SimpleIoc.Default.Register<ShellViewModel>();
        //}

        ///// <summary>
        ///// Gets the Main property.
        ///// </summary>
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        //public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        //public MyPageViewModel MyPage => ServiceLocator.Current.GetInstance<MyPageViewModel>();

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        //public PilotsViewModel Pilots => ServiceLocator.Current.GetInstance<PilotsViewModel>();

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        //public PilotDetailViewModel PilotDetail => ServiceLocator.Current.GetInstance<PilotDetailViewModel>();

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
        //    "CA1822:MarkMembersAsStatic",
        //    Justification = "This non-static member is needed for data binding purposes.")]
        //public ShellViewModel Shell => ServiceLocator.Current.GetInstance<ShellViewModel>();

        //public const string SecondPageKey = "SecondPage";
        //public const string MyPageKey = "MyPage";
        //public const string PilotsPagePageKey = "PilotsPage";
        //public const string PilotDetailPageKey = "PilotDetailPage";
        //public const string ShellPageKey = "ShellPage";
    }
}
