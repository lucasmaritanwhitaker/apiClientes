using System.Text.Json.Serialization;

namespace APICliente.Entity
{
    public class EmailCliente
    {
        public EmailCliente(int id, string nomeEmail)
        {
            Id = id;
            NomeEmail = nomeEmail;
        }

        public int Id { get; set; }
        public string NomeEmail { get; set; }

        [JsonIgnore]
        public int IdCliente { get; set; }
    }
}
