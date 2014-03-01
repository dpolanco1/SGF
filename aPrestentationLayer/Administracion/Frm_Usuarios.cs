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
    public partial class Frm_Usuarios : Frm_Plantilla
    {

        string Estado = string.Empty;
        const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";
        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_Usuarios enlUsuarios = new Enl_Usuarios();
        Bll_Usuarios bllUsuarios = new Bll_Usuarios();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_Usuarios()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
         
            btnVista.Click += btnVista_Click;
            DGV_Usuarios.AutoGenerateColumns = false;
            
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

            if (bllNumeracion.ObtenerTipo("Usuario") == "Automatico")
            {
                txtNombreUsuario.Enabled = false;
                txtNombre.Focus();
            }
            else
            {
                txtNombreUsuario.Enabled = true;
                txtNombreUsuario.Focus();
            }

          

        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            enlUsuarios.NombreUsuario = txtNombreUsuario.Text;
            enlUsuarios.Nombre = txtNombre.Text;
            enlUsuarios.Apellido = txtApellido.Text;
            enlUsuarios.Contrasena = txtContrasena.Text;
            enlUsuarios.IsResetearPass = chkResetearPass.Checked;

            if (txtContrasena.Text == txtContrasena2.Text)
            {


                if (Estado == "Creando")
                {
                    txtNombreUsuario.Text = bllUsuarios.Insert(enlUsuarios);

                    if (bllNumeracion.ObtenerTipo("Usuario") == "Automatico")
                    {
                        bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Usuario"), "Usuario");
                        BotonGuardar();
                        ActualizarDGV = true;
                    }
                }
                else
                {
                    if (Estado == "Editando")
                    {
                        bllUsuarios.Update(enlUsuarios);
                        MessageBox.Show("Registro Actualizado Correctamente", "SGF");
                        BotonGuardar();
                        ActualizarDGV = true;
                    }
                }
            }
            else
            {
                MessageBox.Show("Contraseñas No Coinciden", "Intente de Nuevo");
            }

           

        }

        void btnEditar_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Usuarios.Rows.Count != 0)
                {
                    txtNombreUsuario.Text = DGV_Usuarios[0, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Usuarios[1, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                    txtApellido.Text = DGV_Usuarios[2, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                    txtContrasena.Text = DGV_Usuarios[3, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                    txtContrasena2.Text = DGV_Usuarios[3, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                    chkResetearPass.Checked = Convert.ToBoolean(DGV_Usuarios[4, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString());
                }
            }


            if (!string.IsNullOrEmpty(txtNombreUsuario.Text))
            {
                BotonEditar();
                Estado = EDITAR;
                txtNombreUsuario.Enabled = false;
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
                enlUsuarios.NombreUsuario = txtNombreUsuario.Text;
                enlUsuarios.Nombre = string.Empty;
                enlUsuarios.Apellido = string.Empty;

                var list = bllUsuarios.Search(enlUsuarios);

                txtNombreUsuario.Text = list[0].NombreUsuario;
                txtNombre.Text = list[0].Nombre;
                txtApellido.Text = list[0].Apellido;
                txtContrasena.Text = list[0].Contrasena;
                txtContrasena2.Text = list[0].Contrasena;
                chkResetearPass.Checked = Convert.ToBoolean(list[0].IsResetearPass);

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

                if (DGV_Usuarios.Rows.Count != 0)
                {
                    txtNombreUsuario.Text = DGV_Usuarios[0, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Usuarios[1, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                    txtApellido.Text = DGV_Usuarios[2, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                    txtContrasena.Text = DGV_Usuarios[3, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                    txtContrasena2.Text = DGV_Usuarios[3, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                    chkResetearPass.Checked = Convert.ToBoolean(DGV_Usuarios[4, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString());
                }
            }

            enlUsuarios.NombreUsuario = txtNombreUsuario.Text;
            bllUsuarios.Delete(enlUsuarios);

            BotonEliminar();
            ActualizarDGV = true;

        }

        void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Usuarios_Load(object sender, EventArgs e)
        {
            Estado = CONSULTA;
            tabControl1.TabPages.Remove(tbpMaster);

            enlUsuarios.NombreUsuario = string.Empty;
            enlUsuarios.Nombre = string.Empty;
            enlUsuarios.Apellido = string.Empty;

            DGV_Usuarios.DataSource = bllUsuarios.Search(enlUsuarios);
       }

        void btnVista_Click(object sender, EventArgs e)
        {


            if (ActualizarDGV == true)
            {

                enlUsuarios.NombreUsuario = string.Empty;
                enlUsuarios.Nombre = string.Empty;
                enlUsuarios.Apellido = string.Empty;

                DGV_Usuarios.DataSource = bllUsuarios.Search(enlUsuarios);
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

                    if (DGV_Usuarios.Rows.Count != 0)
                    {
                        txtNombreUsuario.Text = DGV_Usuarios[0, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_Usuarios[1, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                        txtApellido.Text = DGV_Usuarios[2, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                        txtContrasena.Text = DGV_Usuarios[3, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                        txtContrasena2.Text = DGV_Usuarios[3, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString();
                        chkResetearPass.Checked = Convert.ToBoolean(DGV_Usuarios[4, DGV_Usuarios.CurrentCell.RowIndex].Value.ToString());
                    }
                }
            }

        }

        private void DGV_Usuarios_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVista_Click(btnVista, null);
        }
    }
}
