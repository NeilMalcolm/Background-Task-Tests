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
        private ObservableCollection<BaseTask> _runningTasks;

        public ObservableCollection<BaseTask> RunningTasks
        {
            get => _runningTasks;
            set
            {
                _runningTasks = value;
                OnPropertyChanged();
            }
        }

        public bool IsRunning => RunningTasks.Any();

        public event PropertyChangedEventHandler PropertyChanged;

        public AsyncBackgroundTaskService()
        {
        }

        public void AddNewTask(BaseTask newTask)
        {
            RunningTasks.Add(newTask);

            // fire and forget.
            Task.Run(async () => {
                await newTask.RunTask();
                RunningTasks.Remove(newTask);
                OnPropertyChanged(nameof(IsRunning));
            });
        }

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
