using System.ComponentModel;
using System.Data;

namespace Entities.App
{
    public class ProductPaginatedParams
    {
        [Required]
        public int Page { get; set; }

        [Required]
        public int Reg { get; set; }

        [Display(Description = "all products containing the word in any property")]
        public string? FilterValue { get; set; } = null;

        public decimal? PriceMin { get; set; } = null;

        public decimal? PriceMax { get; set; } = null;

        public decimal? Review { get; set; } = null;

        public DateTime? StarTime { get; set; }

        public DateTime? EndTime { get; set; }

        public List<int>? CategoryIds { get; set; } = null;

        public List<int>? FeatureIds { get; set; } = null;

        public int? Serving { get; set; } = null;

        [Display(Description = "Admited Values: all product values in camelCase")]
        [Required]
        public string? SorterValue { get; set; } = null;

        [Display(Description = "ordered ascending or descending")]
        [Required]
        public bool Sort { get; set; }
    }
}
