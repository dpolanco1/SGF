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
        //variable para saber que boton fue clickeado en el panel
        enum fue_Clickeado 
        {
            Inventario,
            Ventas,
            Compras,
            Administracion
        }

        fue_Clickeado botonCLickeado = new fue_Clickeado();

        //declaraciones de formularios
        Frm_CategoriaClientes frmCategoriaClientes;
        Frm_SubCategoriaClientes frmSubCategoriaClientes;
        Frm_Clientes frmClientes;
        Frm_Cotizaciones frmCotizaciones;
        Frm_Facturas frmFacturas;
        Frm_Recibos frmRecibos;
        Frm_NotasCreditos frmNotasCreditosCxC;
        Frm_NotasDebitos frmNotasDebitosCxC;
        Frm_Terminos frmTerminos;
        Frm_Cajas frmCajas;
        Frm_CategoriaSuplidores frmCategoriaSuplidor;
        Frm_SubCategoriaSuplidores frmSubCateSupli;
        Frm_Suplidores frmSuplidores;
        Frm_OrdenesCompras frmOrdenesCompras;
        Frm_Compras frmCompras;
        Frm_NotasCreditosCxP frmNotasCreditosCxP;
        Frm_NotasDebitosCxP frmNotasDebitosCxP;
        Frm_CategoriaArticulos frmCategoriaArticulos;
        Frm_SubCategoriaArticulos frmSubCateArtic;
        Frm_Almacen frmAlmacen;
        Frm_Marcas frmMarcas;
        Frm_TransferenciaAlmacenes frmTransfAlmacenes;
        Frm_Compania frmCompania;
        Frm_Empleados frmEmpleados;
        Frm_Usuarios frmUsuarios;
        Frm_Impuestos frmImpuestos;
        Frm_MododePago frmModoPago;
        Frm_Numeracion frmNumeracion;
        Frm_Gastos frmGastos;

        public Frm_Principal()
        {
            InitializeComponent();
        }


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
          

            treeView1.Refresh();

            if (e.Action == TreeViewAction.ByMouse)
            {

                if (botonCLickeado == fue_Clickeado.Ventas)//solo si se hizo clic en btnVentas
                {

                    #region ModuloVentas
                    //Inicio Modulo de Ventas

                    //visualizar modulo especifico
                    btnVentas_Click("Ventas", null);

                    if (e.Node.Text == "Categoria de Clientes")
                    {
                       //verificar si fue llamado anteriormente
                        if (frmCategoriaClientes == null)
                        {
                            frmCategoriaClientes = new Frm_CategoriaClientes();
                            frmCategoriaClientes.MdiParent = this;
                            frmCategoriaClientes.FormClosed += new FormClosedEventHandler(frmCategoriaClientes_FormClosed);

                        }
                        frmCategoriaClientes.WindowState = FormWindowState.Normal;
                        frmCategoriaClientes.StartPosition = FormStartPosition.CenterScreen;
                        frmCategoriaClientes.BringToFront();
                        frmCategoriaClientes.Show();
                    }

                    if (e.Node.Text == "SubCategoria de Clientes")
                    {
           
                        //verificar si fue llamado anteriormente
                        if (frmSubCategoriaClientes == null)
                        {
                            frmSubCategoriaClientes = new Frm_SubCategoriaClientes();
                            frmSubCategoriaClientes.MdiParent = this;
                            frmSubCategoriaClientes.FormClosed += new FormClosedEventHandler(frmSubCategoriaClientes_FormClosed);

                        }
                        frmSubCategoriaClientes.WindowState = FormWindowState.Normal;
                        frmSubCategoriaClientes.StartPosition = FormStartPosition.CenterScreen;
                        frmSubCategoriaClientes.BringToFront();
                        frmSubCategoriaClientes.Show();

                    }

                    if (e.Node.Text == "Clientes")
                    {
                  
                        //verificar si fue llamado anteriormente
                        if (frmClientes == null)
                        {
                            frmClientes = new Frm_Clientes();
                            frmClientes.MdiParent = this;
                            frmClientes.FormClosed += new FormClosedEventHandler(frmClientes_FormClosed);

                        }
                        frmClientes.WindowState = FormWindowState.Normal;
                        frmClientes.StartPosition = FormStartPosition.CenterScreen;
                        frmClientes.BringToFront();
                        frmClientes.Show();

                    }

                    if (e.Node.Text == "Cotizaciones")
                    {
                     
                        //verificar si fue llamado anteriormente
                        if (frmCotizaciones == null)
                        {
                            frmCotizaciones = new Frm_Cotizaciones();
                            frmCotizaciones.MdiParent = this;
                            frmCotizaciones.FormClosed += new FormClosedEventHandler(frmCotizaciones_FormClosed);

                        }
                        frmCotizaciones.WindowState = FormWindowState.Normal;
                        frmCotizaciones.StartPosition = FormStartPosition.CenterScreen;
                        frmCotizaciones.BringToFront();
                        frmCotizaciones.Show();
                    }

                    if (e.Node.Text == "Facturacion")
                    {
                        
                        //verificar si fue llamado anteriormente
                        if (frmFacturas == null)
                        {
                            frmFacturas = new Frm_Facturas();
                            frmFacturas.MdiParent = this;
                            frmFacturas.FormClosed += new FormClosedEventHandler(frmFacturas_FormClosed);

                        }
                        frmFacturas.WindowState = FormWindowState.Normal;
                        frmFacturas.StartPosition = FormStartPosition.CenterScreen;
                        frmFacturas.BringToFront();
                        frmFacturas.Show();
                    }

                    if (e.Node.Text == "Recibos")
                    {
             
                        //verificar si fue llamado anteriormente
                        if (frmRecibos == null)
                        {
                            frmRecibos = new Frm_Recibos();
                            frmRecibos.MdiParent = this;
                            frmRecibos.FormClosed += new FormClosedEventHandler(frmRecibos_FormClosed);

                        }
                        frmRecibos.WindowState = FormWindowState.Normal;
                        frmRecibos.StartPosition = FormStartPosition.CenterScreen;
                        frmRecibos.BringToFront();
                        frmRecibos.Show();
                    }


                    if (e.Node.Text == "Notas de Creditos CxC")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmNotasCreditosCxC == null)
                        {
                            frmNotasCreditosCxC = new Frm_NotasCreditos();
                            frmNotasCreditosCxC.MdiParent = this;
                            frmNotasCreditosCxC.FormClosed += new FormClosedEventHandler(frmNotasCreditosCxC_FormClosed);

                        }
                        frmNotasCreditosCxC.WindowState = FormWindowState.Normal;
                        frmNotasCreditosCxC.StartPosition = FormStartPosition.CenterScreen;
                        frmNotasCreditosCxC.BringToFront();
                        frmNotasCreditosCxC.Show();
                    }

                    if (e.Node.Text == "Notas de Debito CxC")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmNotasDebitosCxC == null)
                        {
                            frmNotasDebitosCxC = new Frm_NotasDebitos();
                            frmNotasDebitosCxC.MdiParent = this;
                            frmNotasDebitosCxC.FormClosed += new FormClosedEventHandler(frmNotasDebitosCxC_FormClosed);

                        }
                        frmNotasDebitosCxC.WindowState = FormWindowState.Normal;
                        frmNotasDebitosCxC.StartPosition = FormStartPosition.CenterScreen;
                        frmNotasDebitosCxC.BringToFront();
                        frmNotasDebitosCxC.Show();
                    }

                    if (e.Node.Text == "Terminos")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmTerminos == null)
                        {
                            frmTerminos = new Frm_Terminos();
                            frmTerminos.MdiParent = this;
                            frmTerminos.FormClosed += new FormClosedEventHandler(frmTerminos_FormClosed);

                        }
                        frmTerminos.WindowState = FormWindowState.Normal;
                        frmTerminos.StartPosition = FormStartPosition.CenterScreen;
                        frmTerminos.BringToFront();
                        frmTerminos.Show();
                    }

                    if (e.Node.Text == "Cajas")
                    {
                        
                        //verificar si fue llamado anteriormente
                        if (frmCajas == null)
                        {
                            frmCajas = new Frm_Cajas();
                            frmCajas.MdiParent = this;
                            frmCajas.FormClosed += new FormClosedEventHandler(frmCajas_FormClosed);

                        }
                        frmCajas.WindowState = FormWindowState.Normal;
                        frmCajas.StartPosition = FormStartPosition.CenterScreen;
                        frmCajas.BringToFront();
                        frmCajas.Show();
                    }
                    #endregion ModuloVentas
                }//Fin Modulo de Ventas

                else if (botonCLickeado == fue_Clickeado.Compras) //solo si se hizo clic en btnCompras
                {
                    #region ModuloCompras
                    //Inicio Modulo de Compras

                    //visualizar modulo especifico
                    btnCompras_Click("Compras", null);

                    if (e.Node.Text == "Categoria de Suplidores")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmCategoriaSuplidor == null)
                        {
                            frmCategoriaSuplidor = new Frm_CategoriaSuplidores();
                            frmCategoriaSuplidor.MdiParent = this;
                            frmCategoriaSuplidor.FormClosed += new FormClosedEventHandler(frmCategoriaSuplidor_FormClosed);

                        }
                        frmCategoriaSuplidor.WindowState = FormWindowState.Normal;
                        frmCategoriaSuplidor.StartPosition = FormStartPosition.CenterScreen;
                        frmCategoriaSuplidor.BringToFront();
                        frmCategoriaSuplidor.Show();
                    }


                    if (e.Node.Text == "SubCategoria de Suplidores")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmSubCateSupli == null)
                        {
                            frmSubCateSupli = new Frm_SubCategoriaSuplidores();
                            frmSubCateSupli.MdiParent = this;
                            frmSubCateSupli.FormClosed += new FormClosedEventHandler(frmSubCateSupli_FormClosed);

                        }
                        frmSubCateSupli.WindowState = FormWindowState.Normal;
                        frmSubCateSupli.StartPosition = FormStartPosition.CenterScreen;
                        frmSubCateSupli.BringToFront();
                        frmSubCateSupli.Show();
                    }


                    if (e.Node.Text == "Suplidores")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmSuplidores == null)
                        {
                            frmSuplidores = new Frm_Suplidores();
                            frmSuplidores.MdiParent = this;
                            frmSuplidores.FormClosed += new FormClosedEventHandler(frmSuplidores_FormClosed);

                        }
                        frmSuplidores.WindowState = FormWindowState.Normal;
                        frmSuplidores.StartPosition = FormStartPosition.CenterScreen;
                        frmSuplidores.BringToFront();
                        frmSuplidores.Show();
                    }


                    if (e.Node.Text == "Ordenes de Compras")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmOrdenesCompras == null)
                        {
                            frmOrdenesCompras = new Frm_OrdenesCompras();
                            frmOrdenesCompras.MdiParent = this;
                            frmOrdenesCompras.FormClosed += new FormClosedEventHandler(frmOrdenesCompras_FormClosed);

                        }
                        frmOrdenesCompras.WindowState = FormWindowState.Normal;
                        frmOrdenesCompras.StartPosition = FormStartPosition.CenterScreen;
                        frmOrdenesCompras.BringToFront();
                        frmOrdenesCompras.Show();
                    }


                    if (e.Node.Text == "Compras")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmCompras == null)
                        {
                            frmCompras = new Frm_Compras();
                            frmCompras.MdiParent = this;
                            frmCompras.FormClosed += new FormClosedEventHandler(frmCompras_FormClosed);

                        }
                        frmCompras.WindowState = FormWindowState.Normal;
                        frmCompras.StartPosition = FormStartPosition.CenterScreen;
                        frmCompras.BringToFront();
                        frmCompras.Show();
                    }


                    if (e.Node.Text == "Notas de Creditos CxP")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmNotasCreditosCxP == null)
                        {
                            frmNotasCreditosCxP = new Frm_NotasCreditosCxP();
                            frmNotasCreditosCxP.MdiParent = this;
                            frmNotasCreditosCxP.FormClosed += new FormClosedEventHandler(frmNotasCreditosCxP_FormClosed);

                        }
                        frmNotasCreditosCxP.WindowState = FormWindowState.Normal;
                        frmNotasCreditosCxP.StartPosition = FormStartPosition.CenterScreen;
                        frmNotasCreditosCxP.BringToFront();
                        frmNotasCreditosCxP.Show();
                    }



                    if (e.Node.Text == "Notas de Debitos CxP")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmNotasDebitosCxP == null)
                        {
                            frmNotasDebitosCxP = new Frm_NotasDebitosCxP();
                            frmNotasDebitosCxP.MdiParent = this;
                            frmNotasDebitosCxP.FormClosed += new FormClosedEventHandler(frmNotasDebitosCxP_FormClosed);

                        }
                        frmNotasDebitosCxP.WindowState = FormWindowState.Normal;
                        frmNotasDebitosCxP.StartPosition = FormStartPosition.CenterScreen;
                        frmNotasDebitosCxP.BringToFront();
                        frmNotasDebitosCxP.Show();
                    }


                    #endregion
                }//Fin Modulo de Compras

                else if (botonCLickeado == fue_Clickeado.Inventario) //solo si se hizo clic en btnInventario
                {
                    #region ModuloInventario

                    //visualizar modulo especifico
                    btnInventario_Click("Inventario", null);

                    if (e.Node.Text == "Categoria de Articulos")
                    {
                        
                        //verificar si fue llamado anteriormente
                        if (frmCategoriaArticulos == null)
                        {
                            frmCategoriaArticulos = new Frm_CategoriaArticulos();
                            frmCategoriaArticulos.MdiParent = this;
                            frmCategoriaArticulos.FormClosed += new FormClosedEventHandler(frmCategoriaArticulos_FormClosed);

                        }
                        frmCategoriaArticulos.WindowState = FormWindowState.Normal;
                        frmCategoriaArticulos.StartPosition = FormStartPosition.CenterScreen;
                        frmCategoriaArticulos.BringToFront();
                        frmCategoriaArticulos.Show();
                    }

                    if (e.Node.Text == "SubCategoria de Articulos")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmSubCateArtic == null)
                        {
                            frmSubCateArtic = new Frm_SubCategoriaArticulos();
                            frmSubCateArtic.MdiParent = this;
                            frmSubCateArtic.FormClosed += new FormClosedEventHandler(frmSubCateArtic_FormClosed);

                        }
                        frmSubCateArtic.WindowState = FormWindowState.Normal;
                        frmSubCateArtic.StartPosition = FormStartPosition.CenterScreen;
                        frmSubCateArtic.BringToFront();
                        frmSubCateArtic.Show();
                    }


                    if (e.Node.Text == "Almacen")
                    {
                        
                        //verificar si fue llamado anteriormente
                        if (frmAlmacen == null)
                        {
                            frmAlmacen = new Frm_Almacen();
                            frmAlmacen.MdiParent = this;
                            frmAlmacen.FormClosed += new FormClosedEventHandler(frmAlmacen_FormClosed);

                        }
                        frmAlmacen.WindowState = FormWindowState.Normal;
                        frmAlmacen.StartPosition = FormStartPosition.CenterScreen;
                        frmAlmacen.BringToFront();
                        frmAlmacen.Show();
                    }

                    if (e.Node.Text == "Marcas")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmMarcas == null)
                        {
                            frmMarcas = new Frm_Marcas();
                            frmMarcas.MdiParent = this;
                            frmMarcas.FormClosed += new FormClosedEventHandler(frmMarcas_FormClosed);

                        }
                        frmMarcas.WindowState = FormWindowState.Normal;
                        frmMarcas.StartPosition = FormStartPosition.CenterScreen;
                        frmMarcas.BringToFront();
                        frmMarcas.Show();
                    }

                    if (e.Node.Text == "Articulos")
                    {

                        //verificar si fue llamado anteriormente
                        if (frmCompras == null)
                        {
                            frmCompras = new Frm_Compras();
                            frmCompras.MdiParent = this;
                            frmCompras.FormClosed += new FormClosedEventHandler(frmCompras_FormClosed);

                        }
                        frmCompras.WindowState = FormWindowState.Normal;
                        frmCompras.StartPosition = FormStartPosition.CenterScreen;
                        frmCompras.BringToFront();
                        frmCompras.Show();
                    }

                    if (e.Node.Text == "Tranferencia de Almacenes")
                    {

                        //verificar si fue llamado anteriormente
                        if (frmTransfAlmacenes == null)
                        {
                            frmTransfAlmacenes = new Frm_TransferenciaAlmacenes();
                            frmTransfAlmacenes.MdiParent = this;
                            frmTransfAlmacenes.FormClosed += new FormClosedEventHandler(frmTransfAlmacenes_FormClosed);

                        }
                        frmTransfAlmacenes.WindowState = FormWindowState.Normal;
                        frmTransfAlmacenes.StartPosition = FormStartPosition.CenterScreen;
                        frmTransfAlmacenes.BringToFront();
                        frmTransfAlmacenes.Show();
                    }


                    #endregion
                }//Fin Modulo de Inventario

                else if (botonCLickeado == fue_Clickeado.Administracion) //solo si se hizo clic en btnAdministracion
                {
                    #region ModuloAdministracion

                    //visualizar modulo especifico
                    btnAdministracion_Click("Administracion", null);

                    if (e.Node.Text == "Datos de Compania")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmCompania == null)
                        {
                            frmCompania = new Frm_Compania();
                            frmCompania.MdiParent = this;
                            frmCompania.FormClosed += new FormClosedEventHandler(frmCompania_FormClosed);

                        }
                        frmCompania.WindowState = FormWindowState.Normal;
                        frmCompania.StartPosition = FormStartPosition.CenterScreen;
                        frmCompania.BringToFront();
                        frmCompania.Show();
                    }

                    if (e.Node.Text == "Empleados")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmEmpleados == null)
                        {
                            frmEmpleados = new Frm_Empleados();
                            frmEmpleados.MdiParent = this;
                            frmEmpleados.FormClosed += new FormClosedEventHandler(frmEmpleados_FormClosed);

                        }
                        frmEmpleados.WindowState = FormWindowState.Normal;
                        frmEmpleados.StartPosition = FormStartPosition.CenterScreen;
                        frmEmpleados.BringToFront();
                        frmEmpleados.Show();
                    }


                    if (e.Node.Text == "Usuarios")
                    {
                        
                        //verificar si fue llamado anteriormente
                        if (frmUsuarios == null)
                        {
                            frmUsuarios = new Frm_Usuarios();
                            frmUsuarios.MdiParent = this;
                            frmUsuarios.FormClosed += new FormClosedEventHandler(frmUsuarios_FormClosed);

                        }
                        frmUsuarios.WindowState = FormWindowState.Normal;
                        frmUsuarios.StartPosition = FormStartPosition.CenterScreen;
                        frmUsuarios.BringToFront();
                        frmUsuarios.Show();
                    }


                    if (e.Node.Text == "Impuestos")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmImpuestos == null)
                        {
                            frmImpuestos = new Frm_Impuestos();
                            frmImpuestos.MdiParent = this;
                            frmImpuestos.FormClosed += new FormClosedEventHandler(frmImpuestos_FormClosed);

                        }
                        frmImpuestos.WindowState = FormWindowState.Normal;
                        frmImpuestos.StartPosition = FormStartPosition.CenterScreen;
                        frmImpuestos.BringToFront();
                        frmImpuestos.Show();
                    }

                    if (e.Node.Text == "Modo de Pago")
                    {
                        
                        //verificar si fue llamado anteriormente
                        if (frmModoPago == null)
                        {
                            frmModoPago = new Frm_MododePago();
                            frmModoPago.MdiParent = this;
                            frmModoPago.FormClosed += new FormClosedEventHandler(frmModoPago_FormClosed);

                        }
                        frmModoPago.WindowState = FormWindowState.Normal;
                        frmModoPago.StartPosition = FormStartPosition.CenterScreen;
                        frmModoPago.BringToFront();
                        frmModoPago.Show();
                    }

                    if (e.Node.Text == "Numeracion")
                    {
                        
                        //verificar si fue llamado anteriormente
                        if (frmNumeracion == null)
                        {
                            frmNumeracion = new Frm_Numeracion();
                            frmNumeracion.MdiParent = this;
                            frmNumeracion.FormClosed += new FormClosedEventHandler(frmNumeracion_FormClosed);

                        }
                        frmNumeracion.WindowState = FormWindowState.Normal;
                        frmNumeracion.StartPosition = FormStartPosition.CenterScreen;
                        frmNumeracion.BringToFront();
                        frmNumeracion.Show();
                    }


                    if (e.Node.Text == "Gastos")
                    {
                        //verificar si fue llamado anteriormente
                        if (frmGastos == null)
                        {
                            frmGastos = new Frm_Gastos();
                            frmGastos.MdiParent = this;
                            frmGastos.FormClosed += new FormClosedEventHandler(frmGastos_FormClosed);

                        }
                        frmGastos.WindowState = FormWindowState.Normal;
                        frmGastos.StartPosition = FormStartPosition.CenterScreen;
                        frmGastos.BringToFront();
                        frmGastos.Show();
                    }
                    #endregion
                }//Fin Modulo de Administracion

            }
            treeView1.Refresh();

        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            botonCLickeado = fue_Clickeado.Ventas;

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

        private void btnInventario_Click(object sender, EventArgs e)
        {
            botonCLickeado = fue_Clickeado.Inventario;

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

            botonCLickeado = fue_Clickeado.Compras;

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
            botonCLickeado = fue_Clickeado.Administracion;

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


        #region Metodos Cerrar para las ventanas MDICHild

        void frmCategoriaClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCategoriaClientes = null;
        }


        void frmSubCategoriaClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSubCategoriaClientes = null;
        }

        void frmClientes_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmClientes = null;
        }

         void frmCotizaciones_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCotizaciones = null;
        }

         void frmFacturas_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmFacturas = null;
        }

         void frmRecibos_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmRecibos = null;
        }
        
         void frmNotasCreditosCxC_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmNotasCreditosCxC = null;
        }

        void frmNotasDebitosCxC_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmNotasDebitosCxC = null;
        }

        void frmTerminos_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmTerminos = null;
        }

        void frmCajas_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCajas = null;
        }

         void frmCategoriaSuplidor_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmCategoriaSuplidor = null;
        }

         void frmSubCateSupli_FormClosed(object sender, FormClosedEventArgs e)
        {
            frmSubCateSupli = null;
        }

         void frmSuplidores_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmSuplidores = null;
         }

        
         void frmOrdenesCompras_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmOrdenesCompras = null;
         }

         void frmCompras_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmCompras = null;
         }
    
        void frmNotasCreditosCxP_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmNotasCreditosCxP = null;
         }

          void frmNotasDebitosCxP_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmNotasDebitosCxP = null;
         }

          void frmCategoriaArticulos_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmCategoriaArticulos = null;
         }

          void frmSubCateArtic_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmSubCateArtic = null;
         }

          void frmAlmacen_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmAlmacen = null;
         }

          void frmMarcas_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmMarcas = null;
         }
        
         void frmTransfAlmacenes_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmTransfAlmacenes = null;
         }

         void frmCompania_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmCompania = null;
         }

         void frmEmpleados_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmEmpleados = null;
         }
          void frmUsuarios_FormClosed(object sender, FormClosedEventArgs e)
         {
             frmUsuarios = null;
         }

          void frmImpuestos_FormClosed(object sender, FormClosedEventArgs e)
          {
              frmImpuestos = null;
          }
          void frmModoPago_FormClosed(object sender, FormClosedEventArgs e)
          {
              frmModoPago = null;
          }
          void frmNumeracion_FormClosed(object sender, FormClosedEventArgs e)
          {
              frmNumeracion = null;
          }
            void frmGastos_FormClosed(object sender, FormClosedEventArgs e)
          {
              frmGastos = null;
          }
        
       
       
        #endregion
    }
}
