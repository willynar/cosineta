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
        /// Create a new Category
        /// </summary>
        /// <param name="category">The Category to be added</param>
        public async Task AddCategoryAsync(Category category)
        {
            category.CreationDate = DateTime.Now;
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get a Category by its ID
        /// </summary>
        /// <param name="categoryId">The ID of the Category</param>
        /// <returns>The Category with the specified ID</returns>
        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        /// <summary>
        /// Update an existing Category
        /// </summary>
        /// <param name="category">The updated Category</param>
        public async Task UpdateCategoryAsync(Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(category.CategoryId);

            if (existingCategory != null)
            {
                category.UpdateDate = DateTime.Now;
                _context.Entry(existingCategory).CurrentValues.SetValues(category);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Delete a Category by its ID
        /// </summary>
        /// <param name="categoryId">The ID of the Category to be deleted</param>
        public async Task DeleteCategoryAsync(int categoryId)
        {
            var category = await _context.Categories.FindAsync(categoryId);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all Categories
        /// </summary>
        /// <returns>A list of all Categories</returns>
        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        #endregion

        #region CategoryDetail

        /// <summary>
        /// Create a new ProductCategory
        /// </summary>
        /// <param name="productCategory">The ProductCategory to be added</param>
        public async Task AddProductCategoryAsync(ProductCategory productCategory)
        {
            productCategory.CreationDate = DateTime.Now;
            _context.ProductCategorys.Add(productCategory);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get a ProductCategory by its ID
        /// </summary>
        /// <param name="productCategoryId">The ID of the ProductCategory</param>
        /// <returns>The ProductCategory with the specified ID</returns>
        public async Task<ProductCategory> GetProductCategoryByIdAsync(int productCategoryId)
        {
            return await _context.ProductCategorys
                .Include(pc => pc.CategoryIdNavigation)
                .FirstOrDefaultAsync(pc => pc.ProductCategoryId == productCategoryId);
        }

        /// <summary>
        /// Update an existing ProductCategory
        /// </summary>
        /// <param name="productCategory">The updated ProductCategory</param>
        public async Task UpdateProductCategoryAsync(ProductCategory productCategory)
        {
            var existingProductCategory = await _context.ProductCategorys.FindAsync(productCategory.ProductCategoryId);

            if (existingProductCategory != null)
            {
                productCategory.UpdateDate = DateTime.Now;
                _context.Entry(existingProductCategory).CurrentValues.SetValues(productCategory);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Delete a ProductCategory by its ID
        /// </summary>
        /// <param name="productCategoryId">The ID of the ProductCategory to be deleted</param>
        public async Task DeleteProductCategoryAsync(int productCategoryId)
        {
            var productCategory = await _context.ProductCategorys.FindAsync(productCategoryId);
            if (productCategory != null)
            {
                _context.ProductCategorys.Remove(productCategory);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all ProductCategories
        /// </summary>
        /// <returns>A list of all ProductCategories</returns>
        public async Task<List<ProductCategory>> GetAllProductCategoriesAsync()
        {
            return await _context.ProductCategorys
                .Include(pc => pc.CategoryIdNavigation)
                .ToListAsync();
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
            return await _context.ProductCategorys
                .Where(x => x.ProductId == productId)
                .Include(pc => pc.CategoryIdNavigation)
                .ToListAsync();
        }
        #endregion

    }
}
