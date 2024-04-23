using Entities.App;

namespace Logic.App
{
    public class LOrder: IOrderService
    {
        private readonly ApplicationDbContext _context;

        public LOrder(ApplicationDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Create a new Order
        /// </summary>
        /// <param name="order">The Order to be added</param>
        public async Task AddOrderAsync(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Get an Order by its ID
        /// </summary>
        /// <param name="orderId">The ID of the Order</param>
        /// <returns>The Order with the specified ID</returns>
        public async Task<Order> GetOrderByIdAsync(int orderId)
        {
            return await _context.Orders
                .Include(o => o.OrderProducts)
                .ThenInclude(opfd => opfd.OrderIdNavigation)
                .FirstOrDefaultAsync(o => o.OrderId == orderId);
        }

        /// <summary>
        /// Update an existing Order
        /// </summary>
        /// <param name="order">The updated Order</param>
        public async Task UpdateOrderAsync(Order order)
        {
            var existingOrder = await _context.Orders
                .Include(o => o.OrderProducts)
                .FirstOrDefaultAsync(o => o.OrderId == order.OrderId);

            if (existingOrder != null)
            {
                _context.Entry(existingOrder).CurrentValues.SetValues(order);
                await _context.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Get all Orders by user purchase
        /// </summary>
        /// <returns>A list of all Orders</returns>
        public async Task<List<Order>> GetAllOrdersByAplicationUserPurchaseAsync(string applicationUserIdPurchase)
        {
            return await _context.Orders
                .Where(x => x.ApplicationUserId == applicationUserIdPurchase)
                .Include(o => o.OrderProducts)
                .ThenInclude(opfd => opfd.OrderIdNavigation)
                .ToListAsync();
        }

        /// <summary>
        /// Get all Orders by user seller
        /// </summary>
        /// <returns>A list of all Orders</returns>
        public async Task<List<Order>> GetAllOrdersByApplicationUserSellerAsync(string applicationUserIdSeller)
        {
            return await _context.Orders
                .Include(o => o.ApplicationUserIdNavigation)
                .Include(o => o.OrderProducts)
                    .ThenInclude(opfd => opfd.OrderIdNavigation)
                .Where(o => o.OrderProducts.Any(opfd => opfd.ApplicationUserIdSeller == applicationUserIdSeller))
                .ToListAsync();
        }

    }
}
