using Entits;

namespace Services
{
    public interface IProductServices
    {

        Task<List<Product>> GetProduct(int position, int skip, string? desc, int? minPrice, int? maxPrice, int?[] categoryIds);

    }
}