using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using DataAccessLayer.Otros;
using EntityLayer.Administracion;


namespace DataAccessLayer.Administracion
{
  public  class Dal_Numeracion
    {

        public int ObtenerNumero(string Transaccion)
        {
            try
            {

                SqlCommand ObjCmd = new SqlCommand("SELECT Numero FROM Adm.Numeracion WHERE Transaccion = '" + Transaccion + "'", Connection.Get);
                ObjCmd.CommandType = CommandType.Text;
                Connection.Get.Open();

                var dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    return dr.GetInt32(dr.GetOrdinal("Numero"));
                }
            }

            finally
            {

                if (Connection.Get.State != ConnectionState.Closed)
                {
                    Connection.Get.Close();
                }

            }

            return 0;
        }

        public string ObtenerPrefijo(string Transaccion)
        {
            try
            {

                SqlCommand ObjCmd = new SqlCommand("SELECT Prefijo FROM Adm.Numeracion WHERE Transaccion = '" + Transaccion + "'", Connection.Get);
                ObjCmd.CommandType = CommandType.Text;
                Connection.Get.Open();

                var dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {

                    if (dr.IsDBNull(dr.GetOrdinal("Prefijo")) == true)
                    {
                        return "";

                    }
                    else
                    {
                        return dr.GetString(dr.GetOrdinal("Prefijo"));
                    }

                }
            }

            finally
            {

                if (Connection.Get.State != ConnectionState.Closed)
                {
                    Connection.Get.Close();
                }

            }

            return "";



        }

        public string ObtenerTipo(string Transaccion)
        {

            try
            {

                SqlCommand ObjCmd = new SqlCommand("SELECT Tipo FROM Adm.Numeracion WHERE Transaccion = '" + Transaccion + "'", Connection.Get);
                ObjCmd.CommandType = CommandType.Text;
                Connection.Get.Open();

                var dr = ObjCmd.ExecuteReader();
                while (dr.Read())
                {
                    return dr.GetString(dr.GetOrdinal("Tipo"));
                }
            }

            finally
            {

                if (Connection.Get.State != ConnectionState.Closed)
                {
                    Connection.Get.Close();
                }

            }

            return "";



        }

        public void ActualizarNumero(int ValorMax, string Transaccion)
        {

            try
            {
                ValorMax += 1;
                SqlCommand ObjCmd = new SqlCommand("Update  Adm.Numeracion Set Numero = '" + ValorMax + "'   WHERE Transaccion = '" + Transaccion + "'", Connection.Get);
                ObjCmd.CommandType = CommandType.Text;
                Connection.Get.Open();

                var dr = ObjCmd.ExecuteReader();

            }
            finally
            {
                if (Connection.Get.State != ConnectionState.Closed)
                {
                    Connection.Get.Close();
                }
            }





        }

        public IList<Enl_Numeracion> Search(Enl_Numeracion enlNumeracion)
        {
           try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Search_Numeracion", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();



                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Modulo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlNumeracion.Modulo
                });

                var dr = command.ExecuteReader();
                var list = new List<Enl_Numeracion>();

                while (dr.Read())
                {
                    list.Add(new Enl_Numeracion
                    {
                       // IdNumeracion = dr.GetString(dr.GetOrdinal("IdNumeracion")),
                        Modulo = dr.GetString(dr.GetOrdinal("Modulo")),
                        Transaccion = dr.GetString(dr.GetOrdinal("Transaccion")),
                        Numero = dr.GetInt32(dr.GetOrdinal("Numero")),
                        Prefijo = dr.GetString(dr.GetOrdinal("Prefijo")),
                        Longitud = dr.GetInt32(dr.GetOrdinal("Longitud")),
                        Tipo = dr.GetString(dr.GetOrdinal("Tipo"))

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


        public void Insert(Enl_Numeracion enlNumeracion)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Insert_Numeracion", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

       
                command.Parameters.Add(new SqlParameter("@Modulo", enlNumeracion.Modulo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Transaccion", enlNumeracion.Transaccion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Numero", enlNumeracion.Numero) { SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter("@Prefijo", enlNumeracion.Prefijo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Longitud", enlNumeracion.Longitud) { SqlDbType = SqlDbType.Int });
                command.Parameters.Add(new SqlParameter("@Tipo", enlNumeracion.Tipo) { SqlDbType = SqlDbType.NVarChar });
           
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


        public void Delete(Enl_Numeracion enlNumeracion)
        {

            try
            {

                SqlCommand command = new SqlCommand("Adm .Spr_Delete_Numeracion", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

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
    }
}
