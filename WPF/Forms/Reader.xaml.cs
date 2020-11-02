using System.Windows;
using WPF.Pages;
using Logic;

namespace WPF.Forms
{
    /// <summary>
    /// Interaction logic for Reader.xaml
    /// </summary>
    public partial class Reader : Window
    {
        public Reader()
        {
            InitializeComponent();
            showLiteratureBtn.Focus();
        }

        private void ShowLiteratureBtn_Click(object sender, RoutedEventArgs e)
        {
            userFrame.Navigate(new ListLiterature());
            Navigate.mainFrame = userFrame;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Close();
            window.Show();
        }
    }
}
