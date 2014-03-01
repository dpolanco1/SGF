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
  public  class Dal_ComprasDetail
    {


        public void Insert(Enl_ComprasDetail enlCompraDetail)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxP.Spr_Insert_CompraDetail", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Nocompra", enlCompraDetail.NoCompra) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Articulo", enlCompraDetail.Articulo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Descripcion", enlCompraDetail.Descripcion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Precio", enlCompraDetail.Precio) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Cantidad", enlCompraDetail.Cantidad) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Impuesto", enlCompraDetail.Impuesto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalLinea", enlCompraDetail.TotalLinea) { SqlDbType = SqlDbType.Decimal });

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

        public void Update(Enl_ComprasDetail enlCompraDetail)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxP.Spr_Update_CompraDetail", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Nocompra", enlCompraDetail.NoCompra) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Articulo", enlCompraDetail.Articulo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Descripcion", enlCompraDetail.Descripcion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Precio", enlCompraDetail.Precio) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Cantidad", enlCompraDetail.Cantidad) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Impuesto", enlCompraDetail.Impuesto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalLinea", enlCompraDetail.TotalLinea) { SqlDbType = SqlDbType.Decimal });


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

        public void Delete(Enl_ComprasDetail enlCompraDetail)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxP.Spr_Delete_CompraDetail", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@NoCompra", enlCompraDetail.NoCompra) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_ComprasDetail> Search(Enl_ComprasDetail enlCompraDetail)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxP.Spr_Search_CompraDetail", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@NoCompra",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCompraDetail.NoCompra
                });



                var dr = command.ExecuteReader();
                var list = new List<Enl_ComprasDetail>();

                while (dr.Read())
                {
                    list.Add(new Enl_ComprasDetail
                    {
                        Articulo = dr.GetString(dr.GetOrdinal("Articulo")),
                        Descripcion = dr.GetString(dr.GetOrdinal("Descripcion")),
                        Precio = dr.GetDecimal(dr.GetOrdinal("Precio")),
                        Cantidad = dr.GetDecimal(dr.GetOrdinal("Cantidad")),
                        Impuesto = dr.GetDecimal(dr.GetOrdinal("Impuesto")),
                        TotalLinea = dr.GetDecimal(dr.GetOrdinal("TotalLinea"))

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
