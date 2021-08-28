namespace BackgroundDownloadTests.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ParallelAsyncTask : BaseTask
    {
        private IList<Task<bool>> _tasks;

        private int _taskProgress = 0;
        public int TaskProgress
        {
            get => _taskProgress;
            set
            {
                _taskProgress = value;
                OnPropertyChanged();
            }
        }

        public int TotalTasks => _tasks?.Count ?? 0;

        public ParallelAsyncTask(IList<Task<bool>> tasks)
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
                    success |= await task;
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
