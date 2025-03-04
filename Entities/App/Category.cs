﻿
namespace Entities.App
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Image { get; set; }

        public bool Active { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime? UpdateDate { get; set; }

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<ProductCategory> ProductCategorys { get; } = new List<ProductCategory>();
    }
}
