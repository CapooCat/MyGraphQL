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
        [UseFiltering]
        [UseDbContext(typeof(BookShellContext))]
        public IQueryable<Book> GetBooks(
             [ScopedService] BookShellContext dbContext)
             => dbContext.Books;

        [UseFiltering]
        [UseDbContext(typeof(BookShellContext))]
        public IQueryable<User> GetUsers(
             [ScopedService] BookShellContext dbContext)
             => dbContext.Users;
    }
}
