namespace APICliente.Extensions
{
    public static class ConvertToByte
    {
        public static byte ToByte(this object value)
        {
            return byte.Parse(value.ToString());
        }
    }
}
