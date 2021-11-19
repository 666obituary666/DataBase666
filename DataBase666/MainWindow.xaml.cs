using MySql.Data.MySqlClient;
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

namespace DataBase666
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DataClass db = new DataClass();
        int idBook;
        public MainWindow()
        {
            InitializeComponent();
            db.CreateConnectionString();
            dgdbBook.ItemsSource = db.ReadBook();
        }

        private void BtnAddBook_Click(object sender, RoutedEventArgs e)
        {
            db.AddBook(TxtBoxTitleBook.Text, TxtBoxGenreBook.Text, TxtBoxAuthorBook.Text, TxtBoxYearsBook.Text);
            dgdbBook.ItemsSource = db.ReadBook();
        }

        private void BtnSaveBook_Click(object sender, RoutedEventArgs e)
        {
            db.UpdBook(idBook, TxtBoxTitleBook.Text, TxtBoxGenreBook.Text, TxtBoxAuthorBook.Text, Convert.ToInt32(TxtBoxYearsBook.Text));
            dgdbBook.ItemsSource = db.ReadBook();
        }

        private void dgdbBook_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book book = new Book();
            book = dgdbBook.SelectedItem as Book;
            if (book != null)
            {
                TxtBoxTitleBook.Text = book.Title;
                TxtBoxGenreBook.Text = book.Author;
                TxtBoxAuthorBook.Text = book.Genre;
                TxtBoxYearsBook.Text = book.DateCreate.ToString();
                idBook = book.idbooks;
            }
        }

        private void BtnDeleteBook_Click(object sender, RoutedEventArgs e)
        {
            db.DeleteBook(idBook);
            dgdbBook.ItemsSource = db.ReadBook();
        }
    }
}
