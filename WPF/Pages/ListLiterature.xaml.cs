using System.Windows.Controls;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for ListLiterature.xaml
    /// </summary>
    public partial class ListLiterature : Page
    {
        public ListLiterature()
        {
            InitializeComponent();
            var books = Logic.DbQuery.ListLiterature();
            
            foreach (var book in books)
                book.image = @"C:\Users\Aleksandr\source\repos\Library\img\" + book.image;
            
            userDataGrid.ItemsSource = books;
        }
    }
}
