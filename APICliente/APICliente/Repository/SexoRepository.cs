using APICliente.Entity;
using APICliente.Extensions;
using System;
using System.Collections.Generic;
using System.Data;

namespace APICliente.Repositories
{
    public class SexoRepository : BaseRepository
    {
        public List<Sexo> Get()
        {
            var sexos = new List<Sexo>();

            try
            {
                ExecuteProcedure("[dbo].[busca_sexo]");
                var returProcedure = command.ExecuteReader();

                while (returProcedure.Read())
                    sexos.Add(new Sexo(returProcedure["NmSexo"].ToString(), returProcedure["Id"].ToByte()));

                conn.Close();
                return sexos;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(Sexo sexo)
        {
            try
            {
                ExecuteProcedure("[dbo].[inserir_sexo]");
                command.Parameters.AddWithValue("@NOMESEXO", SqlDbType.VarChar).Value = sexo.NmSexo;
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
                ExecuteProcedure("[dbo].[deletar_sexo]");
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