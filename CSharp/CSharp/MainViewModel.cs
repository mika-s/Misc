namespace CSharp
{
    public sealed class MainViewModel : ViewModel
    {
        private MyEnum testEnumToImage;

        public MainViewModel()
        {
            TestEnumToImage = MyEnum.test1;
        }

        public MyEnum TestEnumToImage
        {
            get
            {
                return testEnumToImage;
            }
            set
            {
                if (testEnumToImage != value)
                {
                    testEnumToImage = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
