using APICliente.Entity;
using APICliente.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APICliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SexoController : ControllerBase
    {
        private readonly SexoRepository _sexoRepository;

        public SexoController()
        {
            _sexoRepository = new SexoRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_sexoRepository.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Sexo sexo)
        {
            try
            {
                _sexoRepository.Post(sexo);
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
                _sexoRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
