namespace Entities.App
{
    public class DeliveryManReview
    {
        [Key]
        public int IdDeliveryManReview { get; set; }

        public string? Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public int Stars { get; set; }

        public int? DeliveryManId { get; set; }

        public virtual DeliveryMan? DeliveryManIdNavigation { get; set; }
    }
}
