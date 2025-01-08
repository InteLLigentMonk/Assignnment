using Assignment.Maui.Pages;

namespace Assignment.Maui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(MainPage), typeof(MainPage));
            Routing.RegisterRoute(nameof(AddContactPage), typeof(AddContactPage));

        }
    }
}
