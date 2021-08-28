using System.Collections.ObjectModel;
using BackgroundDownloadTests.Models;

namespace BackgroundDownloadTests.Services
{
    public interface IAsyncBackgroundTaskService
    {
        ObservableCollection<BaseTask> RunningTasks { get; }
        bool IsRunning { get; }
        void AddNewTask(BaseTask newTask);
        void ClearFinishedTasks();
    }
}