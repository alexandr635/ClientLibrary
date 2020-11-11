using Logic;
using System;
using System.Windows;
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

        /// <summary>
        /// Метод для авторизации пользователя 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
                                ReaderForm readerWindow = new ReaderForm(authorization);
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

        /// <summary>
        /// Метод для выполнения задач при загрузке окна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            loginTextBox.Focus();
        }
    }
}
