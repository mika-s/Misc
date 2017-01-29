using System.Windows;

namespace Timers
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(SystemThreadingTimer timerDependency, SystemTimersTimer systemTimersTimerDependency, 
            SystemWindowsFormsTimer systemWindowsFormsTimerDependency)
        {
            InitializeComponent();
            MainViewModel mainViewModel = new MainViewModel(timerDependency, systemTimersTimerDependency, systemWindowsFormsTimerDependency);
            DataContext = mainViewModel;
        }
    }
}
