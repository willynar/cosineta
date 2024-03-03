using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Type = Entities.Administration.Type;

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
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<RolLink> RolLinks { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserSchedule> UserSchedules { get; set; }
        public DbSet<ProductSchedule> ProductSchedules { get; set; }
        public DbSet<ProductCategory> ProductCategorys { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<ProductFeaturesDetail> ProductFeaturesDetails { get; set; }
        public DbSet<ProductFeature> ProductFeatures { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProductFeactureDetail> OrderProductFeactureDetails { get; set; }
        public DbSet<OrderProductFeacture> OrderProductFeactures { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<UserPaymentMethod> UserPaymentMethods { get; set; }
        public DbSet<OrderProductTax> OrderProductTaxes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<ApplicationUser>(x =>
            //{
            //    x.HasMany(z => z.Roles)
            //    .WithOne()
            //    .HasForeignKey(z => z.Id)
            //    .IsRequired();
            //});

            //modelBuilder.Entity<ApplicationRole>(x =>
            //{
            //    x.HasMany(z => z.Users)
            //    .WithOne()
            //    .HasForeignKey(z=>z.Id)
            //    .IsRequired();
            //});

        }
    }
}
