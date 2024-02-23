using Entities.App;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
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

        #region Product

        /// <summary>
        /// gets all list of products 
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAllProducts() =>
          await _context.Products.Include(p => p.ApplicationUserIdNavigation)
                                .Include(p => p.ProductCategorys)
                                    .ThenInclude(pc => pc.CategoryIdNavigation)
                                .Include(p => p.ProductFeaturesDetails)
                                    .ThenInclude(pfd => pfd.ProductFeaturesIdNavigation)
                                .Include(p => p.ProductSchedules)
                                .ToListAsync();

        /// <summary>
        /// get all products by user
        /// </summary>
        /// <param name="applicationUserId"></param>
        /// <returns></returns>
        public async Task<List<Product>> GetAllProductsByUser(string applicationUserId) =>
       await _context.Products.Where(x => x.ApplicationUserId == applicationUserId).Include(p => p.ApplicationUserIdNavigation)
                             .Include(p => p.ProductCategorys)
                                 .ThenInclude(pc => pc.CategoryIdNavigation)
                             .Include(p => p.ProductFeaturesDetails)
                                 .ThenInclude(pfd => pfd.ProductFeaturesIdNavigation)
                             .Include(p => p.ProductSchedules)
                             .ToListAsync();

        /// <summary>
        /// get product by id product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int productId) =>
             await _context.Products.Include(p => p.ApplicationUserIdNavigation)
                                .Include(p => p.ProductCategorys)
                                    .ThenInclude(pc => pc.CategoryIdNavigation)
                                .Include(p => p.ProductFeaturesDetails)
                                    .ThenInclude(pfd => pfd.ProductFeaturesIdNavigation)
                                .Include(p => p.ProductSchedules)
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
                product.Ingredients = updatedProduct.Ingredients;
                product.Serving = updatedProduct.Serving;
                product.Active = updatedProduct.Active;

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
        /// <param name="objectParams"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<List<ProductStoreProcedure>> GetAllProductsFromPaginated(ProductPaginatedParams objectParams)
        {
            try
            {
                string? Filter = objectParams switch
                {
                    var op when op.PriceMin != null && op.PriceMax != null && op.Review != null && op.CategoryValue != null && op.SorterValue != null && op.FilterValue != null => "All",

                    var op when op.PriceMin != null && op.PriceMax != null && op.Review == null && op.CategoryValue == null && op.FilterValue == null => "PriceRange",

                    var op when op.PriceMin == null && op.PriceMax == null && op.Review == null && op.CategoryValue == null && op.FilterValue != null => "FilterValue",

                    var op when op.PriceMin == null && op.PriceMax == null && op.Review == null && op.CategoryValue != null && op.FilterValue == null => "Category",

                    var op when op.PriceMin == null && op.PriceMax == null && op.Review != null && op.CategoryValue == null && op.FilterValue == null => "Review",

                    var op when op.PriceMin != null && op.PriceMax != null && op.Review == null && op.CategoryValue != null && op.FilterValue == null => "PriceRange,Category",

                    var op when op.PriceMin == null && op.PriceMax == null && op.Review != null && op.CategoryValue != null && op.FilterValue == null => "Review,Category",

                    var op when op.PriceMin != null && op.PriceMax != null && op.Review != null && op.CategoryValue == null && op.FilterValue == null => "PriceRange,Review",

                    var op when op.PriceMin != null && op.PriceMax != null && op.Review == null && op.CategoryValue == null && op.FilterValue == null => "PriceRange,FilterValue",

                    var op when op.PriceMin == null && op.PriceMax == null && op.Review != null && op.CategoryValue != null && op.FilterValue == null => "Category,FilterValue",

                    var op when op.PriceMin == null && op.PriceMax == null && op.Review != null && op.CategoryValue == null && op.FilterValue != null => "Review,FilterValue",

                    var op when op.PriceMin != null && op.PriceMax != null && op.Review != null && op.CategoryValue != null && op.FilterValue == null => "PriceRange,Category,Review",

                    var op when op.PriceMin != null && op.PriceMax != null && op.Review == null && op.CategoryValue != null && op.FilterValue != null => "PriceRange,Category,FilterValue",

                    var op when op.PriceMin != null && op.PriceMax != null && op.Review != null && op.CategoryValue == null && op.FilterValue != null => "PriceRange,Review,FilterValue",

                    var op when op.PriceMin == null && op.PriceMax == null && op.Review != null && op.CategoryValue != null && op.FilterValue != null => "Category,Review,FilterValue",

                    _ => null,
                };
                SqlParameter[] parameters =
                {
                      new SqlParameter("@Page", objectParams.Page),
                      new SqlParameter("@Reg", objectParams.Reg),
                      new SqlParameter("@Filter", Filter),
                      new SqlParameter("@FilterValue", objectParams.FilterValue),
                      new SqlParameter("@PriceMin", objectParams.PriceMin),
                      new SqlParameter("@PriceMax", objectParams.PriceMax),
                      new SqlParameter("@Review", objectParams.Review),
                      new SqlParameter("@CategoryValue", objectParams.CategoryValue != null?string.Join(",", objectParams.CategoryValue):null),
                      new SqlParameter("@SorterValue", objectParams.SorterValue),
                      new SqlParameter("@Sort", objectParams.Sort ? 1 : 0)
                };

                //Se crea array con los parametros

                var Data = await IExecuteProceduresService.GetPaginatedProducts(parameters);
                if (!Data.Columns.Contains("error"))
                {
                    return ListProductsFronStoreProcedure(Data);
                }
                else
                {
                    throw new Exception($"{Data.Rows[0][0]}");
                }

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
                        TypeId = data.Rows[i]["TypeId"] != DBNull.Value ? (int)data.Rows[i]["TypeId"] : null,
                        Price = data.Rows[i]["Price"] != DBNull.Value ? (decimal)data.Rows[i]["Price"] : 0,
                        //Serving = data.Rows[i]["Serving"] != DBNull.Value ? (int)data.Rows[i]["Serving"] : 0,
                        Ingredients = data.Rows[i]["Ingredients"] != DBNull.Value ? data.Rows[i]["Ingredients"].ToString() : null,
                        ProductActive = data.Rows[i]["ProductActive"] != DBNull.Value ? (bool)data.Rows[i]["ProductActive"] : false,
                        Review = data.Rows[i]["Review"] != DBNull.Value ? (decimal)data.Rows[i]["Review"] : null,
                        ApplicationUserId = data.Rows[i]["ApplicationUserId"] != DBNull.Value ? data.Rows[i]["ApplicationUserId"].ToString() : null,
                        UserName = data.Rows[i]["UserName"] != DBNull.Value ? data.Rows[i]["UserName"].ToString() : null,
                        UserLastName = data.Rows[i]["UserLastName"] != DBNull.Value ? data.Rows[i]["UserLastName"].ToString() : null,
                        Categorys = data.Rows[i]["Categories"] != DBNull.Value ? JsonConvert.DeserializeObject<List<Category>>($"[{data.Rows[i]["Categories"]}]".Replace("\"\"", "\"")) : null,
                        ProductFeatures = data.Rows[i]["ProductFeatures"] != DBNull.Value ? JsonConvert.DeserializeObject<List<ProductFeature>>($"[{data.Rows[i]["ProductFeatures"]}]".Replace("\"\"", "\"")) : null


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
        #endregion

        #region Reviews

        /// <summary>
        /// call actions necesary to save new review product
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task ActionsAddProductReview(Review review)
        {
            try
            {
                await AddProductReview(review);
                List<int> reviews = await ListReviewStarsProductId(review);
                int average = (int)Math.Round(reviews.Average());
                await UpdStarsProduct(review.ProductId, average);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// call actions necesary to update review product
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task ActionsUpdProductReview(Review review)
        {
            try
            {
                await UpdProductReviewById(review);
                List<int> reviews = await ListReviewStarsProductId(review);
                int average = (int)Math.Round(reviews.Average());
                await UpdStarsProduct(review.ProductId, average);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// list revies stars
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        public async Task<List<int>> ListReviewStarsProductId(Review review) =>
            await _context.Reviews.Where(x => x.ProductId == review.ProductId).Select(x => x.Stars).ToListAsync();

        /// <summary>
        /// update stars averrange fro product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="averageStars"></param>
        /// <returns></returns>
        public async Task UpdStarsProduct(int? productId, int averageStars)
        {
            var Review = _context.Products.Find(productId);

            if (Review != null)
            {
                Review.Review = averageStars;

                _context.Entry(Review).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Review>> GetAllProductReviews() =>
         await _context.Reviews.ToListAsync();

        /// <summary>
        /// get Review by id Review
        /// </summary>
        /// <param name="ProductReviewId"></param>
        /// <returns></returns>
        public async Task<Review> GetProductReviewByProductId(int productId) =>
          await _context.Reviews.FirstOrDefaultAsync(p => p.ProductId == productId);

        /// <summary>
        /// save new Review
        /// </summary>
        /// <param name="review"></param>
        public async Task AddProductReview(Review review)
        {
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// update Review by id
        /// </summary>
        /// <param name="updatedReview"></param>
        public async Task UpdProductReviewById(Review updatedReview)
        {
            var Review = _context.Reviews.Find(updatedReview.ReviewId);

            if (Review != null)
            {
                Review.Title = updatedReview.Title;
                Review.Description = updatedReview.Description;
                Review.Author = updatedReview.Author;
                Review.ProductId = updatedReview.ProductId;

                _context.Entry(Review).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// delete Review by id Review
        /// </summary>
        /// <param name="reviewId"></param>
        public async Task DeleteProductReviewById(int reviewId)
        {
            var Review = _context.Reviews.Find(reviewId);

            if (Review != null)
            {
                _context.Reviews.Remove(Review);
                await _context.SaveChangesAsync();
            }
        }
        #endregion

        #region Schedule
        /// <summary>
        /// Create a new ProductSchedule
        /// </summary>
        /// <param name="productSchedule">The ProductSchedule to be added</param>
        public async Task AddProductScheduleAsync(ProductSchedule productSchedule)
        {
            _context.ProductSchedules.Add(productSchedule);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get a ProductSchedule by its ID
        /// </summary>
        /// <param name="productScheduleId">The ID of the ProductSchedule</param>
        /// <returns>The ProductSchedule with the specified ID</returns>
        public async Task<ProductSchedule> GetProductScheduleByIdAsync(int productScheduleId)
        {
            return await _context.ProductSchedules.FirstOrDefaultAsync(ps => ps.UserScheduleId == productScheduleId);
        }

        /// <summary>
        /// Update an existing ProductSchedule
        /// </summary>
        /// <param name="productSchedule">The updated ProductSchedule</param>
        public async Task UpdateProductScheduleAsync(ProductSchedule productSchedule)
        {
            _context.ProductSchedules.Update(productSchedule);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Delete a ProductSchedule by its ID
        /// </summary>
        /// <param name="productScheduleId">The ID of the ProductSchedule to be deleted</param>
        public async Task DeleteProductScheduleAsync(int productScheduleId)
        {
            var productSchedule = await _context.ProductSchedules.FirstOrDefaultAsync(ps => ps.UserScheduleId == productScheduleId);
            if (productSchedule != null)
            {
                _context.ProductSchedules.Remove(productSchedule);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all ProductSchedules
        /// </summary>
        /// <returns>A list of all ProductSchedules</returns>
        public async Task<List<ProductSchedule>> GetAllProductSchedulesAsync()
        {
            return await _context.ProductSchedules.ToListAsync();
        }

        public async Task<List<ProductSchedule>> GetAllProductSchedulesByProductIdAsync(int productId)
        {
            return await _context.ProductSchedules.Where(x => x.ProductId == productId).ToListAsync();
        }
        #endregion
    }
}
