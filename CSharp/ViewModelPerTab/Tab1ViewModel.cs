namespace ViewModelPerTab
{
    public sealed class Tab1ViewModel : ViewModel
    {
        private string textInTab1;

        public Tab1ViewModel()
        {
            TextInTab1 = "Text in tab1";
        }

        public string TextInTab1
        {
            get
            {
                return textInTab1;
            }

            set
            {
                if (textInTab1 != value)
                {
                    textInTab1 = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
