using Application.Interfaces;
using Application.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly ISellerService _sellerService;

        public SellerController(ISellerService sellerService)
        {
            _sellerService = sellerService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var sellers = _sellerService.GetAll();
            return Ok(sellers);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var sellers=_sellerService.GetByName(name);
            if(sellers== null ||  sellers.Count()==0)
            {
                return NotFound("No se encontraron vendedores activos con este nombre");
            }
            return Ok(sellers);
        }

        [HttpPost]
        public IActionResult Add([FromBody]  SellerDTO sellerdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedseller= _sellerService.Create(sellerdto);
            return Ok(addedseller);
        }

        [HttpPut]
        public IActionResult Update([FromBody] SellerDTO sellerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedSeller = _sellerService.Update(sellerDto);
                return Ok(updatedSeller);
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
                _sellerService.Delete(userName);
                return Ok("Vendedor Eliminado.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
