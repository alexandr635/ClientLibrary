using Logic;
using System;
using System.Windows;
using System.Windows.Media.Imaging;
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
            if (loginTextBox.Text != "" && passwordTextBox.Password != "")
            {
                try
                {
                    var authorization = DbQuery.Authorization(loginTextBox.Text, passwordTextBox.Password);
                    if (authorization != null)
                    {
                        switch (authorization.role)
                        {
                            case 1:
                                AdminForm adminWindow = new AdminForm();
                                Close();
                                adminWindow.Title += $"({authorization.login})";
                                adminWindow.Show();
                                break;
                            case 2:
                                LibrarianForm librarianWindow = new LibrarianForm();
                                Close();
                                librarianWindow.Title += $"({authorization.login})";
                                librarianWindow.Show();
                                break;
                            case 3:
                                ReaderForm readerWindow = new ReaderForm();
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

        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            loginTextBox.Focus();
        }
    }
}
