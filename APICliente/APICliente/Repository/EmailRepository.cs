using APICliente.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace APICliente.Repositories
{
    public class EmailClienteRepository : BaseRepository
    {
        public List<EmailCliente> Get(int id)
        {
            var emails = new List<EmailCliente>();

            try
            {
                ExecuteProcedure("[dbo].[busca_email]");
                command.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int)).Value = id;

                var returnProcedure = command.ExecuteReader();

                while (returnProcedure.Read())
                    emails.Add(new EmailCliente(int.Parse(returnProcedure["Id"].ToString()),
                                                    returnProcedure["nomeEmail"].ToString()));


                conn.Close();
                return emails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Post(EmailCliente email)
        {
            try
            {
                ExecuteProcedure("[dbo].[inserir_email]");
                command.Parameters.AddWithValue("@NOMEEMAIL", SqlDbType.VarChar).Value = email.NomeEmail;
                command.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = email.IdCliente;
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
                ExecuteProcedure("[dbo].[deletar_email]");
                command.Parameters.AddWithValue("@ID", SqlDbType.Int).Value = idCliente;
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
