using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.CxC_Ventas;
using DataAccessLayer.CxC_Ventas;
using DataAccessLayer.Administracion;
using System.Windows.Forms;

namespace BusinessLogicLayer.CxC_Ventas
{
  public  class Bll_CategoriaClientes
    {

      Dal_CategoriaClientes dalCategoriaClientes = new Dal_CategoriaClientes();
      Dal_Numeracion dalNumeracion = new Dal_Numeracion();
     
      public string Insert(Enl_CategoriaClientes enlCategoriaClientes)
      { 
      
            //Validaciones De Lugar


          if (dalNumeracion.ObtenerTipo("Categoria de Clientes") == "Automatico")
          {
              if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Categoria de Clientes")))
              {
                  enlCategoriaClientes.Codigo = dalNumeracion.ObtenerPrefijo("Categoria de Clientes") + dalNumeracion.ObtenerNumero("Categoria de Clientes").ToString("00000000");
              }
              else
              {
                  enlCategoriaClientes.Codigo = dalNumeracion.ObtenerNumero("Categoria de Clientes").ToString("00000000");
              }

          }

          if (dalCategoriaClientes.Search(enlCategoriaClientes).Count == 0)
          {
              dalCategoriaClientes.Insert(enlCategoriaClientes);
              MessageBox.Show("Registro Guardado Correctamente", "SGF");
          }
          else
          {
              MessageBox.Show("Registro Ya Existen", "Error");
         
          }

          return enlCategoriaClientes.Codigo;
      }

      public void Update(Enl_CategoriaClientes enlCategoriaClientes)
      {

          //Validaciones De Lugar

          dalCategoriaClientes.Update(enlCategoriaClientes);

      }

      public bool Delete(Enl_CategoriaClientes enlCategoriaClientes)
      {

          //Validaciones De Lugar

          if (!string.IsNullOrEmpty(enlCategoriaClientes.Codigo))
          {

           if(MessageBox.Show("Realmente Desea Eliminar El Registro","Eliminar",MessageBoxButtons.YesNo,MessageBoxIcon.Error) == DialogResult.Yes)
              {
                  dalCategoriaClientes.Delete(enlCategoriaClientes);
                  MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                  return true;
                    
              }
          }
          return false;
      }

      public IList <Enl_CategoriaClientes> Search(Enl_CategoriaClientes enlCategoriaClientes)
      {

          //Validaciones de Lugar

          var ListaCategoriaClientes = dalCategoriaClientes.Search(enlCategoriaClientes);

          if (ListaCategoriaClientes.Count != 0)
          {

              return ListaCategoriaClientes;

          }
          else
          {
              return null;

          
          }

      }

      public string IsExiste(Enl_CategoriaClientes enlCategoriaClientes)
      {

          return dalCategoriaClientes.IsExiste(enlCategoriaClientes);

      }
  
  }
}
