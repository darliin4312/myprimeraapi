using MiPrimerAPI.Models;
using MiPrimerAPI.Repositories;

namespace MiPrimerAPI.Services
{
    public class ProductService
    {
        private readonly IProductRepository _repo;

        public ProductService(IProductRepository repo)
        {
            _repo = repo;
        }

        public Task<IEnumerable<Product>> GetAllProducts()
        {
            return _repo.GetAllAsync();
        }

        public Task<Product?> GetProductById(int id)
        {
            return _repo.GetByIdAsync(id);
        }

        public Task AddProduct(Product product)
        {
            return _repo.AddAsync(product);
        }
    }
}
