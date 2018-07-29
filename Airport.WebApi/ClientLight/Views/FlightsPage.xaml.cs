using System;

using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace ClientLight.Views
{
    using ClientLight.ViewModel;

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FlightsPage : Page
    {
        private FlightsViewModel ViewModel => DataContext as FlightsViewModel;

        public FlightsPage()
        {
            this.InitializeComponent();
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
            }
        }
    }
}
