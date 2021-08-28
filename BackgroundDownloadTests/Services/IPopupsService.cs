using BackgroundDownloadTests.ViewModels;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BackgroundDownloadTests.Services
{
    public interface IPopupsService
    {
        Task PushPopupAsync<T>() where T : BaseViewModel;
        Task PopCurrentPopup();

        void RegisterPopup<T, P>() where T : BaseViewModel
                                   where P : ContentPage;
    }
}
