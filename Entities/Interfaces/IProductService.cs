﻿using Microsoft.EntityFrameworkCore;
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
        /// <param name="productReview"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task ActionsAddProductReview(ProductReview productReview);

        /// <summary>
        /// call actions necesary to update review product
        /// </summary>
        /// <param name="productReview"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        Task ActionsUpdProductReview(ProductReview productReview);

        /// <summary>
        /// list revies stars
        /// </summary>
        /// <param name="productReview"></param>
        /// <returns></returns>
        Task<List<int>> ListReviewStarsProductId(ProductReview productReview);

        /// <summary>
        /// update stars averrange fro product
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="averageStars"></param>
        /// <returns></returns>
        Task UpdStarsProduct(int? productId, int averageStars);

        Task<List<ProductReview>> GetAllProductReviews();

        /// <summary>
        /// get ProductReview by id ProductReview
        /// </summary>
        /// <param name="ProductReviewId"></param>
        /// <returns></returns>
        Task<ProductReview> GetProductReviewByProductId(int productId);

        /// <summary>
        /// save new ProductReview
        /// </summary>
        /// <param name="productReview"></param>
        Task AddProductReview(ProductReview productReview);

        /// <summary>
        /// update ProductReview by id
        /// </summary>
        /// <param name="updatedProductReview"></param>
        Task UpdProductReviewById(ProductReview updatedProductReview);

        /// <summary>
        /// delete ProductReview by id ProductReview
        /// </summary>
        /// <param name="productReviewId"></param>
        Task DeleteProductReviewById(int productReviewId);

        #endregion
    }
}
