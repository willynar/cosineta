﻿namespace Entities.App
{
    public class OrderProductFeacture
    {
        [Key]
        public int OrderProductFeactureIs { get; set; }

        public decimal Price { get; set; }

        public required string Features { get; set; }

        [Required, ForeignKey("ProductFeature")]
        public required int ProductFeatureId { get; set; }

        public DateTime StarTime { get; set; }

        public DateTime EndTime { get; set; }

        [NotMapped]
        public virtual ProductFeature? ProductFeatureIdNavigation { get; set; }
    }
}
