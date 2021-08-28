namespace BackgroundDownloadTests.Models
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;

    public abstract class BaseTask : INotifyPropertyChanged
    {
        public Guid Id { get; private set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private bool _isRunning;
        public bool IsRunning
        {
            get => _isRunning;
            set
            {
                _isRunning = value;
                OnPropertyChanged();
            }
        }

        public BaseTask()
        {
            Id = Guid.NewGuid();
        }

        public async Task<bool> RunTask()
        {
            bool success = false;
            try
            {
                IsRunning = true;
                success = await Run(); 
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
        
        protected abstract Task<bool> Run();

        protected void OnPropertyChanged([CallerMemberName]string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
