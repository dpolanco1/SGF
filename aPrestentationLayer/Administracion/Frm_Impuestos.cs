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
    public partial class Frm_Impuestos : Frm_Plantilla
    {

        string Estado = string.Empty;
        const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";

        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_Impuestos enlImpuestos = new Enl_Impuestos();
        Bll_Impuestos bllImpuestos = new Bll_Impuestos();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_Impuestos()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
          
            btnVista.Click += btnVista_Click;
            DGV_Impuestos.AutoGenerateColumns = false;

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

            if (bllNumeracion.ObtenerTipo("Impuestos") == "Automatico")
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
            enlImpuestos.Codigo = txtCodigo.Text;
            enlImpuestos.Nombre = txtNombre.Text;
            enlImpuestos.Porcentaje = nudPorcentaje.Value;
            enlImpuestos.Nota = txtNota.Text;

            if (Estado == "Creando")
            {
                txtCodigo.Text = bllImpuestos.Insert(enlImpuestos);
               

                if (bllNumeracion.ObtenerTipo("Impuestos") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Impuestos"), "Impuestos");
                }
            }
            else
            {
                if (Estado == "Editando")
                {
                    bllImpuestos.Update(enlImpuestos);
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

                if (DGV_Impuestos.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_Impuestos[0, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Impuestos[1, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString();
                    nudPorcentaje.Value = Convert.ToDecimal(DGV_Impuestos[2, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString());
                    txtNota.Text = DGV_Impuestos[3, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString();
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
                enlImpuestos.Codigo = txtCodigo.Text;
                enlImpuestos.Nombre = string.Empty;

                var list = bllImpuestos.Search(enlImpuestos);

                txtNombre.Text = list[0].Nombre;
                nudPorcentaje.Value = Convert.ToDecimal(list[0].Porcentaje);
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

                if (DGV_Impuestos.Rows.Count != 0)
                {
                    txtCodigo.Text = DGV_Impuestos[0, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Impuestos[1, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString();
                    nudPorcentaje.Value = Convert.ToDecimal(DGV_Impuestos[2, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString());
                    txtNota.Text = DGV_Impuestos[3, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString();
                }
            }


            enlImpuestos.Codigo = txtCodigo.Text;
            bllImpuestos.Delete(enlImpuestos);

            BotonEliminar();

            ActualizarDGV = true;



        }

        void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        void btnVista_Click(object sender, EventArgs e)
        {
            if (ActualizarDGV == true)
            {

                enlImpuestos.Codigo = string.Empty;
                enlImpuestos.Nombre = string.Empty;

                DGV_Impuestos.DataSource = bllImpuestos.Search(enlImpuestos);
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

                    if (DGV_Impuestos.Rows.Count != 0)
                    {

                        txtCodigo.Text = DGV_Impuestos[0, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_Impuestos[1, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString();
                        nudPorcentaje.Value = Convert.ToDecimal(DGV_Impuestos[2, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString());
                        txtNota.Text = DGV_Impuestos[3, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString();
                    }
                }
            }
        }

        private void Frm_Impuestos_Load(object sender, EventArgs e)
        {
            Estado = CONSULTA;
            tabControl1.TabPages.Remove(tbpMaster);

            enlImpuestos.Codigo = string.Empty;
            enlImpuestos.Nombre = string.Empty;

            DGV_Impuestos.DataSource = bllImpuestos.Search(enlImpuestos);
        }

        private void DGV_Impuestos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (toolBarsPrincipal.Visible == true)
            {
                btnVista_Click(btnVista, null);
            }
            else
            {
                Iinventario frm = this.Owner as Iinventario;
                if (frm != null)
                    frm.CargarImpuesto(DGV_Impuestos[0, DGV_Impuestos.CurrentCell.RowIndex].Value.ToString());
                Close();
            }
        }

       
    }
}
