using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer.Inventario;
using BusinessLogicLayer.Inventario;
using EntityLayer.Administracion;
using BusinessLogicLayer.Administracion;

namespace aPrestentationLayer.Comunes
{
    public partial class Frm_Buscar_Articulos : Form
    {

        Enl_Articulos enlArticulos = new Enl_Articulos();
        Bll_Articulos bllArticulos = new Bll_Articulos();

        Enl_Impuestos enlImpuestos = new Enl_Impuestos();
        Bll_Impuestos bllImpuestos = new Bll_Impuestos();


        public List<Enl_Articulos> ListaArticulos = new List<Enl_Articulos>();

        public Frm_Buscar_Articulos()
        {
            InitializeComponent();
            DGV_Articulos.AutoGenerateColumns = false;
        }

        public string LlamadoDesde { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LlamadoDesde);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            
            for (int a = 0; a < DGV_Articulos.RowCount; a++)
            {
                if (DGV_Articulos[0, a].Value != null)
                {
                    // Verificar si el Check Box esta True
                    if ((bool)(DGV_Articulos[0, a].Value) == true)
                    {
                        //Buscamos el codigo del impuesto filtrando el Articulo
                        enlArticulos.Codigo = DGV_Articulos[1, a].Value.ToString();
                        enlArticulos.Nombre = string.Empty;
                        enlArticulos.Descripcion = string.Empty;
                        enlArticulos.Impuesto = string.Empty;
                        enlArticulos.Marca = string.Empty;
                        enlArticulos.Categoria = string.Empty;
                        enlArticulos.SubCategoria = string.Empty;

                        var ListaArticulos2 = bllArticulos.Search(enlArticulos);

                        // Llamamos el impuesto que esta asociado al Articulo
                        enlImpuestos.Codigo = ListaArticulos2[0].Impuesto;
                        enlImpuestos.Nombre = string.Empty;
                        var ListaImpuesto = bllImpuestos.Search(enlImpuestos);

                        //Calculamos el Impuesto 
                        var ValorImpuesto = (ListaImpuesto[0].Porcentaje / 100) * Convert.ToDecimal(ListaArticulos2[0].Precio.ToString());

                        ListaArticulos.Add(new Enl_Articulos()
                        {
                            Codigo = DGV_Articulos[1, a].Value.ToString(),
                            Descripcion = DGV_Articulos[2, a].Value.ToString(),
                            Precio = Convert.ToDecimal(DGV_Articulos[3, a].Value),
                            Costo = Convert.ToDecimal(DGV_Articulos[4, a].Value),
                            Cantidad = 1,
                            Impuesto = ValorImpuesto.ToString("C2").Replace("RD$", "")
                            

                        });
                    }
                }
            }


            Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DGV_Articulos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)DGV_Articulos.Rows[DGV_Articulos.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    break;
                case "False":
                    ch1.Value = true;
                    break;

            }
        }

        private void Frm_Buscar_Articulos_Load(object sender, EventArgs e)
        {

            enlArticulos.Codigo = string.Empty;
            enlArticulos.Nombre = string.Empty;
            enlArticulos.Descripcion = string.Empty;
            enlArticulos.Impuesto = string.Empty;
            enlArticulos.Marca = string.Empty;
            enlArticulos.Categoria = string.Empty;
            enlArticulos.SubCategoria = string.Empty;



            DGV_Articulos.DataSource = bllArticulos.Search(enlArticulos);
       
        }
    }
}
