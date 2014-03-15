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
    public class Bll_Almacen
    {

        Dal_Almacen dalAlmacen = new Dal_Almacen();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_Almacen enlAlmacen)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("Almacen") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Almacen")))
                {
                    enlAlmacen.Codigo = dalNumeracion.ObtenerPrefijo("Almacen") + dalNumeracion.ObtenerNumero("Almacen").ToString("00000000");
                }
                else
                {
                    enlAlmacen.Codigo = dalNumeracion.ObtenerNumero("Almacen").ToString("00000000");
                }

            }


            if (dalAlmacen.IsExiste(enlAlmacen) == "False")
            {
                dalAlmacen.Insert(enlAlmacen);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro ya Existe", "SGF");
            }
            return enlAlmacen.Codigo;

           



        }

        public void Update(Enl_Almacen enlAlmacen)
        {

            //Validaciones De Lugar

            dalAlmacen.Update(enlAlmacen);

        }

        public bool Delete(Enl_Almacen enlAlmacen)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlAlmacen.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalAlmacen.Delete(enlAlmacen);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                    return true;
                }
            }
            return false;
        }

        public IList<Enl_Almacen> Search(Enl_Almacen enlAlmacen)
        {

            //Validaciones de Lugar

            var ListaAlmacen = dalAlmacen.Search(enlAlmacen);

            if (ListaAlmacen.Count != 0)
            {

                return ListaAlmacen;

            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_Almacen enlAlmacen)
        {

            return dalAlmacen.IsExiste(enlAlmacen);

        }
    }
}
