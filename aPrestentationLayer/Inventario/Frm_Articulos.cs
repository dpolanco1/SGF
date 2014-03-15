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
using BusinessLogicLayer.Inventario;
using EntityLayer.Inventario;
using BusinessLogicLayer.Administracion;
using BusinessLogicLayer.Otros;
using aPrestentationLayer.Inventario.Reportes.Listados;
using EntityLayer.Administracion;

namespace aPrestentationLayer.Inventario
{
    public partial class Frm_Articulos : Frm_Plantilla, Iinventario
    {

        //utilizando los estados predefinidos en la clase Helper
        Helper.EstadoSystema Estado = new Helper.EstadoSystema();

        /*const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";*/
        bool ActualizarDGV = false;

        AdministrarControles AC = new AdministrarControles ();

        Enl_Articulos enlArticulos = new Enl_Articulos();
        Bll_Articulos bllArticulos = new Bll_Articulos();

        Enl_Marcas enlMarcas = new Enl_Marcas();
        Bll_Marcas bllMarcas = new Bll_Marcas();

        Enl_CategoriaArticulos enlCategoriaArituclos = new Enl_CategoriaArticulos();
        Bll_CategoriaArticulos bllCategoriaArgiculos = new Bll_CategoriaArticulos();

        Enl_SubCategoriaArticulos enlSubCategoriaArituclos = new Enl_SubCategoriaArticulos();
        Bll_SubCategoriaArticulos bllSubCategoriaArgiculos = new Bll_SubCategoriaArticulos();

        Enl_Impuestos enlImpuesto = new Enl_Impuestos();
        Bll_Impuestos bllImpuesto = new Bll_Impuestos();


        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_Articulos()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
            btnImprimir.Click += btnImprimir_Click;
         
            btnVista.Click += btnVista_Click;
            DGV_Articulos.AutoGenerateColumns = false;

        }

        void btnImprimir_Click(object sender, EventArgs e)
        {
            Rpt_Articulos rpt = new Rpt_Articulos();
            rpt.ShowDialog();
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

            if (bllNumeracion.ObtenerTipo("Articulos") == "Automatico")
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

            enlArticulos.Codigo = txtCodigo.Text;
            enlArticulos.Nombre = txtNombre.Text;
            enlArticulos.Descripcion = txtDescripcion.Text;
            enlArticulos.Nota = txtNota.Text;
            enlArticulos.Marca = txtMarca.Text;
            enlArticulos.Categoria = txtCategoria.Text;
            enlArticulos.SubCategoria = txtSubCategoria.Text;
            enlArticulos.Costo = nudCosto.Value;
            enlArticulos.Precio = nudPrecio.Value;
            enlArticulos.Impuesto = txtImpuesto.Text;
            enlArticulos.Existencia = 0;
            enlArticulos.CodigoBarra = txtCodigoBarra.Text;
         

            if (Estado == Helper.EstadoSystema.Creando)
            {
                txtCodigo.Text = bllArticulos.Insert(enlArticulos);

                if (bllNumeracion.ObtenerTipo("Articulos") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Articulos"), "Articulos");
                }

            }
            else
            {
                if (Estado == Helper.EstadoSystema.Editando)
                {
                    bllArticulos.Update(enlArticulos);
                    MessageBox.Show("Registro Actualizado Correctamente", "SGF");
                }
            }

            BotonGuardar();
            ActualizarDGV = true;

            Estado = Helper.EstadoSystema.Consultando;

        }

        void btnEditar_Click(object sender, EventArgs e)
        {
            Estado = Helper.EstadoSystema.Editando;

            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Articulos.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_Articulos[0, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Articulos[1, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtDescripcion.Text = DGV_Articulos[2, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_Articulos[3, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtMarca.Text = DGV_Articulos[4, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtCategoria.Text = DGV_Articulos[5, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtSubCategoria.Text = DGV_Articulos[6, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    nudCosto.Text = DGV_Articulos[7, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    nudPrecio.Text = DGV_Articulos[8, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtImpuesto.Text = DGV_Articulos[9, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    lblExistencia.Text = DGV_Articulos[10, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtCodigoBarra.Text = DGV_Articulos[11, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtCodigoBarra.Text = DGV_Articulos[11, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();

                }
            }

            if (!string.IsNullOrEmpty(txtCodigo.Text))
            {

                BotonEditar();
                txtCodigo.Enabled = false;
                txtNombre.Focus();
            }
            else
                {
                    Estado = Helper.EstadoSystema.Consultando;
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
                 enlArticulos.Codigo = txtCodigo.Text;
                 enlArticulos.Nombre = string.Empty;
                 enlArticulos.Descripcion = string.Empty;
                 enlArticulos.Impuesto = string.Empty;
                 enlArticulos.Marca = string.Empty;
                 enlArticulos.Categoria = string.Empty;
                 enlArticulos.SubCategoria = string.Empty;
                 enlArticulos.CodigoBarra = string.Empty;


                 var list = bllArticulos.Search(enlArticulos);

                        txtNombre.Text = list[0].Nombre;
                        txtDescripcion.Text = list[0].Descripcion;
                        txtNota.Text = list[0].Nota;
                        txtMarca.Text =list[0].Marca;
                        txtCategoria.Text = list[0].Categoria;
                        txtSubCategoria.Text =list[0].SubCategoria;
                        nudCosto.Value = list[0].Costo;
                        nudPrecio.Value =list[0].Precio;
                        txtImpuesto.Text = list[0].Impuesto;
                        lblExistencia.Text = Convert.ToString( list[0].Existencia);
                        txtCodigoBarra.Text = list[0].CodigoBarra;

             }

            BotonCancelar();
            Estado = Helper.EstadoSystema.Consultando;
        }

        void btnEliminar_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tbpDetail)
            {
                tabControl1.TabPages.Remove(tbpDetail);
                tabControl1.TabPages.Add(tbpMaster);
                tabControl1.SelectTab(tbpMaster);

                if (DGV_Articulos.Rows.Count != 0)
                {

                    txtCodigo.Text = DGV_Articulos[0, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtNombre.Text = DGV_Articulos[1, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtDescripcion.Text = DGV_Articulos[2, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtNota.Text = DGV_Articulos[3, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtMarca.Text = DGV_Articulos[4, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtCategoria.Text = DGV_Articulos[5, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtSubCategoria.Text = DGV_Articulos[6, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    nudCosto.Text = DGV_Articulos[7, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    nudPrecio.Text = DGV_Articulos[8, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtImpuesto.Text = DGV_Articulos[9, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    lblExistencia.Text = DGV_Articulos[10, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    txtCodigoBarra.Text = DGV_Articulos[11, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                }
            }


            enlArticulos.Codigo = txtCodigo.Text;
            if (bllArticulos.Delete(enlArticulos))
            {
                BotonEliminar();
                ActualizarDGV = true;
            }
        }

        void btnVista_Click(object sender, EventArgs e)
        {
            if (ActualizarDGV == true)
            {

                enlArticulos.Codigo = string.Empty;
                enlArticulos.Nombre = string.Empty;
                enlArticulos.Descripcion = string.Empty;
                enlArticulos.Impuesto = string.Empty;
                enlArticulos.Marca = string.Empty;
                enlArticulos.Categoria = string.Empty;
                enlArticulos.SubCategoria = string.Empty;
                enlArticulos.CodigoBarra = string.Empty;

                DGV_Articulos.DataSource = bllArticulos.Search(enlArticulos);

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

                    if (DGV_Articulos.Rows.Count != 0)
                    {

                        txtCodigo.Text = DGV_Articulos[0, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                        txtNombre.Text = DGV_Articulos[1, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                        txtDescripcion.Text = DGV_Articulos[2, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                        txtNota.Text = DGV_Articulos[3, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                        txtMarca.Text = DGV_Articulos[4, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                        txtCategoria.Text = DGV_Articulos[5, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                        txtSubCategoria.Text = DGV_Articulos[6, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                        nudCosto.Text = DGV_Articulos[7, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                        nudPrecio.Text = DGV_Articulos[8, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                        txtImpuesto.Text = DGV_Articulos[9, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                        lblExistencia.Text = DGV_Articulos[10, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                        txtCodigoBarra.Text = DGV_Articulos[11, DGV_Articulos.CurrentCell.RowIndex].Value.ToString();
                    }
                }
            }
        }

        private void Frm_Articulos_Load(object sender, EventArgs e)

        {
            Estado = Helper.EstadoSystema.Consultando;
            tabControl1.TabPages.Remove(tbpMaster);

            enlArticulos.Codigo = string.Empty;
            enlArticulos.Nombre = string.Empty;
            enlArticulos.Descripcion = string.Empty;
            enlArticulos.Impuesto = string.Empty;
            enlArticulos.Marca = string.Empty;
            enlArticulos.Categoria = string.Empty;
            enlArticulos.SubCategoria = string.Empty;
           
            

            DGV_Articulos.DataSource = bllArticulos.Search(enlArticulos);
        }

        private void DGV_Articulos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnVista_Click(btnVista, null);
        }

        private void lblBuscarMarca_Click(object sender, EventArgs e)
        {

            if (Estado != Helper.EstadoSystema.Consultando)
            {
                Frm_Marcas frmMarcas = new Frm_Marcas();
                frmMarcas.Owner = this;
                frmMarcas.OcultarToolBar();
                frmMarcas.ShowDialog();
            }
        }

        private void LblBuscarCategoria_Click(object sender, EventArgs e)
        {
            if (Estado != Helper.EstadoSystema.Consultando)
            {

                Frm_CategoriaArticulos frmCategoria = new Frm_CategoriaArticulos();
                frmCategoria.Owner = this;
                frmCategoria.OcultarToolBar();
                frmCategoria.ShowDialog();
            }
        }

        private void LblBuscarSubCategoria_Click(object sender, EventArgs e)
        {
            if (Estado != Helper.EstadoSystema.Consultando)
            {
                Frm_SubCategoriaArticulos frmSubCategoria = new Frm_SubCategoriaArticulos();
                frmSubCategoria.Owner = this;
                frmSubCategoria.OcultarToolBar();
                frmSubCategoria.ShowDialog();
            }
        }

        private void LblBuscarImpuesto_Click(object sender, EventArgs e)
        {
            if (Estado != Helper.EstadoSystema.Consultando)
            {
                Frm_Impuestos frmImpuesto = new Frm_Impuestos();
                frmImpuesto.Owner = this;
                frmImpuesto.OcultarToolBar();
                frmImpuesto.ShowDialog();
            }
        }

        public void CargarMarca(string Marca)
        {
            txtMarca.Text = Marca;
        }

        public void CargarCategoria(string Categoria)
        {
            txtCategoria.Text = Categoria;
        }

        public void CargarSubCategoria(string SubCategoria)
        {
            txtSubCategoria.Text = SubCategoria;
        }

        public void CargarImpuesto(string Impuesto)
        {
            txtImpuesto.Text = Impuesto;
        }

        private void txtMarca_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtMarca.Text))
            {
                 enlMarcas.Codigo = txtMarca.Text;
                 if (bllMarcas.IsExiste(enlMarcas) == "False")
                 {
                     txtMarca.Focus();
                     MessageBox.Show("La maca no existe en la base de datos");
                     //ErrArticulos.SetError(txtMarca, "No Existe en la Maestra de Marcas");
                 }
                 else
                 {
                     ErrArticulos.SetError(txtMarca, null); 
                 }
            }

        }

        private void txtCategoria_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtCategoria.Text))
            {
                enlCategoriaArituclos.Codigo = txtCategoria.Text;
                if (bllCategoriaArgiculos.IsExiste(enlCategoriaArituclos) == "False")
                {
                    txtCategoria.Focus();
                    MessageBox.Show("La maca no existe en la base de datos");
                }
            }
        }

        private void txtSubCategoria_Validating(object sender, CancelEventArgs e)
        {
            if (!String.IsNullOrEmpty(txtSubCategoria.Text))
            {
                enlSubCategoriaArituclos.Codigo = txtSubCategoria.Text;
                if (bllSubCategoriaArgiculos.IsExiste(enlSubCategoriaArituclos) == "False")
                {
                    txtSubCategoria.Focus();
                    MessageBox.Show("La maca no existe en la base de datos");
                }
            }
        }

        private void txtImpuesto_Validating(object sender, CancelEventArgs e)
        {
            //if (!String.IsNullOrEmpty(txtImpuesto.Text))
            //{
            //    enlImpuesto.Codigo = txtImpuesto.Text;
            //    if (bllImpuesto.IsExiste(enlImpuesto) == "False")
            //    {
            //        txtImpuesto.Focus();
            //        MessageBox.Show("La maca no existe en la base de datos");
            //    }
            //}
        }

        private void DGV_Articulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



    }
}
