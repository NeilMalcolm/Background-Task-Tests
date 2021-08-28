using Xamarin.Forms;
using BackgroundDownloadTests.Services;

namespace BackgroundDownloadTests
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.RegisterSingleton<IAsyncBackgroundTaskService>(new AsyncBackgroundTaskService());
            DependencyService.Register<MockDataStore>();
            MainPage = new AppShell();
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
