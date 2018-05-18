using System.Windows;

namespace Web
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RestTestService restTest = new RestTestService();
            DataContext = new MainViewModel(restTest);
        }
    }
}
