using System.Formats.Asn1;
using System.Runtime.CompilerServices;
using CLEAN_APPLICATION;
using CLEAN_DOMAIN;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CLEAN_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;
        public ProductController(ProductService productService)
            => _productService = productService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllProducts();
            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> AddOne(Product pro)
        {
            await _productService.AddProduct(pro);
            return Ok(pro);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productService.GetOneProduct(id);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> Update(Product pro)
        {
            await _productService.UpdateProduct(pro);
            return Ok(pro);
        }

        [HttpDelete("{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _productService.DeleteProduct(id);
            return NoContent();
        }
    }
}
