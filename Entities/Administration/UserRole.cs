using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Administration
{
    public class UserRole
    {
        [Key]
        public int UserRoleId { get; set; }

        [Required, ForeignKey("ApplicationRole")]
        public required string RoleId { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        public virtual ApplicationRole? ApplicationRoleIdNavigation { get; set; }
        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }
    }
}
