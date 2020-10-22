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
    /// Interaction logic for LIteratureControl.xaml
    /// </summary>
    public partial class LIteratureControl : Window
    {
        public LIteratureControl()
        {
            InitializeComponent();
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Librarian window = new Librarian();
            Close();
            window.Show();
        }
    }
}
