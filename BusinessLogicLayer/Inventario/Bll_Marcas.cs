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
    public class Bll_Marcas
    {
        Dal_Marcas dalMarcas = new Dal_Marcas();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_Marcas enlMarcas)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("Marcas") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Marcas")))
                {
                    enlMarcas.Codigo = dalNumeracion.ObtenerPrefijo("Marcas") + dalNumeracion.ObtenerNumero("Marcas").ToString("00000000");
                }
                else
                {
                    enlMarcas.Codigo = dalNumeracion.ObtenerNumero("Marcas").ToString("00000000");
                }

            }

            if (dalMarcas.IsExiste(enlMarcas) == "False")
            {

                dalMarcas.Insert(enlMarcas);
                MessageBox.Show("Registro Creado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro ya Existe");
            }
            return enlMarcas.Codigo;

        }

        public void Update(Enl_Marcas enlMarcas)
        {

            //Validaciones De Lugar

            dalMarcas.Update(enlMarcas);

        }

        public void Delete(Enl_Marcas enlMarcas)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlMarcas.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalMarcas.Delete(enlMarcas);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                }
            }
        }

        public IList<Enl_Marcas> Search(Enl_Marcas enlMarcas)
        {

            //Validaciones de Lugar

            if (dalMarcas.Search(enlMarcas).Count != 0)
            {

                return dalMarcas.Search(enlMarcas);

            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_Marcas enlMarcas)
        {

            return dalMarcas.IsExiste(enlMarcas);
        
        }

    }
}
