using APICliente.Entity;
using APICliente.Repositories;
using System.Collections.Generic;

namespace APICliente.Service
{
    public class ClienteService
    {
        private readonly ClienteRepository _clienteRepository;
        private readonly EmailClienteRepository _emailClienteRepository;
        private readonly TelefoneClienteRepository _telefoneClienteRepository;
        private readonly EnderecoClienteRepository _enderecoClienteRepository;
        private readonly NacionalidadeRepository _nacionalidadeRepository;
        private readonly EstadoCivilRepository _estadoCivilRepository;

        public ClienteService()
        {
            _clienteRepository = new ClienteRepository();
            _emailClienteRepository = new EmailClienteRepository();
            _telefoneClienteRepository = new TelefoneClienteRepository();
            _enderecoClienteRepository = new EnderecoClienteRepository();
            _nacionalidadeRepository = new NacionalidadeRepository();
            _estadoCivilRepository = new EstadoCivilRepository();
        }

        public Cliente Get(int id)
        {
            var cliente = _clienteRepository.Get(id);
            cliente.EmailCliente = _emailClienteRepository.Get(id);
            cliente.TelefoneCliente = _telefoneClienteRepository.Get(id);
            cliente.EnderecoCliente = _enderecoClienteRepository.Get(id);

            return cliente;
        }

        public void Post(Cliente cliente)
        {
            cliente.Id = _clienteRepository.Post(cliente);
            InserirEmails(cliente.EmailCliente, cliente.Id.Value);
            InserirTelefone(cliente.TelefoneCliente, cliente.Id.Value);
            InserirEndereco(cliente.EnderecoCliente, cliente.Id.Value);
        }

        public void Put(Cliente cliente)
        {
            _clienteRepository.Put(cliente);
            _emailClienteRepository.Delete(cliente.Id.Value);
            InserirEmails(cliente.EmailCliente, cliente.Id.Value);
            _telefoneClienteRepository.Delete(cliente.Id.Value);
            InserirTelefone(cliente.TelefoneCliente, cliente.Id.Value);
            _enderecoClienteRepository.Delete(cliente.Id.Value);
            InserirEndereco(cliente.EnderecoCliente, cliente.Id.Value);
        }

        public void Delete(int id)
        {
            _enderecoClienteRepository.Delete(id);
            _emailClienteRepository.Delete(id);
            _telefoneClienteRepository.Delete(id);
            _clienteRepository.Delete(id);
        }

        private void InserirEmails(IEnumerable<EmailCliente> emails, int idCliente)
        {
            if (emails != null)
                foreach (var email in emails)
                {
                    email.IdCliente = idCliente;
                    _emailClienteRepository.Post(email);
                }
        }

        private void InserirTelefone(IEnumerable<TelefoneCliente> telefones, int idCliente)
        {
            if (telefones != null)
                foreach (var telefone in telefones)
                {
                    telefone.IdCliente = idCliente;
                    _telefoneClienteRepository.Post(telefone);
                }
        }

        private void InserirEndereco(IEnumerable<EnderecoCliente> enderecos, int idCliente)
        {
            if (enderecos != null)
                foreach (var endereco in enderecos)
                {
                    endereco.IdCliente = idCliente;
                    _enderecoClienteRepository.Post(endereco);
                }
        }
    }
}
