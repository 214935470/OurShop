using Entits;
using Microsoft.AspNetCore.Mvc;
using Services;
using Microsoft.Extensions.Caching.Memory;
using AutoMapper;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        ICategoryServices categoryServices;
        IMemoryCache cache;
        public CategoryController(ICategoryServices categoryServices, IMemoryCache cache)
        {
            this.categoryServices = categoryServices;
            this.cache = cache;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        public async Task<ActionResult<List<Category>>> Get()
        {
            if (!cache.TryGetValue("categories", out List<Category> categories))
            {
                categories = await categoryServices.GetCategory();
                cache.Set("categories", categories, TimeSpan.FromMinutes(30));
            }
            List<Category> categoryList = categories;
            return categoryList != null ? Ok(categoryList) : BadRequest();
        }


    }
}
