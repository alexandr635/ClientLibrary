using System.Windows;
using WPF.Pages;
using Logic;

namespace WPF.Forms
{
    /// <summary>
    /// Interaction logic for Reader.xaml
    /// </summary>
    public partial class ReaderForm : Window
    {
        public ReaderForm()
        {
            InitializeComponent();
        }

        private void ShowLiteratureBtn_Click(object sender, RoutedEventArgs e)
        {
            userFrame.Navigate(new ListLiteraturePage());
            Navigate.mainFrame = userFrame;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Close();
            window.Show();
        }

        private void ReaderForm_Load(object sender, RoutedEventArgs e)
        {
            showLiteratureBtn.Focus();
        }
    }
}
