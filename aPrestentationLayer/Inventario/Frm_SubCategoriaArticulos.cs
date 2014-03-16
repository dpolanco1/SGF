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
    public partial class Frm_SubCategoriaArticulos : Frm_Plantilla
    {
        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

        /*const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/
        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_SubCategoriaArticulos enlSubCategoriaArticulos = new Enl_SubCategoriaArticulos();
        Bll_SubCategoriaArticulos bllSubCategoriaArticulos = new Bll_SubCategoriaArticulos();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();

        public Frm_SubCategoriaArticulos()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnVista.Click += btnVista_Click;
            btnImprimir.Click += btnImprimir_Click;

            DGV_SubCategoriaArticulos.AutoGenerateColumns = false;
        }

        void btnImprimir_Click(object sender, EventArgs e)
        {
            Rpt_SubCategoriaArticulos rpt = new Rpt_SubCategoriaArticulos();
            rpt.ShowDialog();
        }

        void btnNuevo_Click(object sender, EventArgs e)
        {
            //Estado = Estado.;
            Estado = Helper.EstadoSystema.Creando;


            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

            }

            BotonNuevo();

            if (bllNumeracion.ObtenerTipo("SubCategoria de Articulos") == "Automatico")
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

            enlSubCategoriaArticulos.Codigo = txtCodigo.Text;
            enlSubCategoriaArticulos.Nombre = txtNombre.Text;
            enlSubCategoriaArticulos.Nota = txtNota.Text;


            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtCodigo.Text = bllSubCategoriaArticulos.Insert(enlSubCategoriaArticulos);

                if (bllNumeracion.ObtenerTipo("SubCategoria de Articulos") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("SubCategoria de Articulos"), "SubCategoria de Articulos");
                }
                BotonGuardar();
            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllSubCategoriaArticulos.Update(enlSubCategoriaArticulos);
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

                if (DGV_SubCategoriaArticulos.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_SubCategoriaArticulos[0, DGV_SubCategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_SubCategoriaArticulos[1, DGV_SubCategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_SubCategoriaArticulos[2, DGV_SubCategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
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

                  enlSubCategoriaArticulos.Codigo = txtCodigo.Text;
                  enlSubCategoriaArticulos.Nombre = string.Empty;

                  var list = bllSubCategoriaArticulos.Search(enlSubCategoriaArticulos);

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

                if (DGV_SubCategoriaArticulos.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_SubCategoriaArticulos[0, DGV_SubCategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_SubCategoriaArticulos[1, DGV_SubCategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_SubCategoriaArticulos[2, DGV_SubCategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                }
            }


            enlSubCategoriaArticulos.Codigo = txtCodigo.Text;

            if (bllSubCategoriaArticulos.Delete(enlSubCategoriaArticulos))
            {

                BotonEliminar();
                ActualizarDGV = true;
            }
        }

        void btnVista_Click(object sender, EventArgs e)
        {
            if (ActualizarDGV == true)
            {

                enlSubCategoriaArticulos.Codigo = string.Empty;
                enlSubCategoriaArticulos.Nombre = string.Empty;


                DGV_SubCategoriaArticulos.DataSource = bllSubCategoriaArticulos.Search(enlSubCategoriaArticulos);

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

                    if (DGV_SubCategoriaArticulos.Rows.Count != 0)
                    {
                        txtCodigo.Text = DGV_SubCategoriaArticulos[0, DGV_SubCategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_SubCategoriaArticulos[1, DGV_SubCategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                        txtNota.Text = DGV_SubCategoriaArticulos[2, DGV_SubCategoriaArticulos.CurrentCell.RowIndex].Value.ToString();
                    }
                }
            }
        }

        private void Frm_SubCategoriaArticulos_Load(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlSubCategoriaArticulos.Codigo = string.Empty;
            enlSubCategoriaArticulos.Nombre = string.Empty;

            DGV_SubCategoriaArticulos.DataSource = bllSubCategoriaArticulos.Search(enlSubCategoriaArticulos);
        }

        private void DGV_SubCategoriaArticulos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                Iinventario frm = this.Owner as Iinventario;
                if (frm != null)
                    frm.CargarSubCategoria(DGV_SubCategoriaArticulos[0, DGV_SubCategoriaArticulos.CurrentCell.RowIndex].Value.ToString());
                Close();
            }
        }

       
    }
}
