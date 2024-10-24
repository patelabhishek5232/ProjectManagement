using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProductManagement.API.Models;
using ProductManagement.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProductManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public IProductService _productService { get; set; }
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            return Ok(await _productService.GetAllAsync());
        }

        [HttpGet("retrieveProductDetails")]
        public async Task<IActionResult> RetrieveProductDetails()
        {
            return Ok(await _productService.RetrieveProductDetails());
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _productService.GetByIdAsync(id));
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] Product product)
        {
            return Ok(await _productService.AddAsync(product));
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsync(int id, [FromBody] Product product)
        {
            return Ok(await _productService.UpdateAsync(id, product));
        }

        [HttpDelete("softDelete/{id}")]
        public async Task<IActionResult> SoftDeleteAysnc(int id)
        {
            return Ok(await _productService.SoftDelete(id));
        }

        [HttpDelete("hardDelete/{id}")]
        public async Task<IActionResult> HardDeleteAysnc(int id)
        {
            return Ok(await _productService.DeleteAsync(id));
        }
    }
}
