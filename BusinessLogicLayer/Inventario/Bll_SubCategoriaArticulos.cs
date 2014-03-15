using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.Inventario;
using DataAccessLayer.Inventario;
using DataAccessLayer.Administracion;
using System.Windows.Forms;

namespace BusinessLogicLayer.Inventario
{
    public class Bll_SubCategoriaArticulos
    {
        Dal_SubCategoriaArticulos dalSubCategoriaArticulos = new Dal_SubCategoriaArticulos();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_SubCategoriaArticulos enlSubCategoriaArticulo)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("SubCategoria de Articulos") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("SubCategoria de Articulos")))
                {
                    enlSubCategoriaArticulo.Codigo = dalNumeracion.ObtenerPrefijo("SubCategoria de Articulos") + dalNumeracion.ObtenerNumero("SubCategoria de Articulos").ToString("00000000");
                }
                else
                {
                    enlSubCategoriaArticulo.Codigo = dalNumeracion.ObtenerNumero("SubCategoria de Articulos").ToString("00000000");
                }

            }

            if (dalSubCategoriaArticulos.IsExiste(enlSubCategoriaArticulo) == "False")
            {
                dalSubCategoriaArticulos.Insert(enlSubCategoriaArticulo);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro ya Existe","SGF");
            }
            return enlSubCategoriaArticulo.Codigo;

        }

        public void Update(Enl_SubCategoriaArticulos enlSubCategoriaArticulo)
        {

            //Validaciones De Lugar

            dalSubCategoriaArticulos.Update(enlSubCategoriaArticulo);

        }

        public void Delete(Enl_SubCategoriaArticulos enlSubCategoriaArticulo)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlSubCategoriaArticulo.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalSubCategoriaArticulos.Delete(enlSubCategoriaArticulo);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                }
            }
        }

        public IList<Enl_SubCategoriaArticulos> Search(Enl_SubCategoriaArticulos enlCategoriaArticulo)
        {

            //Validaciones de Lugar

            var ListaSubCategoriaArticulos = dalSubCategoriaArticulos.Search(enlCategoriaArticulo);

            if (ListaSubCategoriaArticulos.Count != 0)
            {

                return ListaSubCategoriaArticulos;

            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_SubCategoriaArticulos enlSubCategoriaArticulo)
        {

            return dalSubCategoriaArticulos.IsExiste(enlSubCategoriaArticulo);

        }


    }
}
