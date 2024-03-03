using Entities.Administration;
using Entities.App;

namespace Logic.App
{
    public class LProductFeature : IProductFeatureService
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
        /// <param name="productFeature">The ProductFeature to be added</param>
        public async Task AddProductFeatureAsync(ProductFeature productFeature)
        {
            _context.ProductFeatures.Add(productFeature);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get a ProductFeature by its ID
        /// </summary>
        /// <param name="productFeatureId">The ID of the ProductFeature</param>
        /// <returns>The ProductFeature with the specified ID</returns>
        public async Task<ProductFeature> GetProductFeatureByIdAsync(int productFeatureId)
        {
            return await _context.ProductFeatures.FirstOrDefaultAsync(pf => pf.ProductFeatureId == productFeatureId);
        }

        /// <summary>
        /// Update an existing ProductFeature
        /// </summary>
        /// <param name="productFeature">The updated ProductFeature</param>
        public async Task UpdateProductFeatureAsync(ProductFeature productFeature)
        {
            var existingProductFeature = await _context.ProductFeatures.FindAsync(productFeature.ProductFeatureId);

            if (existingProductFeature != null)
            {
                _context.Entry(existingProductFeature).CurrentValues.SetValues(productFeature);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Delete a ProductFeature by its ID
        /// </summary>
        /// <param name="productFeatureId">The ID of the ProductFeature to be deleted</param>
        public async Task DeleteProductFeatureAsync(int productFeatureId)
        {
            var productFeature = await _context.ProductFeatures.FirstOrDefaultAsync(pf => pf.ProductFeatureId == productFeatureId);
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

        /// <summary>
        /// Get all ProductFeatures Additional
        /// </summary>
        /// <returns>A list of all ProductFeatures</returns>
        public async Task<List<ProductFeature>> GetAllAdditionalProductFeaturesByUserAsync(string applicationUserId)
        {
            return await _context.ProductFeatures.Where(x => x.IsAdditional && x.ApplicationUserId == applicationUserId).ToListAsync();
        }

        #endregion

        #region ProductFeatureDetail

        /// <summary>
        /// Create a new ProductFeaturesDetail
        /// </summary>
        /// <param name="productFeaturesDetail">The ProductFeaturesDetail to be added</param>
        public async Task AddProductFeaturesDetailAsync(ProductFeaturesDetail productFeaturesDetail)
        {
            _context.ProductFeaturesDetails.Add(productFeaturesDetail);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get a ProductFeaturesDetail by its ID
        /// </summary>
        /// <param name="productFeaturesDetailId">The ID of the ProductFeaturesDetail</param>
        /// <returns>The ProductFeaturesDetail with the specified ID</returns>
        public async Task<ProductFeaturesDetail> GetProductFeaturesDetailByIdAsync(int productFeaturesDetailId)
        {
            return await _context.ProductFeaturesDetails
                .Include(pfd => pfd.ProductFeaturesIdNavigation)
                .FirstOrDefaultAsync(pfd => pfd.ProductFeaturesDetailId == productFeaturesDetailId);
        }

        /// <summary>
        /// Update an existing ProductFeaturesDetail
        /// </summary>
        /// <param name="productFeaturesDetail">The updated ProductFeaturesDetail</param>
        public async Task UpdateProductFeaturesDetailAsync(ProductFeaturesDetail productFeaturesDetail)
        {
            var existingProductFeaturesDetail = await _context.ProductFeaturesDetails.FindAsync(productFeaturesDetail.ProductFeaturesDetailId);

            if (existingProductFeaturesDetail != null)
            {
                _context.Entry(existingProductFeaturesDetail).CurrentValues.SetValues(productFeaturesDetail);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Delete a ProductFeaturesDetail by its ID
        /// </summary>
        /// <param name="productFeaturesDetailId">The ID of the ProductFeaturesDetail to be deleted</param>
        public async Task DeleteProductFeaturesDetailAsync(int productFeaturesDetailId)
        {
            var productFeaturesDetail = await _context.ProductFeaturesDetails.FindAsync(productFeaturesDetailId);
            if (productFeaturesDetail != null)
            {
                _context.ProductFeaturesDetails.Remove(productFeaturesDetail);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all ProductFeaturesDetails
        /// </summary>
        /// <returns>A list of all ProductFeaturesDetails</returns>
        public async Task<List<ProductFeaturesDetail>> GetAllProductFeaturesDetailsAsync()
        {
            return await _context.ProductFeaturesDetails
                .Include(pfd => pfd.ProductFeaturesIdNavigation)
                .ToListAsync();
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
