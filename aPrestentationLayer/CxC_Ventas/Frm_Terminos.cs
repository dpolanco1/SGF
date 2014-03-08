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
    public partial class Frm_Terminos : Frm_Plantilla
    {


        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

        /*const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/

        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_Termino enlTermino = new Enl_Termino();
        Bll_Terminos bllTerminos = new Bll_Terminos();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_Terminos()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
          
            btnVista.Click += btnVista_Click;
            this.DGV_Terminos.AutoGenerateColumns = false;
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

            if (bllNumeracion.ObtenerTipo("Terminos") == "Automatico")
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
         
            enlTermino.Codigo = txtCodigo.Text;
            enlTermino.Nombre = txtNombre.Text;
            enlTermino.Dias = nudDias.Value;
            enlTermino.Nota = txtNota.Text;

            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtCodigo.Text = bllTerminos.Insert(enlTermino);

                if (bllNumeracion.ObtenerTipo("Terminos") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Terminos"), "Terminos");
                }
                BotonGuardar();
            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllTerminos.Update(enlTermino);
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

                if (DGV_Terminos.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_Terminos[0, DGV_Terminos.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Terminos[1, DGV_Terminos.CurrentCell.RowIndex].Value.ToString();
                    nudDias.Value = Convert.ToDecimal(DGV_Terminos[2, DGV_Terminos.CurrentCell.RowIndex].Value.ToString());
                    txtNota.Text = DGV_Terminos[3, DGV_Terminos.CurrentCell.RowIndex].Value.ToString();
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
                   enlTermino.Codigo = txtCodigo.Text;
                   enlTermino.Nombre = string.Empty;

                   var list = bllTerminos.Search(enlTermino);

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

                if (DGV_Terminos.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_Terminos[0, DGV_Terminos.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Terminos[1, DGV_Terminos.CurrentCell.RowIndex].Value.ToString();
                    nudDias.Value = Convert.ToDecimal(DGV_Terminos[2, DGV_Terminos.CurrentCell.RowIndex].Value.ToString());
                    txtNota.Text = DGV_Terminos[3, DGV_Terminos.CurrentCell.RowIndex].Value.ToString();
                }
            }

            enlTermino.Codigo = txtCodigo.Text;
            bllTerminos.Delete(enlTermino);

            BotonEliminar();

            ActualizarDGV = true;

        }

        void btnBuscar_Click(object sender, EventArgs e)
        {
            //enlCategoriaClientes.Codigo = string.Empty;
            //enlCategoriaClientes.Nombre = string.Empty;

            //if (bllCategoriaClientes.Search(enlCategoriaClientes) != null)
            //{

            //    Frm_Buscar_CxC frmBuscarCxC = new Frm_Buscar_CxC();
            //    frmBuscarCxC.Owner = this;
            //    frmBuscarCxC.LlamadoDesde = "Frm_CategoriaClientes";
            //    frmBuscarCxC.dataGridView1.DataSource = bllCategoriaClientes.Search(enlCategoriaClientes);
            //    frmBuscarCxC.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("La Maestra Esta Vacia");
            //}


        }

        void btnVista_Click(object sender, EventArgs e)
        {

            if (ActualizarDGV == true)
            {

                enlTermino.Codigo = string.Empty;
                enlTermino.Nombre = string.Empty;

                DGV_Terminos.DataSource = bllTerminos.Search(enlTermino);

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

                    if (DGV_Terminos.Rows.Count != 0)
                    {
                        txtCodigo.Text = DGV_Terminos[0, DGV_Terminos.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_Terminos[1, DGV_Terminos.CurrentCell.RowIndex].Value.ToString();
                        nudDias.Value = Convert.ToDecimal(DGV_Terminos[2, DGV_Terminos.CurrentCell.RowIndex].Value.ToString());
                        txtNota.Text = DGV_Terminos[3, DGV_Terminos.CurrentCell.RowIndex].Value.ToString();
                    }
                }
            }

        }

        private void Frm_Terminos_Load(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlTermino.Codigo = string.Empty;
            enlTermino.Nombre = string.Empty;

            DGV_Terminos.DataSource = bllTerminos.Search(enlTermino);

        }

        private void DGV_Terminos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                Icotizaciones frm = this.Owner as Icotizaciones;
                string Terminos;
                Terminos = DGV_Terminos[0, DGV_Terminos.CurrentCell.RowIndex].Value.ToString();
                if (frm != null)
                frm.CodigoTerminos(Terminos);
                Close();
            }
        }



    }
}
