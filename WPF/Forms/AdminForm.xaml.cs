using Logic;
using System.Windows;

namespace WPF.Forms
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class AdminForm : Window
    {
        public AdminForm()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Close();
            window.Show();
        }

        private void LibrarianControlButton_Click(object sender, RoutedEventArgs e)
        {
            adminFrame.Navigate(new Pages.ControlLibrarianPage());
            Navigate.mainFrame = adminFrame;
        }

        private void UnloadDataButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ReaderControlButton_Click(object sender, RoutedEventArgs e)
        {
            adminFrame.Navigate(new Pages.ControlReaderPage());
            Navigate.mainFrame = adminFrame;
        }

        private void AdminForm_Load(object sender, RoutedEventArgs e)
        {
            readerControlButton.Focus();
        }
    }
}
