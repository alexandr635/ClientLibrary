using System.Windows.Controls;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for BookingListPage.xaml
    /// </summary>
    public partial class BookingListPage : Page
    {
        public BookingListPage()
        {
            InitializeComponent();
            bookingGrid.ItemsSource = Logic.DbQuery.ListBooking(Forms.ReaderForm.session.Reader.id);
        }
    }
}
