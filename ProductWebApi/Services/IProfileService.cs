using ProductWebApi.Modals;

namespace ProductWebApi.Services
{
    public interface IProfileService
    {
        List<Order> GetOrderHistory(int userId);
    }
}
