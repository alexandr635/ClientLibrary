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
        public static DataBase.User session;
        public ReaderForm(DataBase.User user)
        {
            InitializeComponent();
            session = user;
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

        private void bookBtn_Click(object sender, RoutedEventArgs e)
        {
            userFrame.Navigate(new BookingLiteraturePage());
            Navigate.mainFrame = userFrame;
        }

        private void bookStoryBtn_Click(object sender, RoutedEventArgs e)
        {
            userFrame.Navigate(new BookingListPage());
            Navigate.mainFrame = userFrame;
        }
    }
}
