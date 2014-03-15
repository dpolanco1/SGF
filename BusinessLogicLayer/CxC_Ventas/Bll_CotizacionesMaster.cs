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
  public  class Bll_CotizacionesMaster
    {
      Dal_CotizacionesMaster dalCotizacionesMaster = new Dal_CotizacionesMaster();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_CotizacionesMaster enlCotizacionesMaster)
        {

            //Validaciones De Lugar


            if (dalNumeracion.ObtenerTipo("Cotizaciones") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Cotizaciones")))
                {
                    enlCotizacionesMaster.Numero = dalNumeracion.ObtenerPrefijo("Cotizaciones") + dalNumeracion.ObtenerNumero("Cotizaciones").ToString("00000000");
                }
                else
                {
                    enlCotizacionesMaster.Numero = dalNumeracion.ObtenerNumero("Cotizaciones").ToString("00000000");
                }

            }

            if (dalCotizacionesMaster.Search(enlCotizacionesMaster).Count == 0)
            {
                dalCotizacionesMaster.Insert(enlCotizacionesMaster);

            }
            else
            {
                MessageBox.Show("Registro Ya Existen", "Error");

            }

            return enlCotizacionesMaster.Numero;
        }

        public void Update(Enl_CotizacionesMaster enlCotizacionesMaster)
        {

            //Validaciones De Lugar

            dalCotizacionesMaster.Update(enlCotizacionesMaster);

        }

        public void Delete(Enl_CotizacionesMaster enlCotizacionesMaster)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlCotizacionesMaster.Numero))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalCotizacionesMaster.Delete(enlCotizacionesMaster);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                }
            }
        }

        public IList<Enl_CotizacionesMaster> Search(Enl_CotizacionesMaster enlCotizacionesMaster)
        {

            //Validaciones de Lugar

            var ListaCotizacion = dalCotizacionesMaster.Search(enlCotizacionesMaster);

            if (ListaCotizacion.Count != 0)
            {

                return ListaCotizacion;

            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_CotizacionesMaster enlCotizacionesMaster)
        {

            return dalCotizacionesMaster.IsExiste(enlCotizacionesMaster);

        }


    }
}
