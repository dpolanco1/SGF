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
  public  class Bll_Caja
    {

        Dal_Caja dalCaja = new Dal_Caja();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_Caja enlCaja)
        {

            //Validaciones De Lugar


            if (dalNumeracion.ObtenerTipo("Caja") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Caja")))
                {
                    enlCaja.Codigo = dalNumeracion.ObtenerPrefijo("Caja") + dalNumeracion.ObtenerNumero("Caja").ToString("00000000");
                }
                else
                {
                    enlCaja.Codigo = dalNumeracion.ObtenerNumero("Caja").ToString("00000000");
                }

            }

            if (dalCaja.Search(enlCaja).Count == 0)
            {
                dalCaja.Insert(enlCaja);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro Ya Existen", "Error");

            }

            return enlCaja.Codigo;
        }

        public void Update(Enl_Caja enlCaja)
        {

            //Validaciones De Lugar

            dalCaja.Update(enlCaja);

        }

        public void Delete(Enl_Caja enlCaja)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlCaja.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalCaja.Delete(enlCaja);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                }
            }
        }

        public IList<Enl_Caja> Search(Enl_Caja enlCaja)
        {

            //Validaciones de Lugar

            var ListaCaja = dalCaja.Search(enlCaja);

            if (ListaCaja.Count != 0)
            {

                return ListaCaja;

            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_Caja enlCaja)
        {

            return dalCaja.IsExiste(enlCaja);

        }

    }
}
