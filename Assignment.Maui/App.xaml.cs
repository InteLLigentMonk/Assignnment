namespace Assignment.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            var window = new Window
            {
                Page = new AppShell()
            };

#if WINDOWS
        if (DeviceInfo.Idiom == DeviceIdiom.Desktop)
        {
            window.Width = 500;
            window.Height = 800;
        }
#endif

            return window;
        }
    }
}