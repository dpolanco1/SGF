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
   public class Bll_SubCategoriaSuplidores
    {

        Dal_SubCategoriaSuplidores dalSubCategoriaSuplidores = new Dal_SubCategoriaSuplidores();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_SubCategoriaSuplidores enlSubCategoriaSuplidores)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("SubCategoria de Suplidores") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("SubCategoria de Suplidores")))
                {
                    enlSubCategoriaSuplidores.Codigo = dalNumeracion.ObtenerPrefijo("SubCategoria de Suplidores") + dalNumeracion.ObtenerNumero("SubCategoria de Suplidores").ToString("00000000");
                }
                else
                {
                    enlSubCategoriaSuplidores.Codigo = dalNumeracion.ObtenerNumero("SubCategoria de Suplidores").ToString("00000000");
                }

            }

            if (dalSubCategoriaSuplidores.Search(enlSubCategoriaSuplidores).Count == 0)
            {
                dalSubCategoriaSuplidores.Insert(enlSubCategoriaSuplidores);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro ya Existe","SGF");
            }

            return enlSubCategoriaSuplidores.Codigo;

        }

        public void Update(Enl_SubCategoriaSuplidores enlSubCategoriaSuplidores)
        {

            //Validaciones De Lugar

            dalSubCategoriaSuplidores.Update(enlSubCategoriaSuplidores);

        }

        public void Delete(Enl_SubCategoriaSuplidores enlSubCategoriaSuplidores)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlSubCategoriaSuplidores.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalSubCategoriaSuplidores.Delete(enlSubCategoriaSuplidores);
                }
            }
        }

        public IList<Enl_SubCategoriaSuplidores> Search(Enl_SubCategoriaSuplidores enlSubCategoriaSuplidores)
        {

            //Validaciones de Lugar

            if (dalSubCategoriaSuplidores.Search(enlSubCategoriaSuplidores).Count != 0)
            {

                return dalSubCategoriaSuplidores.Search(enlSubCategoriaSuplidores);

            }
            else
            {
                return null;


            }

        }


    }
}
