using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Otros;
using EntityLayer.CxC_Ventas;

namespace DataAccessLayer.CxC_Ventas
{
   public class Dal_Terminos
    {

        public void Insert(Enl_Termino enlTermino)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Insert_Terminos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlTermino.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlTermino.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Dias", enlTermino.Dias) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Nota", enlTermino.Nota) { SqlDbType = SqlDbType.NVarChar });

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                //Guardar Error en la tabla de Erroes V.2
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

        public void Update(Enl_Termino enlTermino)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Update_Terminos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlTermino.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlTermino.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Dias", enlTermino.Dias) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Nota", enlTermino.Nota) { SqlDbType = SqlDbType.NVarChar });

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                //Guardar Error en la tabla de Erroes V.2
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

        public void Delete(Enl_Termino enlTermino)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Delete_Terminos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlTermino.Codigo) { SqlDbType = SqlDbType.NVarChar });

                command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                //Guardar Error en la tabla de Erroes V.2
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

        public IList<Enl_Termino> Search(Enl_Termino enlTermino)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_Search_Terminos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Codigo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlTermino.Codigo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlTermino.Nombre
                });


                var dr = command.ExecuteReader();
                var list = new List<Enl_Termino>();

                while (dr.Read())
                {
                    list.Add(new Enl_Termino
                    {
                        Codigo = dr.GetString(dr.GetOrdinal("Codigo")),
                        Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                        Dias = dr.GetDecimal(dr.GetOrdinal("Dias")),
                        Nota = dr.GetString(dr.GetOrdinal("Nota")),

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

        public string IsExiste(Enl_Termino enlTermino)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_IsExiste_Termino", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlTermino.Codigo) { SqlDbType = SqlDbType.NVarChar });
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
