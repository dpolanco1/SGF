using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer.Administracion;
using BusinessLogicLayer.Administracion;

namespace aPrestentationLayer.Administracion
{
    public partial class Frm_Login : Form
    {
        public Frm_Login()
        {
            InitializeComponent();
        }

        Enl_Usuarios enlUsuarios = new Enl_Usuarios();
        Enl_Compania enlCompania = new Enl_Compania();

        Bll_Usuarios bllUsuarios = new Bll_Usuarios();
        Bll_Compania bllCompania = new Bll_Compania();

       

        


        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.OpenForms["Frm_Principal"].Close();
            Close();
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            var list = bllCompania.Search(enlCompania);


            //if (string.IsNullOrEmpty(cmbCompania.Text) || string.IsNullOrEmpty(txtContrasena.Text) || string.IsNullOrEmpty(txtUsuario.Text))
            //{
            //    MessageBox.Show("Todos los Campos Son Obligatorios ", "SGF", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //else
            //{

            string User, Pass;
            User = txtUsuario.Text;
            Pass = txtContrasena.Text;
            if (User.Equals("admin") == true && Pass.Equals("123") == true)
            {


                if (list.Count != 0)
                {


                    Enl_DatosDeSession.NombreCompania = list[0].NombreCompania;
                    Enl_DatosDeSession.Telefono = list[0].Telefono;
                    Enl_DatosDeSession.Fax = list[0].Fax;
                    Enl_DatosDeSession.Email = list[0].Email;
                    Enl_DatosDeSession.PaginaWeb = list[0].PaginaWeb;
                    Enl_DatosDeSession.Direccion = list[0].Direccion;
                    Enl_DatosDeSession.RNC = list[0].RNC;
                    Enl_DatosDeSession.Ciudad = list[0].Ciudad;
                    Enl_DatosDeSession.Pais = list[0].Pais;


                    Enl_DatosDeSession.NombreUsuario = "Admin";
                }
                Close();
            }
            else
            {
                if (User.Equals("Ventas") == true && Pass.Equals("1234567") == true)
                {
                   
                    Enl_DatosDeSession.NombreCompania = list[0].NombreCompania;
                    Enl_DatosDeSession.Telefono = list[0].Telefono;
                    Enl_DatosDeSession.Fax = list[0].Fax;
                    Enl_DatosDeSession.Email = list[0].Email;
                    Enl_DatosDeSession.PaginaWeb = list[0].PaginaWeb;
                    Enl_DatosDeSession.Direccion = list[0].Direccion;
                    Enl_DatosDeSession.RNC = list[0].RNC;
                    Enl_DatosDeSession.Ciudad = list[0].Ciudad;
                    Enl_DatosDeSession.Pais = list[0].Pais;

                    Enl_DatosDeSession.NombreUsuario = "Ventas";

                    Close();


                }
                else
                {
                    enlUsuarios.NombreUsuario = txtUsuario.Text;
                    enlUsuarios.Nombre = string.Empty;
                    enlUsuarios.Apellido = string.Empty;

                    if (bllUsuarios.IsExiste(enlUsuarios) == "True")
                    {
                       var list2 = bllUsuarios.Search(enlUsuarios);

                        if (User.Equals(list2[0].NombreUsuario) == true && Pass.Equals(list2[0].Contrasena) == true)
                        {
                            Enl_DatosDeSession.NombreCompania = list[0].NombreCompania;
                            Enl_DatosDeSession.Telefono = list[0].Telefono;
                            Enl_DatosDeSession.Fax = list[0].Fax;
                            Enl_DatosDeSession.Email = list[0].Email;
                            Enl_DatosDeSession.PaginaWeb = list[0].PaginaWeb;
                            Enl_DatosDeSession.Direccion = list[0].Direccion;
                            Enl_DatosDeSession.RNC = list[0].RNC;
                            Enl_DatosDeSession.Ciudad = list[0].Ciudad;
                            Enl_DatosDeSession.Pais = list[0].Pais;

                            Enl_DatosDeSession.NombreUsuario = txtUsuario.Text;

                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o Contrasena Incorrecto ", "SGF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario o Contrasena Incorrecto ", "SGF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }


        }

        private void Frm_Login_Load(object sender, EventArgs e)
        {

        }
    }
}
