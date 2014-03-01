namespace ReportLayer.Administracion.Listados
{
    partial class Frm_Rpt_Gastos
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
            this.sprSearchGastosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sGFDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sGFDataSet = new ReportLayer.SGFDataSet();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtTipo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.FechaHasta = new System.Windows.Forms.DateTimePicker();
            this.FechaDesde = new System.Windows.Forms.DateTimePicker();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.Spr_Search_GastosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.spr_Search_GastosTableAdapter = new ReportLayer.SGFDataSetTableAdapters.Spr_Search_GastosTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sprSearchGastosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sGFDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sGFDataSet)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spr_Search_GastosBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // sprSearchGastosBindingSource
            // 
            this.sprSearchGastosBindingSource.DataMember = "Spr_Search_Gastos";
            this.sprSearchGastosBindingSource.DataSource = this.sGFDataSetBindingSource;
            // 
            // sGFDataSetBindingSource
            // 
            this.sGFDataSetBindingSource.DataSource = this.sGFDataSet;
            this.sGFDataSetBindingSource.Position = 0;
            // 
            // sGFDataSet
            // 
            this.sGFDataSet.DataSetName = "SGFDataSet";
            this.sGFDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.Controls.Add(this.txtTipo);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtCodigo);
            this.panel1.Controls.Add(this.btnActualizar);
            this.panel1.Controls.Add(this.FechaHasta);
            this.panel1.Controls.Add(this.FechaDesde);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(137, 488);
            this.panel1.TabIndex = 0;
            // 
            // txtTipo
            // 
            this.txtTipo.Location = new System.Drawing.Point(6, 381);
            this.txtTipo.Name = "txtTipo";
            this.txtTipo.Size = new System.Drawing.Size(121, 20);
            this.txtTipo.TabIndex = 25;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 365);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Tipo";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 317);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Codigo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Fecha Hasta";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 226);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Fecha Desde";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(6, 333);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(121, 20);
            this.txtCodigo.TabIndex = 19;
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(6, 435);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(121, 24);
            this.btnActualizar.TabIndex = 18;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // FechaHasta
            // 
            this.FechaHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaHasta.Location = new System.Drawing.Point(6, 285);
            this.FechaHasta.Name = "FechaHasta";
            this.FechaHasta.Size = new System.Drawing.Size(121, 20);
            this.FechaHasta.TabIndex = 17;
            // 
            // FechaDesde
            // 
            this.FechaDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.FechaDesde.Location = new System.Drawing.Point(6, 242);
            this.FechaDesde.Name = "FechaDesde";
            this.FechaDesde.Size = new System.Drawing.Size(121, 20);
            this.FechaDesde.TabIndex = 16;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sprSearchGastosBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportLayer.Administracion.Listados.Rpt_Gastos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(137, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(668, 488);
            this.reportViewer1.TabIndex = 1;
            // 
            // Spr_Search_GastosBindingSource
            // 
            this.Spr_Search_GastosBindingSource.DataMember = "Spr_Search_Gastos";
            this.Spr_Search_GastosBindingSource.DataSource = this.sGFDataSet;
            // 
            // spr_Search_GastosTableAdapter
            // 
            this.spr_Search_GastosTableAdapter.ClearBeforeFill = true;
            // 
            // Frm_Rpt_Gastos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 488);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.panel1);
            this.Name = "Frm_Rpt_Gastos";
            this.Text = "Frm_Rpt_Gastos";
            this.Load += new System.EventHandler(this.Frm_Rpt_Gastos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sprSearchGastosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sGFDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sGFDataSet)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Spr_Search_GastosBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingSource sGFDataSetBindingSource;
        private SGFDataSet sGFDataSet;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource Spr_Search_GastosBindingSource;
        private System.Windows.Forms.BindingSource sprSearchGastosBindingSource;
        private SGFDataSetTableAdapters.Spr_Search_GastosTableAdapter spr_Search_GastosTableAdapter;
        private System.Windows.Forms.TextBox txtTipo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DateTimePicker FechaHasta;
        private System.Windows.Forms.DateTimePicker FechaDesde;
    }
}