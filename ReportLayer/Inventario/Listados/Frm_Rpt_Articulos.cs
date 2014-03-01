using EntityLayer.Administracion;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ReportLayer.Inventario.Listados
{
    public partial class Frm_Rpt_Articulos : Form
    {
        public Frm_Rpt_Articulos()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Articulos_Load(object sender, EventArgs e)
        {
            this.sGFDataSetInventario.EnforceConstraints = false;

            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_Compania", Enl_DatosDeSession.NombreCompania));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_Telefono", Enl_DatosDeSession.Telefono));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_Fax", Enl_DatosDeSession.Fax));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_Direccion", Enl_DatosDeSession.Direccion));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_RNC", Enl_DatosDeSession.RNC));

            this.spr_Search_ArticulosTableAdapter.Fill(this.sGFDataSetInventario.Spr_Search_Articulos, "", "", "", "", "", "", "");
            this.reportViewer1.RefreshReport();
          
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.spr_Search_ArticulosTableAdapter.Fill(this.sGFDataSetInventario.Spr_Search_Articulos,txtCodigo.Text, "", "", "",txtMarca.Text,txtCategoria.Text, "");
            this.reportViewer1.RefreshReport();
        }
    }
}
