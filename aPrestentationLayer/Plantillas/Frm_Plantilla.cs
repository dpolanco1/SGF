using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BusinessLogicLayer.Otros;

namespace aPrestentationLayer.Plantillas
{
    public partial class Frm_Plantilla : Form
    {

        AdministrarControles AC = new AdministrarControles();


        public Frm_Plantilla()
        {
            InitializeComponent();
        }

        private void Frm_Plantilla_Load(object sender, EventArgs e)
        {
            AC.DeshabilitarText(this);

            this.btnGuardar.Enabled = false;
            this.btnCancelar.Enabled = false;
            this.btnEditar.Enabled = true;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            //this.btnNuevo.Enabled = false;
            //this.btnEditar.Enabled = false;
            //this.btnEliminar.Enabled = false;
            //this.btnImprimir.Enabled = false;
            //this.btnVista.Enabled = false;
            //this.btnBuscar.Enabled = false;

            //this.btnGuardar.Enabled = true;
            //this.btnCancelar.Enabled = true;

            //AC.VaciarText(this);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
         

        }

        private void btnVista_Click(object sender, EventArgs e)
        {
        //    if (tabControl1.SelectedTab == tbpMaster)
        //    {
        //        tabControl1.TabPages.Remove(tbpMaster);
        //        tabControl1.TabPages.Add(tbpDetail);
        //        tabControl1.SelectTab(tbpDetail);
        //    }
        //    else
        //    {
        //        if (tabControl1.SelectedTab == tbpDetail)
        //        {
        //            tabControl1.TabPages.Remove(tbpDetail);
        //            tabControl1.TabPages.Add(tbpMaster);
        //            tabControl1.SelectTab(tbpMaster);
        //        }
        //    }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
           
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
           
        }

        public void BotonNuevo()
        {
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnImprimir.Enabled = false;
            this.btnVista.Enabled = false;
            

            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = true;

            AC.VaciarText(this);
            AC.HabilitarText(this);
        
        }

        public void BotonGuardar ()
        {
            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnImprimir.Enabled = true;
            this.btnVista.Enabled = true;
      

            this.btnGuardar.Enabled = false;

            AC.DeshabilitarText(this);
        }

        public void BotonEditar()
        {
            this.btnNuevo.Enabled = false;
            this.btnEditar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnVista.Enabled = false;
        

            this.btnGuardar.Enabled = true;
            this.btnCancelar.Enabled = true;

            AC.HabilitarText(this);
        
        }

        public void BotonCancelar()
        {
            this.btnNuevo.Enabled = true;
            this.btnEditar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnImprimir.Enabled = true;
            this.btnVista.Enabled = true;
          

            this.btnGuardar.Enabled = false;
            this.btnCancelar.Enabled = false;

            AC.DeshabilitarText(this);
        }

        public void BotonEliminar()
        {
            AC.VaciarText(this);
        }

        public void OcultarToolBar()
        {
            toolBarsPrincipal.Visible = false;
        }

        private void toolBarsPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.Control == true && e.KeyValue == 13)
            //{
            //    btnOk_Click(sender, null);
            //    MessageBox.Show("Prueba 13");
            //}
            //if (e.KeyValue == 27)
            //{
            //    btnCancel_Click(sender, null);
            //    MessageBox.Show("Prueba 27");
            //}

       


        }

        private void Frm_Plantilla_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            {
                e.Handled = true;
                MessageBox.Show("Presiono F3");
            }

         
        }

    }
}
