using APICliente.Entity;
using APICliente.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;

namespace APICliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NacionalidadeController : ControllerBase
    {
        private readonly NacionalidadeRepository _nacionalidadeRepository;

        public NacionalidadeController()
        {
            _nacionalidadeRepository = new NacionalidadeRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_nacionalidadeRepository.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Nacionalidade nacionalidade)
        {
            try
            {
                _nacionalidadeRepository.Post(nacionalidade);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(short id)
        {
            try
            {
                _nacionalidadeRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
