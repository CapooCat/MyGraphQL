using HotChocolate;
using HotChocolate.AspNetCore.Authorization;
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
        [Authorize]
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
        [Authorize]
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

        [UseDbContext(typeof(BookShellContext))]
        public string Login (Login model, [ScopedService] BookShellContext db)
        {
            try
            {
                model.password = DataEncryption.EncryptString(model.password);
                var User = db.Users.Single(x => x.Username == model.username && x.Password == model.password);
                if(User != null)
                {
                    return GenerateToken.Execute(model.username, model.password);
                }
                return "Invalid User";
                
            }
            catch
            {
                return "Invalid User";
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

    public class Login
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
