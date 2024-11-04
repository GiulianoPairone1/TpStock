using Application.Interfaces;
using Application.Models.Dtos;
using Application.Services;
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

        [HttpPost("Name")]
        [Authorize(Roles = "Manager")]
        public IActionResult Add([FromBody] CreateStoreDTO storeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addedStore = _storeService.Create(storeDto);
            return Ok(addedStore);
        }

        [HttpPut]
        [Authorize(Roles = "Manager,StockManager")]
        public IActionResult UpdateByName([FromBody] CreateStoreDTO storeDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _storeService.Update(storeDto);
            return Ok($"Almacén actualizado con éxito.");
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
