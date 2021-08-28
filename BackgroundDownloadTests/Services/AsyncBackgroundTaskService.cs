using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using BackgroundDownloadTests.Models;

namespace BackgroundDownloadTests.Services
{
    public class AsyncBackgroundTaskService : IAsyncBackgroundTaskService, INotifyPropertyChanged
    {
        private ObservableCollection<BaseTask> _runningTasks = new ObservableCollection<BaseTask>();

        public ObservableCollection<BaseTask> RunningTasks
        {
            get => _runningTasks;
            set
            {
                _runningTasks = value;
                OnPropertyChanged();
            }
        }

        public bool IsRunning => RunningTasks?.Any(x => x.IsRunning) ?? false;

        public event PropertyChangedEventHandler PropertyChanged;

        public AsyncBackgroundTaskService()
        {
        }

        public void AddNewTask(BaseTask newTask)
        {
            RunningTasks.Add(newTask);
            // fire and forget.
            Task.Run(async () => {
                newTask.IsRunning = true;
                OnPropertyChanged(nameof(IsRunning));
                await newTask.RunTask();
                OnPropertyChanged(nameof(IsRunning));
            });
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void ClearFinishedTasks()
        {
            var tasks = RunningTasks.Where(x => !x.IsRunning).ToList();
            foreach (var finishedTask in tasks)
            {
                RunningTasks.Remove(finishedTask);
            }
        }
    }
}
