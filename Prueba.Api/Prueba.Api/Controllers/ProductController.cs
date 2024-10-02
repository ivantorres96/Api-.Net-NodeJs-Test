using Microsoft.AspNetCore.Mvc;
using Prueba.Domains.Interfaces;
using Prueba.Models.Models;

namespace Prueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController (IProductDomain productDomain) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductsModel product)
        {
            var response = await productDomain.CreateProduct(product);
            return StatusCode((int)response.Code, response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var response = await productDomain.DeleteProduct(id);
            return StatusCode((int)response.Code, response);
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var response = await productDomain.GetProducts();
            return StatusCode((int)response.Code, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await productDomain.GetProductById(id);
            return StatusCode((int)response.Code, response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductsModel product)
        {
            var response = await productDomain.UpdateProduct(product);
            return StatusCode((int)response.Code, response);
        }
    }
}
