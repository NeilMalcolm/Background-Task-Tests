namespace BackgroundDownloadTests.Models
{
    using System.Threading.Tasks;

    public class AsyncTask : BaseTask
    {
        private Task<bool> _task;

        public AsyncTask(Task<bool> task)
            : base()
        {
            _task = task;
        }

        protected override Task<bool> Run()
        {
            return _task;
        }
    }
}
