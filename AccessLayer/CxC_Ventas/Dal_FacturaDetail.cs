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
  public  class Dal_FacturaDetail
    {
        public void Insert(Enl_FacturaDetail enlFacturaDetail)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Insert_FacturaDetail", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@NoFactura", enlFacturaDetail.NoFactura) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Articulo", enlFacturaDetail.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Descripcion", enlFacturaDetail.Descripcion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Precio", enlFacturaDetail.Precio) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Cantidad", enlFacturaDetail.Cantidad) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Impuesto", enlFacturaDetail.Impuesto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalLinea", enlFacturaDetail.TotalLinea) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Costo", enlFacturaDetail.Costo) { SqlDbType = SqlDbType.Decimal });


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

        public void Update(Enl_FacturaDetail enlFacturaDetail)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Update_FacturaDetail", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@NoFactura", enlFacturaDetail.NoFactura) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Articulo", enlFacturaDetail.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Descripcion", enlFacturaDetail.Descripcion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Precio", enlFacturaDetail.Precio) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Cantidad", enlFacturaDetail.Cantidad) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Impuesto", enlFacturaDetail.Impuesto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalLinea", enlFacturaDetail.TotalLinea) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Costo", enlFacturaDetail.Costo) { SqlDbType = SqlDbType.Decimal });

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

        public void Delete(Enl_FacturaDetail enlFacturaDetail)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Delete_FacturaDetail", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@NoFactura", enlFacturaDetail.NoFactura) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_FacturaDetail> Search(Enl_FacturaDetail enlFacturaDetail)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_Search_FacturaDetail", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@NoFactura",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlFacturaDetail.NoFactura
                });



                var dr = command.ExecuteReader();
                var list = new List<Enl_FacturaDetail>();

                while (dr.Read())
                {
                    list.Add(new Enl_FacturaDetail
                    {
                        Codigo = dr.GetString(dr.GetOrdinal("Articulo")),
                        Descripcion = dr.GetString(dr.GetOrdinal("Descripcion")),
                        Precio = dr.GetDecimal(dr.GetOrdinal("Precio")),
                        Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad")),
                        Impuesto = dr.GetDecimal(dr.GetOrdinal("Impuesto")),
                        TotalLinea = dr.GetDecimal(dr.GetOrdinal("TotalLinea")),
                        Costo = dr.GetDecimal(dr.GetOrdinal("Costo"))

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

    }
}
