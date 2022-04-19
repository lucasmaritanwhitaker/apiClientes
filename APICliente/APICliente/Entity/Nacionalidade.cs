namespace APICliente.Entity
{
    public class Nacionalidade
    {
        public Nacionalidade(string nmNacionalidade, short id)
        {
            NmNacionalidade = nmNacionalidade;
            Id = id;
        }

        public Nacionalidade()
        {

        }

        public short? Id { get; set; }
        public string NmNacionalidade { get; set; }
    }
}
