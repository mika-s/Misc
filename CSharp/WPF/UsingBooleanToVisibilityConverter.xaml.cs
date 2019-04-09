using System.Windows.Controls;

namespace CSharp
{
    public partial class UsingBooleanToVisibilityConverter : UserControl
    {
        public UsingBooleanToVisibilityConverter()
        {
            InitializeComponent();
            DataContext = this;
        }

        public bool IsTextBlock1Visible { get; } = true;

        public bool IsTextBlock2Visible { get; } = false;
    }
}
