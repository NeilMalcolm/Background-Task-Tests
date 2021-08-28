using BackgroundDownloadTests.Services;
using System.Windows.Input;
using Xamarin.Forms;

namespace BackgroundDownloadTests.ViewModels.Popups
{
    public class RunningTasksPopupViewModel : BaseViewModel
    {
        private IAsyncBackgroundTaskService _service;
        public IAsyncBackgroundTaskService Service
        {
            get => _service;
            private set => SetProperty(ref _service, value);
        }
        public ICommand ClearFinishedTasksCommand { get; private set; }


        public RunningTasksPopupViewModel()
            : this(DependencyService.Get<IAsyncBackgroundTaskService>())
        {
            ClearFinishedTasksCommand = new Command(ClearFinishedTasks);
        }

        private RunningTasksPopupViewModel(IAsyncBackgroundTaskService asyncBackgroundTaskService)
        {
            _service = asyncBackgroundTaskService;
        }

        private void ClearFinishedTasks()
        {
            _service.ClearFinishedTasks();
        }
    }
}
