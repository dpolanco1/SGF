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
    public class Dal_SubCategoriaClientes
    {

        public void Insert(Enl_SubCategoriaClientes entSubCategoriaClientes)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Insert_SubCategoriaClientes", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", entSubCategoriaClientes.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", entSubCategoriaClientes.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", entSubCategoriaClientes.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Update(Enl_SubCategoriaClientes entSubCategoriaClientes)
        {
            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Update_SubCategoriaClientes", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", entSubCategoriaClientes.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", entSubCategoriaClientes.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", entSubCategoriaClientes.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Delete(Enl_SubCategoriaClientes enlSubCategoriaClientes)

        {

            try
            {

                SqlCommand command = new SqlCommand("CxC.Spr_Delete_CategoriaClientes", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlSubCategoriaClientes.Codigo) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_SubCategoriaClientes> Search(Enl_SubCategoriaClientes entSubCategoriaClientes)
        {
             try
                 {

                     SqlCommand command = new SqlCommand("CxC.Spr_Search_SubCategoriaClientes", Connection.Get);
                     command.CommandType = CommandType.StoredProcedure;
                     Connection.Get.Open();

                     command.Parameters.Add(new SqlParameter()
                     {
                         ParameterName = "@Codigo",
                         SqlDbType = SqlDbType.NVarChar,
                         Value = entSubCategoriaClientes.Codigo
                     });

                     command.Parameters.Add(new SqlParameter()
                     {
                         ParameterName = "@Nombre",
                         SqlDbType = SqlDbType.NVarChar,
                         Value = entSubCategoriaClientes.Codigo
                     });

                     var dr = command.ExecuteReader();
                     var list = new List<Enl_SubCategoriaClientes>();

                     while (dr.Read())
                     {
                         list.Add(new Enl_SubCategoriaClientes
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

        public string IsExiste(Enl_SubCategoriaClientes enlSubCategoriaClientes)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxC.Spr_IsExiste_SubCategoriaClientes", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlSubCategoriaClientes.Codigo) { SqlDbType = SqlDbType.NVarChar });
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

