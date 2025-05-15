using ProductWebApi.Modals;
using ProductWebApi.Repositories;

namespace ProductWebApi.Services
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _repo;

        public OrderService(IOrderRepository repo)
        {
            _repo = repo;
        }

        public List<Order> GetOrdersForUser(int userId)
        {
            return _repo.GetOrdersByUserId(userId);
        }
    }
}
