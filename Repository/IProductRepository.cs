using Entits;

namespace Repository
{
    public interface IProductRepository
    {

        Task<List<Product>> GetProduct(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);
        Task<Product> GetById(int productId);

    }
}