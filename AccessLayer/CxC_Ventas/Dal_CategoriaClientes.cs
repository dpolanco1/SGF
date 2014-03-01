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
    public class Dal_CategoriaClientes
    {

        public void Insert(Enl_CategoriaClientes enlCategoriaClientes)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Insert_CategoriaClientes", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCategoriaClientes.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlCategoriaClientes.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlCategoriaClientes.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Update(Enl_CategoriaClientes enlCategoriaClientes)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Update_CategoriaClientes", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCategoriaClientes.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlCategoriaClientes.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlCategoriaClientes.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Delete(Enl_CategoriaClientes enlCategoriaClientes)
        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Delete_CategoriaClientes", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCategoriaClientes.Codigo) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_CategoriaClientes> Search(Enl_CategoriaClientes enlCategoriaClientes)
             {

                 try
                 {
                     SqlCommand command = new SqlCommand("CxC.Spr_Search_CategoriaClientes", Connection.Get);
                     command.CommandType = CommandType.StoredProcedure;
                     Connection.Get.Open();

                     command.Parameters.Add(new SqlParameter()
                     {
                         ParameterName = "@Codigo",
                         SqlDbType = SqlDbType.NVarChar,
                         Value = enlCategoriaClientes.Codigo
                     });

                     command.Parameters.Add(new SqlParameter()
                     {
                         ParameterName = "@Nombre",
                         SqlDbType = SqlDbType.NVarChar,
                         Value = enlCategoriaClientes.Codigo
                     });


                     var dr = command.ExecuteReader();
                     var list = new List<Enl_CategoriaClientes>();

                     while (dr.Read())
                     {
                         list.Add(new Enl_CategoriaClientes
                         {
                             Codigo = dr.GetString(dr.GetOrdinal("Codigo")),
                             Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
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

        public string IsExiste(Enl_CategoriaClientes enlCategoriaClientes)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_IsExiste_Categoriaclientes", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCategoriaClientes.Codigo) { SqlDbType = SqlDbType.NVarChar });
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

