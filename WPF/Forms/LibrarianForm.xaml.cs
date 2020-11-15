using Logic;
using System.Windows;

namespace WPF.Forms
{
    /// <summary>
    /// Interaction logic for Librarian.xaml
    /// </summary>
    public partial class LibrarianForm : Window
    {
        public LibrarianForm()
        {
            InitializeComponent();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Close();
            window.Show();
        }

        private void ShowLiteratureBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Pages.ListLiteraturePage());
            Navigate.mainFrame = mainFrame;
        }

        private void LibrarianForm_Load(object sender, RoutedEventArgs e)
        {
            showLiteratureBtn.Focus();
        }

        private void readerControlBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Pages.ControlReaderPage());
            Navigate.mainFrame = mainFrame;
        }

        private void literatureControlBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Pages.ControlLiteraturePage());
            Navigate.mainFrame = mainFrame;
        }
    }
}
