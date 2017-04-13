using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_BindingToSQL
{
    public class Book
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }

        public Book()
        {

        }
        public Book(string title, string descrip, string author)
        {
            Title = title;
            Description = descrip;
            Author = author;
        }
    }
}
