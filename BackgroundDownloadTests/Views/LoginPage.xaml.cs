namespace BackgroundDownloadTests.Views
{
    using BackgroundDownloadTests.ViewModels;

    public partial class LoginPage : BaseContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }
    }
}
