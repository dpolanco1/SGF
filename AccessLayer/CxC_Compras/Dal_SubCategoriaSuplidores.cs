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
  public  class Dal_SubCategoriaSuplidores
    {

        public void Insert(Enl_SubCategoriaSuplidores enlSubCategoriaSuplidores)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxP.Spr_Insert_SubCategoriaSuplidores", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlSubCategoriaSuplidores.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlSubCategoriaSuplidores.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlSubCategoriaSuplidores.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Update(Enl_SubCategoriaSuplidores enlSubCategoriaSuplidores)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxP.Spr_Update_SubCategoriaSuplidores", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlSubCategoriaSuplidores.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlSubCategoriaSuplidores.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlSubCategoriaSuplidores.Nota) { SqlDbType = SqlDbType.NVarChar });

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

        public void Delete(Enl_SubCategoriaSuplidores enlSubCategoriaSuplidores)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxP.Spr_Delete_SubCategoriaSuplidores", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlSubCategoriaSuplidores.Codigo) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_SubCategoriaSuplidores> Search(Enl_SubCategoriaSuplidores enlSubCategoriaSuplidores)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxP.Spr_Search_SubCategoriaSuplidores", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Codigo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlSubCategoriaSuplidores.Codigo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlSubCategoriaSuplidores.Codigo
                });


                var dr = command.ExecuteReader();
                var list = new List<Enl_SubCategoriaSuplidores>();

                while (dr.Read())
                {
                    list.Add(new Enl_SubCategoriaSuplidores
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

        public string IsExiste(Enl_SubCategoriaSuplidores enlSubCategoriaSuplidores)
        {

            try
            {
                SqlCommand command = new SqlCommand("CxP.Spr_IsExiste_SubCategoriasuplidores", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlSubCategoriaSuplidores.Codigo) { SqlDbType = SqlDbType.NVarChar });
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
