using System.Windows;

namespace Timers
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            SystemThreadingTimer systemThreadingTimerDependency = new SystemThreadingTimer();
            SystemTimersTimer systemTimersTimerDependency = new SystemTimersTimer();
            MainWindow window = new MainWindow(systemThreadingTimerDependency, systemTimersTimerDependency);
            window.Show();
        }
    }
}
