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
  public  class Bll_FacturaDetail
    {

        Dal_FacturaDetail dalFacturaDetail = new Dal_FacturaDetail();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public void Insert(Enl_FacturaDetail enlfFacturaDetail)
        {

              //Validaciones De Lugar

            dalFacturaDetail.Insert(enlfFacturaDetail);
       
        }

        public void Update(Enl_FacturaDetail enlfFacturaDetail)
        {

            //Validaciones De Lugar

            dalFacturaDetail.Update(enlfFacturaDetail);

        }

        public void Delete(Enl_FacturaDetail enlfFacturaDetail)
        {

            //Validaciones De Lugar

            dalFacturaDetail.Delete(enlfFacturaDetail);
                  
        }

        public IList<Enl_FacturaDetail> Search(Enl_FacturaDetail enlfFacturaDetail)
        {

            //Validaciones de Lugar
            
                return dalFacturaDetail.Search(enlfFacturaDetail);

        }

    }
}
