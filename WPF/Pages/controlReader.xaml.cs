using Logic;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for controlReader.xaml
    /// </summary>
    public partial class ControlReader : Page
    {        
        public ControlReader()
        {
            InitializeComponent();
            gridUsers.ItemsSource = DbQuery.ListReaders();
            createButton.Focus();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Navigate.mainFrame.Navigate(new Pages.CreateReader());
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (gridUsers.SelectedItem != null)
            {
                try
                {
                    Navigate.mainFrame.Navigate(new changeReader((DataBase.user)gridUsers.SelectedItem));
                }
                catch
                {
                    MessageBox.Show("Другую запись!");
                }
            }
            else
                MessageBox.Show("Сначала выберите запись!");
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (gridUsers.SelectedItem != null)
            {
                MessageBox.Show("Вы действительно хотите удалить данного пользователя?", "Подтверждение", MessageBoxButton.YesNo);
                try
                {
                    Logic.DbQuery.DeleteReader((DataBase.user)gridUsers.SelectedItem);
                    gridUsers.ItemsSource = DbQuery.ListReaders();
                }
                catch
                {
                    MessageBox.Show("Другую запись!");
                }
            }
            else
                MessageBox.Show("Сначала выберите запись!");
        }
    }
}
