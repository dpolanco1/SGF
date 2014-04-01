namespace aPrestentationLayer.Comunes
{
    partial class Frm_MontoDevolver
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
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnOk = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMontoDevolver = new System.Windows.Forms.TextBox();
            this.txtMontoCobrado = new System.Windows.Forms.TextBox();
            this.txtMontoFactura = new System.Windows.Forms.TextBox();
            this.lblMontoDevolver = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnCancelar);
            this.tabPage1.Controls.Add(this.btnOk);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(276, 342);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Monto a Devolver";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(76, 278);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(80, 49);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtMontoDevolver);
            this.groupBox1.Controls.Add(this.txtMontoCobrado);
            this.groupBox1.Controls.Add(this.txtMontoFactura);
            this.groupBox1.Controls.Add(this.lblMontoDevolver);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 17);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(256, 255);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtMontoDevolver
            // 
            this.txtMontoDevolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoDevolver.Location = new System.Drawing.Point(16, 179);
            this.txtMontoDevolver.Name = "txtMontoDevolver";
            this.txtMontoDevolver.ReadOnly = true;
            this.txtMontoDevolver.Size = new System.Drawing.Size(218, 26);
            this.txtMontoDevolver.TabIndex = 5;
            // 
            // txtMontoCobrado
            // 
            this.txtMontoCobrado.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoCobrado.Location = new System.Drawing.Point(16, 112);
            this.txtMontoCobrado.Name = "txtMontoCobrado";
            this.txtMontoCobrado.Size = new System.Drawing.Size(218, 26);
            this.txtMontoCobrado.TabIndex = 0;
            this.txtMontoCobrado.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMontoCobrado_KeyPress);
            this.txtMontoCobrado.Validated += new System.EventHandler(this.txtMontoCobrado_Validated);
            // 
            // txtMontoFactura
            // 
            this.txtMontoFactura.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMontoFactura.Location = new System.Drawing.Point(16, 43);
            this.txtMontoFactura.Name = "txtMontoFactura";
            this.txtMontoFactura.ReadOnly = true;
            this.txtMontoFactura.Size = new System.Drawing.Size(218, 26);
            this.txtMontoFactura.TabIndex = 3;
            // 
            // lblMontoDevolver
            // 
            this.lblMontoDevolver.AutoSize = true;
            this.lblMontoDevolver.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMontoDevolver.Location = new System.Drawing.Point(16, 152);
            this.lblMontoDevolver.Name = "lblMontoDevolver";
            this.lblMontoDevolver.Size = new System.Drawing.Size(176, 24);
            this.lblMontoDevolver.TabIndex = 2;
            this.lblMontoDevolver.Text = "Monto A Devolver";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Monto Cobrado";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Monto De Factura";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(284, 368);
            this.tabControl1.TabIndex = 0;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(162, 278);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(79, 49);
            this.btnCancelar.TabIndex = 2;
            this.btnCancelar.Text = "Salir(Esc)";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Frm_MontoDevolver
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(284, 368);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "Frm_MontoDevolver";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.Activated += new System.EventHandler(this.Frm_MontoDevolver_Activated);
            this.Load += new System.EventHandler(this.Frm_MontoDevolver_Load);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMontoDevolver;
        private System.Windows.Forms.TextBox txtMontoCobrado;
        private System.Windows.Forms.TextBox txtMontoFactura;
        private System.Windows.Forms.Label lblMontoDevolver;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancelar;
    }
}