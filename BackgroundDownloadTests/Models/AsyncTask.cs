namespace BackgroundDownloadTests.Models
{
    using System.Threading.Tasks;

    public class AsyncTask : BaseTask
    {
        private TaskRunner _task;

        public AsyncTask(string text, TaskRunner task)
            : base(text)
        {
            _task = task;
        }

        protected override Task<bool> Run()
        {
            return _task.Invoke();
        }
    }
}
