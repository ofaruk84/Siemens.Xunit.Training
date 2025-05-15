using ProductWebApi.Modals;

namespace ProductWebApi.Repositories
{
    public interface IOrderRepository
    {
        List<Order> GetOrdersByUserId(int userId);
    }
}
