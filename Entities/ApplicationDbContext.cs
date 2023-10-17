using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Entities
{
    public class ApplicationDbContext : IdentityDbContext
        <
            ApplicationUser, // TUser
            ApplicationRole, // TRole
            string, // TKey
            IdentityUserClaim<string>, // TUserClaim
            ApplicationUserRole, // TUserRole,
            IdentityUserLogin<string>, // TUserLogin
            IdentityRoleClaim<string>, // TRoleClaim
            IdentityUserToken<string> // TUserToken
        >
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<UserToken> UserToken { get; set; }
        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
        }
    }
}
