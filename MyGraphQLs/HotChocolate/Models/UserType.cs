using HotChocolate.Types;
using MyGraphQLs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGraphQLs.HotChocolate.Models
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Field(t => t.Id).Type<IdType>();
            descriptor.Field(t => t.Username).Type<NonNullType<StringType>>();
            descriptor.Field(t => t.Displayname).Type<NonNullType<IntType>>();
            descriptor.Ignore(t => t.Token);
            descriptor.Ignore(t => t.Password);
        }
    }
}
