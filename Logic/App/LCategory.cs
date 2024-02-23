using Entities.App;

namespace Logic.App
{
    public class LCategory : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public LCategory(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Category
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="category"></param>
        public async Task AddCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="category"></param>
        public async Task UpdateCategoryAsync(Category category)
        {
            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="categoryId"></param>
        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }
        #endregion

        #region CategoryDetail
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="productCategory"></param>
        public async Task AddProductCategoryAsync(ProductCategory productCategory)
        {
            _context.ProductCategorys.Add(productCategory);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        public async Task<ProductCategory> GetProductCategoryByIdAsync(int productCategoryId)
        {
            return await _context.ProductCategorys.Include(pc => pc.CategoryIdNavigation)
                                                .FirstOrDefaultAsync(pc => pc.ProductCategoryId == productCategoryId);
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="productCategory"></param>
        public async Task UpdateProductCategoryAsync(ProductCategory productCategory)
        {
            _context.ProductCategorys.Update(productCategory);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        public async Task DeleteProductCategory(int productCategoryId)
        {
            var productCategory = await _context.ProductCategorys.FirstOrDefaultAsync(pc => pc.ProductCategoryId == productCategoryId);
            if (productCategory != null)
            {
                _context.ProductCategorys.Remove(productCategory);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Delete by product id
        /// </summary>
        /// <param name="productId"></param>
        public async Task DeleteProductCategoryByProductIdAsync(int productId)
        {
            var productCategory = await _context.ProductCategorys.Where(pc => pc.ProductId == productId).ToListAsync();
            if (productCategory != null)
            {
                _context.ProductCategorys.RemoveRange(productCategory);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all product categories with category information by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<List<ProductCategory>> GetAllProductCategoriesByProductIdAsync(int productId)
        {
            return await _context.ProductCategorys.Where(x => x.ProductId == productId).Include(pc => pc.CategoryIdNavigation).ToListAsync();
        }
        #endregion

    }
}
