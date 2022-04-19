using APICliente.Entity;
using APICliente.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APICliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadoCivilController : ControllerBase
    {
        private readonly EstadoCivilRepository _estadoCivilRepository;

        public EstadoCivilController()
        {
            _estadoCivilRepository = new EstadoCivilRepository();
        }

        [HttpGet]
        public IActionResult GetEstadoCivil()
        {
            try
            {
                return Ok(_estadoCivilRepository.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(EstadoCivil estadoCivil)
        {
            try
            {
                _estadoCivilRepository.Post(estadoCivil);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(byte id)
        {
            try
            {
                _estadoCivilRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
