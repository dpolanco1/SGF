using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aPrestentationLayer.Plantillas;
using BusinessLogicLayer.CxC_Ventas;
using BusinessLogicLayer.Administracion;
using EntityLayer.CxC_Ventas;
using BusinessLogicLayer.Otros;



namespace aPrestentationLayer.CxC_Ventas
{
    public partial class Frm_SubCategoriaClientes : Frm_Plantilla
    {
        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

       /* const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/

        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_SubCategoriaClientes enlSubCategoriaCliente = new Enl_SubCategoriaClientes();
        Bll_SubCategoriaClientes bllSubCategoriaCliente = new Bll_SubCategoriaClientes();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();

        public Frm_SubCategoriaClientes()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
         
            btnVista.Click += btnVista_Click;
            DGV_SubCategoriaClientes.AutoGenerateColumns = false;
        }

        void btnVista_Click(object sender, EventArgs e)
        {
            if (ActualizarDGV == true)
            {

                enlSubCategoriaCliente.Codigo = string.Empty;
                enlSubCategoriaCliente.Nombre = string.Empty;

                DGV_SubCategoriaClientes.DataSource = bllSubCategoriaCliente.Search(enlSubCategoriaCliente);

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

                    if (DGV_SubCategoriaClientes.Rows.Count != 0)
                    {

                        txtCodigo.Text = DGV_SubCategoriaClientes[0, DGV_SubCategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_SubCategoriaClientes[1, DGV_SubCategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                        txtNota.Text = DGV_SubCategoriaClientes[2, DGV_SubCategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                    }
                }
            }
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


            if (bllNumeracion.ObtenerTipo("SubCategoria de Clientes") == "Automatico")
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

            enlSubCategoriaCliente.Codigo = txtCodigo.Text;
            enlSubCategoriaCliente.Nombre = txtNombre.Text;
            enlSubCategoriaCliente.Nota = txtNota.Text;

            if (Estado == Helper.EstadoSystema.Creando)
            {
                bllSubCategoriaCliente.Insert(enlSubCategoriaCliente);

                if (bllNumeracion.ObtenerTipo("SubCategoria de Clientes") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("SubCategoria de Clientes"), "SubCategoria de Clientes");
                }
           
            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllSubCategoriaCliente.Update(enlSubCategoriaCliente);
                    MessageBox.Show("Registro Actualizado Correctamente", "SGF");
                }
            }

            ActualizarDGV = true;
            BotonGuardar();



        }

        void btnEditar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_SubCategoriaClientes.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_SubCategoriaClientes[0, DGV_SubCategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_SubCategoriaClientes[1, DGV_SubCategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_SubCategoriaClientes[2, DGV_SubCategoriaClientes.CurrentCell.RowIndex].Value.ToString();
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
            if (Estado == Helper.EstadoSystema.Creando)
            {
                AC.DeshabilitarText(this);
                AC.VaciarText(this);
            }

            if (Estado == Helper.EstadoSystema.Editando)
             {

                 enlSubCategoriaCliente.Codigo = txtCodigo.Text;
                 enlSubCategoriaCliente.Nombre = string.Empty;

                 var list = bllSubCategoriaCliente.Search(enlSubCategoriaCliente);

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

                if (DGV_SubCategoriaClientes.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_SubCategoriaClientes[0, DGV_SubCategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_SubCategoriaClientes[1, DGV_SubCategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_SubCategoriaClientes[2, DGV_SubCategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                }
            }

            enlSubCategoriaCliente.Codigo = txtCodigo.Text;
            if (bllSubCategoriaCliente.Delete(enlSubCategoriaCliente))
            {

                BotonEliminar();
                ActualizarDGV = true;
            }
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {
            enlSubCategoriaCliente.Codigo = string.Empty;
            enlSubCategoriaCliente.Nombre = string.Empty;

            if (bllSubCategoriaCliente.Search(enlSubCategoriaCliente) != null)
            {

                //Frm_Buscar_CxC frmBuscarCxC = new Frm_Buscar_CxC();
                //frmBuscarCxC.Owner = this;
                //frmBuscarCxC.LlamadoDesde = "Frm_SubCategoriaClientes";
                //frmBuscarCxC.DGV_Datos.DataSource = bllSubCategoriaCliente.Search(enlSubCategoriaCliente);
                //frmBuscarCxC.ShowDialog();
            }
            else
            {
                MessageBox.Show("La Maestra Esta Vacia");
            }
            
        }

        private void Frm_SubCategoriaClientes_Load(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlSubCategoriaCliente.Codigo = string.Empty;
            enlSubCategoriaCliente.Nombre = string.Empty;

            DGV_SubCategoriaClientes.DataSource = bllSubCategoriaCliente.Search(enlSubCategoriaCliente);
        }

        private void DGV_SubCategoriaClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                ImaestraCliente frm = this.Owner as ImaestraCliente;
                string SubCategoria;
                SubCategoria = DGV_SubCategoriaClientes[0, DGV_SubCategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                if (frm != null)
                frm.CodigoSubCategoria(SubCategoria);
                Close();
            }
        }

       
 
    }
}
