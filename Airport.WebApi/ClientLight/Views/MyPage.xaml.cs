namespace ClientLight.Views
{
    using Windows.UI.Core;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;
    using Windows.UI.Xaml.Navigation;

    using ClientLight.ViewModel;

    using GalaSoft.MvvmLight.Views;

    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MyPage : Page
    {
        public MyPageViewModel Vm => (MyPageViewModel)DataContext;

        public MyPage()
        {
            InitializeComponent();

            SystemNavigationManager.GetForCurrentView().BackRequested += SystemNavigationManagerBackRequested;

            //Loaded += (s, e) =>
            //    {
            //        Vm.RunClock();
            //    };
        }

        private void GoBackButtonClick(object sender, RoutedEventArgs e)
        {
            var nav = ServiceLocator.Current.GetInstance<INavigationService>();
            nav.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter != null) DisplayText.Text = e.Parameter.ToString();
            base.OnNavigatedTo(e);
        }

        private void SystemNavigationManagerBackRequested(object sender, BackRequestedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            // Vm.StopClock();
            base.OnNavigatingFrom(e);
        }
    }
}
