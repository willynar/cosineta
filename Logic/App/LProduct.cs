using Entities.App;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Data;

namespace Logic.App
{
    public class LProduct : IProductService
    {
        private readonly ApplicationDbContext _context;

        private readonly IExecuteProceduresService IExecuteProceduresService;

        public LProduct(ApplicationDbContext context, IExecuteProceduresService iExecuteProceduresService)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            IExecuteProceduresService = iExecuteProceduresService ?? throw new ArgumentNullException(nameof(iExecuteProceduresService));
        }

        /// <summary>
        /// gets all list of products whit  the categories and chef
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAllProducts() =>
          await _context.Products
                .Include(p => p.CategoryIdNavigation)
                .Include(p => p.ChefIdNavigation)
                .ToListAsync();

        /// <summary>
        /// get product by id product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int productId) =>
          await _context.Products
                .Include(p => p.CategoryIdNavigation)
                .Include(p => p.ChefIdNavigation)
                .FirstOrDefaultAsync(p => p.ProductId == productId);

        /// <summary>
        /// save new product
        /// </summary>
        /// <param name="product"></param>
        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// update product by id
        /// </summary>
        /// <param name="updatedProduct"></param>
        public async Task UpdProductById(Product updatedProduct)
        {
            var product = _context.Products.Find(updatedProduct.ProductId);

            if (product != null)
            {
                product.Name = updatedProduct.Name;
                product.Price = updatedProduct.Price;
                product.Description = updatedProduct.Description;
                product.Image = updatedProduct.Image;
                product.ChefId = updatedProduct.ChefId;
                product.Serving = updatedProduct.Serving;
                product.Ingredients = updatedProduct.Ingredients;
                product.Active = updatedProduct.Active;
                product.CategoryId = updatedProduct.CategoryId;

                _context.Entry(product).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// delete product by id product
        /// </summary>
        /// <param name="productId"></param>
        public async Task DeleteProductById(int productId)
        {
            var product = _context.Products.Find(productId);

            if (product != null)
            {
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// get all products paginated by store procedure
        /// </summary>
        /// <param name="Page"></param>
        /// <param name="Reg"></param>
        /// <param name="Filter"></param>
        /// <param name="Sort"></param>
        /// <param name="Sorter"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<ProductStoreProcedure>> GetAllProductsFromPaginated(int Page, int Reg, string? Filter, string? Sort, bool Sorter)
        {
            try
            {
                //Se crea array con los parametros
                SqlParameter[] parameters = {
                        new SqlParameter("@Page",Page),
                        new SqlParameter("@Reg",Reg),
                        new SqlParameter("@Filter",Filter ?? ""),
                        new SqlParameter("@Sort",Sort ?? ""),
                        new SqlParameter("@Sorter",Sorter ? 1 : 0)
                };
                var Data = await IExecuteProceduresService.GetPaginatedProducts(parameters);
                return ListProductsFronStoreProcedure(Data);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// list  datatable  to list<T>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<ProductStoreProcedure> ListProductsFronStoreProcedure(DataTable data)
        {
            try
            {
                List<ProductStoreProcedure> objEafit = new();
                for (var i = 0; i < data.Rows.Count; i++)
                {
                    ProductStoreProcedure obj = new()
                    {
                        ProductId = data.Rows[i]["ProductId"] != DBNull.Value ? (int)data.Rows[i]["ProductId"] : 0,
                        ProductName = data.Rows[i]["ProductName"] != DBNull.Value ? data.Rows[i]["ProductName"].ToString() : null,
                        ProductDescription = data.Rows[i]["ProductDescription"] != DBNull.Value ? data.Rows[i]["ProductDescription"].ToString() : null,
                        ProductImage = data.Rows[i]["ProductImage"] != DBNull.Value ? data.Rows[i]["ProductImage"].ToString() : null,
                        ChefId = data.Rows[i]["ChefId"] != DBNull.Value ? data.Rows[i]["ChefId"].ToString() : null,
                        Price = data.Rows[i]["Price"] != DBNull.Value ? (int)data.Rows[i]["Price"] : 0,
                        Serving = data.Rows[i]["Serving"] != DBNull.Value ? (int)data.Rows[i]["Serving"] : 0,
                        Ingredients = data.Rows[i]["Ingredients"] != DBNull.Value ? data.Rows[i]["Ingredients"].ToString() : null,
                        ProductActive = data.Rows[i]["ProductActive"] != DBNull.Value ? (bool)data.Rows[i]["ProductActive"] : false,
                        CategoryId = data.Rows[i]["CategoryId"] != DBNull.Value ? (int)data.Rows[i]["CategoryId"] : 0,
                        CategoryName = data.Rows[i]["CategoryName"] != DBNull.Value ? data.Rows[i]["CategoryName"].ToString() : null,
                        ChefName = data.Rows[i]["ChefName"] != DBNull.Value ? data.Rows[i]["ChefName"].ToString() : null,
                        ChefPhone = data.Rows[i]["ChefPhone"] != DBNull.Value ? data.Rows[i]["ChefPhone"].ToString() : null,
                        ChefCellphone = data.Rows[i]["ChefCellphone"] != DBNull.Value ? data.Rows[i]["ChefCellphone"].ToString() : null,
                        ChefEmail = data.Rows[i]["ChefEmail"] != DBNull.Value ? data.Rows[i]["ChefEmail"].ToString() : null,
                        ChefImage = data.Rows[i]["ChefImage"] != DBNull.Value ? data.Rows[i]["ChefImage"].ToString() : null,
                        ChefCover = data.Rows[i]["ChefCover"] != DBNull.Value ? data.Rows[i]["ChefCover"].ToString() : null,
                        ChefGender = data.Rows[i]["ChefGender"] != DBNull.Value ? data.Rows[i]["ChefGender"].ToString() : null,
                        ChefNationality = data.Rows[i]["ChefNationality"] != DBNull.Value ? data.Rows[i]["ChefNationality"].ToString() : null,
                        ChefCountry = data.Rows[i]["ChefCountry"] != DBNull.Value ? data.Rows[i]["ChefCountry"].ToString() : null,
                        ChefDepartment = data.Rows[i]["ChefDepartment"] != DBNull.Value ? data.Rows[i]["ChefDepartment"].ToString() : null,
                        ChefStatus = data.Rows[i]["ChefStatus"] != DBNull.Value ? data.Rows[i]["ChefStatus"].ToString() : null,
                        ChefCertified = data.Rows[i]["ChefCertified"] != DBNull.Value ? (bool)data.Rows[i]["ChefCertified"] : false,
                        ChefCertifiedMessage = data.Rows[i]["ChefCertifiedMessage"] != DBNull.Value ? data.Rows[i]["ChefCertifiedMessage"].ToString() : null,
                        ChefDescription = data.Rows[i]["ChefDescription"] != DBNull.Value ? data.Rows[i]["ChefDescription"].ToString() : null,
                        ChefActive = data.Rows[i]["ChefActive"] != DBNull.Value ? (bool)data.Rows[i]["ChefActive"] : false,
                        CategoryImage = data.Rows[i]["CategoryImage"] != DBNull.Value ? data.Rows[i]["CategoryImage"].ToString() : null,
                        CategoryActive = data.Rows[i]["CategoryActive"] != DBNull.Value ? (bool)data.Rows[i]["CategoryActive"] : false
                    };
                    objEafit.Add(obj);
                }
                return objEafit;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
