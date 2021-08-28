namespace BackgroundDownloadTests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ParallelAsyncTask : BaseTask
    {
        private IList<TaskRunner> _tasks;

        private int _taskProgress = 0;
        public int TaskProgress
        {
            get => _taskProgress;
            set
            {
                _taskProgress = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(TaskProgressAsFloat));
            }
        }
        
        public float TaskProgressAsFloat
        {
            get => _taskProgress == 0 ? 0 : (float)_taskProgress / (float)TotalTasks;
        }

        public int TotalTasks => _tasks?.Count ?? 0;

        public ParallelAsyncTask(string text, params TaskRunner[] tasks)
            : base(text)
        {
            _tasks = tasks;
        }

        protected override async Task<bool> Run()
        {
            bool success = false;
            if (_tasks is null || !_tasks.Any())
            {
                return success;
            }

            try
            {
                IsRunning = true;
                foreach (var task in _tasks)
                {
                    success |= await task.Invoke();
                    TaskProgress++;
                }
            }
            catch (Exception ex)
            {
                // log
                success = false;
            }
            finally
            {
                IsRunning = false;
            }

            return success;
        }
    }
}
