using System.Text.Json.Serialization;

namespace APICliente.Entity
{
    public class EnderecoCliente
    {
        public EnderecoCliente(int id, string cep, string nomeRua, string numeroCasa, string bairro, string cidade, string estado, string pais)
        {
            Id = id;
            Cep = cep;
            NomeRua = nomeRua;
            NumeroCasa = numeroCasa;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Pais = pais;
        }

        public int Id { get; set; }
        public string Cep { get; set; }
        public string NomeRua { get; set; }
        public string NumeroCasa { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }

        [JsonIgnore]
        public int IdCliente { get; set; }
    }
}
