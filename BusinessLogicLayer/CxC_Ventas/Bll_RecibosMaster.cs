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
  public  class Bll_RecibosMaster
    {

        Dal_ReciboMaster dalReciboMaster = new Dal_ReciboMaster();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_ReciboMaster enlReciboMaster)
        {

            //Validaciones De Lugar


            if (dalNumeracion.ObtenerTipo("Recibos") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Recibos")))
                {
                    enlReciboMaster.Numero = dalNumeracion.ObtenerPrefijo("Recibos") + dalNumeracion.ObtenerNumero("Recibos").ToString("00000000");
                }
                else
                {
                    enlReciboMaster.Numero = dalNumeracion.ObtenerNumero("Recibos").ToString("00000000");
                }

            }

            if (dalReciboMaster.Search(enlReciboMaster).Count == 0)
            {
                dalReciboMaster.Insert(enlReciboMaster);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro Ya Existen", "Error");

            }

            return enlReciboMaster.Numero;
        }

        public void Update(Enl_ReciboMaster enlReciboMaster)
        {

            //Validaciones De Lugar

            dalReciboMaster.Update(enlReciboMaster);

        }

        public void Delete(Enl_ReciboMaster enlReciboMaster)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlReciboMaster.Numero))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalReciboMaster.Delete(enlReciboMaster);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                }
            }
        }

        public IList<Enl_ReciboMaster> Search(Enl_ReciboMaster enlReciboMaster)
        {

            //Validaciones de Lugar

            if (dalReciboMaster.Search(enlReciboMaster).Count != 0)
            {

                return dalReciboMaster.Search(enlReciboMaster);

            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_ReciboMaster enlReciboMaster)
        {

            return dalReciboMaster.IsExiste(enlReciboMaster);

        }
    }
}
