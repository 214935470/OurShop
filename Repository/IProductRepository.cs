using Entits;

namespace Repository
{
    public interface IProductRepository
    {
        //Task<Product> AddProduct(Product product);
        //Task DeleteProduct(int id, Product productToDelete);
        Task<List<Product>> GetProduct();
        //Task UpdateProduct(int id, Product productToUpdate);
    }
}