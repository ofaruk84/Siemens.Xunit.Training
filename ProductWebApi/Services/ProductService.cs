using ProductWebApi.Modals;
using ProductWebApi.Repositories;

namespace ProductWebApi.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public string GetProductName(int id)
        {
            var product = _repo.GetById(id);
            return product?.Name ?? "Not Found";
        }

        public Product GetProduct(int id)
        {
            return _repo.GetById(id);
        }
    }
}
