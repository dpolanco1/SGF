using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.Administracion;
using DataAccessLayer.Administracion;
using System.Windows.Forms;

namespace BusinessLogicLayer.Administracion
{
  public  class Bll_MododePago
    {

        Dal_MododePago dalModoPago = new Dal_MododePago();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_MododePago enlModoPago)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("Modo de Pago") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Modo de Pago")))
                {
                    enlModoPago.Codigo = dalNumeracion.ObtenerPrefijo("Modo de Pago") + dalNumeracion.ObtenerNumero("Modo de Pago").ToString("00000000");
                }
                else
                {
                    enlModoPago.Codigo = dalNumeracion.ObtenerNumero("Modo de Pago").ToString("00000000");
                }

            }

            if (dalModoPago.Search(enlModoPago).Count == 0)
            {

                dalModoPago.Insert(enlModoPago);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
               
            }
            else
            {
                MessageBox.Show("Registro ya Existe", "SGF");
            }


            return enlModoPago.Codigo;
        }

        public void Update(Enl_MododePago enlModoPago)
        {

            //Validaciones De Lugar

            dalModoPago.Update(enlModoPago);

        }

        public bool Delete(Enl_MododePago enlModoPago)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlModoPago.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalModoPago.Delete(enlModoPago);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                    return true;
                }
            }
            return false;
        }

        public IList<Enl_MododePago> Search(Enl_MododePago enlModoPago)
        {

            //Validaciones de Lugar

            var ListaModoPago = dalModoPago.Search(enlModoPago);

            if (ListaModoPago.Count != 0)
            {

                return ListaModoPago;

            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_MododePago enlModoPago)
        {

            return dalModoPago.IsExiste(enlModoPago);

        }
    }
}
