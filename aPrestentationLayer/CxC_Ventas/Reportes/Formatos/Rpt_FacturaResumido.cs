using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;


namespace aPrestentationLayer.CxC_Ventas.Reportes.Formatos
{
    public partial class Rpt_FacturaResumido : Form
    {
        public Rpt_FacturaResumido()
        {
            InitializeComponent();
        }

        private void Rpt_FacturaResumido_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sGF_DataSet_CxC.Spr_Rpt_Facturas_Resumidas' table. You can move, or remove it, as needed.
            this.spr_Rpt_Facturas_ResumidasTableAdapter.Fill(this.sGF_DataSet_CxC.Spr_Rpt_Facturas_Resumidas,txtNoFactura.Text,txtCliente.Text,FechaDesde.Value.Date,FechaHasta.Value.Date,cmbEstatus.Text);



            //ReportParameter[] parametros = new ReportParameter[2];

            //parametros[0] = new ReportParameter("NombreCompania", "Eso es una prueba");
            //parametros[1] = new ReportParameter("Telefono", "809-589-2598");

            //this.spr_Rpt_Facturas_ResumidasTableAdapter.Fill(this.sGF_DataSet_CxC.Spr_Rpt_Facturas_Resumidas, "", "",,,"");

            //this.reportViewer1.LocalReport.SetParameters(parametros);
            this.reportViewer1.RefreshReport();

            
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.spr_Rpt_Facturas_ResumidasTableAdapter.Fill(this.sGF_DataSet_CxC.Spr_Rpt_Facturas_Resumidas, txtNoFactura.Text, txtCliente.Text, FechaDesde.Value.Date, FechaHasta.Value.Date, cmbEstatus.Text);

            this.reportViewer1.RefreshReport();

        }
    }
}
