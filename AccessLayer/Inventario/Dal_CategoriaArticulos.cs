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
   public class Dal_CategoriaArticulos
    {

        public void Insert(Enl_CategoriaArticulos enlCategoriaArticulo)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Insert_CategoriaArticulos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCategoriaArticulo.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlCategoriaArticulo.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlCategoriaArticulo.Nota) { SqlDbType = SqlDbType.NVarChar });
               
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

        public void Update(Enl_CategoriaArticulos enlCategoriaArticulo)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Update_CategoriaArticulos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCategoriaArticulo.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlCategoriaArticulo.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlCategoriaArticulo.Nota) { SqlDbType = SqlDbType.NVarChar });
    
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

        public void Delete(Enl_CategoriaArticulos enlCategoriaArticulo)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Delete_CategoriaArticulos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCategoriaArticulo.Codigo) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_CategoriaArticulos> Search(Enl_CategoriaArticulos enlCategoriaArticulo)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Search_CategoriaArticulos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Codigo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCategoriaArticulo.Codigo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlCategoriaArticulo.Nombre
                });



                var dr = command.ExecuteReader();
                var list = new List<Enl_CategoriaArticulos>();

                while (dr.Read())
                {
                    list.Add(new Enl_CategoriaArticulos
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

        public string IsExiste(Enl_CategoriaArticulos enlCategoriaArticulo)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_IsExiste_CategoriaArticulos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlCategoriaArticulo.Codigo) { SqlDbType = SqlDbType.NVarChar });
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
