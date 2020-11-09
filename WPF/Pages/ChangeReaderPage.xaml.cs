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
        DataBase.User currentUser;
        public ChangeReaderPage(DataBase.User currentUser)
        {
            InitializeComponent();
            DataContext = currentUser;
            this.currentUser = currentUser;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Logic.Navigate.mainFrame.Navigate(new ControlReaderPage());
        }

        private bool ValidationFields()
        {
            if (string.IsNullOrWhiteSpace(loginTextBox.Text))
                return false;
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
                return false;
            if (string.IsNullOrWhiteSpace(nameTextBox.Text))
                return false;
            if (string.IsNullOrWhiteSpace(surnameTextBox.Text))
                return false;
            if (string.IsNullOrWhiteSpace(patronymicTextBox.Text))
                return false;
            if (string.IsNullOrWhiteSpace(birthTextBox.Text))
                return false;
            if (string.IsNullOrWhiteSpace(phoneTextBox.Text))
                return false;
            if (string.IsNullOrWhiteSpace(ratingTextBox.Text))
                return false;
            return true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationFields())
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
