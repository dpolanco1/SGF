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
using EntityLayer.Inventario;
using BusinessLogicLayer.Inventario;
using BusinessLogicLayer.Otros;
using aPrestentationLayer.CxC_Ventas.Reportes.Formatos;
using aPrestentationLayer.Comunes;
using EntityLayer.Administracion;


namespace aPrestentationLayer.CxC_Ventas
{
    public partial class Frm_Facturas : Frm_Plantilla
    {

        string Estado = string.Empty;
        const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";

        bool ActualizarDGV = false;


        AdministrarControles AC = new AdministrarControles();
        Enl_FacturaMaster enlFacturaMaster = new Enl_FacturaMaster();
        Bll_FacturaMaster bllFacturaMaster = new Bll_FacturaMaster();

        Enl_FacturaDetail enlFacturaDetail = new Enl_FacturaDetail();
        Bll_FacturaDetail bllFacturaDetail = new Bll_FacturaDetail();

        Enl_Articulos enlArticulos = new Enl_Articulos();
        Bll_Articulos bllArticulos = new Bll_Articulos();

        Enl_Impuestos enlImpuestos = new Enl_Impuestos();
        Bll_Impuestos bllImpuestos = new Bll_Impuestos();


        Enl_CotizacionesMaster enlCotizacionMaster = new Enl_CotizacionesMaster();
        Enl_CotizacionesDetail enlCotizacionDetail = new Enl_CotizacionesDetail();
        Bll_CotizacionesDetail bllCotizacionDetail = new Bll_CotizacionesDetail();



        Bll_Numeracion bllNumeracion = new Bll_Numeracion();

        IList<Enl_FacturaDetail> list;
        IList<Enl_CotizacionesMaster> listCotiza;


        IList<Enl_Articulos> listArticulos = new List<Enl_Articulos>();


        decimal TotalLineaCompra, linea, cantidad, costo,
        impuesto, TotalImpuestoCompra, SubTotalCompra,
        Porcentaje, TotalDescuentoCompra, TotalCompraCompra;



        // IList<Enl_CotizacionesMaster> listCotizacionMaster;

        public Frm_Facturas()//IList<Enl_CotizacionesMaster> enlCotizacionMasterIlist)
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;

            btnImprimir.Click += btnImprimir_Click;
            btnVista.Click += btnVista_Click;

            this.DGV_DetailFactura.AutoGenerateColumns = false;
            this.DGV_Facturas.AutoGenerateColumns = false;
            this.DGV_Cotizaciones.AutoGenerateColumns = false;

            // this.listCotizacionMaster = enlCotizacionMasterIlist;

        }

        void btnVista_Click(object sender, EventArgs e)
        {
            if (ActualizarDGV == true)
            {

                enlFacturaMaster.Numero = string.Empty;
                enlFacturaMaster.Cliente = string.Empty;
                enlFacturaMaster.Almacen = string.Empty;
                enlFacturaMaster.Terminos = string.Empty;
                enlFacturaMaster.Tipo = string.Empty;
                enlFacturaMaster.Vendedor = string.Empty;
                enlFacturaMaster.BalancePendiente = -1;

                DGV_Facturas.DataSource = bllFacturaMaster.Search(enlFacturaMaster);

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

                }

                if (DGV_Facturas.Rows.Count != 0)
                {

                    txtNoFactura.Text = DGV_Facturas[0, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtCliente.Text = DGV_Facturas[1, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    dtpFecha.Text = DGV_Facturas[2, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtAlmacen.Text = DGV_Facturas[3, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtTerminos.Text = DGV_Facturas[4, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    cmbTipo.Text = DGV_Facturas[5, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    nudDescuento.Value = Convert.ToDecimal(DGV_Facturas[6, DGV_Facturas.CurrentCell.RowIndex].Value);
                    txtVendedor.Text = DGV_Facturas[7, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtCaja.Text = DGV_Facturas[8, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtSubTotal.Text = DGV_Facturas[9, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtTotalImpuesto.Text = DGV_Facturas[10, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtTotalDescuento.Text = DGV_Facturas[11, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtTotalFactura.Text = DGV_Facturas[12, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                }
            }
            enlFacturaDetail.NoFactura = txtNoFactura.Text;

            DGV_DetailFactura.DataSource = bllFacturaDetail.Search(enlFacturaDetail);

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
            // DGV_DetailFactura.Rows.Clear();
            DGV_DetailFactura.DataSource = null;

            if (bllNumeracion.ObtenerTipo("Facturas") == "Automatico")
            {
                txtNoFactura.Enabled = false;
                txtNoFactura.Focus();
            }
            else
            {
                txtNoFactura.Enabled = true;
                txtNoFactura.Focus();
            }


        }

        void btnGuardar_Click(object sender, EventArgs e)
        {


            enlFacturaMaster.Numero = txtNoFactura.Text;
            enlFacturaMaster.Cliente = txtCliente.Text;
            enlFacturaMaster.Fecha = dtpFecha.Value; ;
            enlFacturaMaster.Almacen = txtAlmacen.Text;
            enlFacturaMaster.Terminos = txtTerminos.Text;
            enlFacturaMaster.Tipo = cmbTipo.Text;
            enlFacturaMaster.Descuento = nudDescuento.Value;
            enlFacturaMaster.Vendedor = txtVendedor.Text;
            enlFacturaMaster.Caja = txtCaja.Text;
            enlFacturaMaster.Status = "Prueba";

            enlFacturaMaster.SubTotal = Convert.ToDecimal(txtSubTotal.Text);
            enlFacturaMaster.TotalImpuesto = Convert.ToDecimal(txtTotalImpuesto.Text);
            enlFacturaMaster.TotalDescuento = Convert.ToDecimal(txtTotalDescuento.Text);
            enlFacturaMaster.TotalFactura = Convert.ToDecimal(txtTotalFactura.Text);


            if (enlFacturaMaster.Tipo == "Contado")
            {
                enlFacturaMaster.TotalPagado = enlFacturaMaster.TotalFactura;
                enlFacturaMaster.BalancePendiente = 0;

            }

            if (enlFacturaMaster.Tipo == "Credito")
            {
                enlFacturaMaster.TotalPagado = 0;
                enlFacturaMaster.BalancePendiente = enlFacturaMaster.TotalFactura;

            }


            if (Estado == "Creando")
            {
                txtNoFactura.Text = bllFacturaMaster.Insert(enlFacturaMaster);

                //hago la insercion en los DGV
                for (int a = 0; a < DGV_DetailFactura.RowCount; a++)
                {
                    enlFacturaDetail.NoFactura = txtNoFactura.Text;//No Factura
                    enlFacturaDetail.Articulo = DGV_DetailFactura[0, a].Value.ToString();
                    enlFacturaDetail.Descripcion = DGV_DetailFactura[1, a].Value.ToString();
                    enlFacturaDetail.Precio = Convert.ToDecimal(DGV_DetailFactura[2, a].Value);
                    enlFacturaDetail.Cantidad = Convert.ToDecimal(DGV_DetailFactura[3, a].Value);
                    enlFacturaDetail.Impuesto = Convert.ToDecimal(DGV_DetailFactura[4, a].Value);
                    enlFacturaDetail.TotalLinea = Convert.ToDecimal(DGV_DetailFactura[5, a].Value);
                    enlFacturaDetail.Costo = Convert.ToDecimal(DGV_DetailFactura[6, a].Value);

                    bllFacturaDetail.Insert(enlFacturaDetail);


                    enlArticulos.Codigo = enlFacturaDetail.Articulo;
                    enlArticulos.Existencia = (enlFacturaDetail.Cantidad) * -1;

                    bllArticulos.UpdateExitencia(enlArticulos);

                }

                if (bllNumeracion.ObtenerTipo("Facturas") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Facturas"), "Facturas");
                }

                MessageBox.Show("Registro Guardado Correctamente", "SGF");

            }
            else
            {
                if (Estado == "Editando")
                {
                    bllFacturaMaster.Update(enlFacturaMaster);

                    //Eliminados El Detalle de la Factura
                    enlFacturaDetail.NoFactura = txtNoFactura.Text;
                    bllFacturaDetail.Delete(enlFacturaDetail);

                    //Insertamos el Detalle de la Factura

                    for (int a = 0; a < DGV_DetailFactura.RowCount - 1; a++)
                    {
                        enlFacturaDetail.NoFactura = txtNoFactura.Text;//No Factura
                        enlFacturaDetail.Articulo = DGV_DetailFactura[0, a].Value.ToString();
                        enlFacturaDetail.Descripcion = DGV_DetailFactura[1, a].Value.ToString();
                        enlFacturaDetail.Precio = Convert.ToDecimal(DGV_DetailFactura[2, a].Value);
                        enlFacturaDetail.Cantidad = Convert.ToDecimal(DGV_DetailFactura[3, a].Value);
                        enlFacturaDetail.Impuesto = Convert.ToDecimal(DGV_DetailFactura[4, a].Value);
                        enlFacturaDetail.TotalLinea = Convert.ToDecimal(DGV_DetailFactura[5, a].Value);

                        bllFacturaDetail.Insert(enlFacturaDetail);
                    }
                    MessageBox.Show("Registro Actualizado Correctamente", "SGF");
                }
            }

            BotonGuardar();
            ActualizarDGV = true;
            Estado = CONSULTA;

        }

        void btnEditar_Click(object sender, EventArgs e)
        {
            Estado = "Editando";

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Facturas.Rows.Count != 0)
                {

                    txtNoFactura.Text = DGV_Facturas[0, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtCliente.Text = DGV_Facturas[1, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    dtpFecha.Text = DGV_Facturas[2, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtAlmacen.Text = DGV_Facturas[3, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtTerminos.Text = DGV_Facturas[4, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    cmbTipo.Text = DGV_Facturas[5, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    nudDescuento.Value = Convert.ToDecimal(DGV_Facturas[6, DGV_Facturas.CurrentCell.RowIndex].Value);
                    txtVendedor.Text = DGV_Facturas[7, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtCaja.Text = DGV_Facturas[8, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtSubTotal.Text = DGV_Facturas[9, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtTotalImpuesto.Text = DGV_Facturas[10, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtTotalDescuento.Text = DGV_Facturas[11, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtTotalFactura.Text = DGV_Facturas[12, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();

                    enlFacturaDetail.NoFactura = txtNoFactura.Text;

                    list = bllFacturaDetail.Search(enlFacturaDetail);
                    DGV_DetailFactura.DataSource = list; // bllFacturaDetail.Search(enlFacturaDetail);

                }


            }
            if (!string.IsNullOrEmpty(txtNoFactura.Text))
            {
                BotonEditar();
                txtNoFactura.Enabled = false;
                txtCliente.Focus();


                for (int a = 0; a <= DGV_DetailFactura.RowCount - 1; a++)
                {
                    enlArticulos.Codigo = DGV_DetailFactura[0, a].Value.ToString();
                    enlArticulos.Existencia = Convert.ToDecimal(DGV_DetailFactura[3, a].Value);
                    bllArticulos.UpdateExitencia(enlArticulos);
                }

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
                //enlCategoriaClientes.Codigo = txtCodigo.Text;
                //enlCategoriaClientes.Nombre = string.Empty;

                //var list = bllCategoriaClientes.Search(enlCategoriaClientes);
                //txtNombre.Text = list[0].Nombre;
                //txtNota.Text = list[0].Nota;
                enlFacturaMaster.Numero = txtNoFactura.Text;
                enlFacturaMaster.Cliente = string.Empty;
                enlFacturaMaster.Almacen = string.Empty;
                enlFacturaMaster.Terminos = string.Empty;
                enlFacturaMaster.Tipo = string.Empty;
                enlFacturaMaster.Vendedor = string.Empty;
                enlFacturaMaster.BalancePendiente = -1;


                var list = bllFacturaMaster.Search(enlFacturaMaster);

                enlFacturaDetail.NoFactura = txtNoFactura.Text;
                DGV_DetailFactura.DataSource = bllFacturaDetail.Search(enlFacturaDetail);

                for (int a = 0; a <= DGV_DetailFactura.RowCount - 1; a++)
                {
                    enlArticulos.Codigo = DGV_DetailFactura[0, a].Value.ToString();
                    enlArticulos.Existencia = -Convert.ToDecimal(DGV_DetailFactura[3, a].Value);
                    bllArticulos.UpdateExitencia(enlArticulos);
                }
            }

            BotonCancelar();
            Estado = CONSULTA;
        }

        void btnEliminar_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Facturas.Rows.Count != 0)
                {

                    txtNoFactura.Text = DGV_Facturas[0, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtCliente.Text = DGV_Facturas[1, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    dtpFecha.Text = DGV_Facturas[2, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtAlmacen.Text = DGV_Facturas[3, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtTerminos.Text = DGV_Facturas[4, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    cmbTipo.Text = DGV_Facturas[5, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    nudDescuento.Value = Convert.ToDecimal(DGV_Facturas[6, DGV_Facturas.CurrentCell.RowIndex].Value);
                    txtVendedor.Text = DGV_Facturas[7, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtCaja.Text = DGV_Facturas[8, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtSubTotal.Text = DGV_Facturas[9, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtTotalImpuesto.Text = DGV_Facturas[10, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtTotalDescuento.Text = DGV_Facturas[11, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                    txtTotalFactura.Text = DGV_Facturas[12, DGV_Facturas.CurrentCell.RowIndex].Value.ToString();
                }
            }



            enlFacturaMaster.Numero = txtNoFactura.Text;
            enlFacturaDetail.NoFactura = txtNoFactura.Text;

            bllFacturaDetail.Delete(enlFacturaDetail);
            bllFacturaMaster.Delete(enlFacturaMaster);

            DGV_DetailFactura.DataSource = null;

            BotonEliminar();

            ActualizarDGV = true;
        }

        void btnBuscar_Click(object sender, EventArgs e)
        {
            //Frm_Buscar_CxC frmBuscarCxC = new Frm_Buscar_CxC();
            //frmBuscarCxC.Owner = this;
            //frmBuscarCxC.LlamadoDesde = "Frm_Facturas";
            //frmBuscarCxC.ShowDialog();

        }

        void btnImprimir_Click(object sender, EventArgs e)
        {
            Rpt_FacturaResumido rpt = new Rpt_FacturaResumido();
            rpt.ShowDialog();

        }

        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.Text != "Contado")
            {
                txtCaja.Enabled = false;
                txtCaja.Text = string.Empty;
                lblCaja.Font = new Font(lblCaja.Font, FontStyle.Regular);
            }
            else
            {
                txtCaja.Enabled = true;
                lblCaja.Font = new Font(lblCaja.Font, FontStyle.Bold);
            }

        }

        private void Frm_Facturas_Load(object sender, EventArgs e)
        {

            Estado = CONSULTA;
            tabControl1.TabPages.Remove(tbpMaster);

            enlFacturaMaster.Numero = string.Empty;
            enlFacturaMaster.Cliente = string.Empty;
            enlFacturaMaster.Almacen = string.Empty;
            enlFacturaMaster.Terminos = string.Empty;
            enlFacturaMaster.Tipo = string.Empty;
            enlFacturaMaster.Vendedor = string.Empty;
            enlFacturaMaster.BalancePendiente = -1;

            enlFacturaMaster.DesdeFecha = dtpDesde.Value.Date;
            enlFacturaMaster.HastaFecha = dtpHasta.Value.Date;


            DGV_Facturas.DataSource = bllFacturaMaster.Search(enlFacturaMaster);

            cmbTipo.SelectedIndex = cmbTipo.Items.IndexOf("Contado");

        }

        private void DGV_Facturas_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVista_Click(btnVista, null);
        }

        private void Frm_Facturas_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Estado != CONSULTA)
            {
                if (MessageBox.Show("No ha Guardado el Resigro, Desea Continuar ?", "Salir", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    if (Estado == EDITAR)
                    {
                        for (int a = 0; a <= DGV_DetailFactura.RowCount - 1; a++)
                        {
                            enlArticulos.Codigo = DGV_DetailFactura[0, a].Value.ToString();
                            enlArticulos.Existencia = -Convert.ToDecimal(DGV_DetailFactura[3, a].Value);
                            bllArticulos.UpdateExitencia(enlArticulos);
                        }

                    }

                }
                else
                {
                    e.Cancel = true;
                }
            }








        }

        private void btnBuscarTerminos_Click(object sender, EventArgs e)
        {
            //Frm_Buscar_CxC frm = new Frm_Buscar_CxC();
            //frm.Owner = this;
            //frm.LlamadoDesde = "Terminos";

            //Enl_Termino enlTermino = new Enl_Termino();
            //Bll_Terminos bllTermino = new Bll_Terminos();

            //enlTermino.Codigo = string.Empty;
            //enlTermino.Nombre = string.Empty;
            //frm.DGV_Datos.DataSource = bllTermino.Search(enlTermino);
            //frm.ShowDialog();

        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            if (txtArticulo.Text != String.Empty && txtPrecio.Text != String.Empty && txtCantidad.Text != String.Empty)
            {

                //decimal costo, cantidad, totalLinea,impuesto,TotalLinea = 0,TotalImpuesto = 0;
                costo = Convert.ToDecimal(txtPrecio.Text);
                cantidad = Convert.ToDecimal(txtCantidad.Text);
                impuesto = 0;
                linea = costo * cantidad + impuesto;


                if (Estado == "Editando")
                {

                    list.Add(new Enl_FacturaDetail
                    {
                        Articulo = txtArticulo.Text,
                        Descripcion = txtDescripcion.Text,
                        Precio = Convert.ToDecimal(txtPrecio.Text),
                        Cantidad = Convert.ToDecimal(txtCantidad.Text),
                        TotalLinea = Convert.ToDecimal(txtPrecio.Text) * Convert.ToDecimal(txtCantidad.Text)
                    });

                    list.Add(enlFacturaDetail);

                    DGV_DetailFactura.DataSource = null;
                    DGV_DetailFactura.DataSource = list;

                }
                else
                {
                    //Buscamos el codigo del impuesto filtrando el Articulo
                    enlArticulos.Codigo = txtArticulo.Text;
                    enlArticulos.Nombre = string.Empty;
                    enlArticulos.Descripcion = string.Empty;
                    enlArticulos.Impuesto = string.Empty;
                    enlArticulos.Marca = string.Empty;
                    enlArticulos.Categoria = string.Empty;
                    enlArticulos.SubCategoria = string.Empty;

                    var ListaArticulos = bllArticulos.Search(enlArticulos);

                    // Llamamos el impuesto que esta asociado al Articulo
                    enlImpuestos.Codigo = ListaArticulos[0].Impuesto;
                    enlImpuestos.Nombre = string.Empty;
                    var ListaImpuesto = bllImpuestos.Search(enlImpuestos);

                    //Calculamos el Impuesto 
                    var ValorImpuesto = (ListaImpuesto[0].Porcentaje / 100) * decimal.Parse(txtPrecio.Text);

                    this.listArticulos.Add(new Enl_Articulos()
                    {
                        Codigo = txtArticulo.Text,
                        Descripcion = txtDescripcion.Text,
                        Precio = decimal.Parse(txtPrecio.Text),
                        Cantidad = int.Parse(txtCantidad.Text),
                        Impuesto = ValorImpuesto.ToString("C2").Replace("RD$", "")


                    });
                    DGV_DetailFactura.DataSource = null;
                    DGV_DetailFactura.DataSource = this.listArticulos;
                    lblCantidaArticulos.Text = string.Format("Cantidad: {0}", DGV_DetailFactura.RowCount);
                }
                ////Método con el que recorreremos todas las filas de nuestro Datagridview

                TotalLineaCompra = 0;
                TotalImpuestoCompra = 0;

                foreach (DataGridViewRow row in DGV_DetailFactura.Rows)
                {
                    TotalLineaCompra += Convert.ToDecimal(row.Cells["TotalLineaFacturaGrid"].Value);
                    TotalImpuestoCompra += Convert.ToDecimal(row.Cells["ImpuestoFacturaGrid"].Value);
                }

                Porcentaje = nudDescuento.Value / 100;
                SubTotalCompra = TotalLineaCompra - TotalImpuestoCompra;
                TotalDescuentoCompra = SubTotalCompra * Porcentaje;
                TotalCompraCompra = SubTotalCompra + TotalImpuestoCompra - TotalDescuentoCompra;

                txtSubTotal.Text = Convert.ToString(SubTotalCompra.ToString());
                txtTotalImpuesto.Text = Convert.ToString(TotalImpuestoCompra.ToString());
                txtTotalDescuento.Text = Convert.ToString(TotalDescuentoCompra.ToString());
                txtTotalFactura.Text = Convert.ToString(TotalCompraCompra.ToString());


                txtArticulo.Text = String.Empty;
                txtDescripcion.Text = String.Empty;
                txtPrecio.Text = String.Empty;
                txtCantidad.Text = String.Empty;

                txtArticulo.Focus();
            }
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (DGV_DetailFactura.RowCount != 0)
            {


                if (Estado == "Editando")
                {
                    list.RemoveAt(DGV_DetailFactura.CurrentRow.Index);

                    DGV_DetailFactura.DataSource = null;
                    DGV_DetailFactura.DataSource = list;

                }
                else
                {

                    DGV_DetailFactura.Rows.RemoveAt(DGV_DetailFactura.CurrentRow.Index);
                    lblCantidaArticulos.Text = string.Format("Cantidad: {0}", DGV_DetailFactura.RowCount);

                }
                decimal sumatoria = 0;

                foreach (DataGridViewRow row in DGV_DetailFactura.Rows)
                {
                    sumatoria += Convert.ToDecimal(row.Cells["TotalLineaFacturagrid"].Value);
                }
                txtSubTotal.Text = Convert.ToString(sumatoria.ToString());

            }
        }

        private void btnBuscarDetail_Click(object sender, EventArgs e)
        {
            enlFacturaMaster.Numero = string.Empty;
            enlFacturaMaster.Cliente = string.Empty;
            enlFacturaMaster.Almacen = string.Empty;
            enlFacturaMaster.Terminos = string.Empty;
            enlFacturaMaster.Tipo = string.Empty;
            enlFacturaMaster.Vendedor = string.Empty;
            enlFacturaMaster.BalancePendiente = -1;

            enlFacturaMaster.DesdeFecha = dtpDesde.Value.Date;
            enlFacturaMaster.HastaFecha = dtpHasta.Value.Date;

            DGV_Facturas.DataSource = bllFacturaMaster.Search(enlFacturaMaster);
        }

        private void btnAnadir_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtCliente.Text))
            {

                Frm_Buscar_Cotizacion frmBuscarCotizaciones = new Frm_Buscar_Cotizacion(txtCliente.Text);
                frmBuscarCotizaciones.ShowDialog();

                listCotiza = frmBuscarCotizaciones.ListaCotizaciones;

                if (listCotiza.Count != 0)
                {
                    DGV_Cotizaciones.DataSource = listCotiza;

                    for (int a = 0; a < DGV_Cotizaciones.RowCount; a++)
                    {
                        enlCotizacionDetail.NoCotizacion = DGV_Cotizaciones[0, a].Value.ToString();
                        DGV_DetailFactura.DataSource = bllCotizacionDetail.Search(enlCotizacionDetail);
                    }
                }

            }
            else
            {
                MessageBox.Show("Es Necesario Seleccionar el Cliente");
            }
        }

        private void btnBorrarCotizacion_Click(object sender, EventArgs e)
        {

            if (DGV_Cotizaciones.RowCount != 0)
            {
                //  DGV_Cotizaciones.Rows.RemoveAt(DGV_Cotizaciones.CurrentRow.Index);

                listCotiza.RemoveAt(DGV_Cotizaciones.CurrentRow.Index);

                DGV_Cotizaciones.DataSource = null;
                DGV_Cotizaciones.DataSource = listCotiza;
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

        private void lblBuscarArticulos_Click(object sender, EventArgs e)
        {

            if (Estado != CONSULTA)
            {
                Frm_Buscar_Articulos frmBuscarArticulos = new Frm_Buscar_Articulos();
                if (frmBuscarArticulos.ShowDialog() == DialogResult.OK)
                {
                    if (DGV_DetailFactura.RowCount == 0)
                    {
                        listArticulos = frmBuscarArticulos.ListaArticulos;
                        DGV_DetailFactura.DataSource = this.listArticulos;
                        lblCantidaArticulos.Text = string.Format("Cantidad: {0}", DGV_DetailFactura.RowCount);
                    }
                    else if (frmBuscarArticulos.ListaArticulos.Count != 0)
                    {
                        foreach (Enl_Articulos item in frmBuscarArticulos.ListaArticulos)
                        {
                            this.listArticulos.Add(item);
                        }
                        DGV_DetailFactura.DataSource = null;
                        DGV_DetailFactura.DataSource = this.listArticulos;
                        lblCantidaArticulos.Text = string.Format("Cantidad: {0}", DGV_DetailFactura.RowCount);

                    }
                }



            }



        }

        private void DGV_DetailFactura_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 2 || ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 3))
            {
                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
                e.Handled = true;
        }

        private void DGV_DetailFactura_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            // Helper.CalcularGrid(DGV_DetailFactura, nudDescuento.Value / 100);

        }

        private void DGV_DetailFactura_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (e.RowIndex != 0)
            {
                DGV_DetailFactura.Rows[e.RowIndex].Cells["TotalLineaFacturaGrid"].Value = 10;
            }
            //DGV_DetailFactura.Rows[].Cells[].Value = 

        }
    }
}


