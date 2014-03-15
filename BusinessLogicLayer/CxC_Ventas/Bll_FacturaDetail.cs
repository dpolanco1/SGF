using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.CxC_Ventas;
using DataAccessLayer.CxC_Ventas;
using DataAccessLayer.Administracion;
using DataAccessLayer.Inventario;
using EntityLayer.Inventario;
using System.Windows.Forms;


namespace BusinessLogicLayer.CxC_Ventas
{
  public  class Bll_FacturaDetail
    {

        Dal_FacturaDetail dalFacturaDetail = new Dal_FacturaDetail();
     
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        Enl_Articulos enlArticulos = new Enl_Articulos();
        Dal_Articulos dalArticulos = new Dal_Articulos();

        public bool Insert(Enl_FacturaDetail enlFacturaDetail)
        {

              //Validaciones De Lugar
            
        

            // Verificamos si el articulo se esta vendiendo igual o por debajo del costo, lo cual 
            // no es permitido

            enlArticulos.Codigo = enlFacturaDetail.Codigo;
            enlArticulos.Nombre = string.Empty;
            enlArticulos.Descripcion = string.Empty;
            enlArticulos.Impuesto = string.Empty;
            enlArticulos.Marca = string.Empty;
            enlArticulos.Categoria = string.Empty;
            enlArticulos.SubCategoria = string.Empty;

            var ListaArticulos = dalArticulos.Search(enlArticulos);

            // preguntamos si el precio es menor o igual al costo si es asi devolvemos falso lo cual no se guardara
            // la factura, de lo contrario devolvemos true
            if (enlFacturaDetail.Precio <= ListaArticulos[0].Costo)
            {
                MessageBox.Show("El Articulo " + enlFacturaDetail.Codigo + " tiene un precio menor que el costo");
                return false;
            }
            else
            {
                dalFacturaDetail.Insert(enlFacturaDetail);
                return true;
            }
       
        }

        public void Update(Enl_FacturaDetail enlfFacturaDetail)
        {

            //Validaciones De Lugar

            dalFacturaDetail.Update(enlfFacturaDetail);

        }

        public bool Delete(Enl_FacturaDetail enlfFacturaDetail)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlfFacturaDetail.NoFactura))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {

                    dalFacturaDetail.Delete(enlfFacturaDetail);
                    return true;
                }
            }
            return false;
                  
        }

        public IList<Enl_FacturaDetail> Search(Enl_FacturaDetail enlfFacturaDetail)
        {

            //Validaciones de Lugar
            
                return dalFacturaDetail.Search(enlfFacturaDetail);

        }

    }
}
