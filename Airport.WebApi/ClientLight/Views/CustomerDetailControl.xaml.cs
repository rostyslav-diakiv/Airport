using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace ClientLight.Views
{
    using ClientLight.Model;

    public sealed partial class CustomerDetailControl : UserControl
    {
        public Customer MasterMenuItem
        {
            get => GetValue(MasterMenuItemProperty) as Customer;
            set => SetValue(MasterMenuItemProperty, value);
        }

        public static DependencyProperty MasterMenuItemProperty = DependencyProperty.Register(
            "MasterMenuItem",
            typeof(Customer),
            typeof(CustomerDetailControl),
            new PropertyMetadata(null));

        public CustomerDetailControl()
        {
            InitializeComponent();
        }
    }
}
