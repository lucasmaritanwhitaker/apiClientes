using APICliente.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APICliente.Repositories
{
    public class ClienteRepository : BaseRepository
    {
        public List<Cliente> Get()
        {
            var clientes = new List<Cliente>();

            try
            {
                ExecuteProcedure("[dbo].[busca_clientes]");
                var returnProcedure = command.ExecuteReader();

                while (returnProcedure.Read())
                    clientes.Add(new Cliente(returnProcedure["Nome"].ToString(),
                                    int.Parse(returnProcedure["Id"].ToString()),
                                    returnProcedure["Sexo"].ToString(),
                                    returnProcedure["EstadoCivil"].ToString(),
                                    returnProcedure["Nacionalidade"].ToString()));

                conn.Close();
                return clientes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Cliente Get(int id)
        {
            try
            {
                ExecuteProcedure("[dbo].[busca_cliente]");
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;

                var returnProcedure = command.ExecuteReader();

                if (returnProcedure.Read())
                    return new Cliente(returnProcedure["Nome"].ToString(),
                                            int.Parse(returnProcedure["Id"].ToString()),
                                            byte.Parse(returnProcedure["Sexo"].ToString()),
                                            byte.Parse(returnProcedure["EstadoCivil"].ToString()),
                                            short.Parse(returnProcedure["Nacionalidade"].ToString()));
                conn.Close();
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Post(Cliente cliente)
        {
            try
            {
                ExecuteProcedure("[dbo].[inserir_cliente]");
                command.Parameters.AddWithValue("@NOME", SqlDbType.VarChar).Value = cliente.Nome;
                command.Parameters.AddWithValue("@SEXO", SqlDbType.TinyInt).Value = cliente.Sexo;
                command.Parameters.AddWithValue("@ESTADOCIVIL", SqlDbType.TinyInt).Value = cliente.EstadoCivil;
                command.Parameters.AddWithValue("@NACIONALIDADE", SqlDbType.SmallInt).Value = cliente.Nacionalidade;

                return int.Parse(command.ExecuteScalar().ToString());
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Put(Cliente cliente)
        {
            try
            {
                ExecuteProcedure("[dbo].[alterar_cliente]");
                command.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = cliente.Id;
                command.Parameters.AddWithValue("@NOME", SqlDbType.VarChar).Value = cliente.Nome;
                command.Parameters.AddWithValue("@SEXO", SqlDbType.TinyInt).Value = cliente.Sexo;
                command.Parameters.AddWithValue("@ESTADOCIVIL", SqlDbType.TinyInt).Value = cliente.EstadoCivil;
                command.Parameters.AddWithValue("@NACIONALIDADE", SqlDbType.SmallInt).Value = cliente.Nacionalidade;
                command.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                ExecuteProcedure("[dbo].[deletar_cliente]");
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;
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
