using aPrestentationLayer.Plantillas;
using BusinessLogicLayer.Administracion;
using BusinessLogicLayer.Otros;
using EntityLayer.Administracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aPrestentationLayer.Administracion
{
    public partial class Frm_Gastos : Frm_Plantilla
    {
        //estados del sistema predefinidos
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

        /*const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/

        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_Gastos enlGastos = new Enl_Gastos();
        Bll_Gastos bllGastos = new Bll_Gastos();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();



        public Frm_Gastos()
        {
            InitializeComponent();

            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;

            btnVista.Click += btnVista_Click;
            DGV_Gastos.AutoGenerateColumns = false;
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

            if (bllNumeracion.ObtenerTipo("Gastos") == "Automatico")
            {
                txtNumero.Enabled = false;
                dtpFecha.Focus();
            }
            else
            {
                txtNumero.Enabled = true;
                txtNumero.Focus();
            }


        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            enlGastos.Numero = txtNumero.Text;
            enlGastos.Fecha = dtpFecha.Value;
            enlGastos.Monto = numMonto.Value;
            enlGastos.Tipo = txtTipo.Text;
            enlGastos.Nota = txtDescripcion.Text;

            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtNumero.Text = bllGastos.Insert(enlGastos);


                if (bllNumeracion.ObtenerTipo("Gastos") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Gastos"), "Gastos");
                }
            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllGastos.Update(enlGastos);
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

                if (DGV_Gastos.Rows.Count != 0)
                {
                    txtNumero.Text = DGV_Gastos[0, DGV_Gastos.CurrentCell.RowIndex].Value.ToString();
                    dtpFecha.Text = DGV_Gastos[1, DGV_Gastos.CurrentCell.RowIndex].Value.ToString();
                    numMonto.Value = Convert.ToDecimal(DGV_Gastos[2, DGV_Gastos.CurrentCell.RowIndex].Value.ToString());
                    txtTipo.Text = DGV_Gastos[3, DGV_Gastos.CurrentCell.RowIndex].Value.ToString();
                    txtDescripcion.Text = DGV_Gastos[4, DGV_Gastos.CurrentCell.RowIndex].Value.ToString();
                }
            }

            if (!string.IsNullOrEmpty(txtNumero.Text))
            {

                BotonEditar();
                Estado = Helper.EstadoSystema.Editando;
                dtpFecha.Focus();
                txtNumero.Enabled = false;

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
                enlGastos.Numero = txtNumero.Text;
                enlGastos.Tipo = string.Empty;

                var list = bllGastos.Search(enlGastos);

                txtNumero.Text = list[0].Numero;
                dtpFecha.Value = Convert.ToDateTime(list[0].Fecha);
                numMonto.Value = Convert.ToDecimal(list[0].Monto);
                txtTipo.Text = list[0].Tipo;
                txtDescripcion.Text = list[0].Nota;
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

                if (DGV_Gastos.Rows.Count != 0)
                {
                    txtNumero.Text = DGV_Gastos[0, DGV_Gastos.CurrentCell.RowIndex].Value.ToString();
                    dtpFecha.Value = Convert.ToDateTime(DGV_Gastos[1, DGV_Gastos.CurrentCell.RowIndex].Value.ToString());
                    numMonto.Value = Convert.ToDecimal(DGV_Gastos[2, DGV_Gastos.CurrentCell.RowIndex].Value.ToString());
                    txtTipo.Text = DGV_Gastos[3, DGV_Gastos.CurrentCell.RowIndex].Value.ToString();
                    txtDescripcion.Text = DGV_Gastos[4, DGV_Gastos.CurrentCell.RowIndex].Value.ToString();
                }
            }


            enlGastos.Numero = txtNumero.Text;
            if (bllGastos.Delete(enlGastos))
            {
                BotonEliminar();
                ActualizarDGV = true;
            }



        }

        void btnBuscar_Click(object sender, EventArgs e)
        {

        }

        void btnVista_Click(object sender, EventArgs e)
        {
            if (ActualizarDGV == true)
            {

                enlGastos.Numero = string.Empty;
                enlGastos.Tipo = string.Empty;

                DGV_Gastos.DataSource = bllGastos.Search(enlGastos);
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

                    if (DGV_Gastos.Rows.Count != 0)
                    {

                        txtNumero.Text = DGV_Gastos[0, DGV_Gastos.CurrentCell.RowIndex].Value.ToString();
                        dtpFecha.Value = Convert.ToDateTime(DGV_Gastos[1, DGV_Gastos.CurrentCell.RowIndex].Value.ToString());
                        numMonto.Value = Convert.ToDecimal(DGV_Gastos[2, DGV_Gastos.CurrentCell.RowIndex].Value.ToString());
                        txtTipo.Text = DGV_Gastos[3, DGV_Gastos.CurrentCell.RowIndex].Value.ToString();
                        txtDescripcion.Text = DGV_Gastos[4, DGV_Gastos.CurrentCell.RowIndex].Value.ToString();
                    }
                }
            }
        }

        private void Frm_Gastos_Load(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlGastos.Numero = string.Empty;
            enlGastos.Tipo = string.Empty;
            enlGastos.FechaDesde = DateTime.Parse("01/01/1900");
            enlGastos.FechaHasta = DateTime.Parse("01/01/2100");


            DGV_Gastos.DataSource = bllGastos.Search(enlGastos);
        }
 

        private void DGV_Gastos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVista_Click(btnVista, null);
        }

     
    }
}
