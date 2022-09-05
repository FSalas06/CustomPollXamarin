using CustomPollXamarin.Views;
using Xamarin.Forms;

namespace CustomPollXamarin
{
    public partial class App : Application
    {
        public static INavigation NavigationServices { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainPage());
            
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
