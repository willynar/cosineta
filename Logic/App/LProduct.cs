﻿using Entities.App;
using Microsoft.Data.SqlClient;
using Microsoft.Win32;
using System.Collections.Generic;
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

        /// <summary>
        /// gets all list of products whit  the categories and chef
        /// </summary>
        /// <returns></returns>
        public async Task<List<Product>> GetAllProducts() =>
          await _context.Products
                .ToListAsync();

        /// <summary>
        /// get product by id product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int productId) =>
          await _context.Products
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
                        ChefId = data.Rows[i]["ChefId"] != DBNull.Value ? (int)data.Rows[i]["ChefId"] : null,
                        Price = data.Rows[i]["Price"] != DBNull.Value ? (decimal)data.Rows[i]["Price"] : 0,
                        Serving = data.Rows[i]["Serving"] != DBNull.Value ? (int)data.Rows[i]["Serving"] : 0,
                        Ingredients = data.Rows[i]["Ingredients"] != DBNull.Value ? data.Rows[i]["Ingredients"].ToString() : null,
                        ProductActive = data.Rows[i]["ProductActive"] != DBNull.Value ? (bool)data.Rows[i]["ProductActive"] : false,
                        CategoryId = data.Rows[i]["CategoryId"] != DBNull.Value ? (int)data.Rows[i]["CategoryId"] : 0,
                        Review = data.Rows[i]["Review"] != DBNull.Value ? (decimal)data.Rows[i]["Review"] : null,
                        CategoryName = data.Rows[i]["CategoryName"] != DBNull.Value ? data.Rows[i]["CategoryName"].ToString() : null,
                        ChefName = data.Rows[i]["ChefName"] != DBNull.Value ? data.Rows[i]["ChefName"].ToString() : null,
                        ChefPhone = data.Rows[i]["ChefPhone"] != DBNull.Value ? data.Rows[i]["ChefPhone"].ToString() : null,
                        ChefCellphone = data.Rows[i]["ChefCellphone"] != DBNull.Value ? data.Rows[i]["ChefCellphone"].ToString() : null,
                        ChefEmail = data.Rows[i]["ChefEmail"] != DBNull.Value ? data.Rows[i]["ChefEmail"].ToString() : null,
                        ChefImage = data.Rows[i]["ChefImage"] != DBNull.Value ? data.Rows[i]["ChefImage"].ToString() : null,
                        ChefCover = data.Rows[i]["ChefCover"] != DBNull.Value ? data.Rows[i]["ChefCover"].ToString() : null,
                        ChefGender = data.Rows[i]["ChefGender"] != DBNull.Value ? data.Rows[i]["ChefGender"].ToString() : null,
                        ChefNationality = data.Rows[i]["ChefNationality"] != DBNull.Value ? data.Rows[i]["ChefNationality"].ToString() : null,
                        ChefCountry = data.Rows[i]["ChefCountry"] != DBNull.Value ? data.Rows[i]["ChefCountry"].ToString() : null,
                        ChefDepartment = data.Rows[i]["ChefDepartment"] != DBNull.Value ? data.Rows[i]["ChefDepartment"].ToString() : null,
                        ChefStatus = data.Rows[i]["ChefStatus"] != DBNull.Value ? data.Rows[i]["ChefStatus"].ToString() : null,
                        ChefCertified = data.Rows[i]["ChefCertified"] != DBNull.Value ? (bool)data.Rows[i]["ChefCertified"] : false,
                        ChefCertifiedMessage = data.Rows[i]["ChefCertifiedMessage"] != DBNull.Value ? data.Rows[i]["ChefCertifiedMessage"].ToString() : null,
                        ChefDescription = data.Rows[i]["ChefDescription"] != DBNull.Value ? data.Rows[i]["ChefDescription"].ToString() : null,
                        ChefActive = data.Rows[i]["ChefActive"] != DBNull.Value ? (bool)data.Rows[i]["ChefActive"] : false,
                        CategoryImage = data.Rows[i]["CategoryImage"] != DBNull.Value ? data.Rows[i]["CategoryImage"].ToString() : null,
                        CategoryActive = data.Rows[i]["CategoryActive"] != DBNull.Value ? (bool)data.Rows[i]["CategoryActive"] : false
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
    }
}
