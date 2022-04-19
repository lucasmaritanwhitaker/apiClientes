namespace APICliente.Entity
{
    public class EstadoCivil
    {
        public EstadoCivil(byte id, string nmEstadoCivil)
        {
            Id = id;
            NmEstadoCivil = nmEstadoCivil;
        }
        public byte Id { get; set; }
        public string NmEstadoCivil { get; set; }
    }
}
