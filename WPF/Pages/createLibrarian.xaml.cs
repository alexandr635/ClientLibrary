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
    /// Interaction logic for createLibrarian.xaml
    /// </summary>
    public partial class createLibrarian : Page
    {
        DataBase.user currentLibrarian = new DataBase.user();
        public createLibrarian()
        {
            InitializeComponent();
            DataContext = currentLibrarian;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Logic.Navigate.mainFrame.Navigate(new controlLibrarian());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(loginTextBox.Text) && !string.IsNullOrWhiteSpace(passwordTextBox.Text))
            {
                if (lockedCheckBox.IsChecked == true)
                    currentLibrarian.locked = true;
                else
                    currentLibrarian.locked = false;

                currentLibrarian.role = 2;

                Logic.DbQuery.addLibrarian(currentLibrarian);
            }
            else
            {
                MessageBox.Show("Заполните поля!");
            }
        }
    }
}
