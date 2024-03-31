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
            productFeature.CreationDate = DateTime.Now;
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
                productFeature.UpdateDate = DateTime.Now;
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
            productFeaturesDetail.CreationDate = DateTime.Now;
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
                //.Include(pfd => pfd.ProductFeactureCategorysIdNavigation)
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
                productFeaturesDetail.UpdateDate = DateTime.Now;
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
                //.Include(pfd => pfd.ProductFeactureCategorysIdNavigation)
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
                //.Include(pfd => pfd.ProductFeactureCategorysIdNavigation)
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

        /// <summary>
        /// create new product and categoryfecture and fecture relationship
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public async Task AddProductFeaturesCategoryAsync(ProductModel productModel)
        {
            try
            {
                var product = new Product()
                {
                    Name = productModel.Name,
                    Description = productModel.Description,
                    Image = productModel.Image,
                    Price = productModel.Price,
                    Ingredients = productModel.Ingredients,
                    Active = productModel.Active,
                    Serving = productModel.Serving,
                    Stock = productModel.Stock,
                    TypeId = productModel.TypeId,
                    ApplicationUserId = productModel.ApplicationUserId,
                    CreationDate = DateTime.Now
                };
                _context.Products.Add(product);
                await _context.SaveChangesAsync();

                foreach (var productFeatureCategory in productModel.ListProductCategoryFeacture)
                {
                    var category = new ProductFeactureCategory()
                    {
                        Category = productFeatureCategory.Category,
                        CreationDate = DateTime.Now
                    };
                    _context.ProductFeactureCategorys.Add(category);
                    await _context.SaveChangesAsync();

                    foreach (var item in productFeatureCategory.ListProductFeactures)
                    {
                        var feacture = new ProductFeature()
                        {
                            Features = item.Features,
                            MultipleSelection = item.MultipleSelection,
                            IsAdditional = item.IsAdditional,
                            AdditionalValue = item.AdditionalValue,
                            Active = item.Active,
                            ApplicationUserId = item.ApplicationUserId,
                            CreationDate = DateTime.Now
                        };
                        _context.ProductFeatures.Add(feacture);
                        await _context.SaveChangesAsync();

                        _context.ProductFeaturesDetails.Add(new ProductFeaturesDetail()
                        {
                            ProductFeactureCategoryId = category.ProductFeactureCategoryId,
                            ProductFeaturesId = feacture.ProductFeatureId,
                            ProductId = product.ProductId
                        });
                        await _context.SaveChangesAsync();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        /// <summary>
        /// update product and feactures  and category detail all
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public async Task UpdProductFeaturesCategoryAsync(ProductModel productModel)
        {
            try
            {
                var product = _context.Products.Find(productModel.ProductId);

                if (product != null)
                {

                    product.Name = productModel.Name;
                    product.Description = productModel.Description;
                    product.Image = productModel.Image;
                    product.Price = productModel.Price;
                    product.Ingredients = productModel.Ingredients;
                    product.Active = productModel.Active;
                    product.Serving = productModel.Serving;
                    product.Stock = productModel.Stock;
                    product.TypeId = productModel.TypeId;
                    product.ApplicationUserId = productModel.ApplicationUserId;
                    product.UpdateDate = DateTime.Now;

                    _context.Entry(product).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }

                foreach (var productFeatureCategory in productModel.ListProductCategoryFeacture)
                {
                    var category = _context.ProductFeactureCategorys.Find(productFeatureCategory.ProductFeactureCategoryId);

                    if (category != null)
                    {

                        category.Category = productFeatureCategory.Category;
                        category.UpdateDate = DateTime.Now;
                        _context.Entry(category).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        var newCategory = new ProductFeactureCategory()
                        {
                            Category = productFeatureCategory.Category,
                            CreationDate = DateTime.Now
                        };
                        _context.ProductFeactureCategorys.Add(newCategory);
                        await _context.SaveChangesAsync();
                    }

                    foreach (var item in productFeatureCategory.ListProductFeactures)
                    {
                        var feacture = _context.ProductFeatures.Find(item.ProductFeatureId);

                        if (feacture != null)
                        {
                            feacture.Features = item.Features;
                            feacture.MultipleSelection = item.MultipleSelection;
                            feacture.IsAdditional = item.IsAdditional;
                            feacture.AdditionalValue = item.AdditionalValue;
                            feacture.Active = item.Active;
                            feacture.ApplicationUserId = item.ApplicationUserId;
                            feacture.UpdateDate = DateTime.Now;
                            _context.Entry(feacture).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            var newFeacture = new ProductFeature()
                            {
                                Features = item.Features,
                                MultipleSelection = item.MultipleSelection,
                                IsAdditional = item.IsAdditional,
                                AdditionalValue = item.AdditionalValue,
                                Active = item.Active,
                                ApplicationUserId = item.ApplicationUserId,
                                CreationDate = DateTime.Now
                            };
                            _context.ProductFeatures.Add(newFeacture);
                            await _context.SaveChangesAsync();
                        }

                        var detail = await _context.ProductFeaturesDetails.Where(x => x.ProductFeaturesDetailId == item.ProductFeatureId && x.ProductId == productModel.ProductId).FirstOrDefaultAsync();

                        if (detail != null)
                        {
                            detail.ProductFeactureCategoryId = category.ProductFeactureCategoryId;
                            detail.ProductFeaturesId = feacture.ProductFeatureId;
                            _context.Entry(feacture).State = EntityState.Modified;
                            await _context.SaveChangesAsync();
                        }
                        else
                        {
                            _context.ProductFeaturesDetails.Add(new ProductFeaturesDetail()
                            {
                                ProductFeactureCategoryId = category.ProductFeactureCategoryId,
                                ProductFeaturesId = feacture.ProductFeatureId,
                                ProductId = productModel.ProductId
                            });
                            await _context.SaveChangesAsync();
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        #endregion
    }
}
