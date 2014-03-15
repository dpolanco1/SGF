using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.CxP_Compras;
using DataAccessLayer.CxC_Compras;
using DataAccessLayer.Administracion;
using System.Windows.Forms;

namespace BusinessLogicLayer.CxP_Compras
{
  public  class Bll_ComprasMaster
    {

        Dal_ComprasMaster dalCompraMaster = new Dal_ComprasMaster();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_ComprasMaster enlCompraMaster)
        {

            //Validaciones De Lugar


            if (dalNumeracion.ObtenerTipo("Compras") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Compras")))
                {
                    enlCompraMaster.Numero = dalNumeracion.ObtenerPrefijo("Compras") + dalNumeracion.ObtenerNumero("Compras").ToString("00000000");
                }
                else
                {
                    enlCompraMaster.Numero = dalNumeracion.ObtenerNumero("Compras").ToString("00000000");
                }

            }

            if (dalCompraMaster.Search(enlCompraMaster).Count == 0)
            {
                dalCompraMaster.Insert(enlCompraMaster);

            }
            else
            {
                MessageBox.Show("Registro Ya Existen", "Error");

            }

            return enlCompraMaster.Numero;
        }

        public void Update(Enl_ComprasMaster enlCompraMaster)
        {

            //Validaciones De Lugar

            dalCompraMaster.Update(enlCompraMaster);

        }

        public void Delete(Enl_ComprasMaster enlCompraMaster)
        {

            //Validaciones De Lugar

                    dalCompraMaster.Delete(enlCompraMaster);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
               
        }
        public IList<Enl_ComprasMaster> Search(Enl_ComprasMaster enlCompraMaster)
        {

            //Validaciones de Lugar

            var ListaCompra = dalCompraMaster.Search(enlCompraMaster);

            if (ListaCompra.Count != 0)
            {

                return ListaCompra;

            }
            else
            {
                return null;


            }

        }


    }
}
