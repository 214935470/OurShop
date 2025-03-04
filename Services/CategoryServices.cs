using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entits;
using Repository;

namespace Services
{
    public class CategoryServices : ICategoryServices
    {
        ICategoryRepository categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }



        public async Task<List<Category>> GetCategory()
        {
            return await categoryRepository.GetCategory();
        }





    }
}
