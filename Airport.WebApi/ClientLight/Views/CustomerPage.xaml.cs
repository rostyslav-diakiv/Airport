using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace ClientLight.Views
{
    using System;

    using ClientLight.ViewModel;

    public sealed partial class CustomerPage : Page
    {
        private CustomerViewModel ViewModel => DataContext as CustomerViewModel;

        public CustomerPage()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                await ViewModel.LoadDataAsync(WindowStates.CurrentState);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                //                throw;
            }
        }

    }
}
