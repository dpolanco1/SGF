using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using EntityLayer.Administracion;
using DataAccessLayer.Otros;


namespace DataAccessLayer.Administracion
{
  public  class Dal_Usuarios
    {
        public void Insert(Enl_Usuarios enlUsuarios)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Insert_Usuarios", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@NombreUsuario", enlUsuarios.NombreUsuario) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlUsuarios.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Apellido", enlUsuarios.Apellido) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Contrasena", enlUsuarios.Contrasena) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@IsResetearPass", enlUsuarios.IsResetearPass) { SqlDbType = SqlDbType.Bit });
              
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

        public void Update(Enl_Usuarios enlUsuarios)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Update_Usuarios", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();


                command.Parameters.Add(new SqlParameter("@NombreUsuario", enlUsuarios.NombreUsuario) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlUsuarios.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Apellido", enlUsuarios.Apellido) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Contrasena", enlUsuarios.Contrasena) { SqlDbType = SqlDbType.NVarChar });
           
                command.Parameters.Add(new SqlParameter("@IsResetearPass", enlUsuarios.IsResetearPass) { SqlDbType = SqlDbType.Bit });
               
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

        public void Delete(Enl_Usuarios enlUsuarios)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Delete_Usuarios", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@NombreUsuario", enlUsuarios.NombreUsuario) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_Usuarios> Search(Enl_Usuarios enlUsuarios)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Search_Usuarios", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@NombreUsuario",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlUsuarios.NombreUsuario
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlUsuarios.Nombre
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Apellido",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlUsuarios.Apellido
                });



                var dr = command.ExecuteReader();
                var list = new List<Enl_Usuarios>();

                while (dr.Read())
                {
                    list.Add(new Enl_Usuarios
                    {
                        NombreUsuario = dr.GetString(dr.GetOrdinal("NombreUsuario")),
                        Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                        Apellido = dr.GetString(dr.GetOrdinal("Apellido")),
                        Contrasena = dr.GetString(dr.GetOrdinal("Contrasena")),
                        IsResetearPass = dr.GetBoolean(dr.GetOrdinal("IsResetearPass"))


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


        public string IsExiste(Enl_Usuarios enlUsuarios)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_IsExiste_Usuario", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlUsuarios.NombreUsuario) { SqlDbType = SqlDbType.NVarChar });
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
