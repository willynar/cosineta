using System.ComponentModel;

namespace Entities.App
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }

        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? Author { get; set; }

        public int Stars { get; set; }

        [JsonIgnore]
        public DateTime CreationDate { get; set; }

        [JsonIgnore]
        public DateTime UpdateDate { get; set; }

        [Required, ForeignKey("Type")]
        public required int TypeId { get; set; }


        [ForeignKey("ApplicationUser")]
        [Description("Parametro opcional depende del tipo si es usuario o producto")]
        public string? ApplicationUserId { get; set; }


        [ForeignKey("Product")]
        [Description("Parametro opcional depende del tipo si es usuario o producto")]
        public int? ProductId { get; set; }

        [JsonIgnore]
        public virtual Administration.Type? TypeIdNavigation { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser? ApplicationUserIdNavigation { get; set; }

        [JsonIgnore]
        public virtual Product? ProductIdNavigation { get; set; }
    }
}
