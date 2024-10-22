using Application.Interfaces;
using Application.Models.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockManagerController : ControllerBase
    {
        private readonly IStockManagerService _stockManagerService;

        public StockManagerController (IStockManagerService stockManagerService)
        {
            _stockManagerService = stockManagerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var stockmanagers = _stockManagerService.GetAll();
            return Ok(stockmanagers);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var stockmanagers = _stockManagerService.GetByName(name);
            if (stockmanagers == null || stockmanagers.Count() == 0)
            {
                return NotFound("No se encontro un encargado de stock con este nombre");
            }
            return Ok(stockmanagers);
        }

        [HttpPost]
        public IActionResult Add([FromBody] StockManagerDTO stockManagerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedstockmanager = _stockManagerService.Create(stockManagerDTO);
            return Ok(addedstockmanager);
        }

        [HttpPut]
        public IActionResult Update([FromBody] StockManagerDTO stockManagerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedstockmanager = _stockManagerService.Update(stockManagerDTO);
                return Ok(updatedstockmanager);
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpDelete("{userName}")]
        public IActionResult Delete(string userName)
        {
            try
            {
                _stockManagerService.Delete(userName);
                return Ok("Encargado de Stock Eliminado.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
