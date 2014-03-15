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
   public class Bll_Suplidores
    {
        Dal_Suplidores dalSuplidores = new Dal_Suplidores();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_Suplidores enlSuplidores)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("Suplidores") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Suplidores")))
                {
                    enlSuplidores.Codigo = dalNumeracion.ObtenerPrefijo("Suplidores") + dalNumeracion.ObtenerNumero("Suplidores").ToString("00000000");
                }
                else
                {
                    enlSuplidores.Codigo = dalNumeracion.ObtenerNumero("Suplidores").ToString("00000000");
                }

            }

            if (dalSuplidores.Search(enlSuplidores).Count == 0)
            {
                dalSuplidores.Insert(enlSuplidores);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro ya Existe", "SGF");

            }
            return enlSuplidores.Codigo;

        }

        public void Update(Enl_Suplidores enlSuplidores)
        {

            //Validaciones De Lugar

            dalSuplidores.Update(enlSuplidores);

        }

        public void Delete(Enl_Suplidores enlSuplidores)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlSuplidores.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalSuplidores.Delete(enlSuplidores);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                }
            }
        }

        public IList<Enl_Suplidores> Search(Enl_Suplidores enlSuplidores)
        {

            //Validaciones de Lugar

            var ListaSuplidores = dalSuplidores.Search(enlSuplidores);

            if (ListaSuplidores.Count != 0)
            {

                return ListaSuplidores;

            }
            else
            {
                return null;


            }

        }
    }
}
