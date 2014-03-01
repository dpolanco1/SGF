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
    public partial class Rpt_Marcas : Form
    {
        public Rpt_Marcas()
        {
            InitializeComponent();
        }

        private void Rpt_Marcas_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sGFDataSet.Marcas' table. You can move, or remove it, as needed.
            this.marcasTableAdapter.Fill(this.sGFDataSet.Marcas);

            this.reportViewer1.RefreshReport();
        }
    }
}
