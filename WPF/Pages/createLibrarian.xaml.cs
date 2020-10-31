using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for CreateLibrarian.xaml
    /// </summary>
    public partial class CreateLibrarian : Page
    {
        DataBase.user currentUser = new DataBase.user();

        public CreateLibrarian()
        {
            InitializeComponent();
            loginTextBox.Focus();
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(loginTextBox.Text) && !string.IsNullOrWhiteSpace(passwordTextBox.Text) && 
                !string.IsNullOrWhiteSpace(confirmTextBox.Text))
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

                        MD5 md5 = MD5.Create();
                        var hash = md5.ComputeHash(Encoding.UTF8.GetBytes(passwordTextBox.Text));
                        passwordTextBox.Text = Convert.ToBase64String(hash);
                        currentUser.password = Convert.ToBase64String(hash);

                        DbQuery.AddLibrarian(currentUser);
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
            Logic.Navigate.mainFrame.Navigate(new Pages.ControlLibrarian());
        }
    }
}
