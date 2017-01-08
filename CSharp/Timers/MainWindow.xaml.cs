using System.Windows;

namespace Timers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(SystemThreadingTimer timerDependency)
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel(timerDependency);
            this.DataContext = mainViewModel;
        }
    }
}
