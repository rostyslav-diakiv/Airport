using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ClientLight.Views
{
    using ClientLight.Model;
    using ClientLight.ViewModel;

    public sealed partial class CustomerDetailPage : Page
    {
        private CustomerDetailViewModel ViewModel => DataContext as CustomerDetailViewModel;

        public CustomerDetailPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            ViewModel.Item = e.Parameter as Customer;
        }
    }
}
