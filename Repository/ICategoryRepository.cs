using Entits;

namespace Repository
{
    public interface ICategoryRepository
    {

        Task<List<Category>> GetCategory();

    }
}