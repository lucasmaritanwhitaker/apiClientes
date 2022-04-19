using APICliente.Entity;
using APICliente.Repositories;
using APICliente.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using APICliente.Controllers;

namespace APICliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ClienteService _clienteService;
        private readonly ClienteRepository _clienteRepository;
        private readonly EmailController _emailController;

        public ClienteController()
        {
            _clienteService = new ClienteService();
            _clienteRepository = new ClienteRepository();
            _emailController = new EmailController();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_clienteRepository.Get());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_clienteService.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Cliente cliente)
        {
            string emailDestinatary = cliente.EmailCliente.First().NomeEmail;


            try
            {
                _clienteService.Post(cliente);
                _emailController.SendEmail(emailDestinatary);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public IActionResult Put(Cliente cliente, int id)
        {
            try
            {
                cliente.Id = id;
                _clienteService.Put(cliente);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _clienteService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}