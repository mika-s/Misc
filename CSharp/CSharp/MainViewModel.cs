namespace CSharp
{
    public sealed class MainViewModel : ViewModel
    {
        private MyEnum testEnumToImage;
        private bool boolToImageTrue;
        private bool boolToImageFalse;

        public MainViewModel()
        {
            TestEnumToImage = MyEnum.test1;
            BoolToImageTrue = true;
            BoolToImageFalse = false;
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
        
        public bool BoolToImageTrue
        {
            get
            {
                return boolToImageTrue;
            }
            set
            {
                if (boolToImageTrue != value)
                {
                    boolToImageTrue = value;
                    NotifyPropertyChanged();
                }
            }
        }

        public bool BoolToImageFalse
        {
            get
            {
                return boolToImageFalse;
            }
            set
            {
                if (boolToImageFalse != value)
                {
                    boolToImageFalse = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
