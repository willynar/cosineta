using System.Data;

namespace Entities.Interfaces
{
    public interface IProductService
    {
        /// <summary>
        /// gets all list of products whit  the categories and chef
        /// </summary>
        /// <returns></returns>
        Task<List<Product>> GetAllProducts();

        /// <summary>
        /// get all products by user
        /// </summary>
        /// <param name="applicationUserId"></param>
        /// <returns></returns>
        Task<List<Product>> GetAllProductsByUser(string applicationUserId);

        /// <summary>
        /// get product by id product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        Task<Product> GetProductById(int productId);

        /// <summary>
        /// save new product
        /// </summary>
        /// <param name="product"></param>
        Task AddProduct(Product product);

        /// <summary>
        /// update product by id
        /// </summary>
        /// <param name="updatedProduct"></param>
        Task UpdProductById(Product updatedProduct);

        /// <summary>
        /// delete product by id product
        /// </summary>
        /// <param name="productId"></param>
        Task DeleteProductById(int productId);

        /// <summary>
        /// get all products paginated by store procedure
        /// </summary>
        /// <param name="objectParams"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task<List<ProductStoreProcedure>> GetAllProductsFromPaginated(ProductPaginatedParams objectParams);

        /// <summary>
        /// list  datatable  to list<T>
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        List<ProductStoreProcedure> ListProductsFronStoreProcedure(DataTable data);


        #region Reviews

        /// <summary>
        /// call actions necesary to save new review product
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task ActionsAddProductReview(Review review);

        /// <summary>
        /// call actions necesary to update review product
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task ActionsUpdProductReview(Review review);

        /// <summary>
        /// list revies stars
        /// </summary>
        /// <param name="review"></param>
        /// <returns></returns>
        Task<List<int>> ListReviewStarsProductId(Review review);

        /// <summary>
        /// update stars averrange fro product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="averageStars"></param>
        /// <returns></returns>
        Task UpdStarsProduct(int? productId, decimal averageStars, int quantityReview);

        Task<List<Review>> GetAllProductReviews();

        /// <summary>
        /// get ProductReview by id ProductReview
        /// </summary>
        /// <param name="ProductReviewId"></param>
        /// <returns></returns>
        Task<Review> GetProductReviewByProductId(int productId);

        /// <summary>
        /// save new ProductReview
        /// </summary>
        /// <param name="review"></param>
        Task AddProductReview(Review review);

        /// <summary>
        /// update ProductReview by id
        /// </summary>
        /// <param name="updatedReview"></param>
        Task UpdProductReviewById(Review updatedReview);

        /// <summary>
        /// delete ProductReview by id ProductReview
        /// </summary>
        /// <param name="ReviewId"></param>
        Task DeleteProductReviewById(int ReviewId);

        #endregion

        #region Schedule
        /// <summary>
        /// Create a new ProductSchedule
        /// </summary>
        /// <param name="productSchedule">The ProductSchedule to be added</param>
        Task AddProductScheduleAsync(ProductSchedule productSchedule);

        /// <summary>
        /// Get a ProductSchedule by its ID
        /// </summary>
        /// <param name="productScheduleId">The ID of the ProductSchedule</param>
        /// <returns>The ProductSchedule with the specified ID</returns>
        Task<ProductSchedule> GetProductScheduleByIdAsync(int productScheduleId);

        /// <summary>
        /// Update an existing ProductSchedule
        /// </summary>
        /// <param name="productSchedule">The updated ProductSchedule</param>
        Task UpdateProductScheduleAsync(ProductSchedule productSchedule);

        /// <summary>
        /// Delete a ProductSchedule by its ID
        /// </summary>
        /// <param name="productScheduleId">The ID of the ProductSchedule to be deleted</param>
        Task DeleteProductScheduleAsync(int productScheduleId);

        /// <summary>
        /// Get all ProductSchedules
        /// </summary>
        /// <returns>A list of all ProductSchedules</returns>
        Task<List<ProductSchedule>> GetAllProductSchedulesAsync();

        /// <summary>
        /// Get all ProductSchedules by product Id
        /// </summary>
        /// <returns>A list of all ProductSchedules</returns>
        Task<List<ProductSchedule>> GetAllProductSchedulesByProductIdAsync(int productId);
        #endregion
    }
}
