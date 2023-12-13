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

        [NotMapped]
        //[JsonIgnore]
        public List<ApplicationRole> Roles { get; set; }
    }

    public class ApplicationRole : IdentityRole<string>
    {
        public bool Active { get; set; }
    }

    public class IdentityUserClaim : IdentityUserClaim<string> { }

    public class IdentityUserLogin : IdentityUserLogin<string> { }

    public class ApplicationUserRole : IdentityUserRole<string> { }
}
