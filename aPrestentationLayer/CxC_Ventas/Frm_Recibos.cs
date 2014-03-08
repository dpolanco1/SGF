using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aPrestentationLayer.Plantillas;
using aPrestentationLayer.Administracion;
using EntityLayer.CxC_Ventas;
using BusinessLogicLayer.CxC_Ventas;
using BusinessLogicLayer.Administracion;
using BusinessLogicLayer.Otros;

namespace aPrestentationLayer.CxC_Ventas
{
    public partial class Frm_Recibos : Frm_Plantilla
    {
        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

       /* const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/

        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();

        Enl_ReciboMaster enlReciboMaster = new Enl_ReciboMaster();
        Bll_RecibosMaster bllRecibosMaster = new Bll_RecibosMaster();

        Enl_FacturaMaster enlFacturaMaster = new Enl_FacturaMaster();
        Bll_FacturaMaster bllFacturaMaster = new Bll_FacturaMaster();

        Bll_Numeracion bllNumeracion = new Bll_Numeracion();

        public Frm_Recibos()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
       
            btnVista.Click += btnVista_Click;
            this.DGV_DocumentosPendientes.AutoGenerateColumns = false;
            this.DGV_Recibos.AutoGenerateColumns = false;
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

            if (bllNumeracion.ObtenerTipo("Recibos") == "Automatico")
            {
                txtNumero.Enabled = false;
                txtCliente.Focus();
            }
            else
            {
                txtNumero.Enabled = true;
                txtNumero.Focus();
            }

        }

        void btnGuardar_Click(object sender, EventArgs e)
        {

            enlReciboMaster.Numero = txtNumero.Text;
            enlReciboMaster.Cliente = txtCliente.Text;
            enlReciboMaster.Fecha = dtpFecha.Value;
            enlReciboMaster.MododePago = txtMododePago.Text;
            enlReciboMaster.Referencia = txtReferencia.Text;
            enlReciboMaster.Monto = nudMonto.Value;

            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtNumero.Text = bllRecibosMaster.Insert(enlReciboMaster);

                for (int a = 0; a <= DGV_DocumentosPendientes.RowCount - 1; a++)
                {
                    enlFacturaMaster.Numero = DGV_DocumentosPendientes[2, a].Value.ToString();
                    enlFacturaMaster.MontoAplicar = Convert.ToDecimal( DGV_DocumentosPendientes[6, a].Value.ToString());
                  
                    //Insertar  Referencias Comerciales
                    bllFacturaMaster.UpdateBalance(enlFacturaMaster);
                }

                if (bllNumeracion.ObtenerTipo("Recibos") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Recibos"), "Recibos");
                }

            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllRecibosMaster.Update(enlReciboMaster);
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

                txtNumero.Text = DGV_Recibos[0, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                txtCliente.Text = DGV_Recibos[1, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                dtpFecha.Text = DGV_Recibos[2, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                txtReferencia.Text = DGV_Recibos[3, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                txtMododePago.Text = DGV_Recibos[4, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                nudMonto.Value = Convert.ToDecimal( DGV_Recibos[5, DGV_Recibos.CurrentCell.RowIndex].Value.ToString());
            }
            if (!string.IsNullOrEmpty(txtNumero.Text))
            {
                BotonEditar();
                txtNumero.Enabled = false;
                txtCliente.Focus();

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
                enlReciboMaster.Numero = txtNumero.Text;
                enlReciboMaster.Cliente = string.Empty;
                enlReciboMaster.MododePago = string.Empty;

                var list = bllRecibosMaster.Search(enlReciboMaster);

                txtNumero.Text = list[0].Numero;
                txtCliente.Text = list[0].Cliente;
                txtNombre.Text = ""; // em espera
                dtpFecha.Value = list[0].Fecha;
                txtMododePago.Text = list[0].MododePago;
                txtReferencia.Text = list[0].Referencia;
                nudMonto.Value = list[0].Monto;
                txtCaja.Text = ""; //en Espera
               

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

                txtNumero.Text = DGV_Recibos[0, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                txtCliente.Text = DGV_Recibos[1, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                dtpFecha.Text = DGV_Recibos[2, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                txtReferencia.Text = DGV_Recibos[3, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                txtMododePago.Text = DGV_Recibos[4, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                nudMonto.Value = Convert.ToDecimal(DGV_Recibos[5, DGV_Recibos.CurrentCell.RowIndex].Value.ToString());
            }



            enlReciboMaster.Numero = txtNumero.Text;
            bllRecibosMaster.Delete(enlReciboMaster);

           // bllFacturaDetail.Delete(enlFacturaDetail);
           // bllFacturaMaster.Delete(enlFacturaMaster);


            BotonEliminar();

            ActualizarDGV = true;




        }

        void btnVista_Click(object sender, EventArgs e)
        {

            if (ActualizarDGV == true)
            {

                tabControl1.TabPages.Remove(tbpMaster);

                enlReciboMaster.Numero = string.Empty;
                enlReciboMaster.Cliente = string.Empty;
                enlReciboMaster.MododePago = string.Empty;

                DGV_Recibos.DataSource = bllRecibosMaster.Search(enlReciboMaster);

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

                    txtNumero.Text = DGV_Recibos[0, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                    txtCliente.Text = DGV_Recibos[1, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                    dtpFecha.Text = DGV_Recibos[2, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                    txtReferencia.Text = DGV_Recibos[3, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                    txtMododePago.Text = DGV_Recibos[4, DGV_Recibos.CurrentCell.RowIndex].Value.ToString();
                    nudMonto.Value = Convert.ToDecimal(DGV_Recibos[5, DGV_Recibos.CurrentCell.RowIndex].Value.ToString());
                }
            }

        }

        private void Frm_Recibos_Load(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlReciboMaster.Numero = string.Empty;
            enlReciboMaster.Cliente = string.Empty;
            enlReciboMaster.MododePago = string.Empty;
  
            DGV_Recibos.DataSource = bllRecibosMaster.Search(enlReciboMaster);
        }

        private void txtCliente_Validated(object sender, EventArgs e)
        {
            enlFacturaMaster.Numero = string.Empty;
            enlFacturaMaster.Almacen = string.Empty;
            enlFacturaMaster.Terminos = string.Empty;
            enlFacturaMaster.Tipo = string.Empty;
            enlFacturaMaster.Vendedor = string.Empty;

            enlFacturaMaster.Cliente = txtCliente.Text;
            enlFacturaMaster.BalancePendiente = 0;

            DGV_DocumentosPendientes.DataSource = bllFacturaMaster.Search(enlFacturaMaster);

            //DGV_DocumentosPendientes.DataSource = bllFacturaMaster.FacturasBalancePendientes(enlFacturaMaster);


        }

        #region IForm Members

        public void CodigoModoPago(string ModoPago)
        {
            txtMododePago.Text = ModoPago;

        }

        

        #endregion

        private void LblBuscarModePago_Click(object sender, EventArgs e)
        {
            Frm_MododePago frmModoPago = new Frm_MododePago();
            frmModoPago.Owner = this;
            frmModoPago.OcultarToolBar();
            frmModoPago.ShowDialog();
        }

        private void DGV_Recibos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVista_Click(btnVista, null);
        }

     

    }
}
