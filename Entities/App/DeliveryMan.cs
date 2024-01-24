namespace Entities.App
{
    public class DeliveryMan
    {
        [Key]
        public int DeliveryManId { get; set; }

        public string Name { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public required string? ApplicationUserId { get; set; }

        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }
        public virtual ICollection<DeliveryManReview> DeliveryManReviews { get; } = new List<DeliveryManReview>();
        public virtual ICollection<DeliveryManSchedule> DeliveryManSchedules { get; } = new List<DeliveryManSchedule>();
    }
}
