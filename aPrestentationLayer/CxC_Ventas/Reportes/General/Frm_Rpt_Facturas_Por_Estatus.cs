using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using EntityLayer.Administracion;

namespace aPrestentationLayer.CxC_Ventas.Reportes
{
    public partial class Frm_Rpt_Facturas_Por_Estatus : Form
    {
        public Frm_Rpt_Facturas_Por_Estatus()
        {
            InitializeComponent();
        }

        private void Frm_Rpt_Facturas_Por_Estatus_Load(object sender, EventArgs e)
        {

            this.sGF_DataSet_CxC.EnforceConstraints = false;
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_Compania", Enl_DatosDeSession.NombreCompania));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_Telefono", Enl_DatosDeSession.Telefono));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_Fax", Enl_DatosDeSession.Fax));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_Direccion", Enl_DatosDeSession.Direccion));
            reportViewer1.LocalReport.SetParameters(new ReportParameter("Pr_RNC", Enl_DatosDeSession.RNC));

            this.spr_Rpt_Facturas_ResumidasTableAdapter.Fill(this.sGF_DataSet_CxC.Spr_Rpt_Facturas_Resumidas, "", "",FechaDesde.Value.Date,FechaHasta.Value.Date,"");
            this.reportViewer1.RefreshReport();

         
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            this.spr_Rpt_Facturas_ResumidasTableAdapter.Fill(this.sGF_DataSet_CxC.Spr_Rpt_Facturas_Resumidas, "", txtCliente.Text , FechaDesde.Value.Date, FechaHasta.Value.Date, cmbEstatus.Text);
            this.reportViewer1.RefreshReport();
        }

        private void sprRptFacturasResumidasBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Spr_Rpt_Facturas_ResumidasBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }
    }
}
