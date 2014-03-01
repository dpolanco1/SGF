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
    public partial class Rpt_Almacen : Form
    {
        public Rpt_Almacen()
        {
            InitializeComponent();
        }

        private void Rpt_Almacen_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sGFDataSet.Almacen' table. You can move, or remove it, as needed.
            this.almacenTableAdapter.Fill(this.sGFDataSet.Almacen);

            this.reportViewer1.RefreshReport();

  

        }
    }
}
