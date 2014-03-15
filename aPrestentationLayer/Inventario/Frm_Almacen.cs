using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aPrestentationLayer.Plantillas;
using BusinessLogicLayer.Inventario;
using EntityLayer.Inventario;
using BusinessLogicLayer.Administracion;
using BusinessLogicLayer.Otros;
using aPrestentationLayer.Inventario.Reportes.Listados;

namespace aPrestentationLayer.Inventario
{
    public partial class Frm_Almacen : Frm_Plantilla
    {

        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

        /*const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/
        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_Almacen enlAlmacen = new Enl_Almacen();
        Bll_Almacen bllAlmacen = new Bll_Almacen();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_Almacen()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnImprimir.Click += btnImprimir_Click;
          
            btnVista.Click += btnVista_Click;
            DGV_Almacenes.AutoGenerateColumns = false;


        }

        void btnImprimir_Click(object sender, EventArgs e)
        {
            Rpt_Almacen rpt = new Rpt_Almacen();
            rpt.ShowDialog();
        }

        void btnNuevo_Click(object sender, EventArgs e)
        {

          //  Estado = NUEVO;
            Estado = Helper.EstadoSystema.Creando;

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

            }

            BotonNuevo();

            if (bllNumeracion.ObtenerTipo("Almacen") == "Automatico")
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
            enlAlmacen.Codigo = txtCodigo.Text;
            enlAlmacen.Nombre = txtNombre.Text;
            enlAlmacen.Direccion = txtDireccion.Text;
            enlAlmacen.Encargado = txtEncargado.Text;
            enlAlmacen.Telefono = txtTelefono.Text;
            enlAlmacen.Nota = txtNota.Text;

            if (Estado == Helper.EstadoSystema.Creando)
            {
                 txtCodigo.Text =  bllAlmacen.Insert(enlAlmacen);
   
                if (bllNumeracion.ObtenerTipo("Almacen") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Almacen"), "Almacen");
                }

            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllAlmacen.Update(enlAlmacen);
                    MessageBox.Show("Registro Actualizado Correctamente", "SGF");
                }
            }
            BotonGuardar();
            ActualizarDGV = true;
        }

        void btnEditar_Click(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Editando;

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Almacenes.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_Almacenes[0, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Almacenes[1, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                    txtDireccion.Text = DGV_Almacenes[2, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                    txtEncargado.Text = DGV_Almacenes[3, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                    txtTelefono.Text = DGV_Almacenes[4, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_Almacenes[5, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
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
            enlAlmacen.Codigo = txtCodigo.Text;
            enlAlmacen.Nombre = string.Empty;
            enlAlmacen.Encargado = string.Empty;

             if (Estado == Helper.EstadoSystema.Creando)
            {
                AC.DeshabilitarText(this);
                AC.VaciarText(this);
            }

             if (Estado == Helper.EstadoSystema.Editando)
             {

                 var list = bllAlmacen.Search(enlAlmacen);

                 txtCodigo.Text = list[0].Codigo;
                 txtNombre.Text = list[0].Nombre;
                 txtDireccion.Text = list[0].Direccion;
                 txtEncargado.Text = list[0].Encargado;
                 txtTelefono.Text = list[0].Telefono;
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

                if (DGV_Almacenes.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_Almacenes[0, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Almacenes[1, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                    txtDireccion.Text = DGV_Almacenes[2, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                    txtEncargado.Text = DGV_Almacenes[3, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                    txtTelefono.Text = DGV_Almacenes[4, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_Almacenes[5, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                }
            }


            enlAlmacen.Codigo = txtCodigo.Text;
            if (bllAlmacen.Delete(enlAlmacen))
            {

                BotonEliminar();
                ActualizarDGV = true;
            }
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        private void Frm_Almacen_Load(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlAlmacen.Codigo = string.Empty;
            enlAlmacen.Nombre = string.Empty;
            enlAlmacen.Encargado = string.Empty;

            DGV_Almacenes.DataSource = bllAlmacen.Search(enlAlmacen);
        }

        void btnVista_Click(object sender, EventArgs e)
        {
            if (ActualizarDGV == true)
            {

                enlAlmacen.Codigo = string.Empty;
                enlAlmacen.Nombre = string.Empty;
                enlAlmacen.Encargado = string.Empty;
               
                DGV_Almacenes.DataSource = bllAlmacen.Search(enlAlmacen);

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

                    if (DGV_Almacenes.Rows.Count != 0)
                    {

                        txtCodigo.Text = DGV_Almacenes[0, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_Almacenes[1, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                        txtDireccion.Text = DGV_Almacenes[2, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                        txtEncargado.Text = DGV_Almacenes[3, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                        txtTelefono.Text = DGV_Almacenes[4, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                        txtNota.Text = DGV_Almacenes[5, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString();
                    }
                }
            }
        }

        private void DGV_Almacenes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                Icompras frm = this.Owner as Icompras;
                if (frm != null)
                    frm.CargarAlmacen(DGV_Almacenes[0, DGV_Almacenes.CurrentCell.RowIndex].Value.ToString());
                Close();
            }
        }
    }
}
