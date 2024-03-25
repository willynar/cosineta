using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.App
{
    public class ProductFeactureCategoryStoreProcedure
    {
        public int ProductFeactureCategoryId { get; set; }

        public required string Category { get; set; }

        public List<ProductFeactureStoreProcedure>? ListProductFeactures { get; set; }
    }
}
