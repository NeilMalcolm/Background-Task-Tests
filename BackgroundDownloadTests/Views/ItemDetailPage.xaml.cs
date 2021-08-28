namespace BackgroundDownloadTests.Views
{
    using BackgroundDownloadTests.ViewModels;

    public partial class ItemDetailPage : BaseContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
