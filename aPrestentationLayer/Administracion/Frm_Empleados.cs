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
    public partial class Frm_Empleados : Frm_Plantilla
    {
        string Estado = string.Empty;
        const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";
        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_Empleados enlEmpleados = new Enl_Empleados();
        Bll_Empleados bllEmpleados = new Bll_Empleados();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();

        public Frm_Empleados()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
         
            btnVista.Click += btnVista_Click;

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

            if (bllNumeracion.ObtenerTipo("Empleados") == "Automatico")
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
            enlEmpleados.Codigo = txtCodigo.Text;
            enlEmpleados.Nombre = txtNombre.Text;
            enlEmpleados.Apellido = txtApellido.Text;
            enlEmpleados.Cedula = txtCedula.Text;
            enlEmpleados.Telefono = txtTelefono.Text;
            enlEmpleados.Direccion = txtDireccion.Text;
            enlEmpleados.Email = txtEmail.Text;
            enlEmpleados.Estatus = cmbEstatus.Text;
            enlEmpleados.EstadoCivil = cmbEstadoCivil.Text;
            enlEmpleados.Sexo = cmbSexo.Text;
            enlEmpleados.FechaNacimiento = dtpFechaNacimiento.Value;
            enlEmpleados.Salario = nudSalario.Value;
            enlEmpleados.Nacionalidad = txtNacionalidad.Text;
            enlEmpleados.IsVendedor = chkVendedor.Checked;
            enlEmpleados.Celular = txtCelular.Text;
         

            if (Estado == "Creando")
            {
                txtCodigo.Text = bllEmpleados.Insert(enlEmpleados);

                if (bllNumeracion.ObtenerTipo("Empleados") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Empleados"), "Empleados");
                }
            }
            else
            {
                if (Estado == "Editando")
                {
                    bllEmpleados.Update(enlEmpleados);

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

                if (DGV_Empleados.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_Empleados[0, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Empleados[1, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtApellido.Text = DGV_Empleados[2, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtCedula.Text = DGV_Empleados[3, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtTelefono.Text = DGV_Empleados[4, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtDireccion.Text = DGV_Empleados[5, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtEmail.Text = DGV_Empleados[6, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    cmbEstatus.Text = DGV_Empleados[7, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    cmbEstadoCivil.Text = DGV_Empleados[8, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    cmbSexo.Text = DGV_Empleados[9, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    dtpFechaNacimiento.Text = DGV_Empleados[10, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    nudSalario.Text = DGV_Empleados[11, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtNacionalidad.Text = DGV_Empleados[12, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    chkVendedor.Checked = Convert.ToBoolean(DGV_Empleados[13, DGV_Empleados.CurrentCell.RowIndex].Value.ToString());
                    txtCelular.Text = DGV_Empleados[14, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                }
            }

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {
                BotonEditar();
                Estado = EDITAR;
                txtNombre.Focus();
                txtCodigo.Enabled = false;
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
                enlEmpleados.Codigo = txtCodigo.Text;
                enlEmpleados.Nombre = string.Empty;
                enlEmpleados.Apellido = string.Empty;
                enlEmpleados.Cedula = string.Empty;
                enlEmpleados.Telefono = string.Empty;
                enlEmpleados.Direccion = string.Empty;
                enlEmpleados.Email = string.Empty;
                enlEmpleados.Estatus = string.Empty;

                var list = bllEmpleados.Search(enlEmpleados);

                txtNombre.Text = list[0].Nombre;
                txtApellido.Text = list[0].Apellido;
                txtTelefono.Text = list[0].Telefono;
                txtCelular.Text = list[0].Celular;
                txtCedula.Text = list[0].Cedula;
                txtDireccion.Text = list[0].Direccion;
                txtEmail.Text = list[0].Nombre;
                cmbEstatus.Text = list[0].Estatus;
                cmbEstadoCivil.Text = list[0].EstadoCivil;
                cmbSexo.Text = list[0].Sexo;
                dtpFechaNacimiento.Value = list[0].FechaNacimiento;
                nudSalario.Value = list[0].Salario;
                txtNacionalidad.Text = list[0].Nacionalidad;
                chkVendedor.Checked = Convert.ToBoolean( list[0].IsVendedor);

                //txtNombre.Text = bllEmpleados.Search(enlEmpleados)[0].Nombre;
                //txtApellido.Text = bllEmpleados.Search(enlEmpleados)[0].Nota;


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

                if (DGV_Empleados.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_Empleados[0, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Empleados[1, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtApellido.Text = DGV_Empleados[2, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtCedula.Text = DGV_Empleados[3, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtTelefono.Text = DGV_Empleados[4, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtDireccion.Text = DGV_Empleados[5, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtEmail.Text = DGV_Empleados[6, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    cmbEstatus.Text = DGV_Empleados[7, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    cmbEstadoCivil.Text = DGV_Empleados[8, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    cmbSexo.Text = DGV_Empleados[9, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    dtpFechaNacimiento.Text = DGV_Empleados[10, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    nudSalario.Text = DGV_Empleados[11, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    txtNacionalidad.Text = DGV_Empleados[12, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                    chkVendedor.Checked = Convert.ToBoolean(DGV_Empleados[13, DGV_Empleados.CurrentCell.RowIndex].Value.ToString());
                    txtCelular.Text = DGV_Empleados[14, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                }
            }

            enlEmpleados.Codigo = txtCodigo.Text;
            bllEmpleados.Delete(enlEmpleados);

            BotonEliminar();

            ActualizarDGV = true;
           
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Empleados_Load(object sender, EventArgs e)
        {

            Estado = CONSULTA;
            tabControl1.TabPages.Remove(tbpMaster);

            enlEmpleados.Codigo = string.Empty;
            enlEmpleados.Nombre = string.Empty;
            enlEmpleados.Apellido = string.Empty;
            enlEmpleados.Cedula = string.Empty;
            enlEmpleados.Telefono = string.Empty;
            enlEmpleados.Direccion = string.Empty;
            enlEmpleados.Email = string.Empty;
            enlEmpleados.Estatus = string.Empty;

            DGV_Empleados.DataSource = bllEmpleados.Search(enlEmpleados);
        }

        void btnVista_Click(object sender, EventArgs e)
        {
            if (ActualizarDGV == true)
            {

                enlEmpleados.Codigo = string.Empty;
                enlEmpleados.Nombre = string.Empty;

                DGV_Empleados.DataSource = bllEmpleados.Search(enlEmpleados);
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

                    if (DGV_Empleados.Rows.Count != 0)
                    {

                        txtCodigo.Text = DGV_Empleados[0, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_Empleados[1, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        txtApellido.Text = DGV_Empleados[2, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        txtCedula.Text = DGV_Empleados[3, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        txtTelefono.Text = DGV_Empleados[4, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        txtDireccion.Text = DGV_Empleados[5, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        txtEmail.Text = DGV_Empleados[6, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        cmbEstatus.Text = DGV_Empleados[7, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        cmbEstadoCivil.Text = DGV_Empleados[8, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        cmbSexo.Text = DGV_Empleados[9, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        dtpFechaNacimiento.Text = DGV_Empleados[10, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        nudSalario.Text = DGV_Empleados[11, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        txtNacionalidad.Text = DGV_Empleados[12, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                        chkVendedor.Checked = Convert.ToBoolean(DGV_Empleados[13, DGV_Empleados.CurrentCell.RowIndex].Value.ToString());
                        txtCelular.Text = DGV_Empleados[14, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();

                    }

                }
            }
        }

        private void DGV_Empleados_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                Icotizaciones frm = this.Owner as Icotizaciones;
                string Codigo;
                Codigo = DGV_Empleados[0, DGV_Empleados.CurrentCell.RowIndex].Value.ToString();
                if (frm != null)
                    frm.CodigoVendedor(Codigo);
                Close();
            }
        }

  



    }
}
