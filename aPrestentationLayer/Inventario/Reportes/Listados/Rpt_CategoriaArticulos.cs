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
    public partial class Rpt_CategoriaArticulos : Form
    {
        public Rpt_CategoriaArticulos()
        {
            InitializeComponent();
        }

        private void Rpt_CategoriaArticulos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sGFDataSet.CategoriaArticulos' table. You can move, or remove it, as needed.
            this.categoriaArticulosTableAdapter.Fill(this.sGFDataSet.CategoriaArticulos);

            this.reportViewer1.RefreshReport();
        }
    }
}
