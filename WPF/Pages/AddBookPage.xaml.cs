using System.Windows.Controls;
using System.Windows;
using System;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for AddBookPage.xaml
    /// </summary>
    public partial class AddBookPage : Page
    {
        private static DataBase.Book book = new DataBase.Book();
        public AddBookPage()
        {
            InitializeComponent();
            genreCmbBx.ItemsSource = Logic.DbQuery.ListGenre();
            authorCmbBx.ItemsSource = Logic.DbQuery.ListAuthor();
            DataContext = book;
        }

        private void AddBookPage_Load(object sender, System.Windows.RoutedEventArgs e)
        {
            nameTxtBx.Focus();
        }

        private bool ValidationFields()
        {
            if (string.IsNullOrWhiteSpace(nameTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(descriptionTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(imagePathTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(countTxtBx.Text))
                return false;
            if (string.IsNullOrWhiteSpace(penaltyPointsTxtBx.Text))
                return false;

            return true;
        }

        private void SaveBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (ValidationFields())
            {
                book.genre = genreCmbBx.SelectedIndex + 1;
                book.idAuthor = authorCmbBx.SelectedIndex + 1;
                book.datePublic = DateTime.Now;

                try
                {
                    int count = Convert.ToInt32(countTxtBx.Text);
                    var exception = Logic.DbQuery.AddBook(book);
                    if (exception == null)
                        MessageBox.Show("Книга добавлена!");
                    else
                        MessageBox.Show(exception.Message, "Fatal error!");
                }
                catch
                {
                    MessageBox.Show("Введите числовое значение!");
                }

            }
            else
                MessageBox.Show("Заполните все поля!");
        }
    }
}
