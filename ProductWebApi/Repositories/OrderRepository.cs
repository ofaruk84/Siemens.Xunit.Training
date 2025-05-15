using ProductWebApi.Modals;

namespace ProductWebApi.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        public List<Order> GetOrdersByUserId(int userId)
        {
            // Sample/mock implementation for demo purposes
            return new List<Order>
        {
            new Order { Id = 1, UserId = userId, ProductName = "Pen", OrderDate = DateTime.Now },
            new Order { Id = 2, UserId = userId, ProductName = "Notebook", OrderDate = DateTime.Now.AddDays(-1) }
        };
        }
    }
}
