using System.Collections.Generic;
using BookAssistant.Bussines.Entities;

namespace BookAssistant.Models
{
    public class BooksViewModel
    {
        public List<Book> Items { set; get; }
        public Book SelectedBook { set; get; }
    }
}