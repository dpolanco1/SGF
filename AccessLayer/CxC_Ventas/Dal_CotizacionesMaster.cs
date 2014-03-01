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
  public   class Dal_CotizacionesMaster
    {

        public void Insert(Enl_CotizacionesMaster enlCotizacionMaster)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Insert_CotizacionMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@NoCotizacion", enlCotizacionMaster.Numero) {SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Cliente", enlCotizacionMaster.Cliente) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fecha", enlCotizacionMaster.Fecha) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Terminos", enlCotizacionMaster.Terminos) { SqlDbType = SqlDbType.NVarChar });             
                command.Parameters.Add(new SqlParameter("@Descuento", enlCotizacionMaster.Descuento) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Vendedor", enlCotizacionMaster.Vendedor) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@SubTotal", enlCotizacionMaster.SubTotal) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalImpuesto", enlCotizacionMaster.TotalImpuesto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalDescuento", enlCotizacionMaster.TotalDescuento) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalFactura", enlCotizacionMaster.TotalCotizacion) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@FechaCreacion", DateTime.Now) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@CreadoPor", "Usuario") { SqlDbType = SqlDbType.NVarChar });
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

        public void Update(Enl_CotizacionesMaster enlCotizacionMaster)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Update_CotizacionMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlCotizacionMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Cliente", enlCotizacionMaster.Cliente) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fecha", enlCotizacionMaster.Fecha) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Terminos", enlCotizacionMaster.Terminos) { SqlDbType = SqlDbType.NVarChar });             
                command.Parameters.Add(new SqlParameter("@Descuento", enlCotizacionMaster.Descuento) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Vendedor", enlCotizacionMaster.Vendedor) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@SubTotal", enlCotizacionMaster.SubTotal) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalImpuesto", enlCotizacionMaster.TotalImpuesto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalDescuento", enlCotizacionMaster.TotalDescuento) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalFactura", enlCotizacionMaster.TotalCotizacion) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@FechaCreacion", DateTime.Now) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@CreadoPor", "Usuario") { SqlDbType = SqlDbType.NVarChar });
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

        public void Delete(Enl_CotizacionesMaster enlCotizacionMaster)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Delete_CotizacionMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlCotizacionMaster.Numero) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_CotizacionesMaster> Search(Enl_CotizacionesMaster enlCotizacionMaster)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_Search_CotizacionMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Numero",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCotizacionMaster.Numero
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Cliente",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCotizacionMaster.Cliente
                });


                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Terminos",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCotizacionMaster.Terminos
                });
      

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Vendedor",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCotizacionMaster.Vendedor
                });

                var dr = command.ExecuteReader();
                var list = new List<Enl_CotizacionesMaster>();

                while (dr.Read())
                {
                    list.Add(new Enl_CotizacionesMaster
                    {
                        Numero = dr.GetString(dr.GetOrdinal("NoCotizacion")),
                        Cliente = dr.GetString(dr.GetOrdinal("Cliente")),
                        Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha")),
                        Terminos = dr.GetString(dr.GetOrdinal("Terminos")),
                        Descuento = dr.GetDecimal(dr.GetOrdinal("Descuento")),
                        Vendedor = dr.GetString(dr.GetOrdinal("Vendedor")),
                        SubTotal = dr.GetDecimal(dr.GetOrdinal("SubTotal")),
                        TotalImpuesto = dr.GetDecimal(dr.GetOrdinal("TotalImpuesto")),
                        TotalDescuento = dr.GetDecimal(dr.GetOrdinal("TotalDescuento")),
                        TotalCotizacion = dr.GetDecimal(dr.GetOrdinal("TotalCotizacion"))


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


        public string IsExiste(Enl_CotizacionesMaster enlCotizacionMaster)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_IsExiste_CotizacionMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCotizacionMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
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
