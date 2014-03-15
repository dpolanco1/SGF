using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EntityLayer.Administracion;
using DataAccessLayer.Administracion;
using System.Windows.Forms;

namespace BusinessLogicLayer.Administracion
{
   public class Bll_Usuarios
    {
       Dal_Usuarios dalUsuarios = new Dal_Usuarios();
        Dal_Numeracion dalNumeracion = new Dal_Numeracion();

        public string Insert(Enl_Usuarios enlUsuarios)
        {

            //Validaciones De Lugar

            if (dalNumeracion.ObtenerTipo("Usuario") == "Automatico")
            {
                if (!string.IsNullOrEmpty(dalNumeracion.ObtenerPrefijo("Usuario")))
                {
                    enlUsuarios.NombreUsuario = dalNumeracion.ObtenerPrefijo("Usuario") + dalNumeracion.ObtenerNumero("Usuario").ToString("00000000");
                }
                else
                {
                    enlUsuarios.NombreUsuario = dalNumeracion.ObtenerNumero("Usuario").ToString("00000000");
                }

            }
            else {
                if(string.IsNullOrEmpty(enlUsuarios.NombreUsuario))
                {
                    MessageBox.Show("Ël Nombre de Usuario es Obligatorio", "SGF");
                    return enlUsuarios.NombreUsuario;
                }
            
            }

            if (dalUsuarios.Search(enlUsuarios).Count == 0)
            {

                dalUsuarios.Insert(enlUsuarios);
                MessageBox.Show("Registro Guardado Correctamente", "SGF");
            }
            else
            {
                MessageBox.Show("Registro ya Existe","SGF");
            
            }
            return enlUsuarios.NombreUsuario;

        }

        public void Update(Enl_Usuarios enlUsuarios)
        {

            //Validaciones De Lugar

            dalUsuarios.Update(enlUsuarios);

        }

        public bool Delete(Enl_Usuarios enlUsuarios)
        {

            //Validaciones De Lugar

            if (!string.IsNullOrEmpty(enlUsuarios.NombreUsuario))
            {

                if (MessageBox.Show("Realmente Desea Eliminar El Registro", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                {
                    dalUsuarios.Delete(enlUsuarios);
                    MessageBox.Show("Registro Eliminado Exitosamente", "SGF");
                    return true;
                }
                
            }
            return false;
        }

        public IList<Enl_Usuarios> Search(Enl_Usuarios enlUsuarios)
        {

            //Validaciones de Lugar

            var ListaUsuarios = dalUsuarios.Search(enlUsuarios);

            if (ListaUsuarios.Count != 0)
            {

                return ListaUsuarios;

            }
            else
            {
                return null;


            }

        }

        public string IsExiste(Enl_Usuarios enlUsuarios)
        {

            return dalUsuarios.IsExiste(enlUsuarios);

        }
    }
}
