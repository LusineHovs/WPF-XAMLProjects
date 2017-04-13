using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BindingToSQL
{
    class StoreDB
    {
        public Book GetBook(int bookID)
        {
            Book book = null;
            SqlDataReader reader = null;
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                SqlCommand command = new SqlCommand("select * from Books where ID=@id", connection);
                command.Parameters.AddWithValue("id", bookID);
                connection.Open();

                try
                {
                    reader = command.ExecuteReader();
                    reader.Read();
                    book = new Book()
                    {
                        Title = reader[1].ToString(),
                        Description = reader[2].ToString(),
                        Author = reader[3].ToString()
                    };
                }
                catch (Exception e)
                {
                    if (reader!=null)
                    {
                        reader.Close();
                    }
                    throw e ;
                }
            }
            return book;
        }

        public void UpdateBook(Book book, int bookID)
        {
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                SqlCommand command = new SqlCommand("Update Books SET Title = @title, Description = @description, Author = @author", connection);
                command.Parameters.AddWithValue("title", book.Title);
                command.Parameters.AddWithValue("description", book.Description);
                command.Parameters.AddWithValue("author", book.Author);
                command.Parameters.AddWithValue("ID", bookID);
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
        }

        public List<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            SqlDataReader reader = null;
            using (SqlConnection connection = new SqlConnection(Properties.Settings.Default.ConnectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("select * from Books", connection);
                try
                {
                    reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Book book = new Book()
                        {
                            Title = reader[1].ToString(),
                            Description = reader[2].ToString(),
                            Author = reader[3].ToString()
                        };
                        books.Add(book);
                    }
                }
                catch (Exception exc)
                {
                    reader.Close();
                    throw exc;
                }
                connection.Close();
            }
            return books;
        }
    }
}
