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
  public  class Bll_ComprasDetail
    {
        Dal_ComprasDetail dalComprasDetail = new Dal_ComprasDetail();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public void Insert(Enl_ComprasDetail enlCompraDetail)
        {

            //Validaciones De Lugar

            dalComprasDetail.Insert(enlCompraDetail);

        }

        public void Update(Enl_ComprasDetail enlCompraDetail)
        {

            //Validaciones De Lugar

            dalComprasDetail.Update(enlCompraDetail);

        }

        public bool Delete(Enl_ComprasDetail enlCompraDetail)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlCompraDetail.NoCompra))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalComprasDetail.Delete(enlCompraDetail);
                    return true;
                }
            }
            return false;
        }

        public IList<Enl_ComprasDetail> Search(Enl_ComprasDetail enlCompraDetail)
        {

            //Validaciones de Lugar

            return dalComprasDetail.Search(enlCompraDetail);

        }


    }
}
