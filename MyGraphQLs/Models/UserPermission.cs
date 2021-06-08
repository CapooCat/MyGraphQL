using System;
using System.Collections.Generic;

#nullable disable

namespace MyGraphQLs.Models
{
    public partial class UserPermission
    {
        public int Id { get; set; }
        public int? IdPermission { get; set; }
        public int? IdUser { get; set; }

        public virtual Permission IdPermissionNavigation { get; set; }
        public virtual User IdUserNavigation { get; set; }
    }
}
