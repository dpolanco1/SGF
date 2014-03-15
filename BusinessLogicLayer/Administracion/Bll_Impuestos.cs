using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.Administracion;
using DataAccessLayer.Administracion;
using System.Windows.Forms;

namespace BusinessLogicLayer.Administracion
{
    public   class Bll_Impuestos
    {

        Dal_Impuestos dalImpuestos = new Dal_Impuestos();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_Impuestos enlImpuestos)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("Impuestos") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Impuestos")))
                {
                    enlImpuestos.Codigo = dalNumeracion.ObtenerPrefijo("Impuestos") + dalNumeracion.ObtenerNumero("Impuestos").ToString("00000000");
                }
                else
                {
                    enlImpuestos.Codigo = dalNumeracion.ObtenerNumero("Impuestos").ToString("00000000");
                }

            }


            if (dalImpuestos.Search(enlImpuestos).Count == 0)
            {
                dalImpuestos.Insert(enlImpuestos);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro ya Existe", "SGF");
            }
            return enlImpuestos.Codigo;

        }

        public void Update(Enl_Impuestos enlImpuestos)
        {

            //Validaciones De Lugar

            dalImpuestos.Update(enlImpuestos);

        }

        public void Delete(Enl_Impuestos enlImpuestos)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlImpuestos.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalImpuestos.Delete(enlImpuestos);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                }
            }
        }

        public IList<Enl_Impuestos> Search(Enl_Impuestos enlImpuestos)
        {

            //Validaciones de Lugar

            var ListaImpuesto = dalImpuestos.Search(enlImpuestos);

            if (ListaImpuesto.Count != 0)
            {

                return ListaImpuesto;

            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_Impuestos enlImpuestos)
        {

            return dalImpuestos.IsExiste(enlImpuestos);

        }

    }
}
