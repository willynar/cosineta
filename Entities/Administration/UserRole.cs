﻿namespace Entities.Administration
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        [ForeignKey("ApplicationRole")]
        public string? RoleId { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        public virtual ApplicationRole? ApplicationRoleIdNavigation { get; set; }
        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }
    }
}
