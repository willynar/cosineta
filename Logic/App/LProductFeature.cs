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
            return (from PF in _context.ProductFeatures
                    join DPF in _context.ProductFeaturesDetails on PF.ProductFeatureId equals DPF.ProductId
                    join PFC in _context.ProductFeactureCategorys on DPF.ProductFeactureCategoryId equals PFC.ProductFeactureCategoryId
                    where PFC.IsAdditional && PF.ApplicationUserId == applicationUserId
                    select PF).Distinct().ToList();
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
                else
                {
                    product = new Product()
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
                }
                //to categorys
                await SaveProductCategory(productModel, product);
                //to shedules
                await SaveProductSchedules(productModel, product);
                //to  feactures category
                await SaveFeacturesCategory(productModel, product);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// save  product feacture category detail
        /// </summary>
        /// <param name="productModel"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task SaveFeacturesCategory(ProductModel productModel, Product product)
        {
            foreach (var productFeatureCategory in productModel.ListProductCategoryFeacture)
            {
                var categoryFeacture = _context.ProductFeactureCategorys.Find(productFeatureCategory.ProductFeactureCategoryId);

                if (categoryFeacture != null)
                {

                    categoryFeacture.Description = productFeatureCategory.Description;
                    categoryFeacture.Required = productFeatureCategory.Required;
                    categoryFeacture.IsAdditional = productFeatureCategory.IsAdditional;
                    categoryFeacture.MultipleSelection = productFeatureCategory.MultipleSelection;
                    categoryFeacture.ProductId = product.ProductId;
                    categoryFeacture.UpdateDate = DateTime.Now;
                    _context.Entry(categoryFeacture).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    categoryFeacture = new ProductFeactureCategory()
                    {
                        Description = productFeatureCategory.Description,
                        Required = productFeatureCategory.Required,
                        IsAdditional = productFeatureCategory.IsAdditional,
                        MultipleSelection = productFeatureCategory.MultipleSelection,
                        ProductId = product.ProductId,
                        CreationDate = DateTime.Now
                    };
                    _context.ProductFeactureCategorys.Add(categoryFeacture);
                    await _context.SaveChangesAsync();
                }


                List<ProductFeaturesDetail> deteDetail = new();
                deteDetail = _context.ProductFeaturesDetails.Where(x => x.ProductFeactureCategoryId == categoryFeacture.ProductFeactureCategoryId && x.ProductId == product.ProductId).Select(x => x).ToList();
                if (deteDetail.Count > 0)
                {
                    _context.ProductFeaturesDetails.RemoveRange(deteDetail);
                    await _context.SaveChangesAsync();
                }

                foreach (var item in productFeatureCategory.ListDetailFeatures)
                {
                    var feacture = _context.ProductFeatures.Find(item.ProductFeactureId);

                    if (feacture != null)
                    {
                        feacture.Name = item.Name;
                        feacture.Description = item.Description;
                        feacture.AdditionalValue = item.AdditionalValue;
                        feacture.Stock = item.Stock;
                        feacture.Active = item.Active;
                        feacture.ApplicationUserId = item.ApplicationUserId;
                        feacture.UpdateDate = DateTime.Now;
                        _context.Entry(feacture).State = EntityState.Modified;
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        feacture = new ProductFeature()
                        {
                            Name = item.Name,
                            Description = item.Description,
                            AdditionalValue = item.AdditionalValue,
                            Stock = item.Stock,
                            Active = item.Active,
                            ApplicationUserId = item.ApplicationUserId,
                            CreationDate = DateTime.Now
                        };
                        _context.ProductFeatures.Add(feacture);
                        await _context.SaveChangesAsync();
                    }


                    _context.ProductFeaturesDetails.Add(new ProductFeaturesDetail()
                    {
                        ProductFeactureCategoryId = categoryFeacture.ProductFeactureCategoryId,
                        ProductFeatureId = feacture.ProductFeatureId,
                        ProductId = product.ProductId
                    });
                    await _context.SaveChangesAsync();


                }
            }
        }

        /// <summary>
        /// save  category detail
        /// </summary>
        /// <param name="productModel"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task SaveProductCategory(ProductModel productModel, Product product)
        {
            List<ProductCategory> deteDetail = new();
            deteDetail = _context.ProductCategorys.Where(x => x.ProductId == product.ProductId).Select(x => x).ToList();
            if (deteDetail.Count > 0)
            {
                _context.ProductCategorys.RemoveRange(deteDetail);
                await _context.SaveChangesAsync();
            }

            foreach (var productFeatureCategory in productModel.Categories)
            {
                var category = _context.Categories.Find(productFeatureCategory.CategoryId);

                if (category != null)
                {

                    category.Name = productFeatureCategory.Name;
                    category.Image = productFeatureCategory.Image;
                    category.Active = productFeatureCategory.Active;
                    category.UpdateDate = DateTime.Now;
                    _context.Entry(category).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    category = new Category()
                    {
                        Name = productFeatureCategory.Name,
                        Image = productFeatureCategory.Image,
                        Active = productFeatureCategory.Active,
                        CreationDate = DateTime.Now
                    };
                    _context.Categories.Add(category);
                    await _context.SaveChangesAsync();
                }



                _context.ProductCategorys.Add(new ProductCategory()
                {
                    CategoryId = category.CategoryId,
                    ProductId = product.ProductId
                });
                await _context.SaveChangesAsync();

            }
        }

        /// <summary>
        /// svae  shedules detail
        /// </summary>
        /// <param name="productModel"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public async Task SaveProductSchedules(ProductModel productModel, Product product)
        {
            List<ProductSchedule> deteDetail = new();
            deteDetail = _context.ProductSchedules.Where(x => x.ProductId == product.ProductId && x.PublicationStarTime < DateTime.Now).Select(x => x).ToList();

            if (deteDetail.Count > 0)
            {
                _context.ProductSchedules.RemoveRange(deteDetail);
                await _context.SaveChangesAsync();
            }

            foreach (var productShedule in productModel.ListProductSchedule)
            {
                var schedule = _context.ProductSchedules.Find(productShedule.ProductScheduleId);

                if (schedule != null)
                {

                    schedule.StarTime = productShedule.StarTime;
                    schedule.EndTime = productShedule.EndTime;
                    schedule.PublicationStarTime = productShedule.PublicationStarTime;
                    schedule.PublicationEndTime = productShedule.PublicationEndTime;
                    schedule.ProductId = productShedule.ProductId;
                    schedule.Active = productShedule.Active;
                    schedule.UpdateDate = DateTime.Now;
                    _context.Entry(schedule).State = EntityState.Modified;
                    await _context.SaveChangesAsync();
                }
                else
                {
                    schedule = new ProductSchedule()
                    {
                        StarTime = productShedule.StarTime,
                        EndTime = productShedule.EndTime,
                        PublicationStarTime = productShedule.PublicationStarTime,
                        PublicationEndTime = productShedule.PublicationEndTime,
                        ProductId = product.ProductId,
                        Active = productShedule.Active,
                        CreationDate = DateTime.Now
                    };
                    _context.ProductSchedules.Add(schedule);
                    await _context.SaveChangesAsync();
                }

            }
        }
        #endregion
    }
}
