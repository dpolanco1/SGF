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
   public  class Dal_Empleados
    {
        public void Insert(Enl_Empleados enlEmpleados)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Insert_Empleados", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlEmpleados.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlEmpleados.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Apellido", enlEmpleados.Apellido) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Cedula", enlEmpleados.Cedula) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Telefono", enlEmpleados.Telefono) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Direccion", enlEmpleados.Direccion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Email", enlEmpleados.Email) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Estatus", enlEmpleados.Estatus) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@EstadoCivil", enlEmpleados.EstadoCivil) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Sexo", enlEmpleados.Sexo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@FechaNacimiento", enlEmpleados.FechaNacimiento) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Salario", enlEmpleados.Salario) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Nacionalidad", enlEmpleados.Nacionalidad) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@IsVendedor", enlEmpleados.IsVendedor) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@Celular", enlEmpleados.Celular) { SqlDbType = SqlDbType.NVarChar });

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

        public void Update(Enl_Empleados enlEmpleados)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Update_Empleados", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlEmpleados.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlEmpleados.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Apellido", enlEmpleados.Apellido) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Cedula", enlEmpleados.Cedula) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Telefono", enlEmpleados.Telefono) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Direccion", enlEmpleados.Direccion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Email", enlEmpleados.Email) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Estatus", enlEmpleados.Estatus) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@EstadoCivil", enlEmpleados.EstadoCivil) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Sexo", enlEmpleados.Sexo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@FechaNacimiento", enlEmpleados.FechaNacimiento) { SqlDbType = SqlDbType.DateTime });
                command.Parameters.Add(new SqlParameter("@Salario", enlEmpleados.Salario) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Nacionalidad", enlEmpleados.Nacionalidad) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@IsVendedor", enlEmpleados.IsVendedor) { SqlDbType = SqlDbType.Bit });
                command.Parameters.Add(new SqlParameter("@Celular", enlEmpleados.Celular) { SqlDbType = SqlDbType.NVarChar });

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

        public void Delete(Enl_Empleados enlEmpleados)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Delete_Empleados", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlEmpleados.Codigo) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_Empleados> Search(Enl_Empleados enlEmpleados)
        {

            try
            {
                SqlCommand command = new SqlCommand("Adm.Spr_Search_Empleados", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Codigo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlEmpleados.Codigo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlEmpleados.Nombre
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Apellido",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlEmpleados.Apellido
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Cedula",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlEmpleados.Cedula
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Telefono",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlEmpleados.Telefono
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Direccion",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlEmpleados.Direccion
                });


                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Email",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlEmpleados.Email
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Estatus",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlEmpleados.Estatus
                });


                var dr = command.ExecuteReader();
                var list = new List<Enl_Empleados>();

                while (dr.Read())
                {
                    list.Add(new Enl_Empleados
                    {
                        Codigo = dr.GetString(dr.GetOrdinal("Codigo")),
                        Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                        Apellido = dr.GetString(dr.GetOrdinal("Apellido")),
                        Cedula = dr.GetString(dr.GetOrdinal("Cedula")),
                        Telefono = dr.GetString(dr.GetOrdinal("Telefono")),
                        Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                        Email = dr.GetString(dr.GetOrdinal("Email")),
                        Estatus = dr.GetString(dr.GetOrdinal("Estatus")),
                        EstadoCivil = dr.GetString(dr.GetOrdinal("EstadoCivil")),
                        Sexo = dr.GetString(dr.GetOrdinal("Sexo")),
                        FechaNacimiento = dr.GetDateTime(dr.GetOrdinal("FechaNacimiento")),
                        Salario = dr.GetDecimal(dr.GetOrdinal("Salario")),
                        Nacionalidad = dr.GetString(dr.GetOrdinal("Nacionalidad")),
                        IsVendedor = dr.GetBoolean(dr.GetOrdinal("IsVendedor")),
                        Celular = dr.GetString(dr.GetOrdinal("Celular"))
   

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

        public string IsExiste(Enl_Empleados enlEmpleados)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_IsExiste_Empleado", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlEmpleados.Codigo) { SqlDbType = SqlDbType.NVarChar });
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
