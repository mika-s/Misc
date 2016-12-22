namespace ScaffoldBasicApplication
{
    public sealed class MainViewModel : ViewModel
    {
        private string testProperty;

        public MainViewModel()
        {
            TestCommand = new DelegateCommand<string>(TestExecute);
        }

        public DelegateCommand<string> TestCommand { get; private set; }

        public string TestProperty
        {
            get
            {
                return testProperty;
            }
            set
            {
                if (testProperty != value)
                {
                    testProperty = value;
                    NotifyPropertyChanged();
                }
            }
        }

        private void TestExecute(string parameter)
        {
            TestProperty = "Test";
        }
    }
}
