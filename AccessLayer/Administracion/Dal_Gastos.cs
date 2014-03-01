using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.Administracion;
using System.Data.SqlClient;
using System.Data;
using DataAccessLayer.Otros;

namespace DataAccessLayer.Administracion
{
  public  class Dal_Gastos
    {
        public void Insert(Enl_Gastos enlGastos)
        {

            try
            {

                SqlCommand command = new SqlCommand("Adm.Spr_Insert_Gastos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlGastos.Numero) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fecha", enlGastos.Fecha) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Monto", enlGastos.Monto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Tipo", enlGastos.Tipo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlGastos.Nota) { SqlDbType = SqlDbType.NVarChar });
              

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

        public void Update(Enl_Gastos enlGastos)
        {
            try
            {

                SqlCommand command = new SqlCommand("Adm.Spr_Update_Gastos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlGastos.Numero) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fecha", enlGastos.Fecha) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Monto", enlGastos.Monto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Tipo", enlGastos.Tipo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlGastos.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Delete(Enl_Gastos enlGastos)
        {

            try
            {

                SqlCommand command = new SqlCommand("Adm .Spr_Delete_Gastos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlGastos.Numero) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_Gastos> Search(Enl_Gastos enlGastos)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Search_Gastos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Codigo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlGastos.Numero
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Tipo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlGastos.Tipo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FechaDesde",
                    SqlDbType = SqlDbType.DateTime,
                    Value = enlGastos.FechaDesde
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FechaHasta",
                    SqlDbType = SqlDbType.DateTime,
                    Value = enlGastos.FechaHasta
                });


                var dr = command.ExecuteReader();
                var list = new List<Enl_Gastos>();

                while (dr.Read())
                {
                    list.Add(new Enl_Gastos
                    {
                        Numero = dr.GetString(dr.GetOrdinal("Codigo")),
                        Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha")),
                        Monto =  dr.GetDecimal(dr.GetOrdinal("Monto")),
                        Tipo = dr.GetString(dr.GetOrdinal("Tipo")),
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

        public string IsExiste(Enl_Gastos enlGastos)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_IsExiste_Gastos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlGastos.Numero) { SqlDbType = SqlDbType.NVarChar });
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
