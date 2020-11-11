using System.Windows.Controls;
using System.Windows;
using System;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for BookingLiteraturePage.xaml
    /// </summary>
    public partial class BookingLiteraturePage : Page
    {
        public BookingLiteraturePage()
        {
            InitializeComponent();
            literatureGrid.ItemsSource = Logic.DbQuery.ListLiterature();
        }

        private void bookBtn_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            DataBase.Book selectedBook = (DataBase.Book)literatureGrid.SelectedItem;
            if (selectedBook.count > 0)
            {
                Exception exception = Logic.DbQuery.AddBooking(selectedBook.id, Forms.ReaderForm.session.Reader.id);
                if (exception == null)
                    MessageBox.Show("Запрос библиотекарю отправлен. Ожидайте ответа");
                else
                    MessageBox.Show(exception.Message, "Упс... Что-то пошло не так(");

            }
            else
                MessageBox.Show("В данный момент литературы нет!");
        }
    }
}
