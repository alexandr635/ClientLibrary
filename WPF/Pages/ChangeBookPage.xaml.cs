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
    /// Interaction logic for ChangeBookPage.xaml
    /// </summary>
    public partial class ChangeBookPage : Page
    {
        DataBase.Book currentBook = new DataBase.Book();
        public ChangeBookPage(DataBase.Book book)
        {
            InitializeComponent();
            DataContext = book;
            currentBook = book;
            authorCmbBx.ItemsSource = Logic.DbQuery.ListAuthor();
            genreCmbBx.ItemsSource = Logic.DbQuery.ListGenre();
            authorCmbBx.SelectedItem = book.Author.authorName;
            genreCmbBx.SelectedItem = book.Genre1.genreName;
        }

        private bool ValidationFields()
        {
            if (string.IsNullOrWhiteSpace(nameTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(descriptionTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(imagePathTxtBx.Text))
                return false;

            return true;
        }

        private void SaveBtn_Click(object sender, RoutedEventArgs e)
        {
            if (ValidationFields())
            {
                currentBook.idAuthor = authorCmbBx.SelectedIndex + 1;
                currentBook.genre = genreCmbBx.SelectedIndex + 1;
                Exception exception = Logic.DbQuery.ChangeBook(currentBook);
                if (exception == null)
                    MessageBox.Show("Книга изменена");
                else
                    MessageBox.Show(exception.Message, "Fatal error!");
            }
            else
                MessageBox.Show("Заполните все поля!");
        }
    }
}
