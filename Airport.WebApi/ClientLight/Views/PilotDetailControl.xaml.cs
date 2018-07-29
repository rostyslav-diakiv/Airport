using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ClientLight.Views
{
    using Windows.UI.Xaml;

    using ClientLight.Model;

    public sealed partial class PilotDetailControl : UserControl
    {
        public PilotDto MasterMenuItem
        {
            get { return GetValue(MasterMenuItemProperty) as PilotDto; }
            set { SetValue(MasterMenuItemProperty, value); }
        }

        public static DependencyProperty MasterMenuItemProperty = DependencyProperty.Register(
            "MasterMenuItem", typeof(PilotDto), typeof(PilotDetailControl), new PropertyMetadata(null));

        public PilotDetailControl()
        {
            InitializeComponent();
        }
    }
}
