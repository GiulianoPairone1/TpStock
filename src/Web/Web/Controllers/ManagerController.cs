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
    public class ManagerController : ControllerBase
    {
        private readonly IManagerService _managerservice;
        public ManagerController(IManagerService managerservice)
        {
            _managerservice = managerservice;
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult Get()
        {
            var managers = _managerservice.GetAll();
            return Ok(managers);
        }

        [HttpGet]
        [Authorize(Roles = "Manager")]
        public IActionResult GetByName([FromQuery] string name)
        {
            var manager = _managerservice.GetByName(name);

            if (manager == null)
            {
                return NotFound("No se encontro al gerente");
            }

            return Ok(manager);
        }

        [HttpPost]
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
        [Authorize(Roles = "Manager")]
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
