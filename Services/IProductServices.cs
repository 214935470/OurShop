using Entits;

namespace Services
{
    public interface IProductServices
    {
        //Task<Product> AddProduct(Product product);
        //Task DeleteProduct(int id, Product productToDelete);
        Task<List<Product>> GetProduct();
        //Task UpdateProduct(int id, Product productToUpdate);
    }
}