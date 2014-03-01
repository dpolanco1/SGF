using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessLayer.Administracion;
using EntityLayer.Administracion;
using DataAccessLayer.Administracion;
using System.Windows.Forms;

namespace BusinessLogicLayer.Administracion
{
   public class Bll_Numeracion
    {

       Dal_Numeracion dalNumeracion = new Dal_Numeracion();
      

        public int ObtenerNumero(string Transaccion)
        {
            return dalNumeracion.ObtenerNumero(Transaccion);

        }

        public string ObtenerPrefijo(string Transaccion)
        {

            return dalNumeracion.ObtenerPrefijo(Transaccion);

        }

        public string ObtenerTipo(string Transaccion)
        {

            return dalNumeracion.ObtenerTipo(Transaccion);

        }

        public void ActualizarNumero(int ValorMax, string Transaccion)
        {

            dalNumeracion.ActualizarNumero(ValorMax, Transaccion);
        }

        public IList<Enl_Numeracion> Search(Enl_Numeracion enlNumeracion)
        {

            //Validaciones de Lugar

            if (dalNumeracion.Search(enlNumeracion).Count != 0)
            {

                return dalNumeracion.Search(enlNumeracion);

            }
            else
            {
                return null;


            }

        }

        public void Insert(Enl_Numeracion enlNumeracion)
        {

            //Validaciones De Lugar


            dalNumeracion.Insert(enlNumeracion);
        
        }

        public void Delete(Enl_Numeracion enlNumeracion)
        {

            //Validaciones De Lugar

         
             dalNumeracion.Delete(enlNumeracion);
             
            }
        }
    }



