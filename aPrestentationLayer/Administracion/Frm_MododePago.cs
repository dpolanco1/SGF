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
using BusinessLogicLayer.Otros;

namespace aPrestentationLayer.Administracion
{
    public partial class Frm_MododePago : Frm_Plantilla
    {
        //estodos del sistema predefindos en la clase
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

       /* const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/
        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_MododePago enlModoPago = new Enl_MododePago();
        Bll_MododePago bllModoPago = new Bll_MododePago();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();

        public Frm_MododePago()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
         
            btnVista.Click += btnVista_Click;
            DGV_Modo_de_Pago.AutoGenerateColumns = false;
            
        }

        void btnNuevo_Click(object sender, EventArgs e)
        {
            //Estado = NUEVO;
            Estado = Helper.EstadoSystema.Creando;

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);
            
            }
            BotonNuevo();

            if (bllNumeracion.ObtenerTipo("Modo de Pago") == "Automatico")
            {
                txtCodigo.ReadOnly = true;
                txtNombre.Focus();
            } 
            else
            {
                txtCodigo.ReadOnly = false;
                txtCodigo.Focus();
            }

         


        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            enlModoPago.Codigo = txtCodigo.Text;
            enlModoPago.Nombre = txtNombre.Text;
            enlModoPago.Nota = txtNota.Text;

            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtCodigo.Text = bllModoPago.Insert(enlModoPago);
 
                if (bllNumeracion.ObtenerTipo("Modo de Pago") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Modo de Pago"), "Modo de Pago");
                }
            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllModoPago.Update(enlModoPago);
                    MessageBox.Show("Registro Actualizado Correctamente", "SGF");
                }
            }

            BotonGuardar();
            ActualizarDGV = true;

        }

        void btnEditar_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Modo_de_Pago.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_Modo_de_Pago[0, DGV_Modo_de_Pago.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Modo_de_Pago[1, DGV_Modo_de_Pago.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_Modo_de_Pago[2, DGV_Modo_de_Pago.CurrentCell.RowIndex].Value.ToString();
                }
            }

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {

                BotonEditar();
                Estado = Helper.EstadoSystema.Editando;
                txtNombre.Focus();
                txtCodigo.Enabled = false;

            }
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Estado == Helper.EstadoSystema.Creando)
            {
                AC.DeshabilitarText(this);
                AC.VaciarText(this);
            }

            if (Estado == Helper.EstadoSystema.Editando)
            {
                enlModoPago.Codigo = txtCodigo.Text;
                enlModoPago.Nombre = string.Empty;

                var list = bllModoPago.Search(enlModoPago);

                txtNombre.Text = list[0].Nombre;
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

                if (DGV_Modo_de_Pago.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_Modo_de_Pago[0, DGV_Modo_de_Pago.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Modo_de_Pago[1, DGV_Modo_de_Pago.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_Modo_de_Pago[2, DGV_Modo_de_Pago.CurrentCell.RowIndex].Value.ToString();
                }
            }

            enlModoPago.Codigo = txtCodigo.Text;

            if (bllModoPago.Delete(enlModoPago))
            {
                BotonEliminar();
                ActualizarDGV = true;
            }
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void Frm_MododePago_Load(object sender, EventArgs e)
        {

            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlModoPago.Codigo = string.Empty;
            enlModoPago.Nombre = string.Empty;

            DGV_Modo_de_Pago.DataSource = bllModoPago.Search(enlModoPago);
        }

        void btnVista_Click(object sender, EventArgs e)
        {

            if (ActualizarDGV == true)
            {

                enlModoPago.Codigo = string.Empty;
                enlModoPago.Nombre = string.Empty;

                DGV_Modo_de_Pago.DataSource = bllModoPago.Search(enlModoPago);
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

                    if (DGV_Modo_de_Pago.Rows.Count != 0)
                    {
                        txtCodigo.Text = DGV_Modo_de_Pago[0, DGV_Modo_de_Pago.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_Modo_de_Pago[1, DGV_Modo_de_Pago.CurrentCell.RowIndex].Value.ToString();
                        txtNota.Text = DGV_Modo_de_Pago[2, DGV_Modo_de_Pago.CurrentCell.RowIndex].Value.ToString();
                    }
                }
            }
        }

        private void DGV_Modo_de_Pago_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                Irecibos frm = this.Owner as Irecibos;
                string ModoPago;
                ModoPago = DGV_Modo_de_Pago[0, DGV_Modo_de_Pago.CurrentCell.RowIndex].Value.ToString();
                if (frm != null)
                frm.CodigoModoPago(ModoPago);
                Close();
            }
        }

    
    }
}
