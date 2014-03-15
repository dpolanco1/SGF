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
   public class Bll_FacturaMaster
    {
       Dal_FacturaMaster dalFacturasMaster = new Dal_FacturaMaster();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_FacturaMaster enlFacturasMaster)
        {

            //Validaciones De Lugar


            if (dalNumeracion.ObtenerTipo("Facturas") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Facturas")))
                {
                    enlFacturasMaster.Numero = dalNumeracion.ObtenerPrefijo("Facturas") + dalNumeracion.ObtenerNumero("Facturas").ToString("00000000");
                }
                else
                {
                    enlFacturasMaster.Numero = dalNumeracion.ObtenerNumero("Facturas").ToString("00000000");
                }

            }
            else
            {

                if (enlFacturasMaster.Numero == String.Empty)
                {
                    MessageBox.Show("El Numero de Factura es Obligatorio", "SGF");
                    return enlFacturasMaster.Numero;
                }

            }


   // if enlFacturasMaster.Cliente


            if (dalFacturasMaster.Search(enlFacturasMaster).Count == 0)
            {
                dalFacturasMaster.Insert(enlFacturasMaster);
               
            }
            else
            {
                MessageBox.Show("Registro Ya Existen", "Error");

            }

            return enlFacturasMaster.Numero;
        }

        public void Update(Enl_FacturaMaster enlFacturasMaster)
        {

            //Validaciones De Lugar

            dalFacturasMaster.Update(enlFacturasMaster);

        }

        public void Delete(Enl_FacturaMaster enlFacturasMaster)
        {

            //Validaciones De Lugar

                    dalFacturasMaster.Delete(enlFacturasMaster);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                
            
        }

        public IList<Enl_FacturaMaster> Search(Enl_FacturaMaster enlFacturasMaster)
        {

            //Validaciones de Lugar
            var ListaFactura = (dalFacturasMaster.Search(enlFacturasMaster));

            if (ListaFactura.Count != 0)
            {

                return ListaFactura;

            }
            else
            {
                return null;


            }

        }

        public void UpdateBalance(Enl_FacturaMaster enlFacturasMaster)
        {

            //Validaciones De Lugar

            dalFacturasMaster.UpdateBalance(enlFacturasMaster);

        }

        public string IsExiste(Enl_FacturaMaster enlFacturasMaster)
        {

            return dalFacturasMaster.IsExiste(enlFacturasMaster);

        }
   
   }
}
