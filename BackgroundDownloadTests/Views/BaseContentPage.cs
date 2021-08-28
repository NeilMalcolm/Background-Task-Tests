namespace BackgroundDownloadTests.Views
{
    using Xamarin.Forms;

    public class BaseContentPage : ContentPage
    {
        public BaseContentPage()
        {
            Shell.SetTitleView(this, new DefaultTitleView());
        }
    }
}
