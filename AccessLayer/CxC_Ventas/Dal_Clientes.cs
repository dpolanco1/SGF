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
  public  class Dal_Clientes
    {

        public void Insert(Enl_Clientes enlClientes)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Insert_Clientes", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlClientes.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@RazonSocial", enlClientes.RazonSocial) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@RNC", enlClientes.RNC) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@NCF", enlClientes.NCF) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@LimiteCredito", enlClientes.LimteCredito) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Categoria", enlClientes.Categoria) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@SubCategoria", enlClientes.SubCategoria) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Direccion", enlClientes.Direccion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlClientes.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Apellido", enlClientes.Apellido) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Cedula", enlClientes.Cedula) { SqlDbType = SqlDbType.NVarChar });  
                command.Parameters.Add(new SqlParameter("@Celular", enlClientes.Celular) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fax", enlClientes.Fax) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Telefono", enlClientes.Telefono) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@FechaNacimiento", enlClientes.FechaNacimiento) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Email", enlClientes.Email) { SqlDbType = SqlDbType.NVarChar });

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

        public void Update(Enl_Clientes enlClientes)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Update_Clientes", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlClientes.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@RazonSocial", enlClientes.RazonSocial) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@RNC", enlClientes.RNC) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@NCF", enlClientes.NCF) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@LimiteCredito", enlClientes.LimteCredito) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Categoria", enlClientes.Categoria) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@SubCategoria", enlClientes.SubCategoria) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Direccion", enlClientes.Direccion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlClientes.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Apellido", enlClientes.Apellido) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Cedula", enlClientes.Cedula) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Celular", enlClientes.Celular) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Fax", enlClientes.Fax) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Telefono", enlClientes.Telefono) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@FechaNacimiento", enlClientes.FechaNacimiento) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Email", enlClientes.Email) { SqlDbType = SqlDbType.NVarChar });
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

        public void Delete(Enl_Clientes enlClientes)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Delete_Clientes", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlClientes.Codigo) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_Clientes> Search(Enl_Clientes enlClientes)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_Search_Clientes", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Codigo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlClientes.Codigo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@RazonSocial",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlClientes.RazonSocial
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@RNC",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlClientes.RNC
                });


                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Categoria",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlClientes.Categoria
                });
                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@SubCategoria",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlClientes.SubCategoria
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlClientes.Nombre
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Telefono",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlClientes.Telefono
                });


                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Email",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlClientes.Email
                });

                var dr = command.ExecuteReader();
                var list = new List<Enl_Clientes>();

                while (dr.Read())
                {
                    list.Add(new Enl_Clientes
                    {
                        Codigo = dr.GetString(dr.GetOrdinal("Codigo")),
                        RazonSocial = dr.GetString(dr.GetOrdinal("RazonSocial")),
                        RNC = dr.GetString(dr.GetOrdinal("RNC")),
                        NCF = dr.GetString(dr.GetOrdinal("NCF")),
                        LimteCredito = dr.GetDecimal(dr.GetOrdinal("LimiteCredito")),
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

        public string IsExiste(Enl_Clientes enlClientes)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_IsExiste_Cliente", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlClientes.Codigo) { SqlDbType = SqlDbType.NVarChar });
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
