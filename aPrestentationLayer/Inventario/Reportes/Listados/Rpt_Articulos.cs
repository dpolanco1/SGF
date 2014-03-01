using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aPrestentationLayer.Inventario.Reportes.Listados
{
    public partial class Rpt_Articulos : Form
    {
        public Rpt_Articulos()
        {
            InitializeComponent();
        }

        private void Rpt_Articulos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sGFDataSet.Articulos' table. You can move, or remove it, as needed.
            this.articulosTableAdapter.Fill(this.sGFDataSet.Articulos);

            this.reportViewer1.RefreshReport();

           
            
        }
    }
}
