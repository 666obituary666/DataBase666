using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataBase666
{
    class DataClass
    {
        MySqlBaseConnectionStringBuilder ConnectionString;
        MySqlConnection connection;
        public void CreateConnectionString()
        {
            ConnectionString = new MySqlConnectionStringBuilder();
            ConnectionString.Server = "localhost";
            ConnectionString.UserID = "root";
            ConnectionString.Password = "root";
            ConnectionString.Database = "database_book";

            connection = new MySqlConnection(ConnectionString.ToString());
        }
        public void AddBook (string Title, string Author, string Genre, string DateBook)
        {
            string CommandText = $"INSERT INTO books (Title, Genre, Author, DateCreate) VALUES ('{Title}','{Author}','{Genre}','{DateBook}');";

            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(CommandText, connection);
                cmd.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();
        }
        public List<Book> ReadBook()
        {
            List<Book> books = new List<Book>();
            string cmdtxt = $"SELECT * FROM books;";
            try
            {
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(cmdtxt, connection);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        books.Add(new Book()
                        {
                            idbooks = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Genre = reader.GetString(2),
                            Author = reader.GetString(3),
                            DateCreate = reader.GetInt32(4)
                        });
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            connection.Close();
            return books;
        }
        public void UpdBook(int Id, string newTitle, string newAuthor, string newGenre, int newDate)
        {
            string CommandText = $"UPDATE books SET Title = '{newTitle}', " +
                $"Genre = '{newGenre}', " +
                $"Author = '{newAuthor}', " +
                $"DateCreate = {newDate} WHERE IdBook = {Id};";

            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(CommandText, connection);
                command.ExecuteNonQuery();

            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            connection.Close();
        }
        public void DeleteBook(int Id)
        {
            string CommandText = $"DELETE FROM books WHERE IdBook ={Id};";
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(CommandText, connection);
                command.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            connection.Close();
        }
        public int LoginUser(string Login, string Password)
        
        {
            string CommandText = $"SELECT * FROM user WHERE login = '{Login}' AND password = '{Password}'";
            int codeauth = -1;
            try
            {
                connection.Open();
                MySqlCommand command = new MySqlCommand(CommandText, connection);
                codeauth = Convert.ToInt32(command.ExecuteScalar());
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message);
            }
            connection.Close();
            return codeauth;
        }
    }

}
