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
    /// Interaction logic for ReaderControl.xaml
    /// </summary>
    public partial class UserControl : Window
    {
        public UserControl()
        {
            InitializeComponent();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            Admin window = new Admin();
            Close();
            window.Show();
        }
    }
}
