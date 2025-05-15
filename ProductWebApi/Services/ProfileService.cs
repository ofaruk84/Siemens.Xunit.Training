using ProductWebApi.Modals;

namespace ProductWebApi.Services
{
    public class ProfileService : IProfileService
    {
        private readonly IOrderService _orderService;

        public ProfileService(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public List<Order> GetOrderHistory(int userId)
        {
            return _orderService.GetOrdersForUser(userId);
        }
    }
}
