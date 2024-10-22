using Application.Interfaces;
using Application.Models.Dtos;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var products = _productService.GetAll();
            if (products == null || !products.Any())
            {
                return NotFound("No se encontraron productos");
            }

            return Ok(products);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var product = _productService.GetByName(name);

            if (product == null)
            {
                return NotFound("No se encontró el producto");
            }

            return Ok(product);
        }


        [HttpPost]
        public IActionResult Add([FromBody] ProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedProduct = _productService.Create(productDto);
            return Ok(addedProduct);
        }

    }
}
