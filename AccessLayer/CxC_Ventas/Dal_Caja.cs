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
   public class Dal_Caja
    {

        public void Insert(Enl_Caja enlCaja)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Insert_Caja", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCaja.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlCaja.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Custodio", enlCaja.Custodio) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Saldo", enlCaja.Saldo) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Nota", enlCaja.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Update(Enl_Caja enlCaja)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Update_Caja", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCaja.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlCaja.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Custodio", enlCaja.Custodio) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlCaja.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Delete(Enl_Caja enlCaja)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Delete_Caja", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCaja.Codigo) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_Caja> Search(Enl_Caja enlCaja)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_Search_Caja", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Codigo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCaja.Codigo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCaja.Codigo
                });


                var dr = command.ExecuteReader();
                var list = new List<Enl_Caja>();

                while (dr.Read())
                {
                    list.Add(new Enl_Caja
                    {
                        Codigo = dr.GetString(dr.GetOrdinal("Codigo")),
                        Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                        Custodio = dr.GetString(dr.GetOrdinal("Custodio")),
                        Saldo = dr.GetDecimal(dr.GetOrdinal("Saldo")),
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

        public string IsExiste(Enl_Caja enlCaja)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_IsExiste_Caja", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCaja.Codigo) { SqlDbType = SqlDbType.NVarChar });
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
