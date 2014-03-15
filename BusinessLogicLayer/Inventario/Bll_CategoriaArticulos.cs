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
    public class Bll_CategoriaArticulos
    {
        Dal_CategoriaArticulos dalCategoriaArticulos = new Dal_CategoriaArticulos();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_CategoriaArticulos enlCategoriaArticulo)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("Categoria de Articulos") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Categoria de Articulos")))
                {
                    enlCategoriaArticulo.Codigo = dalNumeracion.ObtenerPrefijo("Categoria de Articulos") + dalNumeracion.ObtenerNumero("Categoria de Articulos").ToString("00000000");
                }
                else
                {
                    enlCategoriaArticulo.Codigo = dalNumeracion.ObtenerNumero("Categoria de Articulos").ToString("00000000");
                }

            }

            if (dalCategoriaArticulos.IsExiste(enlCategoriaArticulo) == "False")
            {
                dalCategoriaArticulos.Insert(enlCategoriaArticulo);
                MessageBox.Show("Registro Creado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro ya Existe", "SGF");
            }
            return enlCategoriaArticulo.Codigo;

        }

        public void Update(Enl_CategoriaArticulos enlCategoriaArticulo)
        {

            //Validaciones De Lugar

            dalCategoriaArticulos.Update(enlCategoriaArticulo);

        }

        public bool Delete(Enl_CategoriaArticulos enlCategoriaArticulo)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlCategoriaArticulo.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalCategoriaArticulos.Delete(enlCategoriaArticulo);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                    return true;
                }
            }
            return false;
        }

        public IList<Enl_CategoriaArticulos> Search(Enl_CategoriaArticulos enlCategoriaArticulo)
        {

            //Validaciones de Lugar

            var ListaCategoriaArticulos = dalCategoriaArticulos.Search(enlCategoriaArticulo);

            if (ListaCategoriaArticulos.Count != 0)
            {

                return ListaCategoriaArticulos;
            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_CategoriaArticulos enlCategoriaArticulo)
        {

            return dalCategoriaArticulos.IsExiste(enlCategoriaArticulo);

        }
    }
}
