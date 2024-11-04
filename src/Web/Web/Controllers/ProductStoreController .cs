using Application.Interfaces;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductStoreController : ControllerBase
    {
        private readonly IProductStoreService _productStoreService;

        public ProductStoreController(IProductStoreService productStoreService)
        {
            _productStoreService = productStoreService;
        }


        [HttpGet("{storeId}/products/{productId}/quantity")]
        public IActionResult GetProductQuantityInStore(int storeId, int productId)
        {
            try
            {
                var quantity = _productStoreService.GetProductQuantityInStore(productId, storeId);
                return Ok(new { ProductId = productId, StoreId = storeId, Quantity = quantity });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("{storeId}/products/{productId}/add")]
        [Authorize(Roles = "Manager,StockManager")]
        public IActionResult AddProductToStore(int storeId, int productId, [FromQuery] int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("La cantidad debe ser mayor a cero.");
            }

            try
            {
                _productStoreService.AddProductToStore(productId, storeId, quantity);
                return Ok("Producto agregado al almacén con éxito.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("UpdateProductInStore")]
        [Authorize(Roles = "Manager,StockManager")]
        public IActionResult UpdateProductInStore([FromQuery] int productId, [FromQuery] int currentStoreId, [FromQuery] int? newStoreId, [FromQuery] int newQuantity)
        {
            try
            {
                _productStoreService.UpdateProductInStore(productId, currentStoreId, newStoreId, newQuantity);
                return Ok("Producto actualizado exitosamente en el almacén.");
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message); // Mensaje si el almacén o producto no son válidos
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message); // Mensaje si la cantidad no es válida
            }
        }



    }
}
