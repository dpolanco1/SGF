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
    public partial class Frm_Marcas : Frm_Plantilla
    {


        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

       /* const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/
        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_Marcas enlMarcas = new Enl_Marcas();
        Bll_Marcas bllMarcas = new Bll_Marcas();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_Marcas()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnVista.Click += btnVista_Click;
            btnImprimir.Click += btnImprimir_Click;

            DGV_Marca.AutoGenerateColumns = false;

        }

        void btnImprimir_Click(object sender, EventArgs e)
        {
            Rpt_Marcas rpt = new Rpt_Marcas();
            rpt.ShowDialog();
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

            if (bllNumeracion.ObtenerTipo("Marcas") == "Automatico")
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
            enlMarcas.Codigo = txtCodigo.Text;
            enlMarcas.Nombre = txtNombre.Text;
            enlMarcas.Nota = txtNota.Text;


            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtCodigo.Text = bllMarcas.Insert(enlMarcas);
 

                if (bllNumeracion.ObtenerTipo("Marcas") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Marcas"), "Marcas");
                }
                BotonGuardar();
            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllMarcas.Update(enlMarcas);
                    MessageBox.Show("Registro Actualizado Correctamente", "SGF");
                    BotonGuardar();
                }
            }
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

                if (DGV_Marca.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_Marca[0, DGV_Marca.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Marca[1, DGV_Marca.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_Marca[2, DGV_Marca.CurrentCell.RowIndex].Value.ToString();
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
                enlMarcas.Codigo = txtCodigo.Text;
                enlMarcas.Nombre = string.Empty;

                var list = bllMarcas.Search(enlMarcas);

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

                if (DGV_Marca.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_Marca[0, DGV_Marca.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Marca[1, DGV_Marca.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_Marca[2, DGV_Marca.CurrentCell.RowIndex].Value.ToString();
                }
            }


            enlMarcas.Codigo = txtCodigo.Text;
            bllMarcas.Delete(enlMarcas);


            BotonEliminar();

            ActualizarDGV = true;
            //Limpiar Textox
        }

        void btnVista_Click(object sender, EventArgs e)
        {

            if (ActualizarDGV == true)
            {

                enlMarcas.Codigo = string.Empty;
                enlMarcas.Nombre = string.Empty;


                DGV_Marca.DataSource = bllMarcas.Search(enlMarcas);

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

                    if (DGV_Marca.Rows.Count != 0)
                    {

                        txtCodigo.Text = DGV_Marca[0, DGV_Marca.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_Marca[1, DGV_Marca.CurrentCell.RowIndex].Value.ToString();
                        txtNota.Text = DGV_Marca[2, DGV_Marca.CurrentCell.RowIndex].Value.ToString();
                    }
                }
            }

        }

        private void Frm_Marcas_Load(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlMarcas.Codigo = string.Empty;
            enlMarcas.Nombre = string.Empty;

            DGV_Marca.DataSource = bllMarcas.Search(enlMarcas);
        }

        private void DGV_Marca_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                Iinventario frm = this.Owner as Iinventario;
                if (frm != null)
                frm.CargarMarca(DGV_Marca[0, DGV_Marca.CurrentCell.RowIndex].Value.ToString());
                Close();
            }
        }

     
 
    }
}
