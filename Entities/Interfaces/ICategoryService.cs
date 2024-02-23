namespace Entities.Interfaces
{
    public interface ICategoryService
    {
        #region Category
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="category"></param>
        Task AddCategoryAsync(Category category);

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Task<Category> GetCategoryByIdAsync(int categoryId);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="category"></param>
        Task UpdateCategoryAsync(Category category);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="categoryId"></param>
        Task DeleteCategoryAsync(int categoryId);

        /// <summary>
        /// Get all categories
        /// </summary>
        /// <returns></returns>
        Task<List<Category>> GetAllCategoriesAsync();
        #endregion

        #region CategoryDetail
        /// <summary>
        /// Create
        /// </summary>
        /// <param name="productCategory"></param>
        Task AddProductCategoryAsync(ProductCategory productCategory);

        /// <summary>
        /// Read
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        Task<ProductCategory> GetProductCategoryByIdAsync(int productCategoryId);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="productCategory"></param>
        Task UpdateProductCategoryAsync(ProductCategory productCategory);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="productCategoryId"></param>
        /// <returns></returns>
        Task DeleteProductCategory(int productCategoryId);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="productId"></param>
        Task DeleteProductCategoryByProductIdAsync(int productId);

        /// <summary>
        /// Get all product categories with category information by product id
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<List<ProductCategory>> GetAllProductCategoriesByProductIdAsync(int productId);
        #endregion

    }
}
