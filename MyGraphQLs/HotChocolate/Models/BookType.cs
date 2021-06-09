using HotChocolate;
using HotChocolate.Types;
using MyGraphQLs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGraphQLs.HotChocolate.Models
{
    public class BookType : ObjectType<Book>
    {
        protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        {
            descriptor.Field(t => t.Id).Type<IdType>();
            descriptor.Field(t => t.BookName).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.BookAuthor).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.Price).Type<NonNullType<IntType>>();
            descriptor.Field(t => t.Img).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.AuthenId).Type<NonNullType<IntType>>();

            descriptor.Field("user").UseDbContext<BookShellContext>().Resolver((ctx) =>
            {
                return ctx.Service<BookShellContext>().Users;
            });
        }
    }
}
