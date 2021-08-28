using BackgroundDownloadTests.Models;
using BackgroundDownloadTests.Views.Popups.Cells;
using System;
using Xamarin.Forms;

namespace BackgroundDownloadTests.Helpers
{
    public class TasksDataTemplateSelector : DataTemplateSelector
    {
        protected DataTemplate AsyncTemplate = new DataTemplate(typeof(AsyncTaskViewCell));
        protected DataTemplate ParallelAsyncTemplate = new DataTemplate(typeof(ParallelAsyncTaskViewCell));

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is AsyncTask asyncTask)
            {
                return AsyncTemplate;
            }
            else if (item is ParallelAsyncTask parallelAsyncTask)
            {
                return ParallelAsyncTemplate;
            }

            return null;
        }
    }
}
