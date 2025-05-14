using ProductWebApi.Modals;

namespace ProductWebApi.Repositories
{
    public interface IProductRepository
    {
        Product GetById(int id);
    }
}
