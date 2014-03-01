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
    public partial class Rpt_SubCategoriaArticulos : Form
    {
        public Rpt_SubCategoriaArticulos()
        {
            InitializeComponent();
        }

        private void Rpt_SubCategoriaArticulos_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sGFDataSet.SubCategoriaArticulos' table. You can move, or remove it, as needed.
            this.subCategoriaArticulosTableAdapter.Fill(this.sGFDataSet.SubCategoriaArticulos);

            this.reportViewer1.RefreshReport();
        }
    }
}
