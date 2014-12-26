using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookAssistant.Bussines.Entities;

namespace BookAssistant.Bussines.Services
{
    public class BookService
    {
        private static readonly List<Book> Books = new List<Book>
        {
            new Book
            {
                Id = 1,
                Title = "Рефакторинг. Улучшение существующего кода",
                Author = "Мартин Фаулер, Кент Бек",
                Description = "Мартин Фаулер с соавторами пролили свет на процесс рефакторинга, описав принципы и лучшие приемы его осуществления, а также указав, где и когда следует начинать углубленное изучение кода с целью его улучшения.",
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
            }
        };

        public List<Book> GetAll()
        {
            return Books;
        }

        public Book GetBook(int id)
        {
            return Books.First(b => b.Id == id);
        }

        public void Add(Book newBook)
        {
            Books.Add(new Book
            {
                Id=Books.Max(b=>b.Id)+1,
                Author = newBook.Author,
                Description = newBook.Description,
                Title = newBook.Title,
                Img = "default.jpg"
            });
        }
    }
}