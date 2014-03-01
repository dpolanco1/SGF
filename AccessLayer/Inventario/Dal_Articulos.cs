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
  public  class Dal_Articulos
    {

        public void Insert(Enl_Articulos enlArticulos)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Insert_Articulos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlArticulos.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlArticulos.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Descripcion", enlArticulos.Descripcion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlArticulos.Nota) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Marca", enlArticulos.Marca) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Categoria", enlArticulos.Categoria) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@SubCategoria", enlArticulos.SubCategoria) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Costo", enlArticulos.Costo) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Precio", enlArticulos.Precio) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Impuesto", enlArticulos.Impuesto) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Existencia", enlArticulos.Existencia) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@CodigoBarra", enlArticulos.CodigoBarra) { SqlDbType = SqlDbType.NVarChar });
               
                
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

        public void Update(Enl_Articulos enlArticulos)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Update_Articulos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();


                command.Parameters.Add(new SqlParameter("@Codigo", enlArticulos.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nombre", enlArticulos.Nombre) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Descripcion", enlArticulos.Descripcion) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Nota", enlArticulos.Nota) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Marca", enlArticulos.Marca) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Categoria", enlArticulos.Categoria) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@SubCategoria", enlArticulos.SubCategoria) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Costo", enlArticulos.Costo) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Precio", enlArticulos.Precio) { SqlDbType = SqlDbType.Decimal });
                command.Parameters.Add(new SqlParameter("@Impuesto", enlArticulos.Impuesto) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@CodigoBarra", enlArticulos.CodigoBarra) { SqlDbType = SqlDbType.NVarChar });

              
               
                
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

        public void Delete(Enl_Articulos enlArticulos)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Delete_Articulos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlArticulos.Codigo) { SqlDbType = SqlDbType.NVarChar });

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

        public IList<Enl_Articulos> Search(Enl_Articulos enlArticulos)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Search_Articulos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Codigo",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlArticulos.Codigo
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Nombre",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlArticulos.Nombre
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Descripcion",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlArticulos.Descripcion
                });


                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Impuesto",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlArticulos.Impuesto
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Marca",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlArticulos.Marca
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@Categoria",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlArticulos.Categoria
                });

                command.Parameters.Add(new SqlParameter()
                {
                    ParameterName = "@SubCategoria",
                    SqlDbType = SqlDbType.NVarChar,
                    Value = enlArticulos.SubCategoria
                });

         


                var dr = command.ExecuteReader();
                var list = new List<Enl_Articulos>();

                while (dr.Read())
                {
                    list.Add(new Enl_Articulos
                    {
                        Codigo = dr.GetString(dr.GetOrdinal("Codigo")),
                        Nombre = dr.GetString(dr.GetOrdinal("Nombre")),
                        Descripcion = dr.GetString(dr.GetOrdinal("Descripcion")),
                        Nota = dr.GetString(dr.GetOrdinal("Nota")),
                        Marca = dr.GetString(dr.GetOrdinal("Marca")),
                        Categoria = dr.GetString(dr.GetOrdinal("Categoria")),
                        SubCategoria = dr.GetString(dr.GetOrdinal("SubCategoria")),
                        Costo = dr.GetDecimal(dr.GetOrdinal("Costo")),
                        Precio = dr.GetDecimal(dr.GetOrdinal("Precio")),
                        Impuesto = dr.GetString(dr.GetOrdinal("Impuesto")),
                        Existencia = dr.GetDecimal(dr.GetOrdinal("Existencia")),
                        CodigoBarra = dr.GetString(dr.GetOrdinal("CodigoBarra"))

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

        public void UpdateExistencia(Enl_Articulos enlArticulos)
        {
            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_Update_Existencia", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;

                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlArticulos.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@Existencia", enlArticulos.Existencia) { SqlDbType = SqlDbType.Decimal });
         
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

        public string IsExiste(Enl_Articulos enlArticulos)
        {

            try
            {
                SqlCommand command = new SqlCommand("Inv.Spr_IsExiste_Articulos", Connection.Get);
                command.CommandType = CommandType.StoredProcedure;
                Connection.Get.Open();

                command.Parameters.Add(new SqlParameter("@Codigo", enlArticulos.Codigo) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add(new SqlParameter("@CodigoBarra", enlArticulos.CodigoBarra) { SqlDbType = SqlDbType.NVarChar });
                command.Parameters.Add("@IsExiste", SqlDbType.Bit);
                command.Parameters["@IsExiste"].Direction = ParameterDirection.Output;

                command.ExecuteNonQuery();

                return  command.Parameters["@IsExiste"].Value.ToString();
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
