namespace Entities.Administration
{
    public class UserPaymentMethod
    {
        [Key] 
        public int UserPaymentMethodsId { get; set; }

        public int Bin { get; set; }

        public required string Bank { get; set; }

        public required string Token { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }


        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }
    }
}
