using Logic;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for controlLibrarian.xaml
    /// </summary>
    public partial class ControlLibrarianPage : Page
    {
        public ControlLibrarianPage()
        {
            InitializeComponent();
            gridUsers.ItemsSource = DbQuery.ListLibrarians();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Logic.Navigate.mainFrame.Navigate(new Pages.CreateLibrarianPage());
        }

        private void ControlLibrarianPage_Load(object sender, RoutedEventArgs e)
        {
            createButton.Focus();
        }
    }
}
