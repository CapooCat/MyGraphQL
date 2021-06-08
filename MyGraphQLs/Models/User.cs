using System;
using System.Collections.Generic;

#nullable disable

namespace MyGraphQLs.Models
{
    public partial class User
    {
        public User()
        {
            Books = new HashSet<Book>();
            UserPermissions = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Displayname { get; set; }
        public string Token { get; set; }

        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
