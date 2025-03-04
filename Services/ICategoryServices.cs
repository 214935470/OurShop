using Entits;

namespace Services
{
    public interface ICategoryServices
    {

        Task<List<Category>> GetCategory();

        
    }
}