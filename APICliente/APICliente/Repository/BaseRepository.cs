using System.Data;
using System.Data.SqlClient;

namespace APICliente.Repositories
{
    public class BaseRepository
    {
        public SqlConnection conn;
        public SqlCommand command;

        public BaseRepository()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-SDT4Q2C\SQLEXPRESS;Initial Catalog=CadastroClientes;Integrated Security=True");
        }

        public void ExecuteProcedure(string procedure)
        {
            command = new(procedure, conn);
            command.CommandType = CommandType.StoredProcedure;
            conn.Open();
        }
    }
}
