namespace Entities.Interfaces
{
    public interface IProductFeatureService
    {
        #region ProductFeature
        /// <summary>
        /// Create a new ProductFeature
        /// </summary>
        /// <param name="productFeature">The ProductFeature object to add</param>
        /// <returns></returns>
        Task AddProductFeatureAsync(ProductFeature productFeature);

        /// <summary>
        /// Get a ProductFeature by its ID
        /// </summary>
        /// <param name="productFeatureId">The ID of the ProductFeature to retrieve</param>
        /// <returns>The ProductFeature</returns>
        Task<ProductFeature> GetProductFeatureByIdAsync(int productFeatureId);

        /// <summary>
        /// Update an existing ProductFeature
        /// </summary>
        /// <param name="productFeature">The updated ProductFeature object</param>
        /// <returns></returns>
        Task UpdateProductFeatureAsync(ProductFeature productFeature);

        /// <summary>
        /// Delete a ProductFeature by its ID
        /// </summary>
        /// <param name="productFeatureId">The ID of the ProductFeature to delete</param>
        /// <returns></returns>
        Task DeleteProductFeatureAsync(int productFeatureId);

        /// <summary>
        /// Get all ProductFeatures
        /// </summary>
        /// <returns>A list of all ProductFeatures</returns>
        Task<List<ProductFeature>> GetAllProductFeaturesAsync();

        /// <summary>
        /// Get all ProductFeatures Additional
        /// </summary>
        /// <returns>A list of all ProductFeatures</returns>
        Task<List<ProductFeature>> GetAllAdditionalProductFeaturesByUserAsync(string applicationUserId);
        #endregion

        #region ProductFeatureDetail

        /// <summary>
        /// Create a new ProductFeaturesDetail
        /// </summary>
        /// <param name="productFeaturesDetail">The ProductFeaturesDetail object to add</param>
        /// <returns></returns>
        Task AddProductFeaturesDetailAsync(ProductFeaturesDetail productFeaturesDetail);

        /// <summary>
        /// Get a ProductFeaturesDetail by its ID with included ProductFeatures
        /// </summary>
        /// <param name="productFeaturesDetailId">The ID of the ProductFeaturesDetail to retrieve</param>
        /// <returns>The ProductFeaturesDetail with included ProductFeatures</returns>
        Task<ProductFeaturesDetail> GetProductFeaturesDetailByIdAsync(int productFeaturesDetailId);

        /// <summary>
        /// Update an existing ProductFeaturesDetail
        /// </summary>
        /// <param name="productFeaturesDetail">The updated ProductFeaturesDetail object</param>
        /// <returns></returns>
        Task UpdateProductFeaturesDetailAsync(ProductFeaturesDetail productFeaturesDetail);

        /// <summary>
        /// Delete a ProductFeaturesDetail by its ID
        /// </summary>
        /// <param name="productFeaturesDetailId">The ID of the ProductFeaturesDetail to delete</param>
        /// <returns></returns>
        Task DeleteProductFeaturesDetailAsync(int productFeaturesDetailId);

        /// <summary>
        /// Get all ProductFeaturesDetails with included ProductFeatures related to a ProductId
        /// </summary>
        /// <param name="productId">The ID of the related Product</param>
        /// <returns>A list of ProductFeaturesDetails with included ProductFeatures</returns>
        Task<List<ProductFeaturesDetail>> GetAllProductFeaturesDetailsByProductIdAsync(int productId);

        /// <summary>
        /// Delete all ProductFeaturesDetails related to a ProductId
        /// </summary>
        /// <param name="productId">The ID of the related Product</param>
        /// <returns></returns>
        Task DeleteAllProductFeaturesDetailsByProductIdAsync(int productId);
        #endregion
    }
}
