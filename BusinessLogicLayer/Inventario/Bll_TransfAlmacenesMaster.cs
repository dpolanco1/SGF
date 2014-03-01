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
  public  class Bll_TransfAlmacenesMaster
    {


        Dal_TransfAlmacenesMaster dalTransfAlmacenesMaster = new Dal_TransfAlmacenesMaster();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_TransfAlmacenesMaster enlTransfAlmacenesMaster)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("Tranferencia de Almacenes") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Tranferencia de Almacenes")))
                {
                    enlTransfAlmacenesMaster.Numero = dalNumeracion.ObtenerPrefijo("Tranferencia de Almacenes") + dalNumeracion.ObtenerNumero("Tranferencia de Almacenes").ToString("00000000");
                }
                else
                {
                    enlTransfAlmacenesMaster.Numero = dalNumeracion.ObtenerNumero("Tranferencia de Almacenes").ToString("00000000");
                }

            }

            if (dalTransfAlmacenesMaster.Search(enlTransfAlmacenesMaster).Count == 0)
            {
                dalTransfAlmacenesMaster.Insert(enlTransfAlmacenesMaster);
                MessageBox.Show("Registro Creado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro ya Existe", "SGF");
            }
            return enlTransfAlmacenesMaster.Numero;

        }

        public void Update(Enl_TransfAlmacenesMaster enlTransfAlmacenesMaster)
        {

            //Validaciones De Lugar

            dalTransfAlmacenesMaster.Update(enlTransfAlmacenesMaster);

        }

        public void Delete(Enl_TransfAlmacenesMaster enlTransfAlmacenesMaster)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlTransfAlmacenesMaster.Numero))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalTransfAlmacenesMaster.Delete(enlTransfAlmacenesMaster);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                }
            }
        }

        public IList<Enl_TransfAlmacenesMaster> Search(Enl_TransfAlmacenesMaster enlTransfAlmacenesMaster)
        {

            //Validaciones de Lugar

            if (dalTransfAlmacenesMaster.Search(enlTransfAlmacenesMaster).Count != 0)
            {

                return dalTransfAlmacenesMaster.Search(enlTransfAlmacenesMaster);

            }
            else
            {
                return null;


            }

        }



    }
}
