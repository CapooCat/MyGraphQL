using HotChocolate;
using HotChocolate.Data;
using MyGraphQLs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGraphQL.GraphQL
{
    public class Query
    {
        
        [UseDbContext(typeof(BookShellContext))]
        [UseProjection]
        [UseFiltering]
        public IQueryable<Book> GetBooks(
             [ScopedService] BookShellContext db)
             => db.Books;

        
        [UseDbContext(typeof(BookShellContext))]
        [UseProjection]
        [UseFiltering]
        public IQueryable<User> GetUsers(
             [ScopedService] BookShellContext db)
             => db.Users;
    }
}
