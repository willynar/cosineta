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
                .Include(p => p.CategoryIdNavigation)
                .Include(p => p.ChefIdNavigation)
                .ToListAsync();

        /// <summary>
        /// get product by id product
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        public async Task<Product> GetProductById(int productId) =>
          await _context.Products
                .Include(p => p.CategoryIdNavigation)
                .Include(p => p.ChefIdNavigation)
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
                product.ChefId = updatedProduct.ChefId;
                product.Serving = updatedProduct.Serving;
                product.Ingredients = updatedProduct.Ingredients;
                product.Active = updatedProduct.Active;
                product.CategoryId = updatedProduct.CategoryId;

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
        /// <param name="productReview"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task ActionsAddProductReview(ProductReview productReview)
        {
            try
            {
                await AddProductReview(productReview);
                List<int> productReviews = await ListReviewStarsProductId(productReview);
                int average = (int)Math.Round(productReviews.Average());
                await UpdStarsProduct(productReview.ProductId, average);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// call actions necesary to update review product
        /// </summary>
        /// <param name="productReview"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task ActionsUpdProductReview(ProductReview productReview)
        {
            try
            {
                await UpdProductReviewById(productReview);
                List<int> productReviews = await ListReviewStarsProductId(productReview);
                int average = (int)Math.Round(productReviews.Average());
                await UpdStarsProduct(productReview.ProductId, average);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// list revies stars
        /// </summary>
        /// <param name="productReview"></param>
        /// <returns></returns>
        public async Task<List<int>> ListReviewStarsProductId(ProductReview productReview) => 
            await _context.ProductsReviews.Where(x => x.ProductId == productReview.ProductId).Select(x => x.Stars).ToListAsync();

        /// <summary>
        /// update stars averrange fro product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="averageStars"></param>
        /// <returns></returns>
        public async Task UpdStarsProduct(int? productId, int averageStars)
        {
            var ProductReview = _context.Products.Find(productId);

            if (ProductReview != null)
            {
                ProductReview.Review = averageStars;

                _context.Entry(ProductReview).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<ProductReview>> GetAllProductReviews() =>
         await _context.ProductsReviews.ToListAsync();

        /// <summary>
        /// get ProductReview by id ProductReview
        /// </summary>
        /// <param name="ProductReviewId"></param>
        /// <returns></returns>
        public async Task<ProductReview> GetProductReviewByProductId(int productId) =>
          await _context.ProductsReviews.FirstOrDefaultAsync(p => p.ProductId == productId);

        /// <summary>
        /// save new ProductReview
        /// </summary>
        /// <param name="productReview"></param>
        public async Task AddProductReview(ProductReview productReview)
        {
            _context.ProductsReviews.Add(productReview);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// update ProductReview by id
        /// </summary>
        /// <param name="updatedProductReview"></param>
        public async Task UpdProductReviewById(ProductReview updatedProductReview)
        {
            var ProductReview = _context.ProductsReviews.Find(updatedProductReview.IdProductReview);

            if (ProductReview != null)
            {
                ProductReview.Title = updatedProductReview.Title;
                ProductReview.Description = updatedProductReview.Description;
                ProductReview.Author = updatedProductReview.Author;
                ProductReview.ProductId = updatedProductReview.ProductId;

                _context.Entry(ProductReview).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// delete ProductReview by id ProductReview
        /// </summary>
        /// <param name="productReviewId"></param>
        public async Task DeleteProductReviewById(int productReviewId)
        {
            var ProductReview = _context.ProductsReviews.Find(productReviewId);

            if (ProductReview != null)
            {
                _context.ProductsReviews.Remove(ProductReview);
                await _context.SaveChangesAsync();
            }
        }
        #endregion
    }
}
