using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace APICliente.Entity
{
    public class Cliente
    {
        public Cliente(string nome, int id, byte sexo, byte estCivil, short nasci)
        {
            Id = id;
            Nome = nome;
            Sexo = sexo;
            EstadoCivil = estCivil;
            Nacionalidade = nasci;
        }

        public Cliente(string nome, int id, string sexo, string estCivil, string nasci)
        {
            Id = id;
            Nome = nome;
            NmSexo = sexo;
            NmEstadoCivil = estCivil;
            NmNacionalidade = nasci;
        }

        [JsonConstructor]
        public Cliente()
        {

        }
        public int? Id { get; set; }
        public string Nome { get; set; }
        public byte Sexo { get; set; }
        public string NmSexo { get; set; }
        public byte EstadoCivil { get; set; }
        public string NmEstadoCivil { get; set; }
        public short Nacionalidade { get; set; }
        public string NmNacionalidade { get; set; }
        public IEnumerable<EmailCliente> EmailCliente { get; set; }
        public IEnumerable<TelefoneCliente> TelefoneCliente { get; set; }
        public IEnumerable<EnderecoCliente> EnderecoCliente { get; set; }
    }
}
