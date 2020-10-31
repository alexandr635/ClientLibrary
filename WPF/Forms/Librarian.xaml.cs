using Logic;
using System.Windows;

namespace WPF.Forms
{
    /// <summary>
    /// Interaction logic for Librarian.xaml
    /// </summary>
    public partial class Librarian : Window
    {
        public Librarian()
        {
            InitializeComponent();
            showLiteratureBtn.Focus();
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Close();
            window.Show();
        }

        private void ShowLiteratureBtn_Click(object sender, RoutedEventArgs e)
        {
            mainFrame.Navigate(new Pages.ListLiterature());
            Navigate.mainFrame = mainFrame;
        }
    }
}
