using System.Text.Json.Serialization;

namespace APICliente.Entity
{
    public class TelefoneCliente
    {
        public TelefoneCliente(int id, string ddd, string ddi, string numero)
        {
            Id = id;
            Numero = numero;
            Ddd = ddd;
            Ddi = ddi;
        }

        public int Id { get; set; }
        public string Ddi { get; set; }
        public string Ddd { get; set; }
        public string Numero { get; set; }
        [JsonIgnore]
        public int IdCliente { get; set; }
    }
}
