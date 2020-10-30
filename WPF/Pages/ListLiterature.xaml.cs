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
using System.IO;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for ListLiterature.xaml
    /// </summary>
    public partial class ListLiterature : Page
    {
        //DataBase.book books = new DataBase.book();
        public ListLiterature()
        {
            InitializeComponent();
            userDataGrid.ItemsSource = Logic.DbQuery.ListLiterature();
            img.Source = new BitmapImage(new Uri(@"C:\Users\Aleksandr\source\repos\Library\img\daughter.jpg"));
        }
    }
}
