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
    public class Bll_Articulos
    {

        Dal_Articulos dalArticulos = new Dal_Articulos();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_Articulos enlArticulos)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlArticulos.Codigo))
            {

                if (dalNumeracion.ObtenerTipo("Articulos") == "Automatico")
                {
                    if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Articulos")))
                    {
                        enlArticulos.Codigo = dalNumeracion.ObtenerPrefijo("Articulos") + dalNumeracion.ObtenerNumero("Articulos").ToString("00000000");
                    }
                    else
                    {
                        enlArticulos.Codigo = dalNumeracion.ObtenerNumero("Articulos").ToString("00000000");
                    }

                }


                if (dalArticulos.IsExiste(enlArticulos) == "False")
                {
                    dalArticulos.Insert(enlArticulos);
                    MessageBox.Show("Registro Guardado Correctamente", "SGF");
                    return enlArticulos.Codigo;
                }
                else
                {
                    MessageBox.Show("Registro ya Existe", "SGF");
                    return "";
                }

            }
            else
            {
                MessageBox.Show("Los Campos en Negritas son Obligatorios");
                return "";
            }
        }

        public void Update(Enl_Articulos enlArticulos)
        {

            //Validaciones De Lugar

            dalArticulos.Update(enlArticulos);

        }

        public bool Delete(Enl_Articulos enlArticulos)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlArticulos.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalArticulos.Delete(enlArticulos);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                    return true;
                }
            }
            return false;
        }

        public IList<Enl_Articulos> Search(Enl_Articulos enlArticulos)
        {

            //Validaciones de Lugar

            var ListaArticulos = dalArticulos.Search(enlArticulos);

            if (ListaArticulos.Count != 0)
            {

                return ListaArticulos;

            }
            else
            {
                return null;


            }

        }

        public void UpdateExitencia(Enl_Articulos enlArticulos)
        { 
            
            //Validaciones de Lugar


            dalArticulos.UpdateExistencia(enlArticulos);
            
        }

        public string IsExiste(Enl_Articulos enlArticulos)
        {

            return dalArticulos.IsExiste(enlArticulos);

        }


    }
}
