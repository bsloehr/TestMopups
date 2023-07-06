using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestMopups
{
    internal class MyPopupPageViewModel : INotifyPropertyChanged
    {
        private string _selectedItem;
        private bool _isTwo;
        private bool _isThree;

        public event EventHandler VisibilityChanged;
        public event PropertyChangedEventHandler PropertyChanged;

        public MyPopupPageViewModel()
        {
            PickerItems = new List<string>(new[] { "One", "Two", "Three" });
            SelectedItem = PickerItems[0];

            PropertyChanged += MyPopupPageViewModel_PropertyChanged;
        }

        private void MyPopupPageViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
#if IOS
            if (e.PropertyName is nameof(IsTwo) or nameof(IsThree))
                VisibilityChanged?.Invoke(this, EventArgs.Empty);
#endif
        }

        public IList<string> PickerItems { get; }

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetField(ref _selectedItem, value);
                IsTwo = value == PickerItems[1];
                IsThree = value == PickerItems[2];
            }
        }

        public bool IsTwo
        {
            get => _isTwo;
            set => SetField(ref _isTwo, value);
        }

        public bool IsThree
        {
            get => _isThree;
            set => SetField(ref _isThree, value);
        }


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
