using System;
using System.Collections.Generic;

#nullable disable

namespace MyGraphQLs.Models
{
    public partial class Book
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string BookAuthor { get; set; }
        public double? Price { get; set; }
        public int AuthenId { get; set; }
        public string Img { get; set; }

        public virtual User Authen { get; set; }
    }
}
