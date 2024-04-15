namespace Entities.App
{
    public class ProductScheduleModel
    {
        public int? ProductScheduleId { get; set; } = null;

        public DateTime StarTime { get; set; }

        public DateTime EndTime { get; set; }

        public DateTime PublicationStarTime { get; set; }

        public DateTime PublicationEndTime { get; set; }

        public bool Active { get; set; }

        public required int ProductId { get; set; }
    }
}
