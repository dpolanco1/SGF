using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DataAccessLayer.CxC_Ventas;
using EntityLayer.CxC_Ventas;
using DataAccessLayer.Administracion;

namespace BusinessLogicLayer.CxC_Ventas
{


   public class Bll_SubCategoriaClientes
    {

       Dal_SubCategoriaClientes dalSubCategoriaCliente = new Dal_SubCategoriaClientes();
       Dal_Numeracion dalNumeracion = new Dal_Numeracion();

       public string Insert(Enl_SubCategoriaClientes enlSubCategoriaClientes)
       {

           //Validaciones De Lugar

           if (dalNumeracion.ObtenerTipo("SubCategoria de Clientes") == "Automatico")
           {
               if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("SubCategoria de Clientes")))
               {
                   enlSubCategoriaClientes.Codigo = dalNumeracion.ObtenerPrefijo("SubCategoria de Clientes") + dalNumeracion.ObtenerNumero("Categoria de Clientes").ToString("00000000");
               }
               else
               {
                   enlSubCategoriaClientes.Codigo = dalNumeracion.ObtenerNumero("SubCategoria de Clientes").ToString("00000000");
               }

           }

           if (dalSubCategoriaCliente.Search(enlSubCategoriaClientes).Count == 0)
           {
               dalSubCategoriaCliente.Insert(enlSubCategoriaClientes);
               MessageBox.Show("Registro Guardado Correctamente","SGF");
           }
           else
           {
               MessageBox.Show("Registro ya Existe", "SGF");
           
           }

           return enlSubCategoriaClientes.Codigo;
       }

       public void Update(Enl_SubCategoriaClientes enlSubCategoriaClientes)
       {

           //Validaciones De Lugar

           dalSubCategoriaCliente.Update(enlSubCategoriaClientes);

       }

       public void Delete(Enl_SubCategoriaClientes enlSubCategoriaClientes)
       {

           //Validaciones De Lugar

           if (!string.IsNullOrEmpty(enlSubCategoriaClientes.Codigo))
           {

               if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
               {
     
                   dalSubCategoriaCliente.Delete(enlSubCategoriaClientes);
               }
           }
       }

       public IList<Enl_SubCategoriaClientes> Search(Enl_SubCategoriaClientes enlSubCategoriaClientes)
       {

           //Validaciones de Luga

           if (dalSubCategoriaCliente.Search(enlSubCategoriaClientes).Count != 0)
           {

               return dalSubCategoriaCliente.Search(enlSubCategoriaClientes);

           }
           else
           {
               return null;


           }

       }

       public string IsExiste(Enl_SubCategoriaClientes enlSubCategoriaClientes)
       {

           return dalSubCategoriaCliente.IsExiste(enlSubCategoriaClientes);

       }

    }
}
