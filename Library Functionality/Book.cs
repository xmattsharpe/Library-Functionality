using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Functionality
{
    public class Book
    {
       
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public double BookRating { get; set; }
        public string BackType { get; set; }
        
        public Book()
        {

        }
        public Book(string bookname, string bookauthor, double bookrating, string backtype)
        {
            this.BookName = bookname;
            this.BookAuthor = bookauthor;
            this.BookRating = bookrating;
            this.BackType = backtype;
        }
    }
}
