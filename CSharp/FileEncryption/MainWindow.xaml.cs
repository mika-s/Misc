using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FileEncryption
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            EncryptionService encryption = new EncryptionService();
            HashingService hashing = new HashingService();
            DataContext = new MainViewModel(encryption, hashing);
        }

        /// <summary>
        /// ListView double-click trick found here:
        /// https://social.msdn.microsoft.com/Forums/vstudio/en-US/3d0eaa54-09a9-4c51-8677-8e90577e7bac/
        /// </summary>
        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ((MainViewModel)DataContext).DoubleClickCommand.Execute((string)((ListViewItem)sender).Content);
        }
    }
}
