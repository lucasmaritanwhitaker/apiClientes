namespace APICliente.Entity
{
    public class Sexo
    {
        public Sexo(string nmSexos, byte id)
        {
            NmSexo = nmSexos;
            Id = id;
        }

        public Sexo()
        {

        }

        public byte? Id { get; set; }
        public string NmSexo { get; set; }
    }
}
