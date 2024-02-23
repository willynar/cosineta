//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;

//namespace Entities.App
//{
//    public class Category
//    {
//        [Key]
//        public int CategoryId { get; set; }

//        [Required, StringLength(100)]
//        public string Name { get; set; } = string.Empty;

//        [StringLength(200)]
//        public string? Image { get; set; }

//        public bool Active { get; set; }

//        [NotMapped]
//        public virtual ICollection<ProductCategory> ProductCategorys { get; } = new List<ProductCategory>();
//    }
//    public class Order
//    {
//        [Key]
//        public int OrderId { get; set; }

//        public decimal TotalOrder { get; set; }

//        public int QuantityOfProducts { get; set; }

//        [Required, ForeignKey("ApplicationUser")]
//        public required string ApplicationUserId { get; set; }

//        [NotMapped]
//        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

//        [NotMapped]
//        public virtual ICollection<OrderProductFeactureDetail> OrderProductFeactureDetails { get; } = new List<OrderProductFeactureDetail>();

//    }
//    public class OrderProductFeacture
//    {
//        [Key]
//        public int OrderProductFeactureIs { get; set; }

//        public decimal Price { get; set; }

//        public required string Features { get; set; }

//        [Required, ForeignKey("ProductFeature")]
//        public required int ProductFeatureId { get; set; }

//        public DateTime StarTime { get; set; }

//        public DateTime EndTime { get; set; }

//        [NotMapped]
//        public virtual ProductFeature? ProductFeatureIdNavigation { get; set; }
//    }
//    public class OrderProductFeactureDetail
//    {
//        [Key]
//        public int OrderProductFeactureDetailId { get; set; }

//        public decimal Price { get; set; }

//        [Required, ForeignKey("Order")]
//        public required int OrderId { get; set; }

//        public virtual Order? OrderIdNavigation { get; set; }

//        //To Product 
//        [ForeignKey("Product")]
//        public int? ProductId { get; set; }

//        [NotMapped]
//        public virtual ICollection<OrderProductFeacture> OrderProductFeactures { get; } = new List<OrderProductFeacture>();

//        //To Feacture
//        [ForeignKey("ProductFeature")]
//        public int? ProductFeatureId { get; set; }

//        [NotMapped]
//        public virtual Product? ProductIdNavigation { get; set; }

//        [NotMapped]
//        public virtual ProductFeature? ProductFeatureIdNavigation { get; set; }

//    }
//    public class Product
//    {
//        [Key]
//        public int ProductId { get; set; }

//        [Required, StringLength(200)]
//        public string Name { get; set; } = string.Empty;

//        public string? Description { get; set; }

//        [StringLength(200)]
//        public string? Image { get; set; }

//        public decimal Price { get; set; }

//        public string? Ingredients { get; set; }

//        public bool Active { get; set; }

//        public decimal? Review { get; set; }

//        public int? Serving { get; set; }

//        [Required, ForeignKey("ApplicationUser")]
//        public required string ApplicationUserId { get; set; }

//        [NotMapped]
//        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

//        [NotMapped]
//        public virtual ICollection<ProductCategory> ProductCategorys { get; } = new List<ProductCategory>();

//        [NotMapped]
//        public virtual ICollection<ProductFeaturesDetail> ProductFeaturesDetails { get; } = new List<ProductFeaturesDetail>();

//        [NotMapped]
//        public virtual ICollection<ProductSchedule> ProductSchedules { get; } = new List<ProductSchedule>();
//    }
//    public class ProductCategory
//    {
//        [Key]
//        public int ProductCategoryId { get; set; }

//        [Required, ForeignKey("Category")]

//        public int CategoryId { get; set; }

//        [Required, ForeignKey("Category")]

//        public int ProductId { get; set; }

//        [NotMapped]
//        public virtual Category? CategoryIdNavigation { get; set; }

//        [NotMapped]
//        public virtual Product? ProductIdNavigation { get; set; }
//    }
//    public class ProductFeature
//    {

//        [Key]
//        public int ProductFeatureId { get; set; }

//        public required string Features { get; set; }

//        public bool MultipleSelection { get; set; }

//        public bool IsAdditional { get; set; }

//        public decimal? AdditionalValue { get; set; }

//        public bool Active { get; set; }

//        [Required, ForeignKey("ApplicationUser")]
//        public required string ApplicationUserId { get; set; }

//        [NotMapped]
//        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

//        [NotMapped]
//        public virtual ICollection<ProductFeaturesDetail> ProductFeaturesDetails { get; } = new List<ProductFeaturesDetail>();

//    }
//    public class ProductFeaturesDetail
//    {
//        [Key]
//        public int ProductFeaturesDetailId { get; set; }

//        public bool Required { get; set; }

//        [Required, ForeignKey("Product")]
//        public required int ProductId { get; set; }

//        [Required, ForeignKey("ProductFeatures")]
//        public required int ProductFeaturesId { get; set; }

//        [NotMapped]
//        public virtual Product? ProductIdNavigation { get; set; }

//        [NotMapped]
//        public virtual ProductFeature? ProductFeaturesIdNavigation { get; set; }
//    }
//    public class ProductSchedule
//    {
//        [Key]
//        public int UserScheduleId { get; set; }

//        public DateTime StarTime { get; set; }

//        public DateTime EndTime { get; set; }

//        public bool Active { get; set; }

//        [Required, ForeignKey("Product")]
//        public required string ProductId { get; set; }

//        [NotMapped]
//        public virtual Product? ProductIdNavigation { get; set; }
//    }
//    public class Review
//    {
//        [Key]
//        public int ReviewId { get; set; }

//        public string? Title { get; set; }

//        public string? Description { get; set; }

//        public string? Author { get; set; }

//        public int Stars { get; set; }

//        public DateTime Date { get; set; }

//        [Required, ForeignKey("Type")]
//        public required int TypeId { get; set; }


//        [ForeignKey("ApplicationUser")]
//        public string? ApplicationUserId { get; set; }


//        [ForeignKey("Product")]
//        public int? ProductId { get; set; }

//        [NotMapped]
//        public virtual Administration.Type? TypeIdNavigation { get; set; }

//        [NotMapped]
//        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

//        [NotMapped]
//        public virtual Product? ProductIdNavigation { get; set; }
//    }
//    public class UserSchedule
//    {
//        [Key]
//        public int UserScheduleId { get; set; }

//        public int StarTime { get; set; }

//        public int EndTime { get; set; }

//        [Required, ForeignKey("ApplicationUser")]
//        public required string ApplicationUserId { get; set; }
//        [NotMapped]
//        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }
//    }
//    public class ApplicationUser : IdentityUser
//    {
//        [StringLength(100)]
//        public string Name { get; set; } = string.Empty;

//        [StringLength(100)]
//        public string LastName { get; set; } = string.Empty;

//        public string? Latitude { get; set; }

//        public string? Longitude { get; set; }

//        [Required, ForeignKey("Type")]
//        public required int TypeId { get; set; }

//        public string? Address { get; set; }

//        public decimal AvgReview { get; set; }

//        public bool Active { get; set; }

//        public int VerifyNumber { get; set; }

//        [NotMapped]
//        public string Login { get; set; } = string.Empty;

//        [NotMapped]
//        public string Password { get; set; } = string.Empty;

//        [NotMapped]
//        public string TokenFacebook { get; set; } = string.Empty;

//        [NotMapped]
//        public string TokenGoogle { get; set; } = string.Empty;

//        [NotMapped]
//        public string TokenOutlook { get; set; } = string.Empty;

//        public virtual Type? TypeIdNavigation { get; set; }


//        public virtual ICollection<UserRole> UsersRoles { get; } = new List<UserRole>();
//        public virtual ICollection<Review> UserReviews { get; } = new List<Review>();
//        public virtual ICollection<UserSchedule> UserSchedules { get; } = new List<UserSchedule>();
//        public virtual ICollection<Order> Orders { get; } = new List<Order>();
//        public virtual ICollection<ProductFeature> ProductFeature { get; } = new List<ProductFeature>();
//        public virtual ICollection<UserPaymentMethod> UserPaymentMethods { get; } = new List<UserPaymentMethod>();


//        /*eliminamos  la propiedades que no vamos a utilizar*/
//        [PersonalData]
//        [NotMapped]
//        public override bool TwoFactorEnabled { get; set; }

//        [PersonalData]
//        [NotMapped]
//        public override string? NormalizedEmail { get; set; }

//        [PersonalData]
//        [NotMapped]
//        public override bool LockoutEnabled { get; set; }

//        [PersonalData]
//        [NotMapped]
//        public override DateTimeOffset? LockoutEnd { get; set; }
//    }
//    public class ApplicationRole : IdentityRole<string>
//    {
//        public bool Active { get; set; }

//        public virtual ICollection<RolLink> RolLinks { get; } = new List<RolLink>();
//        public virtual ICollection<UserRole> UsersRoles { get; } = new List<UserRole>();

//    }
//    public class Type
//    {
//        [Key]
//        public int TypeId { get; set; }

//        public string? TypeName { get; set; }

//        public bool ValidForUser { get; set; }

//        public virtual ICollection<Product> Products { get; } = new List<Product>();
//        public virtual ICollection<ApplicationUser> ApplicationUsers { get; } = new List<ApplicationUser>();

//    }
//    public class UserPaymentMethod
//    {
//        [Key]
//        public int UserPaymentMethodsId { get; set; }

//        public int Bin { get; set; }

//        public required string Bank { get; set; }

//        public required string Token { get; set; }

//        [Required, ForeignKey("ApplicationUser")]
//        public required string ApplicationUserId { get; set; }


//        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }
//    }
//    public class UserRole
//    {
//        [Key]
//        public int UserRoleId { get; set; }

//        [ForeignKey("ApplicationRole")]
//        public string? RoleId { get; set; }

//        [Required, ForeignKey("ApplicationUser")]
//        public required string ApplicationUserId { get; set; }

//        public virtual ApplicationRole? ApplicationRoleIdNavigation { get; set; }
//        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }
//    }
//    public class UserToken
//    {
//        [Key]
//        public int Id { get; set; }

//        [Required, ForeignKey("User"), StringLength(450)]
//        public string? UserId { get; set; }

//        [Required]
//        public string Token { get; set; } = string.Empty;

//        [JsonIgnore]
//        public virtual ApplicationUser? User { get; set; }
//    }
//    public class RolLink
//    {
//        [Key]
//        public int RolLinkId { get; set; }
//        public bool Consult { get; set; }

//        public bool Save { get; set; }

//        public bool Update { get; set; }

//        public bool Delete { get; set; }

//        public bool Especial { get; set; }

//        [Required, ForeignKey("UserRole")]
//        public required int UserRoleId { get; set; }

//        [Required, ForeignKey("Link")]
//        public required string LinkId { get; set; }

//        public virtual UserRole? ApplicationRoleIdNavigation { get; set; }

//        public virtual Link? LinkIdNavigation { get; set; }
//    }
//    public class Module
//    {
//        public int ModuleId { get; set; }
//        public required string Name { get; set; }
//        public required string Description { get; set; }
//        public virtual ICollection<Link> Links { get; } = new List<Link>();

//    }
//    public class Link
//    {
//        [Key]
//        public int LinkId { get; set; }
//        public required string Descripcion { get; set; }
//        public required string Navegacion { get; set; }
//        [Required, ForeignKey("Module")]
//        public required int ModuleId { get; set; }
//        public virtual Module? ModuleIdNavigation { get; set; }
//        public virtual ICollection<RolLink> RolLinks { get; } = new List<RolLink>();

//    }

//UserToken 
//Products 
//Categories
//Links
// RolLinks
//Modules
//UsersRoles
//Reviews
//UserSchedules
//ProductSchedules
//ProductCategorys
//Types
//ProductFeaturesDetails
//ProductFeatures
//Orders
//OrderProductFeactureDetails
//OrderProductFeactures
//UserPaymentMethods
//}
