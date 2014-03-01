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
   public class Dal_Compania
    {

       public void Update(Enl_Compania enlCompania)
       {

           try
           {
               SqlCommand command = new SqlCommand("Adm.Spr_Update_Compania", Connection.Get);
               command.CommandType = CommandType.StoredProcedure;

               Connection.Get.Open();

               command.Parameters.Add(new SqlParameter("@NombreCompania", enlCompania.NombreCompania) { SqlDbType = SqlDbType.NVarChar });
               command.Parameters.Add(new SqlParameter("@Telefono", enlCompania.Telefono) { SqlDbType = SqlDbType.NVarChar });
               command.Parameters.Add(new SqlParameter("@Fax", enlCompania.Fax) { SqlDbType = SqlDbType.NVarChar });
               command.Parameters.Add(new SqlParameter("@Email", enlCompania.Email) { SqlDbType = SqlDbType.NVarChar });
               command.Parameters.Add(new SqlParameter("@PaginaWeb", enlCompania.PaginaWeb) { SqlDbType = SqlDbType.NVarChar });
               command.Parameters.Add(new SqlParameter("@Direccion", enlCompania.Direccion) { SqlDbType = SqlDbType.NVarChar });
               command.Parameters.Add(new SqlParameter("@RNC", enlCompania.RNC) { SqlDbType = SqlDbType.NVarChar });
               command.Parameters.Add(new SqlParameter("@Ciudad", enlCompania.Ciudad) { SqlDbType = SqlDbType.NVarChar });
               command.Parameters.Add(new SqlParameter("@Pais", enlCompania.Pais) { SqlDbType = SqlDbType.NVarChar });
               command.Parameters.Add(new SqlParameter("@Contacto", enlCompania.Contacto) { SqlDbType = SqlDbType.NVarChar });
              
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

       public IList<Enl_Compania> Search(Enl_Compania enlCompania)
       {

           try
           {
               SqlCommand command = new SqlCommand("Adm.Spr_Search_Compania", Connection.Get);
               command.CommandType = CommandType.StoredProcedure;
               Connection.Get.Open();

               var dr = command.ExecuteReader();
               var list = new List<Enl_Compania>();

               while (dr.Read())
               {
                   list.Add(new Enl_Compania
                   {
                       NombreCompania = dr.GetString(dr.GetOrdinal("NombreCompania")),
                       Telefono = dr.GetString(dr.GetOrdinal("Telefono")),
                       Fax = dr.GetString(dr.GetOrdinal("Fax")),
                       Email = dr.GetString(dr.GetOrdinal("Email")),
                       PaginaWeb = dr.GetString(dr.GetOrdinal("PaginaWeb")),
                       Direccion = dr.GetString(dr.GetOrdinal("Direccion")),
                       RNC = dr.GetString(dr.GetOrdinal("RNC")),
                       Ciudad = dr.GetString(dr.GetOrdinal("Ciudad")),
                       Pais = dr.GetString(dr.GetOrdinal("Pais")),
                       Contacto = dr.GetString(dr.GetOrdinal("Contacto"))

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


    }
}
