namespace ViewModelPerTab
{
    public sealed class Tab2ViewModel : ViewModel
    {
        private string textInTab2;

        public Tab2ViewModel()
        {
            TextInTab2 = "Text in tab2";
        }

        public string TextInTab2
        {
            get
            {
                return textInTab2;
            }

            set
            {
                if (textInTab2 != value)
                {
                    textInTab2 = value;
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
