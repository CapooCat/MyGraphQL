using System;
using System.Collections.Generic;

#nullable disable

namespace MyGraphQLs.Models
{
    public partial class PermissionDetail
    {
        public int Id { get; set; }
        public int? IdPermission { get; set; }
        public bool? AllowInsert { get; set; }
        public bool? AllowDelete { get; set; }
        public bool? AllowEdit { get; set; }
        public bool? AllowView { get; set; }

        public virtual Permission IdPermissionNavigation { get; set; }
    }
}
