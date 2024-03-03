namespace Entities.App
{
    public class ProductSchedule
    {
        [Key]
        public int ProductScheduleId { get; set; }

        public DateTime StarTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime PublicationStarTime { get; set; }

        public DateTime PublicationEndTime { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }

        public bool Active { get; set; }

        [Required, ForeignKey("Product")]
        public required int ProductId { get; set; }

        [JsonIgnore]
        public virtual Product? ProductIdNavigation { get; set; }
    }
}
