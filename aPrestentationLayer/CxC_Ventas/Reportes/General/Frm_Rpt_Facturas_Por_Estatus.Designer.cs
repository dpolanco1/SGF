namespace aPrestentationLayer.CxC_Ventas.Reportes
{
    partial class Frm_Rpt_Facturas_Por_Estatus
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.Spr_Rpt_Facturas_ResumidasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sGF_DataSet_CxC = new aPrestentationLayer.CxC_Ventas.SGF_DataSet_CxC();
            this.sprRptFacturasResumidasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spr_Rpt_Facturas_ResumidasTableAdapter = new aPrestentationLayer.CxC_Ventas.SGF_DataSet_CxCTableAdapters.Spr_Rpt_Facturas_ResumidasTableAdapter();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEstatus = new System.Windows.Forms.ComboBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.Spr_Rpt_Facturas_ResumidasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sGF_DataSet_CxC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sprRptFacturasResumidasBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Spr_Rpt_Facturas_ResumidasBindingSource
            // 
            this.Spr_Rpt_Facturas_ResumidasBindingSource.DataMember = "Spr_Rpt_Facturas_Resumidas";
            this.Spr_Rpt_Facturas_ResumidasBindingSource.DataSource = this.sGF_DataSet_CxC;
            this.Spr_Rpt_Facturas_ResumidasBindingSource.CurrentChanged += new System.EventHandler(this.Spr_Rpt_Facturas_ResumidasBindingSource_CurrentChanged);
            // 
            // sGF_DataSet_CxC
            // 
            this.sGF_DataSet_CxC.DataSetName = "SGF_DataSet_CxC";
            this.sGF_DataSet_CxC.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // sprRptFacturasResumidasBindingSource
            // 
            this.sprRptFacturasResumidasBindingSource.DataMember = "Spr_Rpt_Facturas_Resumidas";
            this.sprRptFacturasResumidasBindingSource.DataSource = this.sGF_DataSet_CxC;
            this.sprRptFacturasResumidasBindingSource.CurrentChanged += new System.EventHandler(this.sprRptFacturasResumidasBindingSource_CurrentChanged);
            // 
            // spr_Rpt_Facturas_ResumidasTableAdapter
            // 
            this.spr_Rpt_Facturas_ResumidasTableAdapter.ClearBeforeFill = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbEstatus);
            this.panel1.Controls.Add(this.txtCliente);
            this.panel1.Controls.Add(this.btnActualizar);
            this.panel1.Controls.Add(this.FechaHasta);
            this.panel1.Controls.Add(this.FechaDesde);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 523);
            this.panel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Estatus";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Fecha Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Fecha Desde";
            // 
            // cmbEstatus
            // 
            this.cmbEstatus.FormattingEnabled = true;
            this.cmbEstatus.Items.AddRange(new object[] {
            "",
            "Guardada",
            "Cerrada"});
            this.cmbEstatus.Location = new System.Drawing.Point(6, 174);
            this.cmbEstatus.Name = "cmbEstatus";
            this.cmbEstatus.Size = new System.Drawing.Size(121, 21);
            this.cmbEstatus.TabIndex = 11;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(6, 126);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(121, 20);
            this.txtCliente.TabIndex = 3;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(6, 228);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(121, 24);
            this.btnActualizar.TabIndex = 2;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FechaHasta
            // 
            this.FechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaHasta.Location = new System.Drawing.Point(6, 78);
            this.FechaHasta.Name = "FechaHasta";
            this.FechaHasta.Size = new System.Drawing.Size(121, 20);
            this.FechaHasta.TabIndex = 1;
            // 
            // FechaDesde
            // 
            this.FechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaDesde.Location = new System.Drawing.Point(6, 35);
            this.FechaDesde.Name = "FechaDesde";
            this.FechaDesde.Size = new System.Drawing.Size(121, 20);
            this.FechaDesde.TabIndex = 0;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.Spr_Rpt_Facturas_ResumidasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "aPrestentationLayer.CxC_Ventas.Reportes.General.Rpt_Facturas_Por_Estatus.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(142, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(672, 523);
            this.reportViewer1.TabIndex = 2;
            // 
            // Frm_Rpt_Facturas_Por_Estatus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 523);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_Rpt_Facturas_Por_Estatus";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Rpt_Facturas_Por_Estatus";
            this.Load += new System.EventHandler(this.Frm_Rpt_Facturas_Por_Estatus_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Spr_Rpt_Facturas_ResumidasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sGF_DataSet_CxC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sprRptFacturasResumidasBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource sprRptFacturasResumidasBindingSource;
        private SGF_DataSet_CxC sGF_DataSet_CxC;
        private SGF_DataSet_CxCTableAdapters.Spr_Rpt_Facturas_ResumidasTableAdapter spr_Rpt_Facturas_ResumidasTableAdapter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DateTimePicker FechaHasta;
        private System.Windows.Forms.DateTimePicker FechaDesde;
        private System.Windows.Forms.BindingSource Spr_Rpt_Facturas_ResumidasBindingSource;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.ComboBox cmbEstatus;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}