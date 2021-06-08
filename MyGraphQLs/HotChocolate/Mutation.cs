using HotChocolate;
using HotChocolate.Data;
using MyGraphQLs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGraphQLs.HotChocolate
{
    public class Mutation
    {
        private BookShellContext db;

        public Mutation([ScopedService] BookShellContext _db)
        {
            db = _db;
        }

        [UseDbContext(typeof(BookShellContext))]
        public bool CreateBook(CreateBookInput model)
        {
            Book book = new Book();
            book.BookName = model.bookName;
            book.BookAuthor = model.bookAuthor;
            book.Price = model.Price;
            book.Img = model.img;
            book.AuthenId = 1;
            db.Books.Add(book);
            return true;
        }

        [UseDbContext(typeof(BookShellContext))]
        public bool DeleteBook(DeleteBookId model)
        {
            var BookToDelete = db.Books.Single(x => x.Id == model.id);
            db.Books.Remove(BookToDelete);
            return true;
        }
    }
    public class CreateBookInput
    {
        public string bookName { get; set; }
        public string bookAuthor { get; set; }
        public double? Price { get; set; }
        public int authen_id { get; set; }

        public string img { get; set; }
    }

    public class DeleteBookId
    {
        public int id { get; set; }
    }
}
