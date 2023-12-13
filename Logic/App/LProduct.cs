using Entities.App;

namespace Logic.App
{
    public class LProduct : IProductService
    {
        private readonly ApplicationDbContext _context;

        public LProduct(ApplicationDbContext context)
        {
            _context = context;
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
    }
}
