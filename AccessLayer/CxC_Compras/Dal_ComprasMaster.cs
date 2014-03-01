using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntityLayer.CxP_Compras;
using DataAccessLayer.Otros;

namespace DataAccessLayer.CxC_Compras
{
  public  class Dal_ComprasMaster

    {
        public void Insert(Enl_ComprasMaster enlCompraMaster)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxP.Spr_Insert_CompraMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlCompraMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Suplidor", enlCompraMaster.Suplidor) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fecha", enlCompraMaster.Fecha) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Almacen", enlCompraMaster.Almacen) { SqlDbType = SqlDbType.NVarChar });         
                command.Parameters.Add(new SqlParameter("@Descuento", enlCompraMaster.Descuento) { SqlDbType = SqlDbType.Decimal });   
                command.Parameters.Add(new SqlParameter("@SubTotal", enlCompraMaster.SubTotal) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalImpuesto", enlCompraMaster.TotalImpuesto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalDescuento", enlCompraMaster.TotalDescuento) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalCompra", enlCompraMaster.TotalCompra) { SqlDbType = SqlDbType.Decimal });
               
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

        public void Update(Enl_ComprasMaster enlCompraMaster)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxP.Spr_Update_CompraMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlCompraMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Suplidor", enlCompraMaster.Suplidor) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fecha", enlCompraMaster.Fecha) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Almacen", enlCompraMaster.Almacen) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Descuento", enlCompraMaster.Descuento) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@SubTotal", enlCompraMaster.SubTotal) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalImpuesto", enlCompraMaster.TotalImpuesto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalDescuento", enlCompraMaster.TotalDescuento) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalCompra", enlCompraMaster.TotalCompra) { SqlDbType = SqlDbType.Decimal });

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

        public void Delete(Enl_ComprasMaster enlCompraMaster)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxP.Spr_Delete_CompraMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlCompraMaster.Numero) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_ComprasMaster> Search(Enl_ComprasMaster enlCompraMaster)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxP.Spr_Search_CompraMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Numero",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCompraMaster.Numero
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Suplidor",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCompraMaster.Suplidor
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Almacen",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCompraMaster.Almacen
                });


          
        

                var dr = command.ExecuteReader();
                var list = new List<Enl_ComprasMaster>();

                while (dr.Read())
                {
                    list.Add(new Enl_ComprasMaster
                    {
                        Numero = dr.GetString(dr.GetOrdinal("Numero")),
                        Suplidor = dr.GetString(dr.GetOrdinal("Suplidor")),
                        Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha")),
                        Almacen = dr.GetString(dr.GetOrdinal("Almacen")),
                        Descuento = dr.GetDecimal(dr.GetOrdinal("Descuento")),                  
                        SubTotal = dr.GetDecimal(dr.GetOrdinal("SubTotal")),
                        TotalImpuesto = dr.GetDecimal(dr.GetOrdinal("TotalImpuesto")),
                        TotalDescuento = dr.GetDecimal(dr.GetOrdinal("TotalDescuento")),
                        TotalCompra = dr.GetDecimal(dr.GetOrdinal("TotalCompra"))


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


        public string IsExiste(Enl_ComprasMaster enlCompraMaster)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxP.Spr_IsExiste_CompraMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCompraMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
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
