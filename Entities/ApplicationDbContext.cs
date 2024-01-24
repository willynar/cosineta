﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        public DbSet<Link> Links { get; set; }
        public DbSet<RolLink> RolLinks { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<UserRole> UsersRoles { get; set; }
        public DbSet<ProductReview> ProductsReviews { get; set; }
        public DbSet<ChefReview> ChefReviews { get; set; }
        public DbSet<DeliveryMan> DeliveryMans { get; set; }
        public DbSet<DeliveryManReview> DeliveryManReviews { get; set; }
        public DbSet<DeliveryManSchedule> DeliveryManSchedules { get; set; }

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
