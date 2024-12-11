using Entits;
using Microsoft.AspNetCore.Mvc;
using Services;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        IProductServices productServices;


        public ProductController(IProductServices productServices)
        {
            this.productServices = productServices;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await productServices.GetProduct();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody]string value)
        {
            //return await productServices.AddProduct(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Product productToUpdate)
        {
            //await productServices.UpdateProduct(id, productToUpdate);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id, [FromBody] Product productToDelete)
        {
            //await productServices.DeleteProduct(id, productToDelete);
        }
    }
}
