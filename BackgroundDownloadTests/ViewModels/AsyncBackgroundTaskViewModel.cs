namespace BackgroundDownloadTests.ViewModels
{
    using BackgroundDownloadTests.Services;
    using BackgroundDownloadTests.ViewModels.Popups;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Threading.Tasks;
    using System.Windows.Input;
    using Xamarin.Forms;

    public class AsyncBackgroundTaskViewModel : INotifyPropertyChanged
    {
        IPopupsService _popupsService;

        private IAsyncBackgroundTaskService _service;
        public IAsyncBackgroundTaskService Service
        {
            get => _service;
            private set => SetProperty(ref _service, value);
        }

        public ICommand ShowDownloadsPopupCommand { get; private set; }

        public AsyncBackgroundTaskViewModel() 
            : this
            (
                  DependencyService.Get<IAsyncBackgroundTaskService>(),
                  DependencyService.Get<IPopupsService>()
            )
        {
            ShowDownloadsPopupCommand = new Command(async () => await ShowDownloadsPopup());
        }

        private AsyncBackgroundTaskViewModel(IAsyncBackgroundTaskService asyncBackgroundTaskService,
            IPopupsService popupsService)
        {
            _service = asyncBackgroundTaskService;
            _popupsService = popupsService;
        }

        private Task ShowDownloadsPopup()
        {
            return _popupsService.PushPopupAsync<RunningTasksPopupViewModel>();
        }
        
        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var changed = PropertyChanged;
            if (changed == null)
                return;

            changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }
        #endregion
    }
}
