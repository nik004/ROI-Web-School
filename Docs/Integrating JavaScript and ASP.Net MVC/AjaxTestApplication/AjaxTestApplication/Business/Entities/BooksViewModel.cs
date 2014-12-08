using System.Collections.Generic;

namespace AjaxTestApplication.Business.Entities
{
    public class BooksViewModel
    {
        public IEnumerable<Book> Items { set; get; }
        public Book SelectedBook { set; get; }
    }
}