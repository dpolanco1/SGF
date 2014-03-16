using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aPrestentationLayer.Plantillas;
using aPrestentationLayer.Inventario;
using EntityLayer.CxP_Compras;
using BusinessLogicLayer.CxP_Compras;
using BusinessLogicLayer.Administracion;
using EntityLayer.Inventario;
using BusinessLogicLayer.Inventario;
using BusinessLogicLayer.Otros;

namespace aPrestentationLayer.CxP_Compras
{

    public partial class Frm_Compras : Frm_Plantilla, Icompras
    {

        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

        /*const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/

        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles();

        Enl_ComprasMaster enlCompraMaster = new Enl_ComprasMaster();
        Bll_ComprasMaster bllCompraMaster = new Bll_ComprasMaster();

        Enl_ComprasDetail enlCompraDetail = new Enl_ComprasDetail();
        Bll_ComprasDetail bllCompraDetail = new Bll_ComprasDetail();

        Enl_Articulos enlArticulos = new Enl_Articulos();
        Bll_Articulos bllArticulos = new Bll_Articulos();

        Bll_Numeracion bllNumeracion = new Bll_Numeracion();

        IList<Enl_ComprasDetail> list;

        decimal TotalLineaCompra,linea, cantidad, costo,
                impuesto, TotalImpuestoCompra, SubTotalCompra,
                Porcentaje, TotalDescuentoCompra, TotalCompraCompra;

        public Frm_Compras()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnVista.Click += btnVista_Click;
            DGV_DetailCompra.AutoGenerateColumns = false;
            DGV_Compras_List.AutoGenerateColumns = false;
          

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

            if (DGV_DetailCompra.Rows.Count > 0)
            {
                AC.VaciarDGV(this);
            }

            if (bllNumeracion.ObtenerTipo("Compras") == "Automatico")
            {
                txtNoCompra.ReadOnly = true;
                txtSuplidor.Focus();
            }
            else
            {
                txtNoCompra.ReadOnly = false;
                txtNoCompra.Focus();
            }

            txtSubTotal.Enabled = false;
            txtTotalImpuesto.Enabled = false;
            txtTotalDescuento.Enabled = false;
            txtTotalCompra.Enabled = false;

        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            enlCompraMaster.Numero = txtNoCompra.Text;
            enlCompraMaster.Suplidor = txtSuplidor.Text;
            enlCompraMaster.Fecha = dtpFecha.Value; ;
            enlCompraMaster.Almacen = txtAlmacen.Text;
            enlCompraMaster.Descuento = nudDescuento.Value;


            //TotalLineaCompra = 0;
            //TotalImpuestoCompra = 0;
            //foreach (DataGridViewRow row in DGV_DetailCompra.Rows)
            //{
            //    TotalLineaCompra += Convert.ToDecimal(row.Cells["TotalLinea"].Value);
            //    TotalImpuestoCompra += Convert.ToDecimal(row.Cells["Impuesto"].Value);
            //}
            //Porcentaje = nudDescuento.Value / 100;
            //SubTotalCompra = TotalLineaCompra - TotalImpuestoCompra;
            //TotalDescuentoCompra = SubTotalCompra * Porcentaje;
            //TotalCompraCompra = SubTotalCompra + TotalImpuestoCompra - TotalDescuentoCompra;



            enlCompraMaster.SubTotal = SubTotalCompra;
            enlCompraMaster.TotalImpuesto = TotalImpuestoCompra;
            enlCompraMaster.TotalDescuento = TotalDescuentoCompra;
            enlCompraMaster.TotalCompra = TotalCompraCompra;

            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtNoCompra.Text = bllCompraMaster.Insert(enlCompraMaster);

                //hago la insercion en los DGV
                for (int a = 0; a < DGV_DetailCompra.RowCount - 1; a++)
                {
                    enlCompraDetail.NoCompra = txtNoCompra.Text;//No Factura
                    enlCompraDetail.Articulo = DGV_DetailCompra[0, a].Value.ToString();
                    enlCompraDetail.Descripcion = DGV_DetailCompra[1, a].Value.ToString();
                    enlCompraDetail.Precio = Convert.ToDecimal(DGV_DetailCompra[2, a].Value);
                    enlCompraDetail.Cantidad = Convert.ToDecimal(DGV_DetailCompra[3, a].Value);
                    enlCompraDetail.Impuesto = Convert.ToDecimal(DGV_DetailCompra[4, a].Value);
                    enlCompraDetail.TotalLinea = Convert.ToDecimal(DGV_DetailCompra[5, a].Value);

                    bllCompraDetail.Insert(enlCompraDetail);

                    //Actualizar Inventario
                    enlArticulos.Codigo = enlCompraDetail.Articulo;
                    enlArticulos.Existencia = enlCompraDetail.Cantidad;
                    bllArticulos.UpdateExitencia(enlArticulos);
                }

                if (bllNumeracion.ObtenerTipo("Compras") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Compras"), "Compras");
                }


               


                MessageBox.Show("Registro Guardado Correctamente", "SGF");

            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllCompraMaster.Update(enlCompraMaster);

                    //Eliminados El Detalle de la Factura
                    enlCompraDetail.NoCompra = txtNoCompra.Text;
                    bllCompraDetail.Delete(enlCompraDetail);

                    //Insertamos el Detalle de la Factura

                    for (int a = 0; a < DGV_DetailCompra.RowCount - 1; a++)
                    {
                        enlCompraDetail.NoCompra = txtNoCompra.Text;//No Factura
                        enlCompraDetail.Articulo = DGV_DetailCompra[0, a].Value.ToString();
                        enlCompraDetail.Descripcion = DGV_DetailCompra[1, a].Value.ToString();
                        enlCompraDetail.Precio = Convert.ToDecimal(DGV_DetailCompra[2, a].Value);
                        enlCompraDetail.Cantidad = Convert.ToDecimal(DGV_DetailCompra[3, a].Value);
                        enlCompraDetail.Impuesto = Convert.ToDecimal(DGV_DetailCompra[4, a].Value);
                        enlCompraDetail.TotalLinea = Convert.ToDecimal(DGV_DetailCompra[5, a].Value);

                        bllCompraDetail.Insert(enlCompraDetail);

                        //Actualizar Inventario
                        enlArticulos.Codigo = enlCompraDetail.Articulo;
                        enlArticulos.Existencia = enlCompraDetail.Cantidad;
                        bllArticulos.UpdateExitencia(enlArticulos);
                    }


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

                if (DGV_Compras_List.Rows.Count != 0)
                {

                    txtNoCompra.Text = DGV_Compras_List[0, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    txtSuplidor.Text = DGV_Compras_List[1, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    dtpFecha.Text = DGV_Compras_List[2, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    txtAlmacen.Text = DGV_Compras_List[3, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    nudDescuento.Value = Convert.ToDecimal(DGV_Compras_List[4, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString());
                    txtSubTotal.Text = DGV_Compras_List[5, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    txtTotalImpuesto.Text = DGV_Compras_List[6, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    txtTotalDescuento.Text = DGV_Compras_List[7, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    txtTotalCompra.Text = DGV_Compras_List[8, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();

                    enlCompraDetail.NoCompra = txtNoCompra.Text;

                    list = bllCompraDetail.Search(enlCompraDetail);

                    DGV_DetailCompra.DataSource = list;
                }
            }

            if (!string.IsNullOrEmpty(txtNoCompra.Text))
            {

                BotonEditar();
                Estado = Helper.EstadoSystema.Editando;
                txtNombre.Focus();
                txtNoCompra.Enabled = false;

            }

            txtSubTotal.Enabled = false;
            txtTotalImpuesto.Enabled = false;
            txtTotalDescuento.Enabled = false;
            txtTotalCompra.Enabled = false;
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
                enlCompraMaster.Numero = txtNoCompra.Text;
                enlCompraMaster.Suplidor = string.Empty;
                enlCompraMaster.Almacen = string.Empty;

                var list = bllCompraMaster.Search(enlCompraMaster);

                txtSuplidor.Text = list[0].Suplidor;
                dtpFecha.Value = list[0].Fecha;
                txtAlmacen.Text = list[0].Almacen;
                nudDescuento.Value = list[0].Descuento;

                txtSubTotal.Text = Convert.ToString( list[0].SubTotal);
                txtTotalImpuesto.Text = Convert.ToString( list[0].TotalImpuesto);
                txtTotalDescuento.Text = Convert.ToString(  list[0].TotalDescuento);
                txtTotalCompra.Text = Convert.ToString( list[0].TotalCompra);


                enlCompraDetail.NoCompra = txtNoCompra.Text;
                DGV_DetailCompra.DataSource = bllCompraDetail.Search(enlCompraDetail);

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

                if (DGV_Compras_List.Rows.Count != 0)
                {
                    txtNoCompra.Text = DGV_Compras_List[0, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    txtSuplidor.Text = DGV_Compras_List[1, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    dtpFecha.Text = DGV_Compras_List[2, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    txtAlmacen.Text = DGV_Compras_List[3, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    nudDescuento.Value = Convert.ToDecimal(DGV_Compras_List[4, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString());
                    txtSubTotal.Text = DGV_Compras_List[5, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    txtTotalImpuesto.Text = DGV_Compras_List[6, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    txtTotalDescuento.Text = DGV_Compras_List[7, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                    txtTotalCompra.Text = DGV_Compras_List[8, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                }
            }

            enlCompraDetail.NoCompra = txtNoCompra.Text;
            enlCompraMaster.Numero = txtNoCompra.Text;

             //Eliminamos el Detalle y luego el Master
            
            if (bllCompraDetail.Delete(enlCompraDetail))
            {
                bllCompraMaster.Delete(enlCompraMaster);
                BotonEliminar();
                ActualizarDGV = true;
            }
        }

        void btnVista_Click(object sender, EventArgs e)
        {

            if (ActualizarDGV == true)
            {

                enlCompraMaster.Numero = txtNoCompra.Text;
                enlCompraMaster.Suplidor = string.Empty;
                enlCompraMaster.Almacen = string.Empty;

                DGV_Compras_List.DataSource = bllCompraMaster.Search(enlCompraMaster);
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

                    if (DGV_Compras_List.Rows.Count != 0)
                    {

                        txtNoCompra.Text = DGV_Compras_List[0, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                        txtSuplidor.Text = DGV_Compras_List[1, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                        dtpFecha.Text = DGV_Compras_List[2, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                        txtAlmacen.Text = DGV_Compras_List[3, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                        nudDescuento.Value = Convert.ToDecimal(DGV_Compras_List[4, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString());
                        txtSubTotal.Text = DGV_Compras_List[5, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                        txtTotalImpuesto.Text = DGV_Compras_List[6, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                        txtTotalDescuento.Text = DGV_Compras_List[7, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();
                        txtTotalCompra.Text = DGV_Compras_List[8, DGV_Compras_List.CurrentCell.RowIndex].Value.ToString();

                        enlCompraDetail.NoCompra = txtNoCompra.Text;
                        DGV_DetailCompra.DataSource = bllCompraDetail.Search(enlCompraDetail);
                    }
                }
            }
 
        }

        private void Frm_Compras_Load(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);
            enlCompraMaster.Numero = txtNoCompra.Text;

            enlCompraMaster.Suplidor = string.Empty;
            enlCompraMaster.Almacen = string.Empty;

            DGV_Compras_List.DataSource = bllCompraMaster.Search(enlCompraMaster);
        }

        private void DGV_Compras_List_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVista_Click(btnVista, null);
        }

        private void txtArticulo_Validating(object sender, CancelEventArgs e)
        {
            enlArticulos.Codigo = txtArticulo.Text;
            enlArticulos.Nombre = string.Empty;
            enlArticulos.Descripcion = string.Empty;
            enlArticulos.Impuesto = string.Empty;
            enlArticulos.Marca = string.Empty;
            enlArticulos.Categoria = string.Empty;
            enlArticulos.SubCategoria = string.Empty;

            EntityLayer.Inventario.Enl_Articulos enlArticulos2 = new EntityLayer.Inventario.Enl_Articulos();

            enlArticulos2.Codigo = txtArticulo.Text;
            enlArticulos2.CodigoBarra = txtArticulo.Text;

            if (!String.IsNullOrEmpty(txtArticulo.Text))
            {
                //MessageBox.Show  (Convert.ToString( bllArticulos.Search(enlArticulos).Count));

                var list = bllArticulos.Search(enlArticulos);

                if (bllArticulos.IsExiste(enlArticulos2) == "True")
                {
                    txtArticulo.Text = list[0].Codigo;
                    txtDescripcion.Text = list[0].Descripcion;
                    txtCosto.Text = Convert.ToString(list[0].Costo);
                    txtCantidad.Text = "1";
                }
                else
                {
                    MessageBox.Show("Este Articulo No Existe");
                    txtArticulo.Focus();
                
                }
                

            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
                e.Handled = true; 
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
                e.Handled = true; 
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (txtArticulo.Text != String.Empty && txtCosto.Text != String.Empty && txtCantidad.Text != String.Empty)
            {

                //decimal costo, cantidad, totalLinea,impuesto,TotalLinea = 0,TotalImpuesto = 0;
                costo = Convert.ToDecimal(txtCosto.Text);
                cantidad = Convert.ToDecimal(txtCantidad.Text);
                impuesto = 0;
                linea = costo * cantidad + impuesto;

                if (Estado == Helper.EstadoSystema.Editando)
                {


                    list.Add(new Enl_ComprasDetail
                    {
                        Articulo = txtArticulo.Text,
                        Descripcion = txtDescripcion.Text,
                        Precio = Convert.ToDecimal(txtCosto.Text),
                        Cantidad = Convert.ToDecimal(txtCantidad.Text),
                        TotalLinea = Convert.ToDecimal(txtCosto.Text) * Convert.ToDecimal(txtCantidad.Text)
                    });

                    list.Add(enlCompraDetail);

                    DGV_DetailCompra.DataSource = null;
                    DGV_DetailCompra.DataSource = list;

                }
                else
                {
                    DGV_DetailCompra.Rows.Insert(0, txtArticulo.Text, txtDescripcion.Text, costo, cantidad, 0, linea);
                }
                ////Método con el que recorreremos todas las filas de nuestro Datagridview

                TotalLineaCompra = 0;
                TotalImpuestoCompra = 0;
                foreach (DataGridViewRow row in DGV_DetailCompra.Rows)
                {
                    TotalLineaCompra += Convert.ToDecimal(row.Cells["TotalLinea"].Value);
                    TotalImpuestoCompra += Convert.ToDecimal(row.Cells["Impuesto"].Value);
                }
                Porcentaje = nudDescuento.Value / 100;
                SubTotalCompra = TotalLineaCompra - TotalImpuestoCompra;
                TotalDescuentoCompra = SubTotalCompra * Porcentaje;
                TotalCompraCompra = SubTotalCompra + TotalImpuestoCompra - TotalDescuentoCompra;

                txtSubTotal.Text = Convert.ToString(SubTotalCompra.ToString("C"));
                txtTotalImpuesto.Text = Convert.ToString(TotalImpuestoCompra.ToString("C"));
                txtTotalDescuento.Text = Convert.ToString(TotalDescuentoCompra.ToString("C"));
                txtTotalCompra.Text = Convert.ToString(TotalCompraCompra.ToString("C"));
               
    
                txtArticulo.Text = String.Empty;
                txtDescripcion.Text = String.Empty;
                txtCosto.Text = String.Empty;
                txtCantidad.Text = String.Empty;

                txtArticulo.Focus();
            }
        }

        private void DGV_DetailCompra_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 2 || ((int)(((System.Windows.Forms.DataGridView)(sender)).CurrentCell.ColumnIndex) == 3))
            {
                e.Control.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            }
        }

        private void DGV_DetailCompra_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            decimal precioGrid, impuestoGrid, cantidadGrid, TotalLineaGrid;

            precioGrid = Convert.ToDecimal(DGV_DetailCompra[2, DGV_DetailCompra.CurrentCell.RowIndex].Value.ToString());
            cantidadGrid = Convert.ToDecimal(DGV_DetailCompra[3, DGV_DetailCompra.CurrentCell.RowIndex].Value.ToString());
            impuestoGrid = Convert.ToDecimal(DGV_DetailCompra[4, DGV_DetailCompra.CurrentCell.RowIndex].Value.ToString());
            TotalLineaGrid = precioGrid * cantidadGrid + impuestoGrid;
            DGV_DetailCompra[5, DGV_DetailCompra.CurrentCell.RowIndex].Value = TotalLineaGrid;

            TotalLineaCompra = 0;
            TotalImpuestoCompra = 0;
            foreach (DataGridViewRow row in DGV_DetailCompra.Rows)
            {
                TotalLineaCompra += Convert.ToDecimal(row.Cells["TotalLinea"].Value);
                TotalImpuestoCompra += Convert.ToDecimal(row.Cells["Impuesto"].Value);
            }

            Porcentaje = nudDescuento.Value / 100;
            SubTotalCompra = TotalLineaCompra - TotalImpuestoCompra;
            TotalDescuentoCompra = SubTotalCompra * Porcentaje;
            TotalCompraCompra = SubTotalCompra + TotalImpuestoCompra - TotalDescuentoCompra;

            txtSubTotal.Text = Convert.ToString(SubTotalCompra.ToString("C"));
            txtTotalImpuesto.Text = Convert.ToString(TotalImpuestoCompra.ToString("C"));
            txtTotalDescuento.Text = Convert.ToString(TotalDescuentoCompra.ToString("C"));
            txtTotalCompra.Text = Convert.ToString(TotalCompraCompra.ToString("C"));


        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            if (DGV_DetailCompra.RowCount != 0)
            {

                if (Estado == Helper.EstadoSystema.Editando)
                {
                    list.RemoveAt(DGV_DetailCompra.CurrentRow.Index);

                    DGV_DetailCompra.DataSource = null;
                    DGV_DetailCompra.DataSource = list;

                }
                else
                {

                    DGV_DetailCompra.Rows.RemoveAt(DGV_DetailCompra.CurrentRow.Index);

                }
                decimal sumatoria = 0;

                foreach (DataGridViewRow row in DGV_DetailCompra.Rows)
                {
                    sumatoria += Convert.ToDecimal(row.Cells["TotalLinea"].Value);
                }
                txtSubTotal.Text = Convert.ToString(sumatoria.ToString("C"));

            }
        }

        private void nudDescuento_Validating(object sender, CancelEventArgs e)
        {
          
            TotalLineaCompra = 0;
            TotalImpuestoCompra = 0;
            foreach (DataGridViewRow row in DGV_DetailCompra.Rows)
            {
                TotalLineaCompra += Convert.ToDecimal(row.Cells["TotalLinea"].Value);
                TotalImpuestoCompra += Convert.ToDecimal(row.Cells["Impuesto"].Value);
            }

            Porcentaje = nudDescuento.Value / 100;
            SubTotalCompra = TotalLineaCompra - TotalImpuestoCompra;
            TotalDescuentoCompra = SubTotalCompra * Porcentaje;
            TotalCompraCompra = SubTotalCompra + TotalImpuestoCompra - TotalDescuentoCompra;

            txtSubTotal.Text = Convert.ToString(SubTotalCompra.ToString("C"));
            txtTotalImpuesto.Text = Convert.ToString(TotalImpuestoCompra.ToString("C"));
            txtTotalDescuento.Text = Convert.ToString(TotalDescuentoCompra.ToString("C"));
            txtTotalCompra.Text = Convert.ToString(TotalCompraCompra.ToString("C"));

        }
      
        public void CargarSuplidor(string Suplidor, string Nombre)
        {
            txtSuplidor.Text = Suplidor;
            txtNombre.Text = Nombre;
        }

        public void CargarAlmacen(string Almacen)
        {
            txtAlmacen.Text = Almacen;
        
        }

        private void LblBuscarSuplidor_Click(object sender, EventArgs e)
        {
            Frm_Suplidores frmCategoria = new Frm_Suplidores();
            frmCategoria.Owner = this;
            frmCategoria.OcultarToolBar();
            frmCategoria.ShowDialog();
        }

        private void LblBuscarAlmacen_Click(object sender, EventArgs e)
        {
            Frm_Almacen frmCategoria = new Frm_Almacen();
            frmCategoria.Owner = this;
            frmCategoria.OcultarToolBar();
            frmCategoria.ShowDialog();
        }
    
    }

}
