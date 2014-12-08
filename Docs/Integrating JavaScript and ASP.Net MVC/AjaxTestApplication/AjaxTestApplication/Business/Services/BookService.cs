using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using AjaxTestApplication.Business.Entities;
using AjaxTestApplication.Models;

namespace AjaxTestApplication.Business.Services
{
    public class BookService
    {
        private static readonly List<Book> Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Рефакторинг с использованием шаблонов",
                Author = "Джошуа Кериевски",
                Description = "Данная книга представляет собой результат многолетнего опыта профессионального программиста по применению шаблонов проектирования.",
                Img="1.jpg"
            },
            new Book
            {
                Id = 2,
                Title = "Шаблоны тестирования xUnit",
                Author ="Джерард Месарош",
                Description = "В данной книге показано, как применять принципы разработки программного обеспечения, в частности шаблоны проектирования, инкапсуляцию, исключение повторений и описательные имена, к написанию кода тестов.",
                Img="2.jpg"
            },
            new Book
            {
                Id = 3,
                Title = "Рефакторинг баз данных. Эволюционное проектирование",
                Author ="Скотт Амблер, Прамодкумар Дж. Садаладж",
                Description = "В настоящей книге приведены рекомендации, касающиеся того, как использовать методы рефакторинга для усовершенствования баз данных. ",
                Img="3.jpg"
            },
            new Book
            {
                Id = 4,
                Title = "Шаблоны реализации корпоративных приложений",
                Author = "Кент Бек",
                Description = "та новая коллекция шаблонов предназначена для реализации многих аспектов разработки, включая классы, состояние, поведение, методы, коллекции, инфраструктуры и т.д.",
                Img="4.jpg"
            },
        };

        public Book GetBook(int bookId)
        {
            return Books.First(b => b.Id==bookId);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return  Books.ToList();
        }

        public void AddBook(Book newBook)
        {
            Books.Add(new Book
            {
                Id = Books.Max(b=>b.Id)+1,
                Author = newBook.Author,
                Description = newBook.Description,
                Title = newBook.Title,
                Img = "default.jpg"
            });
        }
    }
}