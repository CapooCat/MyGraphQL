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
        [UseDbContext(typeof(BookShellContext))]
        public bool CreateBook(CreateBookInput model, [ScopedService] BookShellContext db)
        {
            try
            {
                var book = new Book
                {
                    BookName = model.bookName,
                    BookAuthor = model.bookAuthor,
                    Price = model.Price,
                    Img = model.img,
                    AuthenId = model.authen_id
                };
                db.Books.Add(book);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        [UseDbContext(typeof(BookShellContext))]
        public bool DeleteBook(DeleteBookId model, [ScopedService] BookShellContext db)
        {
            try
            {
                var BookToDelete = db.Books.Single(x => x.Id == model.id);
                db.Books.Remove(BookToDelete);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
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
