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


        [HttpGet("Name")]
        [Authorize(Roles = "Manager")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var stockmanager = _stockManagerService.GetByName(name);

            if (stockmanager == null)
            {
                return NotFound("No se encontro al Encargado de stock");
            }

            return Ok(stockmanager);
        }


        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Add([FromBody] CreateStockManagerDTO stockManagerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedstockmanager = _stockManagerService.Create(stockManagerDTO);
            return Ok(addedstockmanager);
        }


        [HttpPut]
        [Authorize(Roles = "Manager,StockManager")]
        public IActionResult Update([FromBody] CreateStockManagerDTO stockManagerDTO)
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
        [Authorize(Roles = "Manager")]
        public IActionResult Delete(string userName)
        {
            try
            {
                _stockManagerService.Delete(userName);
                return Ok("Encargado de Stock desactivado.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
