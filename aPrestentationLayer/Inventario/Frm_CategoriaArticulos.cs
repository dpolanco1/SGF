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
    public partial class Frm_CategoriaArticulos : Frm_Plantilla
    {

        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

        /*const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/
        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_CategoriaArticulos enlCategoriaArticulos = new Enl_CategoriaArticulos();
        Bll_CategoriaArticulos bllCategoriaArticulos = new Bll_CategoriaArticulos();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_CategoriaArticulos()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnImprimir.Click += btnImprimir_Click;
          
            btnVista.Click += btnVista_Click;
            DGV_CategoriaArticulos.AutoGenerateColumns = false;

        }

        void btnImprimir_Click(object sender, EventArgs e)
        {
            Rpt_CategoriaArticulos rpt = new Rpt_CategoriaArticulos();
            rpt.ShowDialog();
        }

        void btnNuevo_Click(object sender, EventArgs e)
        {
            //Estado = Nuevo
            Estado = Helper.EstadoSystema.Creando;

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

            }

            BotonNuevo();

            if (bllNumeracion.ObtenerTipo("Categoria de Articulos") == "Automatico")
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
            enlCategoriaArticulos.Codigo = txtCodigo.Text;
            enlCategoriaArticulos.Nombre = txtNombre.Text;
            enlCategoriaArticulos.Nota = txtNota.Text;


            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtCodigo.Text = bllCategoriaArticulos.Insert(enlCategoriaArticulos);
       

                if (bllNumeracion.ObtenerTipo("Categoria de Articulos") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Categoria de Articulos"), "Categoria de Articulos");
                }
                BotonGuardar();
            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllCategoriaArticulos.Update(enlCategoriaArticulos);
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

                if (DGV_CategoriaArticulos.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_CategoriaArticulos[0, DGV_CategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_CategoriaArticulos[1, DGV_CategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_CategoriaArticulos[2, DGV_CategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
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
                enlCategoriaArticulos.Codigo = txtCodigo.Text;
                enlCategoriaArticulos.Nombre = string.Empty;

                var list = bllCategoriaArticulos.Search(enlCategoriaArticulos);

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

                if (DGV_CategoriaArticulos.Rows.Count != 0)
                {


                    txtCodigo.Text = DGV_CategoriaArticulos[0, DGV_CategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_CategoriaArticulos[1, DGV_CategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_CategoriaArticulos[2, DGV_CategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                }
            }


            enlCategoriaArticulos.Codigo = txtCodigo.Text;
            bllCategoriaArticulos.Delete(enlCategoriaArticulos);


            BotonEliminar();

            ActualizarDGV = true;
            //Limpiar Textox
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        void btnVista_Click(object sender, EventArgs e)
        {
            if (ActualizarDGV == true)
            {

                enlCategoriaArticulos.Codigo = string.Empty;
                enlCategoriaArticulos.Nombre = string.Empty;

                
                DGV_CategoriaArticulos.DataSource = bllCategoriaArticulos.Search(enlCategoriaArticulos);

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

                    if (DGV_CategoriaArticulos.Rows.Count != 0)
                    {

                        txtCodigo.Text = DGV_CategoriaArticulos[0, DGV_CategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_CategoriaArticulos[1, DGV_CategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                        txtNota.Text = DGV_CategoriaArticulos[2, DGV_CategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                    }
                }
            }

        }

        private void Frm_CategoriaArticulos_Load(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlCategoriaArticulos.Codigo = string.Empty;
            enlCategoriaArticulos.Nombre = string.Empty;

            DGV_CategoriaArticulos.DataSource = bllCategoriaArticulos.Search(enlCategoriaArticulos);
        }

        private void DGV_CategoriaArticulos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                Iinventario frm = this.Owner as Iinventario;
                if (frm != null)
                    frm.CargarCategoria(DGV_CategoriaArticulos[0, DGV_CategoriaArticulos.CurrentCell.RowIndex].Value.ToString());
                Close();
            }
        }

      
    }
}
