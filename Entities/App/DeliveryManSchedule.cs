namespace Entities.App
{
    public class DeliveryManSchedule
    {
        [Key]
        public int DeliveryManScheduleId { get; set; }

        public int StarTime { get; set; }

        public int EndTime { get; set; }

        [Required, ForeignKey("DeliveryMan")]
        public required string DeliveryManId { get; set; }

        public virtual DeliveryMan? DeliveryManIdNavigation { get; set; }
    }
}
