using System.Windows.Controls;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for ControlLiterature.xaml
    /// </summary>
    public partial class ControlLiteraturePage : Page
    {
        public ControlLiteraturePage()
        {
            InitializeComponent();
            userDataGrid.ItemsSource = Logic.DbQuery.ListLiterature();
        }

        private void CreateBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Logic.Navigate.mainFrame.Navigate(new AddBookPage());
        }

        private void ControlLiteraturePage_Load(object sender, System.Windows.RoutedEventArgs e)
        {
            ChangeBtn.Focus();
        }

        private void ChangeBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (userDataGrid.SelectedIndex > -1)
                Logic.Navigate.mainFrame.Navigate(new ChangeBookPage((DataBase.Book)userDataGrid.SelectedItem));
            else
                System.Windows.MessageBox.Show("Сначала выберите книгу!");
        }

        private void DeleteBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (userDataGrid.SelectedIndex > -1)
            {
                DataBase.Book book = (DataBase.Book)userDataGrid.SelectedItem;
                System.Exception result = Logic.DbQuery.DeleteBook(book.id);
                if (result == null)
                {
                    System.Windows.MessageBox.Show("Книга удалена");
                    userDataGrid.ItemsSource = Logic.DbQuery.ListLiterature();
                }
                else
                    System.Windows.MessageBox.Show("Упс... что-то пошло не так", "Fatal error");

            }
            else
                System.Windows.MessageBox.Show("Сначала выберите книгу!");
        }
    }
}
