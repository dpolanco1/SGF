using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.Administracion;
using DataAccessLayer.Administracion;
using System.Windows.Forms;

namespace BusinessLogicLayer.Administracion
{
   public class Bll_Gastos
    {

        Dal_Gastos dalGastos = new Dal_Gastos();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_Gastos enlGastos)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("Gastos") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Gastos")))
                {
                    enlGastos.Numero = dalNumeracion.ObtenerPrefijo("Gastos") + dalNumeracion.ObtenerNumero("Gastos").ToString("00000000");
                }
                else
                {
                    enlGastos.Numero = dalNumeracion.ObtenerNumero("Gastos").ToString("00000000");
                }

            }

          

            if (dalGastos.IsExiste(enlGastos) == "False")
            {

                dalGastos.Insert(enlGastos);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
                return enlGastos.Numero;
               
            }
            else
            {
                MessageBox.Show("Registro ya Existe", "SGF");
                return null;
            }


            
        }

        public void Update(Enl_Gastos enlGastos)
        {

            //Validaciones De Lugar

            dalGastos.Update(enlGastos);

        }

        public void Delete(Enl_Gastos enlGastos)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlGastos.Numero))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalGastos.Delete(enlGastos);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                }
            }
        }

        public IList<Enl_Gastos> Search(Enl_Gastos enlGastos)
        {

            //Validaciones de Lugar

            if (dalGastos.Search(enlGastos).Count != 0)
            {

                return dalGastos.Search(enlGastos);

            }
            else
            {
                return null;

            }

        }

        public string IsExiste(Enl_Gastos enlGastos)
        {

            return  (dalGastos.IsExiste(enlGastos));

        }
   
   
   
   
   }

 }


