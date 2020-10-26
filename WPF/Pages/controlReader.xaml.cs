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

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for controlReader.xaml
    /// </summary>
    public partial class controlReader : Page
    {        
        public controlReader()
        {
            InitializeComponent();
            gridUsers.ItemsSource = DbQuery.listReaders();
        }

        private void createButton_Click(object sender, RoutedEventArgs e)
        {
            Navigate.mainFrame.Navigate(new Pages.createReader());
        }

        private void changeButton_Click(object sender, RoutedEventArgs e)
        {
            if (gridUsers.SelectedItem != null)
            {
                changeReader change = new changeReader();
                //change.currentUser = DbQuery.listReaders().Where(p => p.id_reader = index);

                Navigate.mainFrame.Navigate(new changeReader());
            }
            else
                MessageBox.Show("Сначала выберите запись!");
        }
    }
}
