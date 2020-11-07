using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for changeReader.xaml
    /// </summary>
    public partial class ChangeReaderPage : Page
    {
        DataBase.user currentUser;
        public ChangeReaderPage(DataBase.user currentUser)
        {
            InitializeComponent();
            DataContext = currentUser;
            this.currentUser = currentUser;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Logic.Navigate.mainFrame.Navigate(new ControlReaderPage());
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(loginTextBox.Text) && !string.IsNullOrWhiteSpace(passwordTextBox.Text) &&
                !string.IsNullOrWhiteSpace(nameTextBox.Text) && !string.IsNullOrWhiteSpace(surnameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(patronymicTextBox.Text) && !string.IsNullOrWhiteSpace(birthTextBox.Text) &&
                !string.IsNullOrWhiteSpace(phoneTextBox.Text) && !string.IsNullOrWhiteSpace(ratingTextBox.Text))
            {
                try
                {
                    Logic.DbQuery.ChangeReader(currentUser);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
                MessageBox.Show("Введите все данные");
        }

        private void ChangeReaderPage_Load(object sender, RoutedEventArgs e)
        {
            loginTextBox.Focus();
        }
    }
}
