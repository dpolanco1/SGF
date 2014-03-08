using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aPrestentationLayer.Plantillas;
using EntityLayer.CxP_Compras;
using BusinessLogicLayer.CxP_Compras;
using BusinessLogicLayer.Administracion;
using BusinessLogicLayer.Otros;

namespace aPrestentationLayer.CxP_Compras
{
    public partial class Frm_Suplidores : Frm_Plantilla, Isuplidores
    {
        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

       /* const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/
        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_Suplidores enlSuplidores = new Enl_Suplidores();
        Bll_Suplidores bllSuplidores = new Bll_Suplidores();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_Suplidores()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
            //btnBuscar.Click += btnBuscar_Click;
            btnVista.Click += btnVista_Click;
            DGV_Suplidores.AutoGenerateColumns = false;


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

            if (bllNumeracion.ObtenerTipo("Suplidores") == "Automatico")
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

            enlSuplidores.Codigo = txtCodigo.Text;
            enlSuplidores.RazonSocial = txtRazonSocial.Text;
            enlSuplidores.RNC = txtRNC.Text;
            enlSuplidores.Tipo = cmbTipo.Text;
            enlSuplidores.Categoria = txtCategoria.Text;
            enlSuplidores.SubCategoria = txtSubCategoria.Text;
            enlSuplidores.Direccion = txtDireccion.Text;
            enlSuplidores.Nombre = txtNombre.Text;
            enlSuplidores.Apellido = txtApellido.Text;
            enlSuplidores.Cedula = txtCedula.Text;
            enlSuplidores.Celular = txtCelular.Text;
            enlSuplidores.Fax = txtFax.Text;
            enlSuplidores.Telefono = txtTelefono.Text;
            enlSuplidores.FechaNacimiento = dtpFechaNacimiento.Value;
            enlSuplidores.Email = txtEmail.Text;



            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtCodigo.Text = bllSuplidores.Insert(enlSuplidores);

                if (bllNumeracion.ObtenerTipo("Suplidores") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Suplidores"), "Suplidores");
                }
            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllSuplidores.Update(enlSuplidores);
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

                if (DGV_Suplidores.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_Suplidores[0, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtRazonSocial.Text = DGV_Suplidores[1, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtRNC.Text = DGV_Suplidores[2, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    cmbTipo.Text = DGV_Suplidores[3, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtCategoria.Text = DGV_Suplidores[4, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtSubCategoria.Text = DGV_Suplidores[5, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtDireccion.Text = DGV_Suplidores[6, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Suplidores[7, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtApellido.Text = DGV_Suplidores[8, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtCedula.Text = DGV_Suplidores[9, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtCelular.Text = DGV_Suplidores[10, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtFax.Text = DGV_Suplidores[11, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtTelefono.Text = DGV_Suplidores[12, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    dtpFechaNacimiento.Text = DGV_Suplidores[13, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtEmail.Text = DGV_Suplidores[14, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                }
            }

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {

                BotonEditar();
                Estado = Helper.EstadoSystema.Editando;
                txtRazonSocial.Focus();
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
                enlSuplidores.Codigo = txtCodigo.Text;
                enlSuplidores.RazonSocial = string.Empty;
                enlSuplidores.RNC = string.Empty;
                enlSuplidores.Categoria = string.Empty;
                enlSuplidores.SubCategoria = string.Empty;
                enlSuplidores.Nombre = string.Empty;
                enlSuplidores.Telefono = string.Empty;
                enlSuplidores.Email = string.Empty;

                var list = bllSuplidores.Search(enlSuplidores);

                txtCodigo.Text = list[0].Codigo ;
                txtRazonSocial.Text = list[0].RazonSocial;
                txtRNC.Text = list[0].RNC;
                cmbTipo.Text = list[0].Tipo;
                txtCategoria.Text = list[0].Categoria;
                txtSubCategoria.Text =list[0].SubCategoria;
                txtDireccion.Text = list[0].Direccion;
                txtNombre.Text = list[0].Nombre;
                txtApellido.Text = list[0].Apellido;
                txtCedula.Text = list[0].Cedula;
                txtCelular.Text =list[0].Celular;
                txtFax.Text = list[0].Fax;
                txtTelefono.Text = list[0].Telefono;
                dtpFechaNacimiento.Value = Convert.ToDateTime( list[0].FechaNacimiento);
                txtEmail.Text = list[0].Email;


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

                if (DGV_Suplidores.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_Suplidores[0, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtRazonSocial.Text = DGV_Suplidores[1, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtRNC.Text = DGV_Suplidores[2, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    cmbTipo.Text = DGV_Suplidores[3, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtCategoria.Text = DGV_Suplidores[4, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtSubCategoria.Text = DGV_Suplidores[5, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtDireccion.Text = DGV_Suplidores[6, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Suplidores[7, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtApellido.Text = DGV_Suplidores[8, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtCedula.Text = DGV_Suplidores[9, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtCelular.Text = DGV_Suplidores[10, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtFax.Text = DGV_Suplidores[11, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtTelefono.Text = DGV_Suplidores[12, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    dtpFechaNacimiento.Text = DGV_Suplidores[13, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                    txtEmail.Text = DGV_Suplidores[14, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                }
            }

            enlSuplidores.Codigo = txtCodigo.Text;
            bllSuplidores.Delete(enlSuplidores);

            BotonEliminar();

            ActualizarDGV = true;
        }

        private void Frm_Suplidores_Load(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlSuplidores.Codigo = string.Empty;
            enlSuplidores.RazonSocial = string.Empty;
            enlSuplidores.RNC = string.Empty;
            enlSuplidores.Categoria = string.Empty;
            enlSuplidores.SubCategoria = string.Empty;
            enlSuplidores.Nombre = string.Empty;
            enlSuplidores.Telefono = string.Empty;
            enlSuplidores.Email = string.Empty;

            DGV_Suplidores.DataSource = bllSuplidores.Search(enlSuplidores);
        }

        void btnVista_Click(object sender, EventArgs e)
        {

            if (ActualizarDGV == true)
            {

                enlSuplidores.Codigo = string.Empty;
                enlSuplidores.RazonSocial = string.Empty;
                enlSuplidores.RNC = string.Empty;
                enlSuplidores.Categoria = string.Empty;
                enlSuplidores.SubCategoria = string.Empty;
                enlSuplidores.Nombre = string.Empty;
                enlSuplidores.Telefono = string.Empty;
                enlSuplidores.Email = string.Empty;

                DGV_Suplidores.DataSource = bllSuplidores.Search(enlSuplidores);
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

                    if (DGV_Suplidores.Rows.Count != 0)
                    {

                        txtCodigo.Text = DGV_Suplidores[0, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        txtRazonSocial.Text = DGV_Suplidores[1, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        txtRNC.Text = DGV_Suplidores[2, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        cmbTipo.Text = DGV_Suplidores[3, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        txtCategoria.Text = DGV_Suplidores[4, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        txtSubCategoria.Text = DGV_Suplidores[5, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        txtDireccion.Text = DGV_Suplidores[6, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_Suplidores[7, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        txtApellido.Text = DGV_Suplidores[8, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        txtCedula.Text = DGV_Suplidores[9, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        txtCelular.Text = DGV_Suplidores[10, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        txtFax.Text = DGV_Suplidores[11, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        txtTelefono.Text = DGV_Suplidores[12, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        dtpFechaNacimiento.Text =  DGV_Suplidores[13, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                        txtEmail.Text = DGV_Suplidores[14, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();


                    }
                }


            }
        }

        private void DGV_Suplidores_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                Icompras frm = this.Owner as Icompras;
                string Codigo, Nombre;
                Codigo = DGV_Suplidores[0, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                Nombre = DGV_Suplidores[1, DGV_Suplidores.CurrentCell.RowIndex].Value.ToString();
                if (frm != null)
                    frm.CargarSuplidor(Codigo,Nombre);
                Close();
            }
          
        }

        public void CargarCategoria(string Categoria)
        {
            txtCategoria.Text = Categoria;
        }

        public void CargarSubCategoria(string SubCategoria)
        {
            txtSubCategoria.Text = SubCategoria;
        }

        private void LblBuscarCategoria_Click(object sender, EventArgs e)
        {
            Frm_CategoriaSuplidores frmCategoria = new Frm_CategoriaSuplidores();
            frmCategoria.Owner = this;
            frmCategoria.OcultarToolBar();
            frmCategoria.ShowDialog();
        }

        private void lblBuscarSubCategoria_Click(object sender, EventArgs e)
        {
            Frm_SubCategoriaSuplidores frmCategoria = new Frm_SubCategoriaSuplidores();
            frmCategoria.Owner = this;
            frmCategoria.OcultarToolBar();
            frmCategoria.ShowDialog();
        }



    }
}
