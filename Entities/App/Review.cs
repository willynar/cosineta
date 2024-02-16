namespace Entities.App
{
    public class Review
    {
        [Key]
        public int IdDeliveryManReview { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Author { get; set; }

        public int Stars { get; set; }

        public DateTime Date { get; set; }


        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

        [Required, ForeignKey("Type")]
        public required string TypeId { get; set; }

        public virtual Administration.Type? TypeIdNavigation { get; set; }
    }
}
