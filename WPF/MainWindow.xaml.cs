using DataBase;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
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
using WPF.Forms;

namespace WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (loginTextBox.Text != "" && passwordTextBox.Text != "")
            {
                try
                {
                    user authorization = DbQuery.Authorization(loginTextBox.Text, passwordTextBox.Text);
                    if (authorization != null)
                    {
                        switch (authorization.role)
                        {
                            case 1:
                                Admin adminWindow = new Admin();
                                Close();
                                adminWindow.Title += $"({authorization.login})";
                                adminWindow.Show();
                                break;
                            case 2:
                                Librarian librarianWindow = new Librarian();
                                Close();
                                librarianWindow.Title += $"({authorization.login})";
                                librarianWindow.Show();
                                break;
                            case 3:
                                Reader readerWindow = new Reader();
                                Close();
                                readerWindow.Title += $"({authorization.login})";
                                readerWindow.Show();
                                break;
                        }

                    }
                    else
                        MessageBox.Show("Такой записи не существует!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Server error!");
                }
            }
            else
                MessageBox.Show("Введите данные!");

        }
    }
}
