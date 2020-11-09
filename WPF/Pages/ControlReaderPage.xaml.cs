using Logic;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for controlReader.xaml
    /// </summary>
    public partial class ControlReaderPage : Page
    {        
        public ControlReaderPage()
        {
            InitializeComponent();
            gridUsers.ItemsSource = DbQuery.ListReaders();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            Navigate.mainFrame.Navigate(new Pages.CreateReaderPage());
        }

        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            if (gridUsers.SelectedItem != null)
            {
                try
                {
                    Navigate.mainFrame.Navigate(new ChangeReaderPage((DataBase.User)gridUsers.SelectedItem));
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
                var message = MessageBox.Show("Вы действительно хотите удалить данного пользователя?", "Подтверждение", MessageBoxButton.YesNo);
                if (message == MessageBoxResult.Yes)
                {
                    Exception exception = Logic.DbQuery.DeleteReader((DataBase.User)gridUsers.SelectedItem);
                    if (exception == null)
                    {
                        MessageBox.Show("Пользователь удален!");
                        gridUsers.ItemsSource = DbQuery.ListReaders();
                    }
                    else
                        MessageBox.Show(exception.Message);
                }
                else
                    MessageBox.Show("Данные не изменены!");
                
            }
            else
                MessageBox.Show("Сначала выберите запись!");
        }

        private void ControlReaderPage_Load(object sender, RoutedEventArgs e)
        {
            createButton.Focus();
        }
    }
}
