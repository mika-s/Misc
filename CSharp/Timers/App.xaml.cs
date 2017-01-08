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
            SystemThreadingTimer timerDependency = new SystemThreadingTimer();
            MainWindow window = new MainWindow(timerDependency);
            window.Show();
        }
    }
}
