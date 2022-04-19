using APICliente.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace APICliente.Repositories
{
    public class NacionalidadeRepository : BaseRepository
    {
        public List<Nacionalidade> Get()
        {
            var nacionalidades = new List<Nacionalidade>();

            try
            {
                ExecuteProcedure("[dbo].[busca_nacionalidade]");

                var returProcedure = command.ExecuteReader();

                while (returProcedure.Read())
                    nacionalidades.Add(new Nacionalidade(returProcedure["nmNacionalidade"].ToString(),
                                                        short.Parse(returProcedure["Id"].ToString())));
                conn.Close();
                return nacionalidades;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(Nacionalidade nacionalidade)
        {
            try
            {
                ExecuteProcedure("[dbo].[inserir_nacionalidade]");
                command.Parameters.AddWithValue("@NOMENACIONALIDADE", SqlDbType.VarChar).Value = nacionalidade.NmNacionalidade;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private byte BadRequest(string message)
        {
            throw new NotImplementedException();
        }

        public void Delete(short id)
        {
            try
            {
                ExecuteProcedure("[dbo].[deletar_nacionalidade]");
                command.Parameters.AddWithValue("@ID", SqlDbType.SmallInt).Value = id;
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
