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

        public List<string>? CategoryValue { get; set; } = null;

        [Display(Description = "Admited Values: ProductId,ProductName,ProductDescription,ProductImage,ChefId,Price,Serving,Ingredients,ProductActive,CategoryId,Review,CategoryName,ChefName,ChefPhone,ChefCellphone,ChefEmail,ChefImage,ChefCover,ChefGender,ChefNationality,ChefCountry,ChefDepartment,ChefStatus,ChefCertified,ChefCertifiedMessage,ChefDescription,ChefActive,CategoryImage,CategoryActive")]
        [Required]
        public string? SorterValue { get; set; } = null;

        [Display(Description = "ordered ascending or descending")]
        [Required]
        public bool Sort { get; set; }
    }
}
