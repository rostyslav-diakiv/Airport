using Windows.UI.Xaml.Controls;

namespace ClientLight.Views
{
    using ClientLight.ViewModel;

    public sealed partial class ShellPage : Page
    {
        private ShellViewModel ViewModel => DataContext as ShellViewModel;

        public ShellPage()
        {
            InitializeComponent();
            DataContext = ViewModel;
            ViewModel.Initialize(shellFrame);
        }
    }
}
