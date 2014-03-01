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
 public   class Dal_CotizacionesDetail
    {

        public void Insert(Enl_CotizacionesDetail enlCotizacionDetail)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Insert_CotizacionDetail", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@NoCotizacion", enlCotizacionDetail.NoCotizacion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Articulo", enlCotizacionDetail.Articulo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Descripcion", enlCotizacionDetail.Descripcion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Precio", enlCotizacionDetail.Precio) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Cantidad", enlCotizacionDetail.Cantidad) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Impuesto", enlCotizacionDetail.Impuesto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalLinea", enlCotizacionDetail.TotalLinea) { SqlDbType = SqlDbType.Decimal });

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

        public void Update(Enl_CotizacionesDetail enlCotizacionDetail)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Update_CotizacionDetail", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@NoCotizacion", enlCotizacionDetail.NoCotizacion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Articulo", enlCotizacionDetail.Articulo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Descripcion", enlCotizacionDetail.Descripcion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Precio", enlCotizacionDetail.Precio) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Cantidad", enlCotizacionDetail.Cantidad) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Impuesto", enlCotizacionDetail.Impuesto) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@TotalLinea", enlCotizacionDetail.TotalLinea) { SqlDbType = SqlDbType.Decimal });


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

        public void Delete(Enl_CotizacionesDetail enlCotizacionDetail)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Delete_CotizacionDetail", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@NoCotizacion", enlCotizacionDetail.NoCotizacion) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_CotizacionesDetail> Search(Enl_CotizacionesDetail enlCotizacionDetail)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_Search_CotizacionDetail", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@NoCotizacion",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCotizacionDetail.NoCotizacion
                });



                var dr = command.ExecuteReader();
                var list = new List<Enl_CotizacionesDetail>();

                while (dr.Read())
                {
                    list.Add(new Enl_CotizacionesDetail
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
