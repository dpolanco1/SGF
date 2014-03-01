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
  public   class Dal_ReciboMaster
    {

        public void Insert(Enl_ReciboMaster enlReciboMaster)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Insert_RecibosMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlReciboMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Cliente", enlReciboMaster.Cliente) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fecha", enlReciboMaster.Fecha) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Referencia", enlReciboMaster.Referencia) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@MododePago", enlReciboMaster.MododePago) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Monto", enlReciboMaster.Monto) { SqlDbType = SqlDbType.Decimal });


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

        public void Update(Enl_ReciboMaster enlReciboMaster)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Update_RecibosMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlReciboMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Cliente", enlReciboMaster.Cliente) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fecha", enlReciboMaster.Fecha) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Referencia", enlReciboMaster.Referencia) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@MododePago", enlReciboMaster.MododePago) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Monto", enlReciboMaster.Monto) { SqlDbType = SqlDbType.Decimal });

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

        public void Delete(Enl_ReciboMaster enlReciboMaster)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Delete_RecibosMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlReciboMaster.Numero) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_ReciboMaster> Search(Enl_ReciboMaster enlReciboMaster)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_Search_RecibosMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Numero",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlReciboMaster.Numero
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Cliente",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlReciboMaster.Cliente
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@MododePago",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlReciboMaster.MododePago
                });


                var dr = command.ExecuteReader();
                var list = new List<Enl_ReciboMaster>();

                while (dr.Read())
                {
                    list.Add(new Enl_ReciboMaster
                    {
                        Numero = dr.GetString(dr.GetOrdinal("Numero")),
                        Cliente = dr.GetString(dr.GetOrdinal("Cliente")),
                        Fecha = dr.GetDateTime(dr.GetOrdinal("Fecha")),
                        Referencia = dr.GetString(dr.GetOrdinal("Referencia")),
                        MododePago = dr.GetString(dr.GetOrdinal("MododePago")),
                        Monto = dr.GetDecimal(dr.GetOrdinal("Monto")),

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


        public string IsExiste(Enl_ReciboMaster enlReciboMaster)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_IsExiste_ReciboMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlReciboMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
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
