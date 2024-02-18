namespace Entities.App
{
    public class ProductStoreProcedure
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductImage { get; set; }
        public int? TypeId { get; set; }
        public decimal Price { get; set; }
        public int? Serving { get; set; }
        public string? Ingredients { get; set; }
        public bool ProductActive { get; set; }
        public decimal? Review { get; set; }
        public string? ApplicationUserId { get; set; }
        public string? UserName { get; set; }
        public string? UserLastName { get; set; }
        public List<Category>? Categorys { get; set;}
        public List<ProductFeature>? ProductFeatures { get; set; }

    }
}
