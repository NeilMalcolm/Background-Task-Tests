using BackgroundDownloadTests.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace BackgroundDownloadTests.Services
{
    public class RgPopupsService : IPopupsService
    {
        protected Dictionary<Type, Type> Popups {get; private set;}

        public Task PopCurrentPopup()
        {
            return PopupNavigation.Instance.PopAsync();
        }

        public Task PushPopupAsync<T>() where T : BaseViewModel
        {
            var popupPageType = Popups[typeof(T)];
            if (popupPageType is null)
            {
                throw new Exception($"{nameof(T)} is missing from registered popups.");
            }
            var page = GetPageFromViewModel<T>(popupPageType);

            return PopupNavigation.Instance.PushAsync(page, true);
        }

        public void RegisterPopup<T, P>()
            where T : BaseViewModel
            where P : ContentPage
        {
            if (Popups is null)
            {
                Popups = new Dictionary<Type, Type>();
            }

            Popups.Add(typeof(T), typeof(P));
        }

        private PopupPage GetPageFromViewModel<T>(Type popupPageType)
        {
            var viewModel = Activator.CreateInstance<T>();
            var page = (PopupPage)Activator.CreateInstance(popupPageType);
            page.BindingContext = viewModel;

            return page;
        }
    }
}
