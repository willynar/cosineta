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
    }
}
