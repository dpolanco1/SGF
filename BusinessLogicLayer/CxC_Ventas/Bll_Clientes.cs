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
   public class Bll_Clientes
    {
        Dal_Clientes dalClientes = new Dal_Clientes();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_Clientes enlClientes)
        {

            //Validaciones De Lugar


            if (dalNumeracion.ObtenerTipo("Clientes") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Clientes")))
                {
                    enlClientes.Codigo = dalNumeracion.ObtenerPrefijo("Clientes") + dalNumeracion.ObtenerNumero("Clientes").ToString("00000000");
                }
                else
                {
                    enlClientes.Codigo = dalNumeracion.ObtenerNumero("Clientes").ToString("00000000");
                }

            }

            if (dalClientes.Search(enlClientes).Count == 0)
            {
                dalClientes.Insert(enlClientes);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro Ya Existen", "Error");

            }

            return enlClientes.Codigo;
        }

        public void Update(Enl_Clientes enlClientes)
        {

            //Validaciones De Lugar

            dalClientes.Update(enlClientes);

        }

        public void Delete(Enl_Clientes enlClientes)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlClientes.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalClientes.Delete(enlClientes);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                }
            }
        }

        public IList<Enl_Clientes> Search(Enl_Clientes enlClientes)
        {

            //Validaciones de Lugar

            var ListaClientes = dalClientes.Search(enlClientes);

            if (ListaClientes.Count != 0)
            {

                return ListaClientes;

            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_Clientes enlClientes)
        {

            return dalClientes.IsExiste(enlClientes);

        }
    }
}
