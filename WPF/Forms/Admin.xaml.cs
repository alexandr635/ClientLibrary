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
using System.Windows.Shapes;

namespace WPF.Forms
{
    /// <summary>
    /// Interaction logic for Admin.xaml
    /// </summary>
    public partial class Admin : Window
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            Close();
            window.Show();
        }

        private void librarianControlButton_Click(object sender, RoutedEventArgs e)
        {
            UserControl window = new UserControl();
            Close();
            window.Show();
            DbQuery query = new DbQuery();
            window.gridUsers.ItemsSource = query.listLibrarians();
        }

        private void unloadDataButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void readerControlButton_Click(object sender, RoutedEventArgs e)
        {
            UserControl window = new UserControl();
            Close();
            window.Show();
            DbQuery query = new DbQuery();
            //window.gridUsers.ItemsSource = query.listReaders();
            //foreach(var q in query.listReaders())
            //    MessageBox.Show(q.users.Contains.)
        }
    }
}
