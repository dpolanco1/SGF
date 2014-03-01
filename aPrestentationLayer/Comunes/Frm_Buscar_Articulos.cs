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
namespace aPrestentationLayer.Comunes
{
    public partial class Frm_Buscar_Articulos : Form
    {

        Enl_Articulos enlArticulos = new Enl_Articulos();
        Bll_Articulos bllArticulos = new Bll_Articulos();

        public Frm_Buscar_Articulos()
        {
            InitializeComponent();
        }

        public string LlamadoDesde { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show(LlamadoDesde);
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            var list = new List<Enl_Articulos>();

            for (int a = 0; a < DGV_Articulos.RowCount; a++)
            {
                if (DGV_Articulos[0, a].Value != null)
                {
                    // Verificar si el Check Box esta True
                    if ((bool)(DGV_Articulos[0, a].Value) == true)
                    {

                        list.Add(new Enl_Articulos
                        {
                            Codigo = DGV_Articulos[1, a].Value.ToString(),
                            Descripcion = DGV_Articulos[2, a].Value.ToString()
                            //Cantidad = Convert.ToDecimal(DGV_Articulos[3, a].Value)
                            

                        });
                    }
                }
            }


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
    }
}
