using Logic;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for CreateLibrarian.xaml
    /// </summary>
    public partial class CreateLibrarianPage : Page
    {
        DataBase.User currentUser = new DataBase.User();

        public CreateLibrarianPage()
        {
            InitializeComponent();
        }

        private bool ValidationField()
        {
            if (string.IsNullOrWhiteSpace(loginTextBox.Text))
                return false;
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
                return false;
            if (string.IsNullOrWhiteSpace(confirmTextBox.Text))
                return false;
            return true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationField())
            {
                if (passwordTextBox.Text == confirmTextBox.Text)
                {
                    try
                    {
                        if (lockedCheckBox.IsChecked == true)
                            currentUser.locked = true;
                        else
                            currentUser.locked = false;

                        currentUser.role = 2;
                        currentUser.password = PasswordHelper.GetEncryptedPassword(passwordTextBox.Text);

                        Exception exception = DbQuery.AddLibrarian(currentUser);
                        if (exception == null)
                            MessageBox.Show("Библиотекарь добавлен!");
                        else
                            MessageBox.Show(exception.Message);
                    }
                    catch
                    {
                        MessageBox.Show("Введен неверный формат даты!");
                    }
                }
                else
                    MessageBox.Show("Пароли не совпадают");
            }
            else
                MessageBox.Show("Не все поля заполнены!");
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Logic.Navigate.mainFrame.Navigate(new ControlLibrarianPage());
        }

        private void GeneratePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Text = PasswordHelper.GetGeneratedPassword();
            confirmTextBox.Text = PasswordHelper.GetGeneratedPassword();
        }

        private void CreateLibrarianPage_Load(object sender, RoutedEventArgs e)
        {
            loginTextBox.Focus();
        }
    }
}
