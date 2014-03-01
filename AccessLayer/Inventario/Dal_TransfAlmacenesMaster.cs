using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntityLayer.Inventario;
using DataAccessLayer.Otros;

namespace DataAccessLayer.Inventario
{
  public  class Dal_TransfAlmacenesMaster
    {

        public void Insert(Enl_TransfAlmacenesMaster enlTransfAlmacenMaster)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Insert_TransfAlmacenesMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlTransfAlmacenMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fecha", enlTransfAlmacenMaster.Fecha) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@AlmacenSalida", enlTransfAlmacenMaster.AlmacenSalida) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@AlmacenEntrada", enlTransfAlmacenMaster.AlmacenEntrada) { SqlDbType = SqlDbType.NVarChar });

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

        public void Update(Enl_TransfAlmacenesMaster enlTransfAlmacenMaster)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Update_TransfAlmacenMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlTransfAlmacenMaster.Numero) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fecha", enlTransfAlmacenMaster.Fecha) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@AlmacenSalida", enlTransfAlmacenMaster.AlmacenSalida) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@AlmacenEntrada", enlTransfAlmacenMaster.AlmacenEntrada) { SqlDbType = SqlDbType.NVarChar });

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

        public void Delete(Enl_TransfAlmacenesMaster enlTransfAlmacenMaster)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Delete_TransfAlmacenesMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Numero", enlTransfAlmacenMaster.Numero) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_TransfAlmacenesMaster> Search(Enl_TransfAlmacenesMaster enlTransfAlmacenMaster)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Search_TransfAlmacenesMaster", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Numero",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlTransfAlmacenMaster.Numero
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@AlmacenSalida",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlTransfAlmacenMaster.AlmacenSalida
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@AlmacenEntrada",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlTransfAlmacenMaster.AlmacenEntrada
                });


                var dr = command.ExecuteReader();
                var list = new List<Enl_TransfAlmacenesMaster>();

                while (dr.Read())
                {
                    list.Add(new Enl_TransfAlmacenesMaster
                    {
                        Numero = dr.GetString(dr.GetOrdinal("Numero")),
                        AlmacenSalida = dr.GetString(dr.GetOrdinal("AlmacenSalida")),
                        AlmacenEntrada = dr.GetString(dr.GetOrdinal("AlmacenEntrada"))
                    

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
