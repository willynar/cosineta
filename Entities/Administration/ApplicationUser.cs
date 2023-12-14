using Microsoft.AspNetCore.Identity;

namespace Entities.Administration
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        public bool Active { get; set; }

        [NotMapped]
        public string Login { get; set; } = string.Empty;
        [NotMapped]
        public string Password { get; set; } = string.Empty;

        public virtual ICollection<UserRole> UsersRoles { get; } = new List<UserRole>();
    }

    public class ApplicationRole : IdentityRole<string>
    {
        public bool Active { get; set; }

        public virtual ICollection<RolLink> RolLinks { get; } = new List<RolLink>();
        public virtual ICollection<UserRole> UsersRoles { get; } = new List<UserRole>();

    }

    public class IdentityUserClaim : IdentityUserClaim<string> { }

    public class IdentityUserLogin : IdentityUserLogin<string> { }

    public class ApplicationUserRole : IdentityUserRole<string> { }
}
