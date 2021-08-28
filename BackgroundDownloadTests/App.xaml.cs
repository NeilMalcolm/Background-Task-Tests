using Xamarin.Forms;
using BackgroundDownloadTests.Services;
using BackgroundDownloadTests.Views.Popups;
using BackgroundDownloadTests.ViewModels;
using BackgroundDownloadTests.ViewModels.Popups;

namespace BackgroundDownloadTests
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.RegisterSingleton<IPopupsService>(new RgPopupsService());
            DependencyService.RegisterSingleton<IAsyncBackgroundTaskService>(new AsyncBackgroundTaskService());
            DependencyService.Register<MockDataStore>();

            var popupsService = DependencyService.Get<IPopupsService>();

            popupsService.RegisterPopup<RunningTasksPopupViewModel, RunningTasksPopup>();
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
