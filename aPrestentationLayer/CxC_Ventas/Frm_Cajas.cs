using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aPrestentationLayer.Plantillas;
using EntityLayer.CxC_Ventas;
using BusinessLogicLayer.CxC_Ventas;
using BusinessLogicLayer.Administracion;
using BusinessLogicLayer.Otros;

namespace aPrestentationLayer.CxC_Ventas
{
    public partial class Frm_Cajas : Frm_Plantilla
    {

        string Estado = string.Empty;
        const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";

        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_Caja enlCaja = new Enl_Caja();
        Bll_Caja bllCaja = new Bll_Caja();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_Cajas()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
         
            btnVista.Click += btnVista_Click;
            this.DGV_Cajas.AutoGenerateColumns = false;
           
        }



        void btnNuevo_Click(object sender, EventArgs e)
        {
            Estado = NUEVO;

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

            }

            BotonNuevo();

            if (bllNumeracion.ObtenerTipo("Caja") == "Automatico")
            {
                txtCodigo.Enabled = false;
                txtNombre.Focus();
            }
            else
            {
                txtCodigo.Enabled = true;
                txtCodigo.Focus();
            }

        }

        void btnGuardar_Click(object sender, EventArgs e)
        {

            enlCaja.Codigo = txtCodigo.Text;
            enlCaja.Nombre = txtNombre.Text;
            enlCaja.Custodio = txtCustodio.Text;
            enlCaja.Saldo = 0;
            enlCaja.Nota = txtNota.Text;

            if (Estado == "Creando")
            {
                txtCodigo.Text = bllCaja.Insert(enlCaja);

                if (bllNumeracion.ObtenerTipo("Caja") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Caja"), "Caja");
                }

                BotonGuardar();
            }
            else
            {
                if (Estado == "Editando")
                {
                    bllCaja.Update(enlCaja);
                    MessageBox.Show("Registro Actualizado Correctamente", "SGF");
                    BotonGuardar();
                }
            }
            ActualizarDGV = true;

        }

        void btnEditar_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Cajas.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_Cajas[0, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Cajas[1, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                    txtCustodio.Text = DGV_Cajas[2, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                    lblMontoSaldo.Text = DGV_Cajas[3, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_Cajas[4, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                }
            }
            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                BotonEditar();
                txtCodigo.Enabled = false;
                txtNombre.Focus();

            }
            
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {
             if (Estado == "Creando")
            {
                AC.DeshabilitarText(this);
                AC.VaciarText(this);
            }

             if (Estado == "Editando")
             {

                 enlCaja.Codigo = txtCodigo.Text;
                 enlCaja.Nombre = string.Empty;

                 var list = bllCaja.Search(enlCaja);

                 
                    txtNombre.Text = list[0].Nombre;
                    txtCustodio.Text = list[0].Custodio;
                    lblMontoSaldo.Text = Convert.ToString( list[0].Saldo);
                    txtNota.Text = list[0].Nota;

             }
            BotonCancelar();

        }

        void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Cajas.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_Cajas[0, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Cajas[1, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                    txtCustodio.Text = DGV_Cajas[2, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                    lblMontoSaldo.Text = DGV_Cajas[3, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_Cajas[4, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                }
            }

            enlCaja.Codigo = txtCodigo.Text;
            bllCaja.Delete(enlCaja);

            BotonEliminar();

            ActualizarDGV = true;
                

        }

        void btnBuscar_Click(object sender, EventArgs e)
        {
            //enlCategoriaClientes.Codigo = string.Empty;
            //enlCategoriaClientes.Nombre = string.Empty;

            //if (bllCategoriaClientes.Search(enlCategoriaClientes) != null)
            //{

            //    Frm_Buscar_CxC frmBuscarCxC = new Frm_Buscar_CxC();
            //    frmBuscarCxC.Owner = this;
            //    frmBuscarCxC.LlamadoDesde = "Frm_CategoriaClientes";
            //    frmBuscarCxC.dataGridView1.DataSource = bllCategoriaClientes.Search(enlCategoriaClientes);
            //    frmBuscarCxC.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("La Maestra Esta Vacia");
            //}


        }

        void btnVista_Click(object sender, EventArgs e)
        {

            if (ActualizarDGV == true)
            {

                enlCaja.Codigo = string.Empty;
                enlCaja.Nombre = string.Empty;

                DGV_Cajas.DataSource = bllCaja.Search(enlCaja);

                ActualizarDGV = false;
            }


            if (tabControl1.SelectedTab == tbpMaster)
            {
                tabControl1.TabPages.Remove(tbpMaster);
                tabControl1.TabPages.Add(tbpDetail);
                tabControl1.SelectTab(tbpDetail);
            }
            else
            {
                if (tabControl1.SelectedTab == tbpDetail)
                {
                    tabControl1.TabPages.Remove(tbpDetail);
                    tabControl1.TabPages.Add(tbpMaster);
                    tabControl1.SelectTab(tbpMaster);


                    txtCodigo.Text = DGV_Cajas[0, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Cajas[1, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                    txtCustodio.Text = DGV_Cajas[2, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                    lblMontoSaldo.Text = DGV_Cajas[3, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_Cajas[4, DGV_Cajas.CurrentCell.RowIndex].Value.ToString();
                }
            }

        }

        private void Frm_Cajas_Load(object sender, EventArgs e)
        {

            Estado = CONSULTA;
            tabControl1.TabPages.Remove(tbpMaster);

            enlCaja.Codigo = string.Empty;
            enlCaja.Nombre = string.Empty;

            DGV_Cajas.DataSource = bllCaja.Search(enlCaja);
        }

        private void DGV_Cajas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVista_Click(btnVista, null);
        }



      
    }
}
