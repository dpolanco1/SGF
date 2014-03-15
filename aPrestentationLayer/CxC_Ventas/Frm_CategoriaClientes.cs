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
    public partial class Frm_CategoriaClientes : Frm_Plantilla
    {
        //utilizando los estados predefinidos de la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

        /*const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/

        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_CategoriaClientes enlCategoriaClientes = new Enl_CategoriaClientes();
        Bll_CategoriaClientes bllCategoriaClientes = new Bll_CategoriaClientes();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();
        
        public Frm_CategoriaClientes()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
          
            btnVista.Click += btnVista_Click;
           this.DGV_CategoriaClientes.AutoGenerateColumns = false;
   
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
           
            if (bllNumeracion.ObtenerTipo("Categoria de Clientes") == "Automatico")
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
            
            enlCategoriaClientes.Codigo = txtCodigo.Text;
            enlCategoriaClientes.Nombre = txtNombre.Text;
            enlCategoriaClientes.Nota = txtNota.Text;

            if (Estado == Helper.EstadoSystema.Creando)
          {
             txtCodigo.Text = bllCategoriaClientes.Insert(enlCategoriaClientes);
              
                if (bllNumeracion.ObtenerTipo("Categoria de Clientes") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Categoria de Clientes"), "Categoria de Clientes");
                }
                BotonGuardar();
          }
          else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllCategoriaClientes.Update(enlCategoriaClientes);
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

                if (DGV_CategoriaClientes.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_CategoriaClientes[0, DGV_CategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_CategoriaClientes[1, DGV_CategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_CategoriaClientes[2, DGV_CategoriaClientes.CurrentCell.RowIndex].Value.ToString();
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
                enlCategoriaClientes.Codigo = txtCodigo.Text;
                enlCategoriaClientes.Nombre = string.Empty;

                var list = bllCategoriaClientes.Search(enlCategoriaClientes);
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

                if (DGV_CategoriaClientes.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_CategoriaClientes[0, DGV_CategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_CategoriaClientes[1, DGV_CategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_CategoriaClientes[2, DGV_CategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                }
            }
           enlCategoriaClientes.Codigo= txtCodigo.Text;


           if (bllCategoriaClientes.Delete(enlCategoriaClientes))
           {
               BotonEliminar();
               ActualizarDGV = true;
           }    
            
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {
            enlCategoriaClientes.Codigo = string.Empty;
            enlCategoriaClientes.Nombre = string.Empty;

            if (bllCategoriaClientes.Search(enlCategoriaClientes) != null)
            {

                //Frm_Buscar_CxC frmBuscarCxC = new Frm_Buscar_CxC();
                //frmBuscarCxC.Owner = this;
                //frmBuscarCxC.LlamadoDesde = "Frm_CategoriaClientes";
                //frmBuscarCxC.DGV_Datos.DataSource = bllCategoriaClientes.Search(enlCategoriaClientes);
                //frmBuscarCxC.ShowDialog();
            }
            else
            {
                MessageBox.Show("La Maestra Esta Vacia");
            }


        }

        void btnVista_Click(object sender, EventArgs e)
        {

            if (toolBarsPrincipal.Visible == true)
            {

                if (ActualizarDGV == true)
                {

                    enlCategoriaClientes.Codigo = string.Empty;
                    enlCategoriaClientes.Nombre = string.Empty;

                    DGV_CategoriaClientes.DataSource = bllCategoriaClientes.Search(enlCategoriaClientes);

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

                        txtCodigo.Text = DGV_CategoriaClientes[0, DGV_CategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_CategoriaClientes[1, DGV_CategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                        txtNota.Text = DGV_CategoriaClientes[2, DGV_CategoriaClientes.CurrentCell.RowIndex].Value.ToString();
                    }
                }

            }
        }

        private void Frm_CategoriaClientes_Load(object sender, EventArgs e)
        {

            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);
            DGV_CategoriaClientes.Focus();

            enlCategoriaClientes.Codigo = string.Empty;
            enlCategoriaClientes.Nombre = string.Empty;

            DGV_CategoriaClientes.DataSource = bllCategoriaClientes.Search(enlCategoriaClientes);

     

        }

        private void DGV_CategoriaClientes_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                ImaestraCliente frm = this.Owner as ImaestraCliente;       
                if (frm != null)
                frm.CodigoCategoria(DGV_CategoriaClientes[0, DGV_CategoriaClientes.CurrentCell.RowIndex].Value.ToString());
                Close();
            }
          
        }
 
        private void Frm_CategoriaClientes_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.F3)
            //{ // For example
            //    // Do something
            //    e.Handled = true;
            //    btnVista_Click(btnVista, null);
            //}
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F3)
            { // For example
                // Do something
                e.Handled = true;
                btnVista_Click(btnVista, null);
            }
        }

    

      

 
    }
}
