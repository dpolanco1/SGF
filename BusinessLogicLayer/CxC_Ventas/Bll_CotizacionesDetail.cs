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
 public  class Bll_CotizacionesDetail
    {
        Dal_CotizacionesDetail dalCotizacionDetail = new Dal_CotizacionesDetail();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public void Insert(Enl_CotizacionesDetail enlCotizacionesDetail)
        {

            //Validaciones De Lugar

            dalCotizacionDetail.Insert(enlCotizacionesDetail);

        }

        public void Update(Enl_CotizacionesDetail enlCotizacionesDetail)
        {

            //Validaciones De Lugar

            dalCotizacionDetail.Update(enlCotizacionesDetail);

        }

        public bool Delete(Enl_CotizacionesDetail enlCotizacionesDetail)
        {

            //Validaciones De Lugar


            if (!string.IsNullOrEmpty(enlCotizacionesDetail.NoCotizacion))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {

                    dalCotizacionDetail.Delete(enlCotizacionesDetail);
                    return true;
                }
            }

            return false;
        }

        public IList<Enl_CotizacionesDetail> Search(Enl_CotizacionesDetail enlCotizacionesDetail)
        {

            //Validaciones de Lugar

            return dalCotizacionDetail.Search(enlCotizacionesDetail);

        }


    }
}
