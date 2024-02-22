namespace Entities.App
{
    public class ProductSchedule
    {
        [Key]
        public int UserScheduleId { get; set; }

        public DateTime StarTime { get; set; }

        public DateTime EndTime { get; set; }

        public bool Active { get; set; }

        [Required, ForeignKey("Product")]
        public required string ProductId { get; set; }

        [NotMapped]
        public virtual Product? ProductIdNavigation { get; set; }
    }
}
