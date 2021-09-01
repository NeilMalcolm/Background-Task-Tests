using BackgroundDownloadTests.Models;
using BackgroundDownloadTests.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static BackgroundDownloadTests.Models.BaseTask;

namespace BackgroundDownloadTests.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        private readonly IAsyncBackgroundTaskService _backgroundTaskService;
        public AboutViewModel() : this(DependencyService.Get<IAsyncBackgroundTaskService>())
        {
            Title = "About";
            StartDownloadCommand = new Command(BeginDownload);
            StartParallelDownloadCommand = new Command(BeginParallelDownload);
            GoToCarouselCommand = new Command(async () => await GoToCarousel());
        }

        private AboutViewModel(IAsyncBackgroundTaskService backgroundTaskService)
        {
            _backgroundTaskService = backgroundTaskService;
        }

        public ICommand StartDownloadCommand { get; }
        public ICommand StartParallelDownloadCommand { get; }
        public ICommand GoToCarouselCommand { get; }

        public void BeginDownload()
        {
            var newTask = new AsyncTask("Download", DoThing);
            _backgroundTaskService.AddNewTask(newTask);
        }
        
        public void BeginParallelDownload()
        {
            var newTask = new ParallelAsyncTask("Parallel Download", 
                DoParallelThing, 
                DoParallelThing, 
                DoParallelThing,
                DoParallelThing,
                DoParallelThing,
                DoParallelThing,
                DoParallelThing,
                DoParallelThing,
                DoParallelThing
            );
            _backgroundTaskService.AddNewTask(newTask);
        }

        public async Task<bool> DoThing()
        {
            await Task.Delay(2500);
            return true;
        }

        public async Task<bool> DoParallelThing()
        {
            await Task.Delay(1500);
            return true;
        }

        private Task GoToCarousel()
        {
            return Application.Current.MainPage.Navigation.PushAsync(new NavigationPage(new ContentPage
            {
                Content = new CarouselView
                {
                    ItemsSource = new string[] { "hello", "hello 2", "hello 3" },
                    IndicatorView = new IndicatorView
                    {
                        BackgroundColor = Color.Red,
                        HeightRequest = 30,
                        WidthRequest = 30
                    }
                }
            }));
        }
    }
}
