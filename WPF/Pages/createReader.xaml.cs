
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
    /// Interaction logic for createReader.xaml
    /// </summary>
    public partial class createReader : Page
    {
        DataBase.reader currentReader = new DataBase.reader();

        public createReader()
        {
            InitializeComponent();
            DataContext = currentReader;
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            Navigate.mainFrame.Navigate(new Pages.controlReader());
        }

        private void saveBtn_Click(object sender, RoutedEventArgs e)
        {
            //LibraryEntities db = new LibraryEntities();
            if (nameTextBox.Text != "" && surnameTextBox.Text != "" && patronymicTextBox.Text != "" &&
                birthTextBox.Text != "" && phoneTextBox.Text != "" && loginTextBox.Text != "" && passwordTextBox.Text != "")
            {
                DateTime birth;
                try
                {
                    birth = Convert.ToDateTime(birthTextBox.Text);
                    if (employeeCheckBox.IsChecked == true)
                        currentReader.employee = true;
                    else
                        currentReader.employee = false;
                    currentReader.rating = 0;
                    DbQuery.addReader(currentReader);
                }
                catch
                {
                    MessageBox.Show("Введен неверный формат даты!");
                }
            }
            else
                MessageBox.Show("Не все поля заполнены!");
        }
    }
}
