namespace Entities.Interfaces
{
    public interface IOrderService
    {

        /// <summary>
        /// Create a new Order
        /// </summary>
        /// <param name="order">The Order to be added</param>
        Task AddOrderAsync(Order order);

        /// <summary>
        /// Get an Order by its ID
        /// </summary>
        /// <param name="orderId">The ID of the Order</param>
        /// <returns>The Order with the specified ID</returns>
        Task<Order> GetOrderByIdAsync(int orderId);

        /// <summary>
        /// Update an existing Order
        /// </summary>
        /// <param name="order">The updated Order</param>
        Task UpdateOrderAsync(Order order);

        /// <summary>
        /// Get all Orders by user purchase
        /// </summary>
        /// <returns>A list of all Orders</returns>
        Task<List<Order>> GetAllOrdersByAplicationUserPurchaseAsync(string applicationUserIdPurchase);

        /// <summary>
        /// Get all Orders by user seller
        /// </summary>
        /// <returns>A list of all Orders</returns>
        Task<List<Order>> GetAllOrdersByApplicationUserSellerAsync(string applicationUserIdSeller);
    }
}
