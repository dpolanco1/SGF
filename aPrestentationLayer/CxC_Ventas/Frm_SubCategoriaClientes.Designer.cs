namespace aPrestentationLayer.CxC_Ventas
{
    partial class Frm_SubCategoriaClientes
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpMaster = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtNota = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblnota = new System.Windows.Forms.Label();
            this.lblnombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpDetail = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGV_SubCategoriaClientes = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tbpMaster.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tbpDetail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SubCategoriaClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbpMaster);
            this.tabControl1.Controls.Add(this.tbpDetail);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(605, 377);
            this.tabControl1.TabIndex = 3;
            // 
            // tbpMaster
            // 
            this.tbpMaster.Controls.Add(this.groupBox1);
            this.tbpMaster.Location = new System.Drawing.Point(4, 22);
            this.tbpMaster.Name = "tbpMaster";
            this.tbpMaster.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMaster.Size = new System.Drawing.Size(597, 351);
            this.tbpMaster.TabIndex = 0;
            this.tbpMaster.Text = "Sub Categoria de Clientes";
            this.tbpMaster.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtNota);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtCodigo);
            this.groupBox1.Controls.Add(this.lblnota);
            this.groupBox1.Controls.Add(this.lblnombre);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 30);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(541, 274);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // txtNota
            // 
            this.txtNota.Location = new System.Drawing.Point(75, 112);
            this.txtNota.Multiline = true;
            this.txtNota.Name = "txtNota";
            this.txtNota.Size = new System.Drawing.Size(357, 112);
            this.txtNota.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(75, 70);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(165, 20);
            this.txtNombre.TabIndex = 4;
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(75, 26);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(165, 20);
            this.txtCodigo.TabIndex = 3;
            // 
            // lblnota
            // 
            this.lblnota.AutoSize = true;
            this.lblnota.Location = new System.Drawing.Point(16, 158);
            this.lblnota.Name = "lblnota";
            this.lblnota.Size = new System.Drawing.Size(30, 13);
            this.lblnota.TabIndex = 2;
            this.lblnota.Text = "Nota";
            // 
            // lblnombre
            // 
            this.lblnombre.AutoSize = true;
            this.lblnombre.Location = new System.Drawing.Point(16, 73);
            this.lblnombre.Name = "lblnombre";
            this.lblnombre.Size = new System.Drawing.Size(44, 13);
            this.lblnombre.TabIndex = 1;
            this.lblnombre.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Codigo";
            // 
            // tbpDetail
            // 
            this.tbpDetail.Controls.Add(this.groupBox3);
            this.tbpDetail.Controls.Add(this.groupBox2);
            this.tbpDetail.Location = new System.Drawing.Point(4, 22);
            this.tbpDetail.Name = "tbpDetail";
            this.tbpDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDetail.Size = new System.Drawing.Size(597, 351);
            this.tbpDetail.TabIndex = 1;
            this.tbpDetail.Text = "Sub Categoria de Clientes";
            this.tbpDetail.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(8, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(570, 50);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscar";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGV_SubCategoriaClientes);
            this.groupBox2.Location = new System.Drawing.Point(8, 83);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(570, 260);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // DGV_SubCategoriaClientes
            // 
            this.DGV_SubCategoriaClientes.AllowUserToAddRows = false;
            this.DGV_SubCategoriaClientes.AllowUserToDeleteRows = false;
            this.DGV_SubCategoriaClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_SubCategoriaClientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Nombre,
            this.Nota});
            this.DGV_SubCategoriaClientes.Location = new System.Drawing.Point(6, 19);
            this.DGV_SubCategoriaClientes.Name = "DGV_SubCategoriaClientes";
            this.DGV_SubCategoriaClientes.ReadOnly = true;
            this.DGV_SubCategoriaClientes.Size = new System.Drawing.Size(551, 235);
            this.DGV_SubCategoriaClientes.TabIndex = 1;
            this.DGV_SubCategoriaClientes.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_SubCategoriaClientes_CellContentDoubleClick);
            // 
            // Codigo
            // 
            this.Codigo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Codigo.DataPropertyName = "Codigo";
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nombre.DataPropertyName = "Nombre";
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Nota
            // 
            this.Nota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Nota.DataPropertyName = "Nota";
            this.Nota.HeaderText = "Nota";
            this.Nota.Name = "Nota";
            this.Nota.ReadOnly = true;
            // 
            // Frm_SubCategoriaClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 402);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_SubCategoriaClientes";
            this.Text = "SubCategoria de Clientes";
            this.Load += new System.EventHandler(this.Frm_SubCategoriaClientes_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tbpMaster.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tbpDetail.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_SubCategoriaClientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpMaster;
        private System.Windows.Forms.TabPage tbpDetail;
        private System.Windows.Forms.TextBox txtNota;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblnota;
        private System.Windows.Forms.Label lblnombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DGV_SubCategoriaClientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nota;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}