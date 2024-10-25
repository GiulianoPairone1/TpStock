using Application.Interfaces;
using Application.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        [Authorize(Roles = "Manager,StockManager")]
        public IActionResult GetAll()
        {
            var stores = _storeService.GetAll();
            if (stores == null || !stores.Any())
            {
                return NotFound("No se encontraron almacenes.");
            }

            return Ok(stores);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Add([FromBody] StoreDTO storeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedStore = _storeService.Create(storeDto);
            return Ok(addedStore);
        }

        [HttpPost("{storeId}/products/{productId}/add")]
        [Authorize(Roles = "Manager,StockManager")]
        public IActionResult AddProductToStore(int storeId, int productId, [FromQuery] int quantity)
        {
            if (quantity <= 0)
            {
                return BadRequest("La cantidad debe ser mayor a cero.");
            }

            _storeService.AddProductToStore(productId, storeId, quantity);
            return Ok("Producto agregado al almacén con éxito.");
        }

        [HttpGet("{storeId}/products/{productId}/quantity")]
        public IActionResult GetProductQuantityInStore(int storeId, int productId)
        {
            var quantity = _storeService.GetProductQuantityInStore(productId, storeId);
            return Ok(new { ProductId = productId, StoreId = storeId, Quantity = quantity });
        }
    }

}
