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
   public class Bll_Terminos
    {

       Dal_Terminos dalTerminos = new Dal_Terminos();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_Termino enlTermino)
        {

            //Validaciones De Lugar


            if (dalNumeracion.ObtenerTipo("Terminos") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Terminos")))
                {
                    enlTermino.Codigo = dalNumeracion.ObtenerPrefijo("Terminos") + dalNumeracion.ObtenerNumero("Terminos").ToString("00000000");
                }
                else
                {
                    enlTermino.Codigo = dalNumeracion.ObtenerNumero("Terminos").ToString("00000000");
                }

            }
            else {

                if (enlTermino.Codigo == String.Empty)
                {
                    MessageBox.Show("El Codigo es Obligatorio", "SGF");
                    return enlTermino.Codigo;
                
                }
            
            }

            if (dalTerminos.Search(enlTermino).Count == 0)
            {
                dalTerminos.Insert(enlTermino);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro Ya Existen", "Error");

            }

            return enlTermino.Codigo;
        }

        public void Update(Enl_Termino enlTermino)
        {

            //Validaciones De Lugar

            dalTerminos.Update(enlTermino);

        }

        public void Delete(Enl_Termino enlTermino)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlTermino.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalTerminos.Delete(enlTermino);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                }
            }
        }

        public IList<Enl_Termino> Search(Enl_Termino enlTermino)
        {

            //Validaciones de Lugar

            if (dalTerminos.Search(enlTermino).Count != 0)
            {

                return dalTerminos.Search(enlTermino);

            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_Termino enlTermino)
        {

            return dalTerminos.IsExiste(enlTermino);

        }

    }
}
