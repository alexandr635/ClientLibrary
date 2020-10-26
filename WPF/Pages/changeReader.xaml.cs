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

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for changeReader.xaml
    /// </summary>
    public partial class changeReader : Page
    {
        public DataBase.reader currentUser = new DataBase.reader();
        public changeReader()
        {
            InitializeComponent();
            DataContext = currentUser;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Logic.Navigate.mainFrame.Navigate(new controlReader());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(loginTextBox.Text) && !string.IsNullOrWhiteSpace(passwordTextBox.Text) &&
                !string.IsNullOrWhiteSpace(nameTextBox.Text) && !string.IsNullOrWhiteSpace(surnameTextBox.Text) &&
                !string.IsNullOrWhiteSpace(patronymicTextBox.Text) && !string.IsNullOrWhiteSpace(birthTextBox.Text) &&
                !string.IsNullOrWhiteSpace(phoneTextBox.Text) && !string.IsNullOrWhiteSpace(ratingTextBox.Text))
            {
                try
                {
                    DateTime birth = Convert.ToDateTime(birthTextBox);
                    MessageBox.Show("sdf");
                }
                catch
                {
                    MessageBox.Show("Введите корректную дату!");
                }
            }
            else
                MessageBox.Show("Введите все данные");
        }
    }
}
