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
  public  class Dal_Suplidores
    {
        public void Insert(Enl_Suplidores enlSuplidores)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxP.Spr_Insert_Suplidores", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlSuplidores.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@RazonSocial", enlSuplidores.RazonSocial) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@RNC", enlSuplidores.RNC) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Tipo", enlSuplidores.Tipo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Categoria", enlSuplidores.Categoria) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@SubCategoria", enlSuplidores.SubCategoria) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Direccion", enlSuplidores.Direccion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlSuplidores.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Apellido", enlSuplidores.Apellido) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Cedula", enlSuplidores.Cedula) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Celular", enlSuplidores.Celular) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fax", enlSuplidores.Fax) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Telefono", enlSuplidores.Telefono) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@FechaNacimiento", enlSuplidores.FechaNacimiento) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Email", enlSuplidores.Email) { SqlDbType = SqlDbType.NVarChar });
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

        public void Update(Enl_Suplidores enlSuplidores)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxP.Spr_Update_Suplidores", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlSuplidores.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@RazonSocial", enlSuplidores.RazonSocial) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@RNC", enlSuplidores.RNC) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Tipo", enlSuplidores.Tipo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Categoria", enlSuplidores.Categoria) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@SubCategoria", enlSuplidores.SubCategoria) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Direccion", enlSuplidores.Direccion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlSuplidores.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Apellido", enlSuplidores.Apellido) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Cedula", enlSuplidores.Cedula) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Celular", enlSuplidores.Celular) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fax", enlSuplidores.Fax) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Telefono", enlSuplidores.Telefono) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@FechaNacimiento", enlSuplidores.FechaNacimiento) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Email", enlSuplidores.Email) { SqlDbType = SqlDbType.NVarChar });

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

        public void Delete(Enl_Suplidores enlSuplidores)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxP.Spr_Delete_Suplidores", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlSuplidores.Codigo) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_Suplidores> Search(Enl_Suplidores enlSuplidores)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxP.Spr_Search_Suplidores", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Codigo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlSuplidores.Codigo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@RazonSocial",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlSuplidores.RazonSocial
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@RNC",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlSuplidores.RNC
                });


                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Categoria",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlSuplidores.Categoria
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@SubCategoria",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlSuplidores.SubCategoria
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlSuplidores.Nombre
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Telefono",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlSuplidores.Telefono
                });


                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Email",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlSuplidores.Email
                });

                var dr = command.ExecuteReader();
                var list = new List<Enl_Suplidores>();

                while (dr.Read())
                {
                    list.Add(new Enl_Suplidores
                    {
                        Codigo = dr.GetString(dr.GetOrdinal("Codigo")),
                        RazonSocial = dr.GetString(dr.GetOrdinal("RazonSocial")),
                        RNC = dr.GetString(dr.GetOrdinal("RNC")),
                        Tipo = dr.GetString(dr.GetOrdinal("Tipo")),
                        Categoria = dr.GetString(dr.GetOrdinal("Categoria")),
                        SubCategoria = dr.GetString(dr.GetOrdinal("SubCategoria")),
                        Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                        Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                        Apellido = dr.GetString(dr.GetOrdinal("Apellido")),
                        Cedula = dr.GetString(dr.GetOrdinal("Cedula")),
                        Celular = dr.GetString(dr.GetOrdinal("Celular")),
                        Fax = dr.GetString(dr.GetOrdinal("Fax")),
                        Telefono = dr.GetString(dr.GetOrdinal("Telefono")),
                        FechaNacimiento = dr.GetDateTime(dr.GetOrdinal("FechaNacimiento")),
                        Email = dr.GetString(dr.GetOrdinal("Email")),

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

        public string IsExiste(Enl_Suplidores enlSuplidores)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxP.Spr_IsExiste_Suplidor", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlSuplidores.Codigo) { SqlDbType = SqlDbType.NVarChar });
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
