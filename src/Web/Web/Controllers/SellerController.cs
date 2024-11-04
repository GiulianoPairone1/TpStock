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

        [HttpGet("Name")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var seller = _sellerService.GetByName(name);

            if (seller == null)
            {
                return NotFound("No se encontro al vendedor");
            }

            return Ok(seller);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
        public IActionResult Add([FromBody]  CreateSellerDTO sellerdto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addedseller= _sellerService.Create(sellerdto);
            return Ok(addedseller);
        }

        [HttpPut]
        [Authorize(Roles = "Manager,Seller")]
        public IActionResult Update([FromBody] CreateSellerDTO sellerDto)
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
        [Authorize(Roles = "Manager")]
        public IActionResult Delete(string userName)
        {
            try
            {
                _sellerService.Delete(userName);
                return Ok("Vendedor desactivado.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
