using aPrestentationLayer.Administracion;
using aPrestentationLayer.Plantillas;
using BusinessLogicLayer.Administracion;
using BusinessLogicLayer.CxC_Ventas;
using BusinessLogicLayer.Inventario;
using BusinessLogicLayer.Otros;
using EntityLayer.CxC_Ventas;
using EntityLayer.Inventario;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Transactions;
using System.Windows.Forms;




namespace aPrestentationLayer.CxC_Ventas
{
    public partial class Frm_Cotizaciones : Frm_Plantilla, Icotizaciones
    {
        
        string Estado = string.Empty;
        const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";
        //CultureInfo ci = new CultureInfo("es-DO");

        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();
        Enl_CotizacionesMaster enlCotizacionMaster = new Enl_CotizacionesMaster();
        Bll_CotizacionesMaster bllCotizacionMaster = new Bll_CotizacionesMaster();

        Enl_CotizacionesDetail enlCotizacionDetail = new Enl_CotizacionesDetail();
        Bll_CotizacionesDetail bllCotizacionDetail = new Bll_CotizacionesDetail();

        Enl_Articulos enlArticulos = new Enl_Articulos();
        Bll_Articulos bllArticulos = new Bll_Articulos();
        

        Bll_Numeracion bllNumeracion = new Bll_Numeracion();

        IList<Enl_CotizacionesDetail> list;

    

        public Frm_Cotizaciones()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnVista.Click += btnVista_Click;

            DGV_DetailCotizaciones.AutoGenerateColumns = false;
            DGV_Cotizacion_List.AutoGenerateColumns = false;
 
         

        }


        #region IForm Members

        public void CodigoTerminos(string termino)
        {
            txtTerminos.Text = termino;

        }

        public void CodigoVendedor(string vendedor)
        {
            txtVendedor.Text = vendedor;

        }

        public void CodigoCliente(string cliente, string nombre)
        {
            txtCliente.Text = cliente;
            txtNombre.Text = nombre;

        }

        #endregion

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
            if (bllNumeracion.ObtenerTipo("Cotizaciones") == "Automatico")
            {
                txtNoCotizacion.Enabled = false;
                txtNoCotizacion.Focus();
            }
            else
            {
                txtNoCotizacion.Enabled = true;
                txtNoCotizacion.Focus();
            }

        }

        void btnGuardar_Click(object sender, EventArgs e)
        {

            using (TransactionScope ts = new TransactionScope())
            {

                try
                {


                    enlCotizacionMaster.Numero = txtNoCotizacion.Text;
                    enlCotizacionMaster.Cliente = txtCliente.Text;
                    enlCotizacionMaster.Fecha = dtpFecha.Value; ;
                    enlCotizacionMaster.Terminos = txtTerminos.Text;
                    enlCotizacionMaster.Descuento = nudDescuento.Value;
                    enlCotizacionMaster.Vendedor = txtVendedor.Text;
                    enlCotizacionMaster.SubTotal = Convert.ToDecimal(string.Format(txtSubTotal.Text.ToString().Replace("RD$", "")));
                    enlCotizacionMaster.TotalImpuesto = Convert.ToDecimal(txtTotalImpuesto.Text.ToString().Replace("RD$", ""));
                    enlCotizacionMaster.TotalDescuento = Convert.ToDecimal(txtTotalDescuento.Text.ToString().Replace("RD$", ""));
                    enlCotizacionMaster.TotalCotizacion = Convert.ToDecimal(txtTotalCotizacion.Text.ToString().Replace("RD$", ""));

                    if (Estado == "Creando")
                    {
                        txtNoCotizacion.Text = bllCotizacionMaster.Insert(enlCotizacionMaster);

                        //hago la insercion en los DGV
                        for (int a = 0; a < DGV_DetailCotizaciones.RowCount - 1; a++)
                        {
                            enlCotizacionDetail.NoCotizacion = txtNoCotizacion.Text;//No Factura
                            enlCotizacionDetail.Articulo = DGV_DetailCotizaciones[0, a].Value.ToString();
                            enlCotizacionDetail.Descripcion = DGV_DetailCotizaciones[1, a].Value.ToString();
                            enlCotizacionDetail.Precio = Convert.ToDecimal(DGV_DetailCotizaciones[2, a].Value);
                            enlCotizacionDetail.Cantidad = Convert.ToDecimal(DGV_DetailCotizaciones[3, a].Value);
                            enlCotizacionDetail.Impuesto = Convert.ToDecimal(DGV_DetailCotizaciones[4, a].Value);
                            enlCotizacionDetail.TotalLinea = Convert.ToDecimal(DGV_DetailCotizaciones[5, a].Value);

                            bllCotizacionDetail.Insert(enlCotizacionDetail);
                        }

                        if (bllNumeracion.ObtenerTipo("Cotizaciones") == "Automatico")
                        {
                            bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Cotizaciones"), "Cotizaciones");
                        }

                        MessageBox.Show("Registro Guardado Correctamente", "SGF");


                    }
                    else
                    {
                        if (Estado == "Editando")
                        {
                            bllCotizacionMaster.Update(enlCotizacionMaster);

                            //Eliminados El Detalle de la Factura
                            enlCotizacionMaster.Numero = txtNoCotizacion.Text;
                            bllCotizacionMaster.Delete(enlCotizacionMaster);

                            //Insertamos el Detalle de la Factura

                            for (int a = 0; a < DGV_DetailCotizaciones.RowCount - 1; a++)
                            {
                                enlCotizacionDetail.NoCotizacion = txtNoCotizacion.Text;//No Factura
                                enlCotizacionDetail.Articulo = DGV_DetailCotizaciones[0, a].Value.ToString();
                                enlCotizacionDetail.Descripcion = DGV_DetailCotizaciones[1, a].Value.ToString();
                                enlCotizacionDetail.Precio = Convert.ToDecimal(DGV_DetailCotizaciones[2, a].Value);
                                enlCotizacionDetail.Cantidad = Convert.ToDecimal(DGV_DetailCotizaciones[3, a].Value);
                                enlCotizacionDetail.Impuesto = Convert.ToDecimal(DGV_DetailCotizaciones[4, a].Value);
                                enlCotizacionDetail.TotalLinea = Convert.ToDecimal(DGV_DetailCotizaciones[5, a].Value);

                                bllCotizacionDetail.Insert(enlCotizacionDetail);
                            }


                            MessageBox.Show("Registro Actualizado Correctamente", "SGF");

                        }
                    }

                    BotonGuardar();
                    ActualizarDGV = true;
                    Estado = CONSULTA;
                    ts.Complete();
                }
                catch (Exception x)
                {

                    MessageBox.Show(x.Message);
                    ts.Dispose();
                }
                
            }
        }

        void btnEditar_Click(object sender, EventArgs e)
        {
            Estado = "Editando";

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Cotizacion_List.Rows.Count != 0)
                {

                    txtNoCotizacion.Text = DGV_Cotizacion_List[0, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();
                    txtCliente.Text = DGV_Cotizacion_List[1, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();
                    dtpFecha.Text = DGV_Cotizacion_List[2, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();
                    txtTerminos.Text = DGV_Cotizacion_List[3, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();
                    nudDescuento.Value = Convert.ToDecimal(DGV_Cotizacion_List[4, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString());
                    txtVendedor.Text = DGV_Cotizacion_List[5, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();

                    txtSubTotal.Text = DGV_Cotizacion_List[6, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();
                    txtTotalDescuento.Text = "Trabajando";
                    txtTotalImpuesto.Text = DGV_Cotizacion_List[7, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();
                    txtTotalCotizacion.Text = DGV_Cotizacion_List[8, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();

                    enlCotizacionDetail.NoCotizacion = txtNoCotizacion.Text;
                    DGV_DetailCotizaciones.DataSource = bllCotizacionDetail.Search(enlCotizacionDetail);
                }
            }
            if (!string.IsNullOrEmpty(txtNoCotizacion.Text))
            {
                BotonEditar();
                txtNoCotizacion.Enabled = false;
                txtCliente.Focus();
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
                enlCotizacionMaster.Numero = txtNoCotizacion.Text;
                enlCotizacionMaster.Cliente = string.Empty;
                enlCotizacionMaster.Terminos = string.Empty;
                enlCotizacionMaster.Vendedor = string.Empty;
           


                var list = bllCotizacionMaster.Search(enlCotizacionMaster);

                enlCotizacionDetail.NoCotizacion = txtNoCotizacion.Text;
                DGV_DetailCotizaciones.DataSource = bllCotizacionDetail.Search(enlCotizacionDetail);

                //for (int a = 0; a <= DGV_DetailCotizaciones.RowCount - 1; a++)
                //{
                //    enlArticulos.Codigo = DGV_DetailFactura[0, a].Value.ToString();
                //    enlArticulos.Existencia = -Convert.ToDecimal(DGV_DetailFactura[3, a].Value);
                //    bllArticulos.UpdateExitencia(enlArticulos);
                //}
            }

            BotonCancelar();
            Estado = CONSULTA;
        }

        void btnEliminar_Click(object sender, EventArgs e)
        {

            enlCotizacionMaster.Numero = txtNoCotizacion.Text;
            enlCotizacionDetail.NoCotizacion = txtNoCotizacion.Text;

            bllCotizacionDetail.Delete(enlCotizacionDetail);
            bllCotizacionMaster.Delete(enlCotizacionMaster);

        }

        void btnBuscar_Click(object sender, EventArgs e)
        {
            //Frm_Buscar_CxC frmBuscarCxC = new Frm_Buscar_CxC();
            //frmBuscarCxC.Owner = this;
            //frmBuscarCxC.LlamadoDesde = "Frm_Cotizaciones";
            //frmBuscarCxC.ShowDialog();
        }

        private void Frm_Cotizaciones_Load(object sender, EventArgs e)
        {
            
            Estado = CONSULTA;
            tabControl1.TabPages.Remove(tbpMaster);

            enlCotizacionMaster.Numero = string.Empty;
            enlCotizacionMaster.Cliente = string.Empty;
            enlCotizacionMaster.Terminos = string.Empty;
            enlCotizacionMaster.Vendedor = string.Empty;
           

            DGV_Cotizacion_List.DataSource = bllCotizacionMaster.Search(enlCotizacionMaster);

        }

        void btnVista_Click(object sender, EventArgs e)
        {
            if (ActualizarDGV == true)
            {

                enlCotizacionMaster.Numero = string.Empty;
                enlCotizacionMaster.Cliente = string.Empty;
                enlCotizacionMaster.Terminos = string.Empty;
                enlCotizacionMaster.Vendedor = string.Empty;

                DGV_Cotizacion_List.DataSource = bllCotizacionMaster.Search(enlCotizacionMaster);

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

                if (DGV_Cotizacion_List.Rows.Count != 0)
                {

                    txtNoCotizacion.Text = DGV_Cotizacion_List[0, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();
                    txtCliente.Text = DGV_Cotizacion_List[1, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();
                    dtpFecha.Text = DGV_Cotizacion_List[2, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();
                    txtTerminos.Text = DGV_Cotizacion_List[3, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();
                    nudDescuento.Value = Convert.ToDecimal(DGV_Cotizacion_List[4, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString());
                    txtVendedor.Text = DGV_Cotizacion_List[5, DGV_Cotizacion_List.CurrentCell.RowIndex].Value.ToString();

                    enlCotizacionDetail.NoCotizacion = txtNoCotizacion.Text;
                    DGV_DetailCotizaciones.DataSource = bllCotizacionDetail.Search(enlCotizacionDetail);
                }
            }
           
        }

        private void DGV_Cotizacion_List_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVista_Click(btnVista, null);
        }

        private void LblBuscarTerminos_Click(object sender, EventArgs e)
        {
            Frm_Terminos frmTerminos = new Frm_Terminos();
            frmTerminos.Owner = this;
            frmTerminos.OcultarToolBar();
            frmTerminos.ShowDialog();
        }

        private void LblBuscarVendedor_Click(object sender, EventArgs e)
        {
            Frm_Empleados frmEmpleados = new Frm_Empleados();
            frmEmpleados.Owner = this;
            frmEmpleados.OcultarToolBar();
            frmEmpleados.ShowDialog();
        }

        private void LblBuscarCliente_Click(object sender, EventArgs e)
        {
            Frm_Clientes frmClientes = new Frm_Clientes();
            frmClientes.Owner = this;
            frmClientes.OcultarToolBar();
            frmClientes.ShowDialog();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (Estado != CONSULTA)
            {

                if (txtArticulo.Text != String.Empty && txtPrecio.Text != String.Empty && txtCantidad.Text != String.Empty)
                {

                    decimal precio, cantidad, totalLinea;
                    precio = Convert.ToDecimal(txtPrecio.Text);
                    cantidad = Convert.ToDecimal(txtCantidad.Text);
                    totalLinea = precio * cantidad;
                    //   costo = Convert.ToDecimal(txtCosto.Text);

                    if (Estado == "Editando")
                    {


                        list.Add(new Enl_CotizacionesDetail
                        {
                            Articulo = txtArticulo.Text,
                            Descripcion = txtDescripcion.Text,
                            Precio = Convert.ToDecimal(txtPrecio.Text),
                            Cantidad = Convert.ToDecimal(txtCantidad.Text),
                            TotalLinea = Convert.ToDecimal(txtPrecio.Text) * Convert.ToDecimal(txtCantidad.Text),
                            //   Costo = Convert.ToDecimal(txtCosto.Text)
                        });

                        list.Add(enlCotizacionDetail);



                        DGV_DetailCotizaciones.DataSource = null;
                        DGV_DetailCotizaciones.DataSource = list;

                    }
                    else
                    {
                        if (DGV_DetailCotizaciones.Rows.Count > 0)
                        {
                            int cantidadgridLinea;
                            decimal preciogridLinea;
                            decimal totalgridLinea;

                            foreach (DataGridViewRow row in DGV_DetailCotizaciones.Rows)
                            {
                                //Si el producto ya existe en el datagridview
                                if (row.Cells["ArticuloCotizacion"].Value.Equals(txtArticulo.Text))
                                {
                                    cantidadgridLinea = Convert.ToInt32(row.Cells["CantidadCotizacion"].Value);
                                    totalgridLinea = Convert.ToDecimal(row.Cells["TotalLineaCotizaciong"].Value);
                                    preciogridLinea = Convert.ToDecimal(row.Cells["PrecioCotizacion"].Value);

                                    //precio digitado
                                    row.Cells["PrecioCotizacion"].Value = txtPrecio.Text;
                                    //cantidad actual + digitada
                                    row.Cells["CantidadCotizacion"].Value = (cantidadgridLinea + Convert.ToInt32(txtCantidad.Text));
                                    //precio * cantiad
                                    row.Cells["TotalLineaCotizaciong"].Value = (int)row.Cells["CantidadCotizacion"].Value * Convert.ToDecimal(row.Cells["PrecioCotizacion"].Value);

                                }
                            }
                        }
                        else
                        {
                            DGV_DetailCotizaciones.Rows.Insert(0, txtArticulo.Text, txtDescripcion.Text, precio, cantidad, 0, totalLinea);
                        }

                    }

                    //actualizar valores grid.
                    ActualizarGrid();

                    #region "codigo comentado"
                    /*TotalImpuestoCotizacion = 0;
                foreach (DataGridViewRow row in DGV_DetailCotizaciones.Rows)
                {
                    TotalLineaCotizacion += Convert.ToDecimal(row.Cells["TotalLineaCotizaciong"].Value);
                    TotalImpuestoCotizacion += Convert.ToDecimal(row.Cells["ImpuestoCotizacion"].Value);
                }
                
                Porcentaje = nudDescuento.Value / 100;
                SubTotalCotizacion = TotalLineaCotizacion - TotalImpuestoCotizacion;
                TotalDescuentoCotizacion = SubTotalCotizacion * Porcentaje;
                TotalCotizacion = SubTotalCotizacion + TotalImpuestoCotizacion - TotalDescuentoCotizacion;*/
                    #endregion


                    //limpiar Textbox
                    txtArticulo.Text = String.Empty;
                    txtDescripcion.Text = String.Empty;
                    txtPrecio.Text = String.Empty;
                    txtCantidad.Text = String.Empty;

                    txtArticulo.Focus();
                }
            }
        }

        private void ActualizarGrid ()
        {
            //Calculamos los valores en el grid y devolvemos los totales
            ArrayList valores = new ArrayList(Helper.CalcularGrid(DGV_DetailCotizaciones, nudDescuento.Value / 100));

            txtSubTotal.Text = Helper.ConvertirANumero(valores[0].ToString()).ToString("C2");//Convert.ToString(SubTotalCotizacion.ToString());
            txtTotalImpuesto.Text = Helper.ConvertirANumero(valores[1].ToString()).ToString("C2");// Convert.ToString(TotalImpuestoCotizacion.ToString());
            txtTotalDescuento.Text = Helper.ConvertirANumero(valores[2].ToString()).ToString("C2");//Convert.ToString(TotalDescuentoCotizacion.ToString());
            txtTotalCotizacion.Text = Helper.ConvertirANumero(valores[3].ToString()).ToString("C2");//Convert.ToString(TotalCotizacion.ToString());
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
                    txtPrecio.Text = list[0].Precio.ToString("C2").Replace("RD$", "");
                    txtCantidad.Text = "1";
                   // txtCosto.Text = Convert.ToString(list[0].Costo);

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Articulo no Existe");
            }  
            
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (DGV_DetailCotizaciones.RowCount != 0)
            {


                if (Estado == "Editando")
                {
                    list.RemoveAt(DGV_DetailCotizaciones.CurrentRow.Index);

                    DGV_DetailCotizaciones.DataSource = null;
                    DGV_DetailCotizaciones.DataSource = list;

                }
                else
                {

                    DGV_DetailCotizaciones.Rows.RemoveAt(DGV_DetailCotizaciones.CurrentRow.Index);

                }
                decimal sumatoria = 0;

                foreach (DataGridViewRow row in DGV_DetailCotizaciones.Rows)
                {
                    sumatoria += Convert.ToDecimal(row.Cells["TotalLineaCotizaciong"].Value);
                }
                txtSubTotal.Text = Convert.ToString(sumatoria.ToString("C2"));

            }
        }

        private void DGV_DetailCotizaciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal precioGrid, impuestoGrid, cantidadGrid, TotalLineaGrid;

            precioGrid = Convert.ToDecimal(DGV_DetailCotizaciones[2, DGV_DetailCotizaciones.CurrentCell.RowIndex].Value.ToString());
            cantidadGrid = Convert.ToDecimal(DGV_DetailCotizaciones[3, DGV_DetailCotizaciones.CurrentCell.RowIndex].Value.ToString());
            impuestoGrid = Convert.ToDecimal(DGV_DetailCotizaciones[4, DGV_DetailCotizaciones.CurrentCell.RowIndex].Value.ToString());
            TotalLineaGrid = precioGrid * cantidadGrid + impuestoGrid;
            DGV_DetailCotizaciones[5, DGV_DetailCotizaciones.CurrentCell.RowIndex].Value = TotalLineaGrid;

            #region "Codigo Comentado"
            /*
            TotalLineaCotizacion = 0;
            TotalImpuestoCotizacion = 0;
            foreach (DataGridViewRow row in DGV_DetailCotizaciones.Rows)
            {
                TotalLineaCotizacion += Convert.ToDecimal(row.Cells["TotalLineaCotizaciong"].Value);
                TotalImpuestoCotizacion += Convert.ToDecimal(row.Cells["ImpuestoCotizacion"].Value);
            }

            Porcentaje = nudDescuento.Value / 100;
            SubTotalCotizacion = TotalLineaCotizacion - TotalImpuestoCotizacion;
            TotalDescuentoCotizacion = SubTotalCotizacion * Porcentaje;
            TotalCotizacion = SubTotalCotizacion + TotalImpuestoCotizacion - TotalDescuentoCotizacion;

            txtSubTotal.Text = Convert.ToString(SubTotalCotizacion.ToString());
            txtTotalImpuesto.Text = Convert.ToString(TotalImpuestoCotizacion.ToString());
            txtTotalDescuento.Text = Convert.ToString(TotalDescuentoCotizacion.ToString());
            txtTotalCotizacion.Text = Convert.ToString(TotalCotizacion.ToString());
             
             */
            #endregion

            //Calculamos los valores en el grid y devolvemos los totales
            ArrayList valores = new ArrayList(Helper.CalcularGrid(DGV_DetailCotizaciones, nudDescuento.Value / 100));

            txtSubTotal.Text = Helper.ConvertirANumero(valores[0].ToString()).ToString("C2");//Convert.ToString(SubTotalCotizacion.ToString());
            txtTotalImpuesto.Text = Helper.ConvertirANumero(valores[1].ToString()).ToString("C2");// Convert.ToString(TotalImpuestoCotizacion.ToString());
            txtTotalDescuento.Text = Helper.ConvertirANumero(valores[2].ToString()).ToString("C2");//Convert.ToString(TotalDescuentoCotizacion.ToString());
            txtTotalCotizacion.Text = Helper.ConvertirANumero(valores[3].ToString()).ToString("C2");//Convert.ToString(TotalCotizacion.ToString());



        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                    e.Handled = false;
                    else if (e.KeyChar == '.')//permitir el punto (0)
                     e.Handled = false;

                else
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
            }
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Para obligar a que sólo se introduzcan números 
            if (Char.IsDigit(e.KeyChar))
                e.Handled = false;
            else
            {
                if (Char.IsControl(e.KeyChar)) //permitir teclas de control como retroceso 
                    e.Handled = false;
                else
                    //el resto de teclas pulsadas se desactivan 
                    e.Handled = true;
            }
        }


        private void nudDescuento_Validating(object sender, CancelEventArgs e)
        {
                ActualizarGrid();
        }

        private void txtPrecio_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtPrecio.Text))
            {
                string precio = Convert.ToDecimal(txtPrecio.Text).ToString("C2").Replace("RD$", "");
                txtPrecio.Text = precio;
            }
        }
    }
}
