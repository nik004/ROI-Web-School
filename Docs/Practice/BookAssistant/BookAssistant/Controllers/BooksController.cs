using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookAssistant.Bussines.Entities;
using BookAssistant.Bussines.Services;
using BookAssistant.Models;

namespace BookAssistant.Controllers
{
    public class BooksController : Controller
    {
        private BookService _bookService = new BookService();
        
        public ActionResult Index()
        {
            var books = _bookService.GetAll();
            var booksViewModel = new BooksViewModel
            {
                Items = books,
                SelectedBook = books.First()
            };

            return View(booksViewModel);
        }

        public ActionResult GetBook(Book selectedBook)
        {
            var book = _bookService.GetBook(selectedBook.Id);

            return PartialView(book);
        }

        public ActionResult AddBook(Book newBook)
        {
            _bookService.Add(newBook);
            var books = _bookService.GetAll();
            var booksViewModel = new BooksViewModel
            {
                Items = books,
                SelectedBook = books.Last()
            };
            return PartialView("_SelectBook", booksViewModel);
        }
    }
}
