using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aPrestentationLayer.CxC_Ventas;
using aPrestentationLayer.CxC_Ventas.Reportes.General;
using aPrestentationLayer.CxC_Ventas.Reportes;
using aPrestentationLayer.CxC_Ventas.Reportes.Formatos;
using aPrestentationLayer.CxP_Compras;
using aPrestentationLayer.Inventario;
using aPrestentationLayer.Administracion;
using ReportLayer.Administracion.Listados;
using ReportLayer.Inventario.Listados;
using aPrestentationLayer.Comunes;


namespace aPrestentationLayer.Administracion
{
    public partial class Frm_Principal : Form
    {
        public Frm_Principal()
        {
            InitializeComponent();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {

            treeView1.Nodes.Clear();
            TreeNode node = treeView1.Nodes.Add("Modulo de Ventas");
            node = treeView1.Nodes.Add("Maestras");
            node.Nodes.Add("Categoria de Clientes");
            node.Nodes.Add("SubCategoria de Clientes");
            node.Nodes.Add("Terminos");
            node.Nodes.Add("Cajas");
            node.Nodes.Add("Clientes");
            node = treeView1.Nodes.Add("Transacciones");
            node.Nodes.Add("Cotizaciones");
            node.Nodes.Add("Facturacion");
            //node.Nodes.Add("Recibos");
            //node.Nodes.Add("Notas de Creditos CxC");
            //node.Nodes.Add("Notas de Debito CxC");

   
            treeView1.ExpandAll();
          
            lblModulo.Text = "Modulo de Ventas";

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            treeView1.Refresh();

            if (e.Action == TreeViewAction.ByMouse)
            {

                #region ModuloVentas
                //Inicio Modulo de Ventas
                if (e.Node.Text == "Categoria de Clientes")
                {
                    Frm_CategoriaClientes frmCategoriaClientes = new Frm_CategoriaClientes();
                    frmCategoriaClientes.MdiParent = this;
                    frmCategoriaClientes.Show();
                }

                if (e.Node.Text == "SubCategoria de Clientes")
                {
                    Frm_SubCategoriaClientes frmSubCategoriaClientes = new Frm_SubCategoriaClientes();
                    frmSubCategoriaClientes.MdiParent = this;
                    frmSubCategoriaClientes.Show();
                }

                if (e.Node.Text == "Clientes")
                {
                    Frm_Clientes frmClientes = new Frm_Clientes ();
                    frmClientes.MdiParent = this;
                    frmClientes.Show();
                }

                if (e.Node.Text == "Cotizaciones")
                {
                    Frm_Cotizaciones frmCotizaciones = new Frm_Cotizaciones();
                    frmCotizaciones.MdiParent = this;
                    frmCotizaciones.Show();
                }

                if (e.Node.Text == "Facturacion")
                {
                    Frm_Facturas frmFacturas = new Frm_Facturas();
                    frmFacturas.MdiParent = this;
                    frmFacturas.Show();
                }

                if (e.Node.Text == "Recibos")
                {
                    Frm_Recibos frmRecibos = new Frm_Recibos();
                    frmRecibos.MdiParent = this;
                    frmRecibos.Show();
                }


                if (e.Node.Text == "Notas de Creditos CxC")
                {
                    Frm_NotasCreditos frmNotasCreditosCxC = new Frm_NotasCreditos();
                    frmNotasCreditosCxC.MdiParent = this;
                    frmNotasCreditosCxC.Show();
                }

                if (e.Node.Text == "Notas de Debito CxC")
                {
                    Frm_NotasDebitos frmNotasDebitosCxC = new Frm_NotasDebitos();
                    frmNotasDebitosCxC.MdiParent = this;
                    frmNotasDebitosCxC.Show();
                }

                if (e.Node.Text == "Terminos")
                {
                    Frm_Terminos frmTerminos = new Frm_Terminos();
                    frmTerminos.MdiParent = this;
                    frmTerminos.Show();
                }

                if (e.Node.Text == "Cajas")
                {
                    Frm_Cajas frmCajas = new Frm_Cajas();
                    frmCajas.MdiParent = this;
                    frmCajas.Show();
                }

            
                //Fin Modulo de Ventas

                #endregion ModuloVentas
                
                #region ModuloCompras
                //Inicio Modulo de Compras
                if (e.Node.Text == "Categoria de Suplidores")
                {
                    Frm_CategoriaSuplidores frmCategoriaSuplidor = new Frm_CategoriaSuplidores();
                    frmCategoriaSuplidor.MdiParent = this;
                    frmCategoriaSuplidor.Show();
                }


                if (e.Node.Text == "SubCategoria de Suplidores")
                {
                    Frm_SubCategoriaSuplidores frmSubCateSupli = new Frm_SubCategoriaSuplidores();
                    frmSubCateSupli.MdiParent = this;
                    frmSubCateSupli.Show();
                }


                if (e.Node.Text == "Suplidores")
                {
                    Frm_Suplidores frmSuplidores = new Frm_Suplidores();
                    frmSuplidores.MdiParent = this;
                    frmSuplidores.Show();
                }


                if (e.Node.Text == "Ordenes de Compras")
                {
                    Frm_OrdenesCompras frmOrdenesCompras = new Frm_OrdenesCompras();
                    frmOrdenesCompras.MdiParent = this;
                    frmOrdenesCompras.Show();
                }


                if (e.Node.Text == "Compras")
                {
                    Frm_Compras frmCompras = new Frm_Compras();
                    frmCompras.MdiParent = this;
                    frmCompras.Show();
                }


                if (e.Node.Text == "Notas de Creditos CxP")
                {
                    Frm_NotasCreditosCxP frmNotasCreditosCxP = new Frm_NotasCreditosCxP();
                    frmNotasCreditosCxP.MdiParent = this;
                    frmNotasCreditosCxP.Show();
                }



                if (e.Node.Text == "Notas de Debitos CxP")
                {
                    Frm_NotasDebitosCxP frmNotasDebitosCxP = new Frm_NotasDebitosCxP();
                    frmNotasDebitosCxP.MdiParent = this;
                    frmNotasDebitosCxP.Show();
                }


                #endregion 

                #region ModuloInventario
                if (e.Node.Text == "Categoria de Articulos")
                {
                    Frm_CategoriaArticulos frmCategoriaArticulos = new Frm_CategoriaArticulos();
                    frmCategoriaArticulos.MdiParent = this;
                    frmCategoriaArticulos.Show();
                }

                if (e.Node.Text == "SubCategoria de Articulos")
                {
                    Frm_SubCategoriaArticulos frmSubCateArtic = new Frm_SubCategoriaArticulos();
                    frmSubCateArtic.MdiParent = this;
                    frmSubCateArtic.Show();
                }


                if (e.Node.Text == "Almacen")
                {
                    Frm_Almacen frmAlmacen = new Frm_Almacen();
                    frmAlmacen.MdiParent = this;
                    frmAlmacen.Show();
                }

                if (e.Node.Text == "Marcas")
                {
                    Frm_Marcas frmMarcas = new Frm_Marcas();
                    frmMarcas.MdiParent = this;
                    frmMarcas.Show();
                }

                if (e.Node.Text == "Articulos")
                {
                    Frm_Articulos frmArticulos = new Frm_Articulos();
                    frmArticulos.MdiParent = this;
                    frmArticulos.Show();
                }

                if (e.Node.Text == "Tranferencia de Almacenes")
                {
                    Frm_TransferenciaAlmacenes frmTransfAlmacenes = new Frm_TransferenciaAlmacenes();
                    frmTransfAlmacenes.MdiParent = this;
                    frmTransfAlmacenes.Show();
                }


#endregion

                #region ModuloAdministracion
                if (e.Node.Text == "Datos de Compania")
                {
                    Frm_Compania frmCompania = new Frm_Compania();
                    frmCompania.MdiParent = this;
                    frmCompania.Show();
                }

                if (e.Node.Text == "Empleados")
                {
                    Frm_Empleados frmEmpleados = new Frm_Empleados ();
                    frmEmpleados.MdiParent = this;
                    frmEmpleados.Show();
                }


                if (e.Node.Text == "Usuarios")
                {
                    Frm_Usuarios frmUsuarios = new Frm_Usuarios();
                    frmUsuarios.MdiParent = this;
                    frmUsuarios.Show();
                }


                if (e.Node.Text == "Impuestos")
                {
                    Frm_Impuestos  frmImpuestos = new Frm_Impuestos();
                    frmImpuestos.MdiParent = this;
                    frmImpuestos.Show();
                }

                if (e.Node.Text == "Modo de Pago")
                {
                    Frm_MododePago frmModoPago = new Frm_MododePago();
                    frmModoPago.MdiParent = this;
                    frmModoPago.Show();
                }

                if (e.Node.Text == "Numeracion")
                {
                    Frm_Numeracion frmNumeracion = new Frm_Numeracion();
                    frmNumeracion.MdiParent = this;
                    frmNumeracion.Show();
                }


                if (e.Node.Text == "Gastos")
                {
                    Frm_Gastos frmGastos = new Frm_Gastos();
                    frmGastos.MdiParent = this;
                    frmGastos.Show();
                }
                #endregion

            }
            treeView1.Refresh();

        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();

            TreeNode node = treeView1.Nodes.Add("Modulo de Inventario");
            node = treeView1.Nodes.Add("Maestras");
            node.Nodes.Add("Categoria de Articulos");
            node.Nodes.Add("SubCategoria de Articulos") ;
            node.Nodes.Add("Almacen");
            node.Nodes.Add("Marcas");
            node.Nodes.Add("Articulos");
            //node = treeView1.Nodes.Add("Transacciones");
            //node.Nodes.Add("Transferencia de Almacenes");

            treeView1.ExpandAll();

            lblModulo.Text = "Modulo de Inventario";
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {

            treeView1.Nodes.Clear();

            TreeNode node = treeView1.Nodes.Add("Modulo de Compras");
            node = treeView1.Nodes.Add("Maestras");
            node.Nodes.Add("Categoria de Suplidores");
            node.Nodes.Add("SubCategoria de Suplidores");
            node.Nodes.Add("Suplidores");
            node = treeView1.Nodes.Add("Transacciones");
            //node.Nodes.Add("Ordenes de Compras");
            node.Nodes.Add("Compras");
            //node.Nodes.Add("Notas de Creditos CxP");
            //node.Nodes.Add("Notas de Debitos CxP");

            treeView1.ExpandAll();

            lblModulo.Text = "Modulo de Compras";
        }

        private void btnAdministracion_Click(object sender, EventArgs e)
        {

            treeView1.Nodes.Clear();

            TreeNode node = treeView1.Nodes.Add("Modulo de Administracion");
            node.Nodes.Add("Datos de Compania");
            node.Nodes.Add("Empleados");
            node.Nodes.Add("Usuarios");
            node.Nodes.Add("Impuestos");
            node.Nodes.Add("Modo de Pago");
            node.Nodes.Add("Gastos");
            node.Nodes.Add("Numeracion");

          treeView1.ExpandAll();

          lblModulo.Text = "Modulo de Administracion";



        }

        private void Frm_Principal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.B)
            {

                MessageBox.Show("Presiono B");
            
            }
        }

        private void btnPos_Click(object sender, EventArgs e)
        {

            treeView1.Nodes.Clear();

            Frm_Pos frmPos = new Frm_Pos();
            frmPos.MdiParent = this;

            if (EntityLayer.Administracion.Enl_DatosDeSession.NombreUsuario == "Ventas")
            {
                frmPos.btnEliminar.Visible = false;
            }
            frmPos.Show();

            lblModulo.Text = "Modulo POS";

        }

        private void Frm_Principal_Load(object sender, EventArgs e)
        {

          

            //Frm_Login frmLogin = new Frm_Login();
            //frmLogin.ShowDialog();       

            lblFechaSistema.Text = Convert.ToString( DateTime.Now.ToLongDateString());
            lblHora.Text = Convert.ToString(DateTime.Now.ToLongTimeString());
          
           
        }

        public  void DesabilitarBotones()
        {
            btnAdministracion.Enabled = false;
            btnCompras.Enabled = false;
            btnVentas.Enabled = false;
            btnInventario.Enabled = false;


        }

        private void Frm_Principal_Activated(object sender, EventArgs e)
        {
            if (EntityLayer.Administracion.Enl_DatosDeSession.NombreUsuario == "Ventas")
            {
                btnAdministracion.Enabled = false;
                btnCompras.Enabled = false;
                btnInventario.Enabled = false;
                btnVentas.Enabled = false;
            
            }

          

            lblUsuario.Text = EntityLayer.Administracion.Enl_DatosDeSession.NombreUsuario;
        }

        private void Frm_Principal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Realmente Desea Abandonar la Aplicacion ?", "Saliendo...", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
         
            
        }

        private void facturasPorStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Rpt_Facturas_Por_Estatus rpt = new Frm_Rpt_Facturas_Por_Estatus();
            rpt.MdiParent = this;
            rpt.Show();
        }

        private void facturasConDetalleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Rpt_Facturas_Detalle_Articulos rpt = new Frm_Rpt_Facturas_Detalle_Articulos();
            rpt.MdiParent = this;
            rpt.Show();
        }

        private void facturasResumidoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rpt_FacturaResumido rptFacturarRes = new Rpt_FacturaResumido();
            rptFacturarRes.MdiParent = this;
            rptFacturarRes.Show();
        }

        private void gastosAgrupadoPorTiposToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Frm_Rpt_Gastos rptGastos = new Frm_Rpt_Gastos();
            rptGastos.MdiParent = this;
            rptGastos.Show();
        }

        private void listadoDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_Rpt_Articulos rptArticulos = new Frm_Rpt_Articulos();
            rptArticulos.MdiParent = this;
            rptArticulos.Show();
        }

        private void acercaDeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Frm_ArcercaDe frmAcercaDe = new Frm_ArcercaDe();
            frmAcercaDe.MdiParent = this;
            frmAcercaDe.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
       
    }
}
