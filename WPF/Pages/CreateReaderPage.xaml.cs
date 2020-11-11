using Logic;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for createReader.xaml
    /// </summary>
    public partial class CreateReaderPage : Page
    {
        Logic.UserAndReader currentPers = new UserAndReader();

        public CreateReaderPage()
        {
            InitializeComponent();
            DataContext = currentPers;
        }

        private void BackBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.mainFrame.Navigate(new ControlReaderPage());
        }

        /// <summary>
        /// Метод для проверки на заполнение полей окна CreateReaderPage
        /// </summary>
        /// <returns>Возвращает true если все поля заполнены или false если какое-либо поле не заполнено</returns>
        private bool ValidationField()
        {
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
            if (string.IsNullOrWhiteSpace(loginTextBox.Text))
                return false;
            if (string.IsNullOrWhiteSpace(passwordTextBox.Text))
                return false;

            return true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationField())
            {
                try
                {
                    var convert = Convert.ToDateTime(birthTextBox.Text);

                    if (employeeCheckBox.IsChecked == true)
                        currentPers.newReader.employee = true;
                    else
                        currentPers.newReader.employee = false;

                    currentPers.newReader.rating = 0;
                    currentPers.newUser.locked = false;
                    currentPers.newUser.role = 3;

                    currentPers.newUser.password = PasswordHelper.GetEncryptedPassword(passwordTextBox.Text);
                    Exception exception = DbQuery.AddReader(currentPers);
                    if (exception == null)
                        MessageBox.Show("Пользователь добавлен!");
                    else
                        MessageBox.Show(exception.Message);
                }
                catch
                {
                    MessageBox.Show("Введен неверный формат даты!");
                }
                
            }
            else
                MessageBox.Show("Не все поля заполнены!");
        }

        private void GeneratePasswordBtn_Click(object sender, RoutedEventArgs e)
        {
            passwordTextBox.Text = PasswordHelper.GetGeneratedPassword();
        }

        private void CreateReaderPage_Load(object sender, RoutedEventArgs e)
        {
            nameTextBox.Focus();
        }
    }
}
