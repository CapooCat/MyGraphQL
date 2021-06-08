using System;
using System.Collections.Generic;

#nullable disable

namespace MyGraphQLs.Models
{
    public partial class Permission
    {
        public Permission()
        {
            PermissionDetails = new HashSet<PermissionDetail>();
            UserPermissions = new HashSet<UserPermission>();
        }

        public int Id { get; set; }
        public string NamePermission { get; set; }

        public virtual ICollection<PermissionDetail> PermissionDetails { get; set; }
        public virtual ICollection<UserPermission> UserPermissions { get; set; }
    }
}
