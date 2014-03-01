namespace aPrestentationLayer.CxC_Ventas
{
    partial class Frm_Recibos
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpMaster = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGV_DocumentosPendientes = new System.Windows.Forms.DataGridView();
            this.Cliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Factura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalFactura = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalPagado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BalancePendiente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Monto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblBuscarCaja = new System.Windows.Forms.Label();
            this.LblBuscarModePago = new System.Windows.Forms.Label();
            this.LblBuscarCliente = new System.Windows.Forms.Label();
            this.txtCaja = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtMododePago = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtReferencia = new System.Windows.Forms.TextBox();
            this.nudMonto = new System.Windows.Forms.NumericUpDown();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtCliente = new System.Windows.Forms.TextBox();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpDetail = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.DGV_Recibos = new System.Windows.Forms.DataGridView();
            this.NumeroList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ClienteList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Referencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MododePago = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MontoList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1.SuspendLayout();
            this.tbpMaster.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DocumentosPendientes)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).BeginInit();
            this.tbpDetail.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Recibos)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(765, 469);
            this.tabControl1.TabIndex = 3;
            // 
            // tbpMaster
            // 
            this.tbpMaster.Controls.Add(this.groupBox2);
            this.tbpMaster.Controls.Add(this.groupBox1);
            this.tbpMaster.Location = new System.Drawing.Point(4, 22);
            this.tbpMaster.Name = "tbpMaster";
            this.tbpMaster.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMaster.Size = new System.Drawing.Size(757, 443);
            this.tbpMaster.TabIndex = 0;
            this.tbpMaster.Text = "Recibos";
            this.tbpMaster.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGV_DocumentosPendientes);
            this.groupBox2.Location = new System.Drawing.Point(11, 218);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(664, 194);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Documentos Pendientes";
            // 
            // DGV_DocumentosPendientes
            // 
            this.DGV_DocumentosPendientes.AllowUserToOrderColumns = true;
            this.DGV_DocumentosPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DocumentosPendientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Cliente,
            this.Fecha,
            this.Factura,
            this.TotalFactura,
            this.TotalPagado,
            this.BalancePendiente,
            this.Monto});
            this.DGV_DocumentosPendientes.Location = new System.Drawing.Point(6, 19);
            this.DGV_DocumentosPendientes.Name = "DGV_DocumentosPendientes";
            this.DGV_DocumentosPendientes.Size = new System.Drawing.Size(652, 158);
            this.DGV_DocumentosPendientes.TabIndex = 6;
            // 
            // Cliente
            // 
            this.Cliente.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cliente.DataPropertyName = "Cliente";
            this.Cliente.HeaderText = "Cliente";
            this.Cliente.Name = "Cliente";
            this.Cliente.Visible = false;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.Format = "d";
            dataGridViewCellStyle3.NullValue = null;
            this.Fecha.DefaultCellStyle = dataGridViewCellStyle3;
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Factura
            // 
            this.Factura.DataPropertyName = "Numero";
            this.Factura.HeaderText = "No. Factura";
            this.Factura.Name = "Factura";
            this.Factura.ReadOnly = true;
            // 
            // TotalFactura
            // 
            this.TotalFactura.DataPropertyName = "TotalFactura";
            this.TotalFactura.HeaderText = "Monto Factura";
            this.TotalFactura.Name = "TotalFactura";
            this.TotalFactura.ReadOnly = true;
            // 
            // TotalPagado
            // 
            this.TotalPagado.DataPropertyName = "TotalPagado";
            this.TotalPagado.HeaderText = "Monto Pagado";
            this.TotalPagado.Name = "TotalPagado";
            this.TotalPagado.ReadOnly = true;
            // 
            // BalancePendiente
            // 
            this.BalancePendiente.DataPropertyName = "BalancePendiente";
            this.BalancePendiente.HeaderText = "Balance Pendiente";
            this.BalancePendiente.Name = "BalancePendiente";
            this.BalancePendiente.ReadOnly = true;
            // 
            // Monto
            // 
            this.Monto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Monto.DataPropertyName = "MontoAplicar";
            this.Monto.HeaderText = "Monto Aplicar";
            this.Monto.Name = "Monto";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblBuscarCaja);
            this.groupBox1.Controls.Add(this.LblBuscarModePago);
            this.groupBox1.Controls.Add(this.LblBuscarCliente);
            this.groupBox1.Controls.Add(this.txtCaja);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtMododePago);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtReferencia);
            this.groupBox1.Controls.Add(this.nudMonto);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtCliente);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(8, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(667, 173);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            // 
            // LblBuscarCaja
            // 
            this.LblBuscarCaja.Image = global::aPrestentationLayer.Properties.Resources.Buscar;
            this.LblBuscarCaja.Location = new System.Drawing.Point(570, 142);
            this.LblBuscarCaja.Name = "LblBuscarCaja";
            this.LblBuscarCaja.Size = new System.Drawing.Size(23, 20);
            this.LblBuscarCaja.TabIndex = 19;
            // 
            // LblBuscarModePago
            // 
            this.LblBuscarModePago.Image = global::aPrestentationLayer.Properties.Resources.Buscar;
            this.LblBuscarModePago.Location = new System.Drawing.Point(570, 25);
            this.LblBuscarModePago.Name = "LblBuscarModePago";
            this.LblBuscarModePago.Size = new System.Drawing.Size(23, 20);
            this.LblBuscarModePago.TabIndex = 18;
            this.LblBuscarModePago.Click += new System.EventHandler(this.LblBuscarModePago_Click);
            // 
            // LblBuscarCliente
            // 
            this.LblBuscarCliente.Image = global::aPrestentationLayer.Properties.Resources.Buscar;
            this.LblBuscarCliente.Location = new System.Drawing.Point(220, 67);
            this.LblBuscarCliente.Name = "LblBuscarCliente";
            this.LblBuscarCliente.Size = new System.Drawing.Size(23, 20);
            this.LblBuscarCliente.TabIndex = 18;
            // 
            // txtCaja
            // 
            this.txtCaja.Location = new System.Drawing.Point(406, 142);
            this.txtCaja.Name = "txtCaja";
            this.txtCaja.Size = new System.Drawing.Size(158, 20);
            this.txtCaja.TabIndex = 10;
            this.txtCaja.Text = "Pendiente de Agregar";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(335, 145);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(28, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Caja";
            // 
            // txtMododePago
            // 
            this.txtMododePago.Location = new System.Drawing.Point(405, 25);
            this.txtMododePago.Name = "txtMododePago";
            this.txtMododePago.Size = new System.Drawing.Size(159, 20);
            this.txtMododePago.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(317, 28);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Modo de Pago";
            // 
            // txtReferencia
            // 
            this.txtReferencia.Location = new System.Drawing.Point(405, 67);
            this.txtReferencia.Name = "txtReferencia";
            this.txtReferencia.Size = new System.Drawing.Size(188, 20);
            this.txtReferencia.TabIndex = 4;
            // 
            // nudMonto
            // 
            this.nudMonto.Location = new System.Drawing.Point(405, 106);
            this.nudMonto.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.nudMonto.Name = "nudMonto";
            this.nudMonto.Size = new System.Drawing.Size(188, 20);
            this.nudMonto.TabIndex = 5;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(83, 139);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(159, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(83, 102);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(159, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtCliente
            // 
            this.txtCliente.Location = new System.Drawing.Point(83, 67);
            this.txtCliente.Name = "txtCliente";
            this.txtCliente.Size = new System.Drawing.Size(134, 20);
            this.txtCliente.TabIndex = 1;
            this.txtCliente.Validated += new System.EventHandler(this.txtCliente_Validated);
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(83, 28);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(160, 20);
            this.txtNumero.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(335, 70);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(59, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Referencia";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(335, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Monto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fecha";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero";
            // 
            // tbpDetail
            // 
            this.tbpDetail.Controls.Add(this.groupBox4);
            this.tbpDetail.Controls.Add(this.groupBox3);
            this.tbpDetail.Location = new System.Drawing.Point(4, 22);
            this.tbpDetail.Name = "tbpDetail";
            this.tbpDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDetail.Size = new System.Drawing.Size(757, 443);
            this.tbpDetail.TabIndex = 1;
            this.tbpDetail.Text = "Recibos";
            this.tbpDetail.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(14, 34);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(710, 50);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Buscar";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.DGV_Recibos);
            this.groupBox3.Location = new System.Drawing.Point(8, 102);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(716, 338);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            // 
            // DGV_Recibos
            // 
            this.DGV_Recibos.AllowUserToAddRows = false;
            this.DGV_Recibos.AllowUserToDeleteRows = false;
            this.DGV_Recibos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Recibos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NumeroList,
            this.ClienteList,
            this.FechaList,
            this.Referencia,
            this.MododePago,
            this.MontoList});
            this.DGV_Recibos.Location = new System.Drawing.Point(6, 19);
            this.DGV_Recibos.Name = "DGV_Recibos";
            this.DGV_Recibos.ReadOnly = true;
            this.DGV_Recibos.Size = new System.Drawing.Size(693, 299);
            this.DGV_Recibos.TabIndex = 0;
            this.DGV_Recibos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Recibos_CellContentDoubleClick);
            // 
            // NumeroList
            // 
            this.NumeroList.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NumeroList.DataPropertyName = "Numero";
            this.NumeroList.HeaderText = "Numero";
            this.NumeroList.Name = "NumeroList";
            this.NumeroList.ReadOnly = true;
            // 
            // ClienteList
            // 
            this.ClienteList.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ClienteList.DataPropertyName = "Cliente";
            this.ClienteList.HeaderText = "Cliente";
            this.ClienteList.Name = "ClienteList";
            this.ClienteList.ReadOnly = true;
            // 
            // FechaList
            // 
            this.FechaList.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FechaList.DataPropertyName = "Fecha";
            this.FechaList.HeaderText = "Fecha";
            this.FechaList.Name = "FechaList";
            this.FechaList.ReadOnly = true;
            // 
            // Referencia
            // 
            this.Referencia.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Referencia.DataPropertyName = "Referencia";
            this.Referencia.HeaderText = "Referencia";
            this.Referencia.Name = "Referencia";
            this.Referencia.ReadOnly = true;
            // 
            // MododePago
            // 
            this.MododePago.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MododePago.DataPropertyName = "MododePago";
            this.MododePago.HeaderText = "Modo De Pago";
            this.MododePago.Name = "MododePago";
            this.MododePago.ReadOnly = true;
            // 
            // MontoList
            // 
            this.MontoList.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MontoList.DataPropertyName = "Monto";
            this.MontoList.HeaderText = "Monto";
            this.MontoList.Name = "MontoList";
            this.MontoList.ReadOnly = true;
            // 
            // Frm_Recibos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 494);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_Recibos";
            this.Text = "Recibos";
            this.Load += new System.EventHandler(this.Frm_Recibos_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tbpMaster.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DocumentosPendientes)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMonto)).EndInit();
            this.tbpDetail.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Recibos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpMaster;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtReferencia;
        private System.Windows.Forms.NumericUpDown nudMonto;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtCliente;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbpDetail;
        private System.Windows.Forms.DataGridView DGV_DocumentosPendientes;
        private System.Windows.Forms.TextBox txtMododePago;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Factura;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalFactura;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalPagado;
        private System.Windows.Forms.DataGridViewTextBoxColumn BalancePendiente;
        private System.Windows.Forms.DataGridViewTextBoxColumn Monto;
        private System.Windows.Forms.TextBox txtCaja;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DGV_Recibos;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label LblBuscarCaja;
        private System.Windows.Forms.Label LblBuscarModePago;
        private System.Windows.Forms.Label LblBuscarCliente;
        private System.Windows.Forms.DataGridViewTextBoxColumn NumeroList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ClienteList;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Referencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn MododePago;
        private System.Windows.Forms.DataGridViewTextBoxColumn MontoList;
    }
}