using System.Collections.ObjectModel;

namespace ViewModelPerTab
{
    public sealed class MainViewModel : ViewModel
    {
        public MainViewModel()
        {
            TabViewModels = new ObservableCollection<object>();
            TabViewModels.Add(new Tab1ViewModel());
            TabViewModels.Add(new Tab2ViewModel());
        }

        public ObservableCollection<object> TabViewModels { get; }
    }
}
