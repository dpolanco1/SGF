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
  public  class Dal_FacturaMaster
    {
        public void Insert(Enl_FacturaMaster enlFacturaMaster)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Insert_FacturaMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlFacturaMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Cliente", enlFacturaMaster.Cliente) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fecha", enlFacturaMaster.Fecha) { SqlDbType = SqlDbType.Date });
                command.Parameters.Add(new SqlParameter("@Almacen", enlFacturaMaster.Almacen) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Terminos", enlFacturaMaster.Terminos) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Tipo", enlFacturaMaster.Tipo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Descuento", enlFacturaMaster.Descuento) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Vendedor", enlFacturaMaster.Vendedor) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Caja", enlFacturaMaster.Caja) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@SubTotal", enlFacturaMaster.SubTotal) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalImpuesto", enlFacturaMaster.TotalImpuesto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalDescuento", enlFacturaMaster.TotalDescuento) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalFactura", enlFacturaMaster.TotalFactura) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalPagado", enlFacturaMaster.TotalPagado) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@BalancePendiente", enlFacturaMaster.BalancePendiente) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@FechaCreacion", DateTime.Now) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@CreadoPor", "Usuario") { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Status", enlFacturaMaster.Status) { SqlDbType = SqlDbType.NVarChar });
             
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

        public void Update(Enl_FacturaMaster enlFacturaMaster)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Update_FacturaMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlFacturaMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Cliente", enlFacturaMaster.Cliente) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fecha", enlFacturaMaster.Fecha) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Almacen", enlFacturaMaster.Almacen) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Terminos", enlFacturaMaster.Terminos) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Tipo", enlFacturaMaster.Tipo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Descuento", enlFacturaMaster.Descuento) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Vendedor", enlFacturaMaster.Vendedor) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@SubTotal", enlFacturaMaster.SubTotal) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalImpuesto", enlFacturaMaster.TotalImpuesto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalDescuento", enlFacturaMaster.TotalDescuento) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalFactura", enlFacturaMaster.TotalFactura) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Status", enlFacturaMaster.Status) { SqlDbType = SqlDbType.NVarChar });

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

        public void Delete(Enl_FacturaMaster enlFacturaMaster)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Delete_FacturaMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlFacturaMaster.Numero) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_FacturaMaster> Search(Enl_FacturaMaster enlFacturaMaster)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_Search_FacturaMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Numero",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlFacturaMaster.Numero
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Cliente",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlFacturaMaster.Cliente
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Almacen",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlFacturaMaster.Almacen
                });


                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Terminos",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlFacturaMaster.Terminos
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Tipo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlFacturaMaster.Tipo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Vendedor",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlFacturaMaster.Vendedor
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@BalancePendiente",
                    SqlDbType = SqlDbType.Decimal,
                    Value = enlFacturaMaster.BalancePendiente
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FechaInicio",
                    SqlDbType = SqlDbType.Date,
                    Value = enlFacturaMaster.DesdeFecha
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@FechaFinal",
                    SqlDbType = SqlDbType.Date,
                    Value = enlFacturaMaster.HastaFecha
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Status",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlFacturaMaster.Status
                });

                var dr = command.ExecuteReader();
                var list = new List<Enl_FacturaMaster>();

                while (dr.Read())
                {
                    list.Add(new Enl_FacturaMaster
                    {
                        Numero = dr.GetString(dr.GetOrdinal("Numero")),
                        Cliente = dr.GetString(dr.GetOrdinal("Cliente")),
                        Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha")),
                        Almacen = dr.GetString(dr.GetOrdinal("Almacen")),
                        Terminos = dr.GetString(dr.GetOrdinal("Terminos")),
                        Tipo = dr.GetString(dr.GetOrdinal("Tipo")),
                        Descuento = dr.GetDecimal(dr.GetOrdinal("Descuento")),
                        Vendedor = dr.GetString(dr.GetOrdinal("Vendedor")),
                        Caja = dr.GetString(dr.GetOrdinal("Caja")),
                        SubTotal = dr.GetDecimal(dr.GetOrdinal("SubTotal")),
                        TotalImpuesto = dr.GetDecimal(dr.GetOrdinal("TotalImpuesto")),
                        TotalDescuento = dr.GetDecimal(dr.GetOrdinal("TotalDescuento")),
                        TotalFactura = dr.GetDecimal(dr.GetOrdinal("TotalFactura")),
                        TotalPagado = dr.GetDecimal(dr.GetOrdinal("TotalPagado")),
                        BalancePendiente = dr.GetDecimal(dr.GetOrdinal("BalancePendiente")),
                        Status = dr.GetString(dr.GetOrdinal("Status"))
            

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

        public void UpdateBalance(Enl_FacturaMaster enlFacturaMaster)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_UpdateBalanceFactura", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@NoFactura", enlFacturaMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Monto", enlFacturaMaster.MontoAplicar) { SqlDbType = SqlDbType.Decimal });

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

        public string IsExiste(Enl_FacturaMaster enlFacturaMaster)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_IsExiste_FacturaMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlFacturaMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
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
