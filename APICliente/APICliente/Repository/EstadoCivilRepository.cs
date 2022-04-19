using APICliente.Entity;
using System;
using System.Collections.Generic;
using System.Data;

namespace APICliente.Repositories
{
    public class EstadoCivilRepository : BaseRepository
    {
        public List<EstadoCivil> Get()
        {
            var estadosCivils = new List<EstadoCivil>();

            try
            {
                ExecuteProcedure("[dbo].[busca_estadoCivil]");
                var returnProcedure = command.ExecuteReader();

                while (returnProcedure.Read())
                    estadosCivils.Add(new EstadoCivil(byte.Parse(returnProcedure["Id"].ToString()),
                                                                   returnProcedure["NmEstadoCivil"].ToString()));
                conn.Close();
                return estadosCivils;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(EstadoCivil estadoCivil)
        {
            try
            {
                ExecuteProcedure("[dbo].[inserir_estadoCivil]");
                command.Parameters.AddWithValue("@NOMEESTADOCIVIL", SqlDbType.VarChar).Value = estadoCivil.NmEstadoCivil;
                command.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Delete(byte id)
        {
            try
            {
                ExecuteProcedure("[dbo].[deletar_estadoCivil]");
                command.Parameters.AddWithValue("@ID", SqlDbType.TinyInt).Value = id;
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
