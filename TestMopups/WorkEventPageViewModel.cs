using System.Collections.ObjectModel;
using System.ComponentModel;

namespace TestMopups
{
    internal class WorkEventPageViewModel : ViewModelBase
    {
        public event EventHandler VisibilityChanged;

        public WorkEventPageViewModel()
        {
            PopulateList();

            PropertyChanged += MyPopupPageViewModel_PropertyChanged;
        }

        private void PopulateList()
        {
            ListItems.Add(new WorkEventViewModel());
            ListItems.Add(new WorkEventViewModel());
            ListItems.Add(new WorkEventViewModel());
            ListItems.Add(new WorkEventViewModel());
        }

        private void MyPopupPageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
#if IOS
            //if (e.PropertyName is nameof(IsTwo) or nameof(IsThree))
            //    VisibilityChanged?.Invoke(this, EventArgs.Empty);
#endif
        }

        public ObservableCollection<WorkEventViewModel> ListItems { get; } = new();
    }
}
