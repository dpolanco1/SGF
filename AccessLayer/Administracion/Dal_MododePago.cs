using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntityLayer.Administracion;
using DataAccessLayer.Otros;

namespace DataAccessLayer.Administracion
{
  public  class Dal_MododePago
    {

       public void Insert(Enl_MododePago enlModoPago)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Insert_ModoPago", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlModoPago.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlModoPago.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlModoPago.Nota) { SqlDbType = SqlDbType.NVarChar });
              

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (Connection.Get.State != ConnectionState.Closed)
                {
                    Connection.Get.Close();
                }

            }

        }

        public void Update(Enl_MododePago enlModoPago)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Update_ModoPago", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlModoPago.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlModoPago.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlModoPago.Nota) { SqlDbType = SqlDbType.NVarChar });

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (Connection.Get.State != ConnectionState.Closed)
                {
                    Connection.Get.Close();
                }

            }


        }

        public void Delete(Enl_MododePago enlModoPago)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Delete_ModoPago", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlModoPago.Codigo) { SqlDbType = SqlDbType.NVarChar });

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (Connection.Get.State != ConnectionState.Closed)
                {
                    Connection.Get.Close();
                }

            }

        }

        public IList<Enl_MododePago> Search(Enl_MododePago enlModoPago)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Search_ModoPago", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Codigo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlModoPago.Codigo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlModoPago.Nombre
                });


                var dr = command.ExecuteReader();
                var list = new List<Enl_MododePago>();

                while (dr.Read())
                {
                    list.Add(new Enl_MododePago
                    {
                        Codigo = dr.GetString(dr.GetOrdinal("Codigo")),
                        Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                        Nota = dr.GetString(dr.GetOrdinal("Nota"))

                    });
                }

                return list;

            }
            catch (Exception)
            {
                //Guardar Error en Tabla
                throw;
            }
            finally
            {
                if (Connection.Get.State != ConnectionState.Closed)
                {
                    Connection.Get.Close();
                }
            }


        }

        public string IsExiste(Enl_MododePago enlModoPago)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_IsExiste_ModoPago", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlModoPago.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add("@IsExiste", SqlDbType.Bit);
                command.Parameters["@IsExiste"].Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                return command.Parameters["@IsExiste"].Value.ToString();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                if (Connection.Get.State != ConnectionState.Closed)
                {
                    Connection.Get.Close();
                }

            }

        }



    }
}
