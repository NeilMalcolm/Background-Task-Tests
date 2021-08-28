namespace BackgroundDownloadTests.Views
{
    using BackgroundDownloadTests.Models;
    using BackgroundDownloadTests.ViewModels;

    public partial class NewItemPage : BaseContentPage
    {
        public Item Item { get; set; }

        public NewItemPage()
        {
            InitializeComponent();
            BindingContext = new NewItemViewModel();
        }
    }
}
