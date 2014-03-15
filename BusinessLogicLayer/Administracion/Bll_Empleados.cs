using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.Administracion;
using DataAccessLayer.Administracion;
using System.Windows.Forms;

namespace BusinessLogicLayer.Administracion
{
  public  class Bll_Empleados
    {

        Dal_Empleados dalEmpleados = new Dal_Empleados();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_Empleados enlEmpleados)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("Empleados") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Empleados")))
                {
                    enlEmpleados.Codigo = dalNumeracion.ObtenerPrefijo("Empleados") + dalNumeracion.ObtenerNumero("Empleados").ToString("00000000");
                }
                else
                {
                    enlEmpleados.Codigo = dalNumeracion.ObtenerNumero("Empleados").ToString("00000000");
                }

            }


            if (dalEmpleados.Search(enlEmpleados).Count == 0)
            {
                dalEmpleados.Insert(enlEmpleados);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro Ya Existe", "SGF");
            }

            return enlEmpleados.Codigo;
        }

        public void Update(Enl_Empleados enlEmpleados)
        {

            //Validaciones De Lugar

            dalEmpleados.Update(enlEmpleados);
            MessageBox.Show("Registro Guardado Correctamente", "SGF");

        }

        public bool Delete(Enl_Empleados enlEmpleados)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlEmpleados.Codigo))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalEmpleados.Delete(enlEmpleados);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                    return true;
                }
            }
            return false;
        }

        public IList<Enl_Empleados> Search(Enl_Empleados enlEmpleados)
        {

            //Validaciones de Lugar

            var ListaEmpleados = dalEmpleados.Search(enlEmpleados);

            if (ListaEmpleados.Count != 0)
            {

                return ListaEmpleados;

            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_Empleados enlEmpleados)
        {

            return dalEmpleados.IsExiste(enlEmpleados);

        }

    }
}
