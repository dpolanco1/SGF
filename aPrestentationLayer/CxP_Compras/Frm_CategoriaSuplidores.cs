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
    public partial class Frm_CategoriaSuplidores : Frm_Plantilla
    {

        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

        /*const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/
        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_CategoriaSuplidores enlCategoriaSuplidores = new Enl_CategoriaSuplidores();
        Bll_CategoriaSuplidores bllCategoriaSuplidores = new Bll_CategoriaSuplidores();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_CategoriaSuplidores()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
            //btnBuscar.Click += btnBuscar_Click;
            btnVista.Click += btnVista_Click;
            DGV_CategoriaSuplidor.AutoGenerateColumns = false;

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

            if (bllNumeracion.ObtenerTipo("Categoria de Suplidores") == "Automatico")
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

            enlCategoriaSuplidores.Codigo = txtCodigo.Text;
            enlCategoriaSuplidores.Nombre = txtNombre.Text;
            enlCategoriaSuplidores.Nota = txtNota.Text;

            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtCodigo.Text =  bllCategoriaSuplidores.Insert(enlCategoriaSuplidores);
             

                if (bllNumeracion.ObtenerTipo("Categoria de Suplidores") == "Automatico")
                {
                bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Categoria de Suplidores"), "Categoria de Suplidores");
                }
               
            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllCategoriaSuplidores.Update(enlCategoriaSuplidores);
                    MessageBox.Show("Registro Actualizado Correctamente","SGF");
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

                if (DGV_CategoriaSuplidor.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_CategoriaSuplidor[0, DGV_CategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_CategoriaSuplidor[1, DGV_CategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_CategoriaSuplidor[2, DGV_CategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
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
                enlCategoriaSuplidores.Codigo = txtCodigo.Text;
                enlCategoriaSuplidores.Nombre = string.Empty;

                var list = bllCategoriaSuplidores.Search(enlCategoriaSuplidores);

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

                if (DGV_CategoriaSuplidor.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_CategoriaSuplidor[0, DGV_CategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_CategoriaSuplidor[1, DGV_CategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_CategoriaSuplidor[2, DGV_CategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                }
            }

            enlCategoriaSuplidores.Codigo = txtCodigo.Text;

            if (bllCategoriaSuplidores.Delete(enlCategoriaSuplidores))
            {

                BotonEliminar();
                ActualizarDGV = true;
            }

        }

        private void Frm_CategoriaSuplidores_Load(object sender, EventArgs e)
        {

            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlCategoriaSuplidores.Codigo = string.Empty;
            enlCategoriaSuplidores.Nombre = string.Empty;

            DGV_CategoriaSuplidor.DataSource = bllCategoriaSuplidores.Search(enlCategoriaSuplidores);
           
        }
      
        void btnVista_Click(object sender, EventArgs e)
        {
            if (ActualizarDGV == true)
            {

                enlCategoriaSuplidores.Codigo = string.Empty;
                enlCategoriaSuplidores.Nombre = string.Empty;

                DGV_CategoriaSuplidor.DataSource = bllCategoriaSuplidores.Search(enlCategoriaSuplidores);
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

                    if (DGV_CategoriaSuplidor.Rows.Count != 0)
                    {

                        txtCodigo.Text = DGV_CategoriaSuplidor[0, DGV_CategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_CategoriaSuplidor[1, DGV_CategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                        txtNota.Text = DGV_CategoriaSuplidor[2, DGV_CategoriaSuplidor.CurrentCell.RowIndex].Value.ToString();
                    }
                }
            }
        }

        private void DGV_CategoriaSuplidor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                Isuplidores frm = this.Owner as Isuplidores;
                if (frm != null)
                frm.CargarCategoria(DGV_CategoriaSuplidor[0, DGV_CategoriaSuplidor.CurrentCell.RowIndex].Value.ToString());
                Close();
            }
        }

 
    }
}
