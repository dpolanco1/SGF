using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EntityLayer.Administracion;

namespace ReportLayer.Administracion.Listados
{
    public partial class Frm_Rpt_Gastos : Form
    {
        public Frm_Rpt_Gastos()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Gastos_Load(object sender, EventArgs e)
        {
            this.sGFDataSet.EnforceConstraints = false;
         
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_Compania", Enl_DatosDeSession.NombreCompania));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_Telefono", Enl_DatosDeSession.Telefono));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_Fax", Enl_DatosDeSession.Fax));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_Direccion", Enl_DatosDeSession.Direccion));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_RNC", Enl_DatosDeSession.RNC));

            this.spr_Search_GastosTableAdapter.Fill(this.sGFDataSet.Spr_Search_Gastos, "", "", Convert.ToDateTime( "01/01/1900"), Convert.ToDateTime("01/01/2900"));
          //  this.spr_Rpt_Facturas_ResumidasTableAdapter.Fill(this.sGF_DataSet_CxC.Spr_Rpt_Facturas_Resumidas, "", "", FechaDesde.Value.Date, FechaHasta.Value.Date, "");
            this.reportViewer1.RefreshReport();
            
          
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.spr_Search_GastosTableAdapter.Fill(this.sGFDataSet.Spr_Search_Gastos, txtCodigo.Text, txtTipo.Text, Convert.ToDateTime("01/01/1900"), Convert.ToDateTime("01/01/2900"));
            //  this.spr_Rpt_Facturas_ResumidasTableAdapter.Fill(this.sGF_DataSet_CxC.Spr_Rpt_Facturas_Resumidas, "", "", FechaDesde.Value.Date, FechaHasta.Value.Date, "");
            this.reportViewer1.RefreshReport();
        }
    }
}
