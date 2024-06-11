using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Interfaces;
using ProductMicroservice.Models;

namespace ProductMicroservice.Controllers
{
    [ApiController]
    [Produces("application/json")]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private const string GetAsyncName = "Get product by Id";
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet()]
        public async Task<IActionResult> FindAsync()
        {
            var result = await _productService.FindAsync();
            return Ok(result);

        }
        [HttpGet("{id}", Name = GetAsyncName)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _productService.GetAsync(id);
            if(result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> SaveAsync([FromBody]ProductPostDto productPostDto)
        {
            var result = await _productService.SaveAsync(productPostDto);
            if(result is null)
            {
                return Conflict();
            }
            return CreatedAtRoute(GetAsyncName, new {result?.Id}, result);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody]ProductPutDto productPutDto)
        {
            var result = await _productService.UpdateAsync(id, productPutDto);
            if(result is null)
            {
                return Conflict();
            }
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deleteSuccessfull = await _productService.DeleteAsync(id);
            if(!deleteSuccessfull)
            {
                return Conflict();
            }
            return Ok(deleteSuccessfull);
        }
    }
}