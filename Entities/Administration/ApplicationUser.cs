using Microsoft.AspNetCore.Identity;

namespace Entities.Administration
{
    public class ApplicationUser : IdentityUser
    {
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        public string? Latitude { get; set; }

        public string? Longitude { get; set; }

        [Required, ForeignKey("Type")]
        public required string TypeId { get; set; }

        public string? Address { get; set; }

        public decimal AvgReview { get; set; }

        public bool Active { get; set; }

        public int VerifyNumber { get; set; }

        [NotMapped]
        public string Login { get; set; } = string.Empty;

        [NotMapped]
        public string Password { get; set; } = string.Empty;

        [NotMapped]
        public string TokenFacebook { get; set; } = string.Empty;

        [NotMapped]
        public string TokenGoogle { get; set; } = string.Empty;

        [NotMapped]
        public string TokenOutlook { get; set; } = string.Empty;

        public virtual Type? TypeIdNavigation { get; set; }


        public virtual ICollection<UserRole> UsersRoles { get; } = new List<UserRole>();
        public virtual ICollection<Review> UserReviews { get; } = new List<Review>();
        public virtual ICollection<UserSchedule> UserSchedules { get; } = new List<UserSchedule>();


        /*eliminamos  la propiedades que no vamos a utilizar*/
        [PersonalData]
        [NotMapped]
        public override bool TwoFactorEnabled { get; set; }

        [PersonalData]
        [NotMapped]
        public override string? NormalizedEmail { get; set; }

        [PersonalData]
        [NotMapped]
        public override bool LockoutEnabled { get; set; }

        [PersonalData]
        [NotMapped]
        public override DateTimeOffset? LockoutEnd { get; set; }
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
