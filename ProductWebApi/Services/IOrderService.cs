using ProductWebApi.Modals;

namespace ProductWebApi.Services
{
    public interface IOrderService
    {
        List<Order> GetOrdersForUser(int userId);
    }
}
