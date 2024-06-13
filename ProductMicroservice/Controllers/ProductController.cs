using Microsoft.AspNetCore.Mvc;
using ProductMicroservice.Domain.DTO;
using ProductMicroservice.Interfaces;

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

        /// <summary>
        /// Returns all the products
        /// </summary>
        /// <response code="200">Returns a list of all products</response>
        /// <response code="404">Returns not found response</response>
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ProductDto>))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> FindAsync()
        {
            var result = await _productService.FindAsync();
            if(!result.Any())
            {
                return NotFound();
            }
            return Ok(result);

        }

        /// <summary>
        /// Returns a product by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <response code="200">Returns a single product with the same id</response>
        /// <response code="404">Returns not found response</response>
        [HttpGet("{id}", Name = GetAsyncName)]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetAsync(Guid id)
        {
            var result = await _productService.GetAsync(id);
            if(result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        /// <summary>
        /// Adds a new product
        /// </summary>
        /// <param name="productPostDto">Product Post DTO</param>
        /// <response code="200">Returns the product that was just created</response>
        /// <response code="409">Returns conflict response</response>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        [ProducesResponseType(409)]
        public async Task<IActionResult> SaveAsync([FromBody]ProductPostDto productPostDto)
        {
            var result = await _productService.SaveAsync(productPostDto);
            if(result is null)
            {
                return Conflict();
            }
            return CreatedAtRoute(GetAsyncName, new {result?.Id}, result);
        }

        /// <summary>
        /// Updates existing product
        /// </summary>
        /// <param name="id">Id</param>
        /// <param name="productPutDto">Product Put DTO</param>
        /// <response code="200">Returns the product that was just updated</response>
        /// <response code="409">Returns conflict response</response>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(ProductDto))]
        [ProducesResponseType(409)]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody]ProductPutDto productPutDto)
        {
            var result = await _productService.UpdateAsync(id, productPutDto);
            if(result is null)
            {
                return Conflict();
            }
            return Ok(result);
        }

        /// <summary>
        /// Deletes a product by Id
        /// </summary>
        /// <param name="id">Id</param>
        /// <response code="200">Returns true if the product was deleted</response>
        /// <response code="404">Returns not found response</response>
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(bool))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var deleteSuccessfull = await _productService.DeleteAsync(id);
            if(!deleteSuccessfull)
            {
                return NotFound();
            }
            return Ok(deleteSuccessfull);
        }
    }
}