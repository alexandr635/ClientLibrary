using Logic;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Security.Cryptography;
using System.Text;

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
            Navigate.mainFrame.Navigate(new Pages.ControlReaderPage());
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (nameTextBox.Text != "" && surnameTextBox.Text != "" && patronymicTextBox.Text != "" &&
                birthTextBox.Text != "" && phoneTextBox.Text != "" && loginTextBox.Text != "" && passwordTextBox.Text != "")
            {
                try
                {
                    if (employeeCheckBox.IsChecked == true)
                        currentPers.newReader.employee = true;
                    else
                        currentPers.newReader.employee = false;

                    currentPers.newReader.rating = 0;
                    currentPers.newUser.locked = false;
                    currentPers.newUser.role = 3;

                    MD5 md5 = MD5.Create();
                    var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(passwordTextBox.Text));
                    passwordTextBox.Text = Convert.ToBase64String(hash);
                    currentPers.newUser.password = Convert.ToBase64String(hash);

                    DbQuery.AddReader(currentPers);
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
            passwordTextBox.Text = Logic.PasswordGeneration.returnNewPassword();
        }

        private void CreateReaderPage_Load(object sender, RoutedEventArgs e)
        {
            nameTextBox.Focus();
        }
    }
}
