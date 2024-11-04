using Application.Interfaces;
using Application.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPut("Update/{name}")]
        [Authorize(Roles = "Manager,StockManager")]
        public IActionResult UpdateByName(string name, [FromBody] StoreDTO storeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _storeService.UpdateStoreByName(name, storeDto);
            return Ok($"Almacén '{name}' actualizado con éxito.");
        }

        [HttpDelete("Desactive/{name}")]
        [Authorize(Roles = "Manager")]
        public IActionResult DesactivateByName(string name)
        {
            _storeService.DesactivateStoreByName(name);
            return Ok($"Almacén '{name}' desactivado con éxito.");


        }
    }
}
