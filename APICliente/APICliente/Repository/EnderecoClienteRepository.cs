using APICliente.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APICliente.Repositories
{
    public class EnderecoClienteRepository : BaseRepository
    {
        public List<EnderecoCliente> Get(int id)
        {
            var enderecos = new List<EnderecoCliente>();

            try
            {
                ExecuteProcedure("[dbo].[busca_endereco]");
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;

                var returProcedure = command.ExecuteReader();

                while (returProcedure.Read())
                    enderecos.Add(new EnderecoCliente(int.Parse(returProcedure["Id"].ToString()),
                                                          returProcedure["Cep"].ToString(),
                                                          returProcedure["NomeRua"].ToString(),
                                                          returProcedure["NumeroCasa"].ToString(),
                                                          returProcedure["Bairro"].ToString(),
                                                          returProcedure["Cidade"].ToString(),
                                                          returProcedure["Estado"].ToString(),
                                                          returProcedure["Pais"].ToString()));
                conn.Close();
                return enderecos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(EnderecoCliente endereco)
        {
            try
            {
                ExecuteProcedure("[dbo].[inserir_endereco]");
                command.Parameters.AddWithValue("@CEP", SqlDbType.VarChar).Value = endereco.Cep;
                command.Parameters.AddWithValue("@NOMERUA", SqlDbType.VarChar).Value = endereco.NomeRua;
                command.Parameters.AddWithValue("@NUMEROCASA", SqlDbType.VarChar).Value = endereco.NumeroCasa;
                command.Parameters.AddWithValue("@BAIRRO", SqlDbType.VarChar).Value = endereco.Bairro;
                command.Parameters.AddWithValue("@CIDADE", SqlDbType.VarChar).Value = endereco.Cidade;
                command.Parameters.AddWithValue("@ESTADO", SqlDbType.VarChar).Value = endereco.Estado;
                command.Parameters.AddWithValue("@PAIS", SqlDbType.VarChar).Value = endereco.Pais;
                command.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = endereco.IdCliente;
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
                ExecuteProcedure("[dbo].[deletar_endereco]");
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
