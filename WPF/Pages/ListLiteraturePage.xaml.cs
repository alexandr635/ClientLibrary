using System.Windows.Controls;
using System.IO;

namespace WPF.Pages
{
    /// <summary>
    /// Interaction logic for ListLiterature.xaml
    /// </summary>
    public partial class ListLiteraturePage : Page
    {
        public ListLiteraturePage()
        {
            InitializeComponent();
            var books = Logic.DbQuery.ListLiterature();
            var directoryPath = Path.GetFullPath(@"..\..\..\Resources\img\");

            foreach (var book in books)
                book.image = directoryPath + book.image;
            
            userDataGrid.ItemsSource = books;
        }
    }
}
