 using Application.Interfaces;
using Application.Models.Dtos;
using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Authorization;
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

        [HttpGet("GetByBrand")]
        public IActionResult GetAllByBrand([FromQuery] string brand)
        {
            var products = _productService.GetAllByBrand(brand);

            if (products == null || !products.Any())
            {
                return NotFound("No se encontraron productos con esa marca");
            }

            return Ok(products);
        }

        [HttpPost]
        [Authorize(Roles = "Manager,StockManager")]
        public IActionResult Add([FromBody] CreateProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedProduct = _productService.Create(productDto);
            return Ok(addedProduct);
        }

        [HttpPut]
        [Authorize(Roles = "Manager,StockManager")]
        public IActionResult Update([FromBody] CreateProductDTO productDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingProduct = _productService.GetByName(productDto.Name);
            if (existingProduct == null)
            {
                return NotFound($"No se encontró el producto con el nombre '{productDto.Name}'.");
            }

            _productService.Update(productDto);
            return Ok("Producto actualizado con éxito.");
        }


        [HttpDelete("{productName}")]
        [Authorize(Roles = "Manager")]
        public IActionResult Delete(string productName)
        {
            _productService.Delete(productName);
            return Ok($"Producto '{productName}' desactivado con éxito");
        }


    }
}
