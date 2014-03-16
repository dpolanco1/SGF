using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer.CxC_Ventas;
using BusinessLogicLayer.CxC_Ventas;
using BusinessLogicLayer.Administracion;
using EntityLayer.Inventario;
using BusinessLogicLayer.Inventario;
using BusinessLogicLayer.Otros;
using System.Transactions;
using aPrestentationLayer.Comunes;



namespace aPrestentationLayer.CxC_Ventas
{
    public partial class Frm_Pos : Form
    {

        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

       /* const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/

        AdministrarControles AC = new AdministrarControles();

        bool ActualizarDGV = false;
        
        IList<Enl_FacturaDetail> list ;

        decimal TotalFactura = 0;

        Enl_FacturaMaster enlFacturaMaster = new Enl_FacturaMaster();
        Bll_FacturaMaster bllFacturaMaster = new Bll_FacturaMaster();

        Enl_FacturaDetail enlFacturaDetail = new Enl_FacturaDetail();
        Bll_FacturaDetail bllFacturaDetail = new Bll_FacturaDetail();

        Enl_Articulos enlArticulos = new Enl_Articulos();
        Bll_Articulos bllArticulos = new Bll_Articulos();

        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_Pos()
        {
            InitializeComponent();
            DGV_Facturas_Pos_List.AutoGenerateColumns = false;
            DGV_Factura_Pos.AutoGenerateColumns = false;
           
        }

        private void Frm_Pos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F10)
            { // For example
                // Do something
                e.Handled = true;
                btnNuevo_Click(btnNuevo, null);
            }

            if (e.KeyCode == Keys.F4)
            { // For example
                // Do something
                e.Handled = true;
                btnGuardar_Click(btnGuardar, null);
            }

            if (e.KeyCode == Keys.F5)
            { // For example
                // Do something
                e.Handled = true;
                btnGuardarCerrar_Click(btnGuardarCerrar, null);
            }

            if (e.KeyCode == Keys.F6)
            { // For example
                // Do something
                e.Handled = true;
                btnModificar_Click(btnModificar, null);
            }

            if (e.KeyCode == Keys.F8)
            { // For example
                // Do something
                e.Handled = true;
                btnCancelar_Click(btnCancelar, null);
            }

            if (e.KeyCode == Keys.F7)
            { // For example
                // Do something
                e.Handled = true;
                btnEliminar_Click(btnEliminar, null);
            }
        }

        private void tabControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            { // For example
                // Do something
                e.Handled = true;
                MessageBox.Show("Prueba F2");
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int isNumber = 0;
            //e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
                e.Handled = true; 

        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
                e.Handled = true; 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtArticulo.Text != String.Empty && txtPrecio.Text != String.Empty && txtCantidad.Text != String.Empty) 
            {

                decimal precio, cantidad, totalLinea,costo;
                precio = Convert.ToDecimal(txtPrecio.Text);
                cantidad = Convert.ToDecimal(txtCantidad.Text);
                totalLinea = precio * cantidad;
                costo = Convert.ToDecimal(txtCosto.Text);

                if (Estado == Helper.EstadoSystema.Editando)
                {


                    list.Add(new Enl_FacturaDetail
                    {
                     Codigo = txtArticulo.Text,
                     Descripcion = txtDescripcion.Text,
                     Precio = Convert.ToDecimal(txtPrecio.Text),
                     Cantidad = Convert.ToDecimal(txtCantidad.Text),
                     TotalLinea = Convert.ToDecimal(txtPrecio.Text) * Convert.ToDecimal(txtCantidad.Text),
                     Costo = Convert.ToDecimal(txtCosto.Text)
                    });

                   list.Add(enlFacturaDetail);

                   DGV_Factura_Pos.DataSource = null;
                   DGV_Factura_Pos.DataSource = list;   

                }
                else
                {

                    DGV_Factura_Pos.Rows.Insert(0, txtArticulo.Text, txtDescripcion.Text, precio, cantidad, "", totalLinea,costo);
                }

                TotalFactura = 0;
                ////Método con el que recorreremos todas las filas de nuestro Datagridview
                foreach (DataGridViewRow row in DGV_Factura_Pos.Rows)
                {
                    TotalFactura += Convert.ToDecimal(row.Cells["TotalLinea"].Value);
                }
                lblTotal.Text = Convert.ToString(TotalFactura.ToString("C"));

                txtArticulo.Text = String.Empty;
                txtDescripcion.Text = String.Empty;
                txtPrecio.Text = String.Empty; 
                txtCantidad.Text = String.Empty;

                txtArticulo.Focus();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {


            if (DGV_Factura_Pos.RowCount != 0)
            {

                if (Estado == Helper.EstadoSystema.Editando)
                {
                    list.RemoveAt(DGV_Factura_Pos.CurrentRow.Index);

                    DGV_Factura_Pos.DataSource = null;
                    DGV_Factura_Pos.DataSource = list;

                }
                else
                {

                    DGV_Factura_Pos.Rows.RemoveAt(DGV_Factura_Pos.CurrentRow.Index);
                    decimal sumatoria = 0;

                    foreach (DataGridViewRow row in DGV_Factura_Pos.Rows)
                    {
                        sumatoria += Convert.ToDecimal(row.Cells["TotalLinea"].Value);
                    }
                    lblTotal.Text = Convert.ToString(sumatoria.ToString("C"));
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using (TransactionScope ts = new TransactionScope())
            {

                try
                {

            enlFacturaMaster.Numero = txtNoFactura.Text;
            enlFacturaMaster.Cliente = txtCliente.Text;
            enlFacturaMaster.Fecha = dtpFecha.Value; ;
            enlFacturaMaster.Almacen = String.Empty;
            enlFacturaMaster.Terminos = String.Empty;
            enlFacturaMaster.Tipo = "POS";
            enlFacturaMaster.Descuento = 0;
            enlFacturaMaster.Vendedor = String.Empty;
            enlFacturaMaster.Caja = String.Empty;

            enlFacturaMaster.SubTotal = 0;
            enlFacturaMaster.TotalImpuesto = 0;
            enlFacturaMaster.TotalDescuento = 0;

            TotalFactura = 0;
            foreach (DataGridViewRow row in DGV_Factura_Pos.Rows)
            {
                TotalFactura += Convert.ToDecimal(row.Cells["TotalLinea"].Value);
            }

            enlFacturaMaster.TotalFactura = TotalFactura;

            enlFacturaMaster.Status = "Guardada";
            enlFacturaMaster.TotalPagado = 0;
            enlFacturaMaster.BalancePendiente = enlFacturaMaster.TotalFactura;



            if (Estado == Helper.EstadoSystema.Creando)
            {
                // Inserto el Header de la Factura
                txtNoFactura.Text = bllFacturaMaster.Insert(enlFacturaMaster);

                for (int a = 0; a < DGV_Factura_Pos.RowCount; a++)
                {
                    enlFacturaDetail.NoFactura = txtNoFactura.Text;//No Factura
                    enlFacturaDetail.Codigo = DGV_Factura_Pos[0, a].Value.ToString();
                    enlFacturaDetail.Descripcion = DGV_Factura_Pos[1, a].Value.ToString();
                    enlFacturaDetail.Precio = Convert.ToDecimal(DGV_Factura_Pos[2, a].Value);
                    enlFacturaDetail.Cantidad = Convert.ToDecimal(DGV_Factura_Pos[3, a].Value);
                    enlFacturaDetail.Impuesto = 0;
                    enlFacturaDetail.TotalLinea = Convert.ToDecimal(DGV_Factura_Pos[5, a].Value);
                    enlFacturaDetail.Costo = Convert.ToDecimal(DGV_Factura_Pos[6, a].Value);

                    // Insertando el Detalle de la Factura
                    bllFacturaDetail.Insert(enlFacturaDetail);

                    //Rebajo la existencia de la maestra de Articulo
                    enlArticulos.Codigo = enlFacturaDetail.Codigo;
                    enlArticulos.Existencia = (enlFacturaDetail.Cantidad) * -1;
                    bllArticulos.UpdateExitencia(enlArticulos);

                }

                if (bllNumeracion.ObtenerTipo("Facturas") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Facturas"), "Facturas");
                }
            }
            else {

                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllFacturaMaster.Update(enlFacturaMaster);

                    //Eliminados El Detalle de la Factura
                    enlFacturaDetail.NoFactura = txtNoFactura.Text;
                    bllFacturaDetail.Delete(enlFacturaDetail);

                    //Insertamos el Detalle de la Factura

                    for (int a = 0; a <= DGV_Factura_Pos.RowCount - 1; a++)
                    {
                        enlFacturaDetail.NoFactura = txtNoFactura.Text;//No Factura
                        enlFacturaDetail.Codigo = DGV_Factura_Pos[0, a].Value.ToString();
                        enlFacturaDetail.Descripcion = DGV_Factura_Pos[1, a].Value.ToString();
                        enlFacturaDetail.Precio = Convert.ToDecimal(DGV_Factura_Pos[2, a].Value);
                        enlFacturaDetail.Cantidad = Convert.ToDecimal(DGV_Factura_Pos[3, a].Value);
                        enlFacturaDetail.Impuesto = 0;
                        enlFacturaDetail.TotalLinea = Convert.ToDecimal(DGV_Factura_Pos[4, a].Value);

                        bllFacturaDetail.Insert(enlFacturaDetail);
                    }
                
                
                }

            
            }

            this.btnNuevo.Enabled = true;
            this.btnModificar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnImprimir.Enabled = true;
            this.btnGuardar.Enabled = false;

            AC.DeshabilitarText(this);
            ActualizarDGV = true;
            lblMensaje.Text = "Guardado Correctamente";
            ts.Complete();
            Estado = Helper.EstadoSystema.Consultando;

                }
                catch (Exception x)
                {

                    MessageBox.Show(x.Message);
                }
                ts.Dispose();
                //MessageBox.Show("Error al guardar el registro, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardarCerrar_Click(object sender, EventArgs e)
        {

            using (TransactionScope ts = new TransactionScope())
            {

                try
                {
                    enlFacturaMaster.Numero = txtNoFactura.Text;
                    enlFacturaMaster.Cliente = txtCliente.Text;
                    enlFacturaMaster.Fecha = dtpFecha.Value; ;
                    enlFacturaMaster.Almacen = String.Empty;
                    enlFacturaMaster.Terminos = String.Empty;
                    enlFacturaMaster.Tipo = "POS";
                    enlFacturaMaster.Descuento = 0;
                    enlFacturaMaster.Vendedor = String.Empty;
                    enlFacturaMaster.Caja = String.Empty;

                    enlFacturaMaster.SubTotal = 0;
                    enlFacturaMaster.TotalImpuesto = 0;
                    enlFacturaMaster.TotalDescuento = 0;

                    TotalFactura = 0;
                    foreach (DataGridViewRow row in DGV_Factura_Pos.Rows)
                    {
                        TotalFactura += Convert.ToDecimal(row.Cells["TotalLinea"].Value);
                    }
                    enlFacturaMaster.TotalFactura = TotalFactura;

                    enlFacturaMaster.Status = "Cerrada";
                    enlFacturaMaster.TotalPagado = enlFacturaMaster.TotalFactura;
                    enlFacturaMaster.BalancePendiente = 0;



                    if (Estado == Helper.EstadoSystema.Creando)
                    {

                        txtNoFactura.Text = bllFacturaMaster.Insert(enlFacturaMaster);

                        //hago la insercion en los DGV
                        for (int a = 0; a < DGV_Factura_Pos.RowCount; a++)
                        {
                            enlFacturaDetail.NoFactura = txtNoFactura.Text;//No Factura
                            enlFacturaDetail.Codigo = DGV_Factura_Pos[0, a].Value.ToString();
                            enlFacturaDetail.Descripcion = DGV_Factura_Pos[1, a].Value.ToString();
                            enlFacturaDetail.Precio = Convert.ToDecimal(DGV_Factura_Pos[2, a].Value);
                            enlFacturaDetail.Cantidad = Convert.ToDecimal(DGV_Factura_Pos[3, a].Value);
                            enlFacturaDetail.Impuesto = 0;
                            enlFacturaDetail.TotalLinea = Convert.ToDecimal(DGV_Factura_Pos[5, a].Value);
                            enlFacturaDetail.Costo = Convert.ToDecimal(DGV_Factura_Pos[6, a].Value);

                            bllFacturaDetail.Insert(enlFacturaDetail);

                            enlArticulos.Codigo = enlFacturaDetail.Codigo;
                            enlArticulos.Existencia = (enlFacturaDetail.Cantidad) * -1;
                            bllArticulos.UpdateExitencia(enlArticulos);

                        }

                        if (bllNumeracion.ObtenerTipo("Facturas") == "Automatico")
                        {
                            bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Facturas"), "Facturas");
                        }
                    }
                    else
                    {

                        if (Estado == Helper.EstadoSystema.Editando)
                        {
                            bllFacturaMaster.Update(enlFacturaMaster);

                            //Eliminados El Detalle de la Factura
                            enlFacturaDetail.NoFactura = txtNoFactura.Text;
                            bllFacturaDetail.Delete(enlFacturaDetail);

                            //Insertamos el Detalle de la Factura

                            for (int a = 0; a < DGV_Factura_Pos.RowCount - 1; a++)
                            {
                                enlFacturaDetail.NoFactura = txtNoFactura.Text;//No Factura
                                enlFacturaDetail.Codigo = DGV_Factura_Pos[0, a].Value.ToString();
                                enlFacturaDetail.Descripcion = DGV_Factura_Pos[1, a].Value.ToString();
                                enlFacturaDetail.Precio = Convert.ToDecimal(DGV_Factura_Pos[2, a].Value);
                                enlFacturaDetail.Cantidad = Convert.ToDecimal(DGV_Factura_Pos[3, a].Value);
                                enlFacturaDetail.Impuesto = 0;
                                //  enlFacturaDetail.TotalLinea = Convert.ToDecimal(DGV_Factura_Pos[4, a].Value);
                                enlFacturaDetail.TotalLinea = Convert.ToDecimal(DGV_Factura_Pos[4, a].Value);

                                bllFacturaDetail.Insert(enlFacturaDetail);


                                enlArticulos.Codigo = enlFacturaDetail.Codigo;
                                enlArticulos.Existencia = (enlFacturaDetail.Cantidad) * -1;
                                bllArticulos.UpdateExitencia(enlArticulos);
                            }
                        }

                    }

                    this.btnNuevo.Enabled = true;
                    this.btnModificar.Enabled = true;
                    this.btnEliminar.Enabled = true;
                    this.btnImprimir.Enabled = true;
                    this.btnGuardar.Enabled = false;
                    this.btnGuardarCerrar.Enabled = false;

                    AC.DeshabilitarText(this);

                    lblMensaje.Text = "Guardado Correctamente";
                    txtEstatus.Text = "Cerrada";

                    ts.Complete();

                }
                catch (Exception x )
                {
                    MessageBox.Show(x.Message);
                  
                }
                ts.Dispose();
               // MessageBox.Show("Error al guardar el registro, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
       
        private void DGV_Factura_Pos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {


            decimal precio, cantidad, totalLinea;
            precio = Convert.ToDecimal(DGV_Factura_Pos[2, DGV_Factura_Pos.CurrentCell.RowIndex].Value.ToString());
            cantidad = Convert.ToDecimal(DGV_Factura_Pos[3, DGV_Factura_Pos.CurrentCell.RowIndex].Value.ToString()); 
            totalLinea = precio * cantidad;

            DGV_Factura_Pos[5, DGV_Factura_Pos.CurrentCell.RowIndex].Value = totalLinea;

            TotalFactura = 0;
            foreach (DataGridViewRow row in DGV_Factura_Pos.Rows)
            {
                TotalFactura += Convert.ToDecimal(row.Cells["TotalLinea"].Value);
            }
            lblTotal.Text = Convert.ToString(TotalFactura.ToString("C"));

            txtArticulo.Text = String.Empty;
            txtDescripcion.Text = String.Empty;
            txtPrecio.Text = String.Empty;
            txtCantidad.Text = String.Empty;



        }
        
        private void DGV_Factura_Pos_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {

            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 2 || ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 3))
            {
                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            }


        }

        private void Frm_Pos_Load(object sender, EventArgs e)
        {
            AC.DeshabilitarText(this);

            txtBuscarCliente.Enabled = true;
            txtBuscarNoFactura.Enabled = true;

            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            btnGuardar.Enabled = false;
            btnGuardarCerrar.Enabled = false;
            btnCancelar.Enabled = false;

            //tabControl1.TabPages.Remove(tbpMaster);

            enlFacturaMaster.Numero = string.Empty;
            enlFacturaMaster.Cliente = string.Empty;
            enlFacturaMaster.Almacen = string.Empty;
            enlFacturaMaster.Terminos = string.Empty;
            enlFacturaMaster.Tipo = "POS";
            enlFacturaMaster.Vendedor = string.Empty;
            enlFacturaMaster.BalancePendiente = -1;

            enlFacturaMaster.DesdeFecha = dtpDesde.Value.Date;
            enlFacturaMaster.HastaFecha = dtpHasta.Value.Date; 
            
            
           DGV_Facturas_Pos_List.DataSource = bllFacturaMaster.Search(enlFacturaMaster);
        
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Editando;
  

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Facturas_Pos_List.Rows.Count != 0)
                {

                    txtNoFactura.Text = DGV_Facturas_Pos_List[0, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();
                    txtCliente.Text = DGV_Facturas_Pos_List[1, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();
                    dtpFecha.Text = DGV_Facturas_Pos_List[2, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();
                    lblTotal.Text = DGV_Facturas_Pos_List[12, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();
                    txtEstatus.Text = DGV_Facturas_Pos_List[15, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();

                    enlFacturaDetail.NoFactura = txtNoFactura.Text;
                    DGV_Factura_Pos.DataSource = bllFacturaDetail.Search(enlFacturaDetail);

                }
            }

            if (!string.IsNullOrEmpty(txtNoFactura.Text))
            {
                //BotonEditar();
                //txtCodigo.Enabled = false;
                //txtNombre.Focus();
                this.btnNuevo.Enabled = false;
                this.btnModificar.Enabled = false;
                this.btnEliminar.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnGuardarCerrar.Enabled = true;
                this.btnCancelar.Enabled = true;
                this.btnVista.Enabled = false;
                btnImprimir.Enabled = false;

                AC.HabilitarText(this);
                txtNoFactura.Enabled = false;

                for (int a = 0; a <= DGV_Factura_Pos.RowCount - 1; a++)
                {
                    enlArticulos.Codigo = DGV_Factura_Pos[0, a].Value.ToString();
                    enlArticulos.Existencia = Convert.ToDecimal(DGV_Factura_Pos[3, a].Value);
                    bllArticulos.UpdateExitencia(enlArticulos);
                }

                lblMensaje.Text = "Modificando Factura";
            
            }

            /////
            enlFacturaDetail.NoFactura = txtNoFactura.Text;
            list = bllFacturaDetail.Search(enlFacturaDetail);
           
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Estado == Helper.EstadoSystema.Creando)
            {
                AC.DeshabilitarText(this);
                AC.VaciarText(this);

                if (DGV_Factura_Pos.Rows.Count != 0)
                {
                    AC.VaciarDGV(this);
                    lblTotal.Text = "RD$0.00";
                }

            
            }

            if (Estado == Helper.EstadoSystema.Editando)
            {
                //enlCategoriaClientes.Codigo = txtCodigo.Text;
                //enlCategoriaClientes.Nombre = string.Empty;

                //txtNombre.Text = bllCategoriaClientes.Search(enlCategoriaClientes)[0].Nombre;
                //txtNota.Text = bllCategoriaClientes.Search(enlCategoriaClientes)[0].Nota;
                enlFacturaMaster.Numero = txtNoFactura.Text;
                enlFacturaMaster.Cliente = string.Empty;
                enlFacturaMaster.Almacen = string.Empty;
                enlFacturaMaster.Terminos = string.Empty;
                enlFacturaMaster.Tipo = "POS";
                enlFacturaMaster.Vendedor = string.Empty;
                enlFacturaMaster.BalancePendiente = -1;
                var list = bllFacturaMaster.Search(enlFacturaMaster);

                txtCliente.Text = list[0].Cliente;
                dtpFecha.Value = list[0].Fecha;
                txtEstatus.Text = list[0].Status;



                enlFacturaDetail.NoFactura = txtNoFactura.Text;
                DGV_Factura_Pos.DataSource =  bllFacturaDetail.Search(enlFacturaDetail);
                
                for (int a = 0; a <= DGV_Factura_Pos.RowCount - 1; a++)
                {
                    enlArticulos.Codigo = DGV_Factura_Pos[0, a].Value.ToString();
                    enlArticulos.Existencia = -Convert.ToDecimal(DGV_Factura_Pos[3, a].Value);
                    bllArticulos.UpdateExitencia(enlArticulos);
                }

            }

            this.btnNuevo.Enabled = true;
            this.btnModificar.Enabled = true;
            this.btnEliminar.Enabled = true;
            this.btnImprimir.Enabled = true;
            this.btnVista.Enabled = true;

            this.btnGuardar.Enabled = false;
            this.btnGuardarCerrar.Enabled = false;
            this.btnCancelar.Enabled = false;

        

            AC.DeshabilitarText(this);
            Estado = Helper.EstadoSystema.Consultando;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Creando;


            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

            }
            this.btnNuevo.Enabled = false;
            this.btnModificar.Enabled = false;
            this.btnEliminar.Enabled = false;
            this.btnImprimir.Enabled = false;
            //    this.btnVista.Enabled = false;
            this.btnGuardar.Enabled = true;
            this.btnGuardarCerrar.Enabled = true;
            this.btnCancelar.Enabled = true;
            this.btnVista.Enabled = false;

            AC.VaciarText(this);
            AC.HabilitarText(this);

            DGV_Factura_Pos.DataSource = null;

            if (bllNumeracion.ObtenerTipo("Facturas") == "Automatico")
            {
                txtNoFactura.ReadOnly = true;
                txtArticulo.Focus();
            }
            else
            {
                txtNoFactura.ReadOnly = false;
                txtNoFactura.Focus();
            }


            lblTotal.Text = "0.00";
            lblMensaje.Text = "Çreando Factura";

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {


          try
            {
                if (tabControl1.SelectedTab == tbpDetail)
                {
                    tabControl1.TabPages.Remove(tbpDetail);
                    tabControl1.TabPages.Add(tbpMaster);
                    tabControl1.SelectTab(tbpMaster);

                    if (DGV_Facturas_Pos_List.Rows.Count != 0)
                    {

                        txtNoFactura.Text = DGV_Facturas_Pos_List[0, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();
                        txtCliente.Text = DGV_Facturas_Pos_List[1, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();
                        dtpFecha.Text = DGV_Facturas_Pos_List[2, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();
                        lblTotal.Text = DGV_Facturas_Pos_List[12, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();
                        txtEstatus.Text = DGV_Facturas_Pos_List[15, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();

                        enlFacturaDetail.NoFactura = txtNoFactura.Text;
                        DGV_Factura_Pos.DataSource = bllFacturaDetail.Search(enlFacturaDetail);
                    }
                }


            if (!string.IsNullOrEmpty(txtNoFactura.Text))
            {


                enlFacturaMaster.Numero = txtNoFactura.Text;
                enlFacturaDetail.NoFactura = txtNoFactura.Text;

                // Antes de Borrar el Detalle, acutlizamos la existencia.
                for (int a = 0; a < DGV_Factura_Pos.RowCount; a++)
                {
                    enlFacturaDetail.Codigo = DGV_Factura_Pos[0, a].Value.ToString();
                    enlFacturaDetail.Cantidad = Convert.ToDecimal(DGV_Factura_Pos[3, a].Value);

                    enlArticulos.Codigo = enlFacturaDetail.Codigo;
                    enlArticulos.Existencia = (enlFacturaDetail.Cantidad) * 1;
                    bllArticulos.UpdateExitencia(enlArticulos);
                }



                if (bllFacturaDetail.Delete(enlFacturaDetail))
                {
                    bllFacturaMaster.Delete(enlFacturaMaster);

                    DGV_Facturas_Pos_List.DataSource = null;
                    ActualizarDGV = true;
                    AC.VaciarText(this);
                    DGV_Factura_Pos.DataSource = null;
                }

            }


            }
            catch (Exception E)
            {

                MessageBox.Show(E.Message);
            }

        }

        private void txtArticulo_Validating(object sender, CancelEventArgs e)
        {

            try
            {

 
            enlArticulos.Codigo = txtArticulo.Text;
            enlArticulos.Nombre = string.Empty;
            enlArticulos.Descripcion = string.Empty;
            enlArticulos.Impuesto = string.Empty;
            enlArticulos.Marca = string.Empty;
            enlArticulos.Categoria = string.Empty;
            enlArticulos.SubCategoria = string.Empty;

            if (!String.IsNullOrEmpty(txtArticulo.Text))
            {
              //MessageBox.Show  (Convert.ToString( bllArticulos.Search(enlArticulos).Count));

                var list = bllArticulos.Search(enlArticulos);

                txtArticulo.Text = list[0].Codigo;
                txtDescripcion.Text = list[0].Descripcion;
                txtPrecio.Text = Convert.ToString(list[0].Precio);
                txtCantidad.Text = "1";
                txtCosto.Text = Convert.ToString(list[0].Costo);
              
             }
            }
            catch (Exception)
            {

                MessageBox.Show("Articulo no Existe");
            }  
            
        }

        private void DGV_Facturas_Pos_List_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVista_Click(btnVista, null);
        }

        private void btnVista_Click(object sender, EventArgs e)
        {


            if (ActualizarDGV == true)
            {

                enlFacturaMaster.Numero = string.Empty;
                enlFacturaMaster.Cliente = string.Empty;
                enlFacturaMaster.Almacen = string.Empty;
                enlFacturaMaster.Terminos = string.Empty;
                enlFacturaMaster.Tipo = "POS";
                enlFacturaMaster.Vendedor = string.Empty;
                enlFacturaMaster.BalancePendiente = -1;

                DGV_Facturas_Pos_List.DataSource = bllFacturaMaster.Search(enlFacturaMaster);

                ActualizarDGV = false;
            }


            if (tabControl1.SelectedTab == tbpMaster)
            {
                tabControl1.TabPages.Remove(tbpMaster);
                tabControl1.TabPages.Add(tbpDetail);
                tabControl1.SelectTab(tbpDetail);
            }
            else
            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Facturas_Pos_List.Rows.Count != 0)
                {

                    txtNoFactura.Text = DGV_Facturas_Pos_List[0, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();
                    txtCliente.Text = DGV_Facturas_Pos_List[1, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();
                    dtpFecha.Text = DGV_Facturas_Pos_List[2, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();
                    lblTotal.Text = DGV_Facturas_Pos_List[12, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();
                    txtEstatus.Text = DGV_Facturas_Pos_List[15, DGV_Facturas_Pos_List.CurrentCell.RowIndex].Value.ToString();

                    enlFacturaDetail.NoFactura = txtNoFactura.Text;
                    DGV_Factura_Pos.DataSource = bllFacturaDetail.Search(enlFacturaDetail);

                }

            }
        }

        private void btnBuscarDetail_Click(object sender, EventArgs e)
        {
            enlFacturaMaster.Numero = txtBuscarNoFactura.Text;
            enlFacturaMaster.Cliente = txtBuscarCliente.Text;
            enlFacturaMaster.Almacen = string.Empty;
            enlFacturaMaster.Terminos = string.Empty;
            enlFacturaMaster.Tipo = "POS";
            enlFacturaMaster.Vendedor = string.Empty;
            enlFacturaMaster.BalancePendiente = -1;

            enlFacturaMaster.DesdeFecha = dtpDesde.Value;
            enlFacturaMaster.HastaFecha = dtpHasta.Value;

            enlFacturaMaster.Status = cmbEstatus.Text;


            DGV_Facturas_Pos_List.DataSource = bllFacturaMaster.Search(enlFacturaMaster);
        }

        private void Frm_Pos_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Estado == Helper.EstadoSystema.Editando)
            {
                
                enlFacturaDetail.NoFactura = txtNoFactura.Text;
                DGV_Factura_Pos.DataSource = bllFacturaDetail.Search(enlFacturaDetail);

                for (int a = 0; a <= DGV_Factura_Pos.RowCount - 1; a++)
                {
                    enlArticulos.Codigo = DGV_Factura_Pos[0, a].Value.ToString();
                    enlArticulos.Existencia = -Convert.ToDecimal(DGV_Factura_Pos[3, a].Value);
                    bllArticulos.UpdateExitencia(enlArticulos);
                }

            }
        }

        private void lblBuscarArticulo_Click(object sender, EventArgs e)
        {

            if (Estado != Helper.EstadoSystema.Consultando)
            {
                enlArticulos.Codigo = string.Empty;
                enlArticulos.Nombre = string.Empty;
                enlArticulos.Descripcion = string.Empty;
                enlArticulos.Impuesto = string.Empty;
                enlArticulos.Marca = string.Empty;
                enlArticulos.Categoria = string.Empty;
                enlArticulos.SubCategoria = string.Empty;
                enlArticulos.CodigoBarra = string.Empty;

                if (bllArticulos.Search(enlArticulos) != null)
                {

                    Frm_Buscar_Articulos frmBuscarArticulos = new Frm_Buscar_Articulos();
                    frmBuscarArticulos.Owner = this;
                    frmBuscarArticulos.LlamadoDesde = "Frm_POS";
                    //frmBuscarCxC.DGV_Datos.DataSource = bllArticulos.Search(enlArticulos);
                    frmBuscarArticulos.ShowDialog();
                }
                else
                {
                    MessageBox.Show("La Maestra Esta Vacia");
                }
            }

        }
    
    }
}
