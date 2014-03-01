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
   public class Dal_Impuestos
    {


        public void Insert(Enl_Impuestos enlImpuestos)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Insert_Impuestos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlImpuestos.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlImpuestos.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Porcentaje", enlImpuestos.Porcentaje) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Nota", enlImpuestos.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Update(Enl_Impuestos enlImpuestos)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Update_Impuestos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlImpuestos.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlImpuestos.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Porcentaje", enlImpuestos.Porcentaje) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Nota", enlImpuestos.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Delete(Enl_Impuestos enlImpuestos)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Delete_Impuestos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlImpuestos.Codigo) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_Impuestos> Search(Enl_Impuestos enlImpuestos)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Search_Impuestos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Codigo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlImpuestos.Codigo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlImpuestos.Nombre
                });


                var dr = command.ExecuteReader();
                var list = new List<Enl_Impuestos>();

                while (dr.Read())
                {
                    list.Add(new Enl_Impuestos
                    {
                        Codigo = dr.GetString(dr.GetOrdinal("Codigo")),
                        Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                        Porcentaje = dr.GetDecimal(dr.GetOrdinal("Porcentaje")),
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

        public string IsExiste(Enl_Impuestos enlImpuestos)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_IsExiste_Impuesto", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlImpuestos.Codigo) { SqlDbType = SqlDbType.NVarChar });
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
