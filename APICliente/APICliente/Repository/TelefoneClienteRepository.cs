using APICliente.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APICliente.Repositories
{
    public class TelefoneClienteRepository : BaseRepository
    {
        public List<TelefoneCliente> Get(int id)
        {
            var telefone = new List<TelefoneCliente>();

            try
            {
                ExecuteProcedure("[dbo].[busca_telefone]");
                command.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = id;

                var returProcedure = command.ExecuteReader();

                while (returProcedure.Read())
                    telefone.Add(new TelefoneCliente(int.Parse(returProcedure["Id"].ToString()),
                                                        returProcedure["ddd"].ToString(),
                                                        returProcedure["ddi"].ToString(),
                                                        returProcedure["numero"].ToString()));
                conn.Close();
                return telefone;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(TelefoneCliente telefone)
        {
            try
            {
                ExecuteProcedure("[dbo].[inserir_telefone]");
                command.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = telefone.IdCliente;
                command.Parameters.AddWithValue("@DDI", SqlDbType.Int).Value = telefone.Ddi;
                command.Parameters.AddWithValue("@DDD", SqlDbType.Int).Value = telefone.Ddd;
                command.Parameters.AddWithValue("@NUMERO", SqlDbType.VarChar).Value = telefone.Numero;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int idCliente)
        {
            try
            {
                ExecuteProcedure("[dbo].[deletar_telefone]");
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = idCliente;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
