using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using repasito_DOMAIN.Core.DTO;
using repasito_DOMAIN.Core.Services;

namespace Repasito_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productService;

        public ProductsController(IProductsService productsService)
        {
            _productService = productsService;
        }

        [HttpGet()]
        public async Task<ActionResult> getProductsDTO()
        {
            var result = await _productService.GetProductsDTO();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> getCategoryById(int id)
        {
            return Ok(await _productService.GetProductById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ProductsDTO productDTO)
        {
            int productId = await _productService.Insert(productDTO);
            return Ok(productId);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ProductsDTO productDTO)
        {
            if (id != productDTO.IdProduct) return BadRequest();
            var result = await _productService.Update(productDTO);
            if (!result) return NotFound();
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _productService.Delete(id);
            if (!result) return NotFound();
            return Ok(result);
        }

    }
}
