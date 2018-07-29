using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace ClientLight.Views
{
    using ClientLight.Model;

    public sealed partial class TicketDetailControl : UserControl
    {
        public TicketDto MasterMenuItem
        {
            get => GetValue(MasterMenuItemProperty) as TicketDto;
            set => SetValue(MasterMenuItemProperty, value);
        }

        public static DependencyProperty MasterMenuItemProperty = DependencyProperty.Register(
            "MasterMenuItem", typeof(TicketDto), typeof(TicketDetailControl), new PropertyMetadata(null));

        public TicketDetailControl()
        {
            InitializeComponent();
        }

        // <!--Converter={StaticResource StringFormatConverter}, ConverterParameter='0{0.0}'}-->
    }
}
