namespace BackgroundDownloadTests.Views
{
    using System.Linq;
    using BackgroundDownloadTests.Services;
    using BackgroundDownloadTests.Views.AsyncToolbar;
    using Xamarin.Forms;

    public class BaseContentPage : ContentPage
    {
        private IAsyncBackgroundTaskService _backgroundTaskService;

        public BaseContentPage() : this (DependencyService.Get<IAsyncBackgroundTaskService>())
        {
        }

        private BaseContentPage(IAsyncBackgroundTaskService backgroundTaskService)
        {
            _backgroundTaskService = backgroundTaskService;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_backgroundTaskService is null)
            {
                return;
            }

            if (_backgroundTaskService.IsRunning)
            {
                ToolbarItems.Add(new AsyncToolbarItem());
            }
            else if(ToolbarItems.FirstOrDefault(x => x.Text == "Async") is AsyncToolbarItem toolbarItem)
            {
                ToolbarItems.Remove(toolbarItem);
            }
        }
    }
}
