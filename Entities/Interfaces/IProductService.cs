﻿using System.Data;

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
    }
}
