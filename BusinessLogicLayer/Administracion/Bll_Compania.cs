using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.Administracion;
using DataAccessLayer.Administracion;
using System.Windows.Forms;


namespace BusinessLogicLayer.Administracion
{
  public  class Bll_Compania
    {
      Dal_Compania dalCompania = new Dal_Compania();

      public void Update(Enl_Compania enlCompania)
      {

          //Validaciones De Lugar

          dalCompania.Update(enlCompania);
      

      }

      public IList<Enl_Compania> Search(Enl_Compania enlCompania)

      {

          //Validaciones de Lugar

  
              return dalCompania.Search(enlCompania);

         

      }

    }
}
