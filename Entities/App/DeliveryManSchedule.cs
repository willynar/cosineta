namespace Entities.App
{
    public class DeliveryManSchedule
    {
        [Key]
        public int DeliveryManScheduleId { get; set; }

        public int StarTime { get; set; }

        public int EndTime { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public required string ApplicationUserId { get; set; }

        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }
    }
}
