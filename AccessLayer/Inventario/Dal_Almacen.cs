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
  public  class Dal_Almacen
    {

        public void Insert(Enl_Almacen enlAlmacen)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Insert_Almacen", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlAlmacen.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlAlmacen.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Direccion", enlAlmacen.Direccion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Encargado", enlAlmacen.Encargado) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Telefono", enlAlmacen.Telefono) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlAlmacen.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Update(Enl_Almacen enlAlmacen)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Update_Almacen", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlAlmacen.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlAlmacen.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Direccion", enlAlmacen.Direccion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Encargado", enlAlmacen.Encargado) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Telefono", enlAlmacen.Telefono) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlAlmacen.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Delete(Enl_Almacen enlAlmacen)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Delete_Almacen", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlAlmacen.Codigo) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_Almacen> Search(Enl_Almacen enlAlmacen)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Search_Almacen", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Codigo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlAlmacen.Codigo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlAlmacen.Nombre
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Encargado",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlAlmacen.Encargado
                });


                var dr = command.ExecuteReader();
                var list = new List<Enl_Almacen>();

                while (dr.Read())
                {
                    list.Add(new Enl_Almacen
                    {
                        Codigo = dr.GetString(dr.GetOrdinal("Codigo")),
                        Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                        Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                        Encargado = dr.GetString(dr.GetOrdinal("Encargado")),
                        Telefono = dr.GetString(dr.GetOrdinal("Telefono")),
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

        public string IsExiste(Enl_Almacen enlAlmacen)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_IsExiste_Almacen", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlAlmacen.Codigo) { SqlDbType = SqlDbType.NVarChar });
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
