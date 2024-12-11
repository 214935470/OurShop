using Entits;
using Microsoft.AspNetCore.Mvc;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<List<Category>> Get()
        {
            return await categoryServices.GetCategory();
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public void GetCategoryById(int id)
        {
            //return await categoryServices.GetCategoryById(id);
        }

        // POST api/<CategoryController>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
           //return await categoryServices.AddCategory(category);
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category category)
        {
            //await categoryServices.UpdateCategory(id, category);
        }


        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromBody] Category category)
        {
            //await categoryServices.UpdateCategory(id, category);
        }
    }
}
