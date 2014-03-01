using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aPrestentationLayer.Plantillas;
using EntityLayer.Administracion;
using BusinessLogicLayer.Administracion;

namespace aPrestentationLayer.Administracion
{
    public partial class Frm_Compania : Form
    {

        Enl_Compania enlCompania = new Enl_Compania();
        Bll_Compania bllCompania = new Bll_Compania();

        public Frm_Compania()
        {
            InitializeComponent();
        }


        private void Frm_Compania_Load(object sender, EventArgs e)
        {
            var list = bllCompania.Search(enlCompania);


            if (list.Count != 0)
            {

                txtNombreCompania.Text = list[0].NombreCompania;
                txtTelefono.Text = list[0].Telefono;
                txtFax.Text = list[0].Fax;
                txtEmail.Text = list[0].Email;
                txtPaginaWeb.Text = list[0].PaginaWeb;
                txtDireccion.Text = list[0].Direccion;
                txtRNC.Text = list[0].RNC;
                txtCiudad.Text = list[0].Ciudad;
                txtPais.Text = list[0].Pais;
                txtContacto.Text = list[0].Contacto;
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            enlCompania.NombreCompania = txtNombreCompania.Text;
            enlCompania.Telefono = txtTelefono.Text;
            enlCompania.Fax = txtFax.Text;
            enlCompania.Email = txtEmail.Text;
            enlCompania.PaginaWeb = txtPaginaWeb.Text;
            enlCompania.Direccion = txtDireccion.Text;
            enlCompania.RNC = txtRNC.Text;
            enlCompania.Ciudad = txtCiudad.Text;
            enlCompania.Pais = txtPais.Text;
            enlCompania.Contacto = txtContacto.Text;

            bllCompania.Update(enlCompania);

            //Actualizar Datos de Session
            
            Enl_DatosDeSession.NombreCompania = enlCompania.NombreCompania;
            Enl_DatosDeSession.Telefono = enlCompania.Telefono;
            Enl_DatosDeSession.Fax = enlCompania.Fax;
            Enl_DatosDeSession.Email = enlCompania.Email;
            Enl_DatosDeSession.PaginaWeb = enlCompania.PaginaWeb;
            Enl_DatosDeSession.Direccion = enlCompania.Direccion;
            Enl_DatosDeSession.RNC = enlCompania.RNC;
            Enl_DatosDeSession.Ciudad = enlCompania.Ciudad;
            Enl_DatosDeSession.Pais = enlCompania.Pais;
            Enl_DatosDeSession.Contacto = enlCompania.Contacto;
           


            Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

  

    }
}
