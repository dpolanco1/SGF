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
    public partial class Frm_Clientes : Frm_Plantilla, ImaestraCliente
    {
        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

       /* const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/

        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_Clientes enlClientes = new Enl_Clientes();
        Bll_Clientes bllClientes = new Bll_Clientes();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();

        public string prueba;

        public Frm_Clientes()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
         
            btnVista.Click += btnVista_Click;
            DGV_Clientes.AutoGenerateColumns = false;

        }

        public void CodigoCategoria(string Categoria)
        {
            txtCategoria.Text = Categoria;
            
        }

        public void CodigoSubCategoria(string SubCategoria)
        {
            txtSubCategoria.Text = SubCategoria;

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
            //Habilitar eshabilitar botones de Busqueda
            lblBucarCategoria.Enabled = true;
            lblBuscarSubCategoria.Enabled = true;

            if (bllNumeracion.ObtenerTipo("Clientes") == "Automatico")
            {
                txtCodigo.Enabled = false;
                txtRazonSocial.Focus();
            }
            else
            {
                txtCodigo.Enabled = true;
                txtCodigo.Focus();
            }

          
        }

        void btnGuardar_Click(object sender, EventArgs e)
        {

            enlClientes.Codigo = txtCodigo.Text;
            enlClientes.RazonSocial = txtRazonSocial.Text;
            enlClientes.RNC = txtRNC.Text;
            enlClientes.NCF = cmbNCF.Text;
            enlClientes.LimteCredito = nudLimiteCredito.Value;
            enlClientes.Categoria = txtCategoria.Text;
            enlClientes.SubCategoria = txtSubCategoria.Text;
            enlClientes.Direccion = txtDireccion.Text;
            enlClientes.Nombre = txtNombre.Text;
            enlClientes.Apellido = txtApellido.Text;
            enlClientes.Cedula = txtCedula.Text;
            enlClientes.Celular = txtCelular.Text;
            enlClientes.Fax = txtFax .Text;
            enlClientes.Telefono = txtTelefono.Text;
            enlClientes.FechaNacimiento = dtpFechaNacimiento.Value;
            enlClientes.Email = txtEmail.Text;
            


            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtCodigo.Text = bllClientes.Insert(enlClientes);

                if (bllNumeracion.ObtenerTipo("Clientes") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Clientes"), "Clientes");
                }
            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllClientes.Update(enlClientes);
                    MessageBox.Show("Registro Actualizado Correctamente", "SGF");

                }
            }
            ActualizarDGV = true;
            BotonGuardar();

        }

        void btnEditar_Click(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Editando;

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Clientes.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_Clientes[0, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtRazonSocial.Text = DGV_Clientes[1, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtRNC.Text = DGV_Clientes[2, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    cmbNCF.Text = DGV_Clientes[3, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    nudLimiteCredito.Value = Convert.ToDecimal(DGV_Clientes[4, DGV_Clientes.CurrentCell.RowIndex].Value.ToString());
                    txtCategoria.Text = DGV_Clientes[5, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtSubCategoria.Text = DGV_Clientes[6, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtDireccion.Text = DGV_Clientes[7, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Clientes[8, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtApellido.Text = DGV_Clientes[9, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtCedula.Text = DGV_Clientes[10, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtCelular.Text = DGV_Clientes[11, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtFax.Text = DGV_Clientes[12, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtTelefono.Text = DGV_Clientes[13, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    dtpFechaNacimiento.Text = DGV_Clientes[14, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtEmail.Text = DGV_Clientes[15, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                }
            }

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                BotonEditar();
                txtCodigo.Enabled = false;
                txtRazonSocial.Focus();

                //Habilitar eshabilitar botones de Busqueda
                lblBucarCategoria.Enabled = true;
                lblBuscarSubCategoria.Enabled = true;

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
                enlClientes.Codigo = txtCodigo.Text;
                enlClientes.RazonSocial = string.Empty;
                enlClientes.RNC = string.Empty;
                enlClientes.Categoria = string.Empty;
                enlClientes.SubCategoria = string.Empty;
                enlClientes.Nombre = string.Empty;
                enlClientes.Telefono = string.Empty;
                enlClientes.Email = string.Empty;

                var list = bllClientes.Search(enlClientes);

                    txtCodigo.Text = list[0].Codigo;
                    txtRazonSocial.Text = list[0].RazonSocial;
                    txtRNC.Text = list[0].RNC;
                    cmbNCF.Text = list[0].NCF;
                    nudLimiteCredito.Value = list[0].LimteCredito;
                    txtCategoria.Text = list[0].Categoria;
                    txtSubCategoria.Text = list[0].SubCategoria;
                    txtDireccion.Text = list[0].Direccion;
                    txtNombre.Text = list[0].Nombre;
                    txtApellido.Text = list[0].Apellido;
                    txtCedula.Text = list[0].Cedula ;
                    txtCelular.Text =list[0].Celular;
                    txtFax.Text = list[0].Fax;
                    txtTelefono.Text =list[0].Telefono;
                    dtpFechaNacimiento.Value = list[0].FechaNacimiento;
                    txtEmail.Text = list[0].Email;

            }

            BotonCancelar();  
            //Habilitar eshabilitar botones de Busqueda
            lblBucarCategoria.Enabled = false;
            lblBuscarSubCategoria.Enabled = false;


        }

        void btnEliminar_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Clientes.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_Clientes[0, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtRazonSocial.Text = DGV_Clientes[1, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtRNC.Text = DGV_Clientes[2, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    cmbNCF.Text = DGV_Clientes[3, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    nudLimiteCredito.Value = Convert.ToDecimal(DGV_Clientes[4, DGV_Clientes.CurrentCell.RowIndex].Value.ToString());
                    txtCategoria.Text = DGV_Clientes[5, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtSubCategoria.Text = DGV_Clientes[6, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtDireccion.Text = DGV_Clientes[7, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Clientes[8, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtApellido.Text = DGV_Clientes[9, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtCedula.Text = DGV_Clientes[10, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtCelular.Text = DGV_Clientes[11, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtFax.Text = DGV_Clientes[12, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtTelefono.Text = DGV_Clientes[13, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    dtpFechaNacimiento.Text = DGV_Clientes[14, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                    txtEmail.Text = DGV_Clientes[15, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                }
            }

            enlClientes.Codigo = txtCodigo.Text;
            bllClientes.Delete(enlClientes);

            BotonEliminar();

            ActualizarDGV = true;

          
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {
            //Frm_Buscar_CxC frmBuscarCxC = new Frm_Buscar_CxC();
            //frmBuscarCxC.Owner = this;
            //frmBuscarCxC.LlamadoDesde = "Frm_Clientes";
            //frmBuscarCxC.ShowDialog();
        }

        private void Frm_Clientes_Load(object sender, EventArgs e)
        {


            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlClientes.Codigo = string.Empty;
            enlClientes.RazonSocial = string.Empty;
            enlClientes.RNC = string.Empty;
            enlClientes.Categoria = string.Empty;
            enlClientes.SubCategoria = string.Empty;
            enlClientes.Nombre = string.Empty;
            enlClientes.Telefono = string.Empty;
            enlClientes.Email = string.Empty;

            DGV_Clientes.DataSource = bllClientes.Search(enlClientes);

            //Deshabilitar botones de Busqueda
            lblBucarCategoria.Enabled = false;
            lblBuscarSubCategoria.Enabled = false;

        }

        void btnVista_Click(object sender, EventArgs e)
        {

            

                if (ActualizarDGV == true)
                {

                    enlClientes.Codigo = string.Empty;
                    enlClientes.RazonSocial = string.Empty;
                    enlClientes.RNC = string.Empty;
                    enlClientes.Categoria = string.Empty;
                    enlClientes.SubCategoria = string.Empty;
                    enlClientes.Nombre = string.Empty;
                    enlClientes.Telefono = string.Empty;
                    enlClientes.Email = string.Empty;

                    DGV_Clientes.DataSource = bllClientes.Search(enlClientes);

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

                        if (DGV_Clientes.Rows.Count != 0)
                        {

                            txtCodigo.Text = DGV_Clientes[0, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            txtRazonSocial.Text = DGV_Clientes[1, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            txtRNC.Text = DGV_Clientes[2, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            cmbNCF.Text = DGV_Clientes[3, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            nudLimiteCredito.Value = Convert.ToDecimal(DGV_Clientes[4, DGV_Clientes.CurrentCell.RowIndex].Value.ToString());
                            txtCategoria.Text = DGV_Clientes[5, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            txtSubCategoria.Text = DGV_Clientes[6, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            txtDireccion.Text = DGV_Clientes[7, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            txtNombre.Text = DGV_Clientes[8, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            txtApellido.Text = DGV_Clientes[9, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            txtCedula.Text = DGV_Clientes[10, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            txtCelular.Text = DGV_Clientes[11, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            txtFax.Text = DGV_Clientes[12, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            txtTelefono.Text = DGV_Clientes[13, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            dtpFechaNacimiento.Text = DGV_Clientes[14, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                            txtEmail.Text = DGV_Clientes[15, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();

                        }
                    }
                }


           
            //else
            //{ 
            
            //}
        }

        private void DGV_Clientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                Icotizaciones frm = this.Owner as Icotizaciones;
                string Codigo, Nombre;
                Codigo = DGV_Clientes[0, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                Nombre = DGV_Clientes[1, DGV_Clientes.CurrentCell.RowIndex].Value.ToString();
                if (frm != null)
                frm.CodigoCliente(Codigo,Nombre);
                Close();
            }
        }

        private void lblBucarCategoria_Click(object sender, EventArgs e)
        {
            Frm_CategoriaClientes frmCategoria = new Frm_CategoriaClientes();
            frmCategoria.Owner = this;
            frmCategoria.OcultarToolBar();
            frmCategoria.ShowDialog();
        }

        private void lblBuscarSubCategoria_Click(object sender, EventArgs e)
        {
            Frm_SubCategoriaClientes frmSubCategoria = new Frm_SubCategoriaClientes();
            frmSubCategoria.Owner = this;
            frmSubCategoria.OcultarToolBar();
            frmSubCategoria.ShowDialog();
        }

      
      
    }
}
