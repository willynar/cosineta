namespace Entities.App
{
    public class ProductStoreProcedure
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductImage { get; set; }
        public string? ChefId { get; set; }
        public decimal Price { get; set; }
        public int Serving { get; set; }
        public string? Ingredients { get; set; }
        public bool ProductActive { get; set; }
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryImage { get; set; }
        public bool CategoryActive { get; set; }
        public string? ChefName { get; set; }
        public string? ChefPhone { get; set; }
        public string? ChefCellphone { get; set; }
        public string? ChefEmail { get; set; }
        public string? ChefImage { get; set; }
        public string? ChefCover { get; set; }
        public string? ChefGender { get; set; }
        public string? ChefNationality { get; set; }
        public string? ChefCountry { get; set; }
        public string? ChefDepartment { get; set; }
        public string? ChefStatus { get; set; }
        public bool ChefCertified { get; set; }
        public string? ChefCertifiedMessage { get; set; }
        public string? ChefDescription { get; set; }
        public bool ChefActive { get; set; }
    
    }
}
