using Entities.App;

namespace Logic.App
{
    public class LProductFeature: IProductFeatureService
    {
        private readonly ApplicationDbContext _context;

        public LProductFeature(ApplicationDbContext context)
        {
            _context = context;
        }

        #region ProductFeature
        /// <summary>
        /// Create a new ProductFeature
        /// </summary>
        /// <param name="productFeature">The ProductFeature object to add</param>
        /// <returns></returns>
        public async Task AddProductFeatureAsync(ProductFeature productFeature)
        {
            _context.ProductFeatures.Add(productFeature);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get a ProductFeature by its ID
        /// </summary>
        /// <param name="productFeatureId">The ID of the ProductFeature to retrieve</param>
        /// <returns>The ProductFeature</returns>
        public async Task<ProductFeature> GetProductFeatureByIdAsync(int productFeatureId)
        {
            return await _context.ProductFeatures
                .FirstOrDefaultAsync(pf => pf.ProductFeatureId == productFeatureId);
        }

        /// <summary>
        /// Update an existing ProductFeature
        /// </summary>
        /// <param name="productFeature">The updated ProductFeature object</param>
        /// <returns></returns>
        public async Task UpdateProductFeatureAsync(ProductFeature productFeature)
        {
            _context.ProductFeatures.Update(productFeature);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a ProductFeature by its ID
        /// </summary>
        /// <param name="productFeatureId">The ID of the ProductFeature to delete</param>
        /// <returns></returns>
        public async Task DeleteProductFeatureAsync(int productFeatureId)
        {
            var productFeature = await _context.ProductFeatures
                .FirstOrDefaultAsync(pf => pf.ProductFeatureId == productFeatureId);

            if (productFeature != null)
            {
                _context.ProductFeatures.Remove(productFeature);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all ProductFeatures
        /// </summary>
        /// <returns>A list of all ProductFeatures</returns>
        public async Task<List<ProductFeature>> GetAllProductFeaturesAsync()
        {
            return await _context.ProductFeatures.ToListAsync();
        }
        #endregion

        #region ProductFeatureDetail

        /// <summary>
        /// Create a new ProductFeaturesDetail
        /// </summary>
        /// <param name="productFeaturesDetail">The ProductFeaturesDetail object to add</param>
        /// <returns></returns>
        public async Task AddProductFeaturesDetailAsync(ProductFeaturesDetail productFeaturesDetail)
        {
            _context.ProductFeaturesDetails.Add(productFeaturesDetail);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get a ProductFeaturesDetail by its ID with included ProductFeatures
        /// </summary>
        /// <param name="productFeaturesDetailId">The ID of the ProductFeaturesDetail to retrieve</param>
        /// <returns>The ProductFeaturesDetail with included ProductFeatures</returns>
        public async Task<ProductFeaturesDetail> GetProductFeaturesDetailByIdAsync(int productFeaturesDetailId)
        {
            return await _context.ProductFeaturesDetails
                .Include(pfd => pfd.ProductFeaturesIdNavigation)
                .FirstOrDefaultAsync(pfd => pfd.ProductFeaturesDetailId == productFeaturesDetailId);
        }


        /// <summary>
        /// Update an existing ProductFeaturesDetail
        /// </summary>
        /// <param name="productFeaturesDetail">The updated ProductFeaturesDetail object</param>
        /// <returns></returns>
        public async Task UpdateProductFeaturesDetailAsync(ProductFeaturesDetail productFeaturesDetail)
        {
            _context.ProductFeaturesDetails.Update(productFeaturesDetail);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a ProductFeaturesDetail by its ID
        /// </summary>
        /// <param name="productFeaturesDetailId">The ID of the ProductFeaturesDetail to delete</param>
        /// <returns></returns>
        public async Task DeleteProductFeaturesDetailAsync(int productFeaturesDetailId)
        {
            var productFeaturesDetail = await _context.ProductFeaturesDetails
                .FirstOrDefaultAsync(pfd => pfd.ProductFeaturesDetailId == productFeaturesDetailId);

            if (productFeaturesDetail != null)
            {
                _context.ProductFeaturesDetails.Remove(productFeaturesDetail);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all ProductFeaturesDetails with included ProductFeatures related to a ProductId
        /// </summary>
        /// <param name="productId">The ID of the related Product</param>
        /// <returns>A list of ProductFeaturesDetails with included ProductFeatures</returns>
        public async Task<List<ProductFeaturesDetail>> GetAllProductFeaturesDetailsByProductIdAsync(int productId)
        {
            return await _context.ProductFeaturesDetails
                .Where(pfd => pfd.ProductId == productId)
                .Include(pfd => pfd.ProductFeaturesIdNavigation)
                .ToListAsync();
        }

        /// <summary>
        /// Delete all ProductFeaturesDetails related to a ProductId
        /// </summary>
        /// <param name="productId">The ID of the related Product</param>
        /// <returns></returns>
        public async Task DeleteAllProductFeaturesDetailsByProductIdAsync(int productId)
        {
            var productFeaturesDetails = await _context.ProductFeaturesDetails
                .Where(pfd => pfd.ProductId == productId)
                .ToListAsync();

            if (productFeaturesDetails != null && productFeaturesDetails.Any())
            {
                _context.ProductFeaturesDetails.RemoveRange(productFeaturesDetails);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
