using Application.Interfaces;
using Application.Models.Dtos;
using Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerservice;
        public ManagerController(IManagerService managerservice)
        {
            _managerservice = managerservice;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var managers = _managerservice.GetAll();
            return Ok(managers);
        }

        [HttpGet("GetByName")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var managers = _managerservice.GetByName(name);
            if (managers == null || managers.Count() == 0)
            {
                return NotFound("No se encontro Gerente con ese Nombre");
            }
            return Ok(managers);
        }

        [HttpPost]
        public IActionResult Add([FromBody] ManagerDTO managerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var addmanager = _managerservice.Create(managerDTO);
            return Ok(addmanager);
        }

        [HttpPut]
        public IActionResult Update([FromBody] ManagerDTO managerDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var updatedmanager = _managerservice.Update(managerDTO);
                return Ok(updatedmanager);
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
                _managerservice.Delete(userName);
                return Ok("Gerente Eliminado.");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
