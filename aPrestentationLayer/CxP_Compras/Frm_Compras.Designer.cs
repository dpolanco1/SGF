namespace aPrestentationLayer.CxP_Compras
{
    partial class Frm_Compras
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_Compras));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbpMaster = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.LblBuscarArticulo = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtArticulo = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.txtTotalCompra = new System.Windows.Forms.TextBox();
            this.txtTotalDescuento = new System.Windows.Forms.TextBox();
            this.txtTotalImpuesto = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.DGV_DetailCompra = new System.Windows.Forms.DataGridView();
            this.Articulo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalLinea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblBuscarSuplidor = new System.Windows.Forms.Label();
            this.LblBuscarAlmacen = new System.Windows.Forms.Label();
            this.txtAlmacen = new System.Windows.Forms.TextBox();
            this.nudDescuento = new System.Windows.Forms.NumericUpDown();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtSuplidor = new System.Windows.Forms.TextBox();
            this.txtNoCompra = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbpDetail = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.DGV_Compras_List = new System.Windows.Forms.DataGridView();
            this.Numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Suplidor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Almacen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Descuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalImpuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalDescuento = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1.SuspendLayout();
            this.tbpMaster.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DetailCompra)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).BeginInit();
            this.tbpDetail.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Compras_List)).BeginInit();
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
            this.tabControl1.Size = new System.Drawing.Size(837, 518);
            this.tabControl1.TabIndex = 3;
            // 
            // tbpMaster
            // 
            this.tbpMaster.Controls.Add(this.groupBox5);
            this.tbpMaster.Controls.Add(this.txtTotalCompra);
            this.tbpMaster.Controls.Add(this.txtTotalDescuento);
            this.tbpMaster.Controls.Add(this.txtTotalImpuesto);
            this.tbpMaster.Controls.Add(this.txtSubTotal);
            this.tbpMaster.Controls.Add(this.label8);
            this.tbpMaster.Controls.Add(this.label5);
            this.tbpMaster.Controls.Add(this.label3);
            this.tbpMaster.Controls.Add(this.label2);
            this.tbpMaster.Controls.Add(this.groupBox2);
            this.tbpMaster.Controls.Add(this.groupBox1);
            this.tbpMaster.Location = new System.Drawing.Point(4, 22);
            this.tbpMaster.Name = "tbpMaster";
            this.tbpMaster.Padding = new System.Windows.Forms.Padding(3);
            this.tbpMaster.Size = new System.Drawing.Size(829, 492);
            this.tbpMaster.TabIndex = 0;
            this.tbpMaster.Text = "Compras";
            this.tbpMaster.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox5.Controls.Add(this.LblBuscarArticulo);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.btnBorrar);
            this.groupBox5.Controls.Add(this.btnAgregar);
            this.groupBox5.Controls.Add(this.txtCantidad);
            this.groupBox5.Controls.Add(this.txtCosto);
            this.groupBox5.Controls.Add(this.txtDescripcion);
            this.groupBox5.Controls.Add(this.txtArticulo);
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Location = new System.Drawing.Point(18, 173);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(786, 53);
            this.groupBox5.TabIndex = 17;
            this.groupBox5.TabStop = false;
            // 
            // LblBuscarArticulo
            // 
            this.LblBuscarArticulo.Image = ((System.Drawing.Image)(resources.GetObject("LblBuscarArticulo.Image")));
            this.LblBuscarArticulo.Location = new System.Drawing.Point(151, 26);
            this.LblBuscarArticulo.Name = "LblBuscarArticulo";
            this.LblBuscarArticulo.Size = new System.Drawing.Size(23, 20);
            this.LblBuscarArticulo.TabIndex = 18;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(177, 10);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(63, 13);
            this.label15.TabIndex = 9;
            this.label15.Text = "Descripcion";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(347, 10);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(34, 13);
            this.label16.TabIndex = 8;
            this.label16.Text = "Costo";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(483, 10);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(49, 13);
            this.label17.TabIndex = 7;
            this.label17.Text = "Cantidad";
            // 
            // btnBorrar
            // 
            this.btnBorrar.Location = new System.Drawing.Point(705, 19);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(68, 27);
            this.btnBorrar.TabIndex = 6;
            this.btnBorrar.Text = "Borrar";
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(631, 19);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(68, 27);
            this.btnAgregar.TabIndex = 10;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(486, 26);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(128, 20);
            this.txtCantidad.TabIndex = 9;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtCosto
            // 
            this.txtCosto.Location = new System.Drawing.Point(350, 26);
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.Size = new System.Drawing.Size(130, 20);
            this.txtCosto.TabIndex = 8;
            this.txtCosto.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(180, 26);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(164, 20);
            this.txtDescripcion.TabIndex = 7;
            // 
            // txtArticulo
            // 
            this.txtArticulo.Location = new System.Drawing.Point(15, 26);
            this.txtArticulo.Name = "txtArticulo";
            this.txtArticulo.Size = new System.Drawing.Size(131, 20);
            this.txtArticulo.TabIndex = 6;
            this.txtArticulo.Validating += new System.ComponentModel.CancelEventHandler(this.txtArticulo_Validating);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 11);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(42, 13);
            this.label18.TabIndex = 0;
            this.label18.Text = "Articulo";
            // 
            // txtTotalCompra
            // 
            this.txtTotalCompra.Location = new System.Drawing.Point(556, 453);
            this.txtTotalCompra.Name = "txtTotalCompra";
            this.txtTotalCompra.Size = new System.Drawing.Size(144, 20);
            this.txtTotalCompra.TabIndex = 15;
            // 
            // txtTotalDescuento
            // 
            this.txtTotalDescuento.Location = new System.Drawing.Point(362, 453);
            this.txtTotalDescuento.Name = "txtTotalDescuento";
            this.txtTotalDescuento.Size = new System.Drawing.Size(144, 20);
            this.txtTotalDescuento.TabIndex = 14;
            // 
            // txtTotalImpuesto
            // 
            this.txtTotalImpuesto.Location = new System.Drawing.Point(193, 453);
            this.txtTotalImpuesto.Name = "txtTotalImpuesto";
            this.txtTotalImpuesto.Size = new System.Drawing.Size(144, 20);
            this.txtTotalImpuesto.TabIndex = 13;
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(35, 453);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.Size = new System.Drawing.Size(135, 20);
            this.txtSubTotal.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(553, 437);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Total Compra";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(359, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Total Descuento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(190, 437);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Total Impuesto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 437);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "SubTotal";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.DGV_DetailCompra);
            this.groupBox2.Location = new System.Drawing.Point(18, 214);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(786, 210);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle";
            // 
            // DGV_DetailCompra
            // 
            this.DGV_DetailCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_DetailCompra.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Articulo,
            this.Descripcion,
            this.Precio,
            this.Cantidad,
            this.Impuesto,
            this.TotalLinea});
            this.DGV_DetailCompra.Location = new System.Drawing.Point(17, 18);
            this.DGV_DetailCompra.Name = "DGV_DetailCompra";
            this.DGV_DetailCompra.Size = new System.Drawing.Size(756, 183);
            this.DGV_DetailCompra.TabIndex = 0;
            this.DGV_DetailCompra.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_DetailCompra_CellEndEdit);
            this.DGV_DetailCompra.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DGV_DetailCompra_EditingControlShowing);
            // 
            // Articulo
            // 
            this.Articulo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Articulo.DataPropertyName = "Articulo";
            this.Articulo.HeaderText = "Articulo";
            this.Articulo.Name = "Articulo";
            // 
            // Descripcion
            // 
            this.Descripcion.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descripcion.DataPropertyName = "Descripcion";
            this.Descripcion.HeaderText = "Descripcion";
            this.Descripcion.Name = "Descripcion";
            // 
            // Precio
            // 
            this.Precio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Precio.DataPropertyName = "Precio";
            this.Precio.HeaderText = "Costo";
            this.Precio.Name = "Precio";
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Impuesto
            // 
            this.Impuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Impuesto.DataPropertyName = "Impuesto";
            this.Impuesto.HeaderText = "Impuesto";
            this.Impuesto.Name = "Impuesto";
            // 
            // TotalLinea
            // 
            this.TotalLinea.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalLinea.DataPropertyName = "TotalLinea";
            this.TotalLinea.HeaderText = "Total";
            this.TotalLinea.Name = "TotalLinea";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblBuscarSuplidor);
            this.groupBox1.Controls.Add(this.LblBuscarAlmacen);
            this.groupBox1.Controls.Add(this.txtAlmacen);
            this.groupBox1.Controls.Add(this.nudDescuento);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.txtSuplidor);
            this.groupBox1.Controls.Add(this.txtNoCompra);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(18, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(786, 127);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Datos Generales";
            // 
            // LblBuscarSuplidor
            // 
            this.LblBuscarSuplidor.Image = ((System.Drawing.Image)(resources.GetObject("LblBuscarSuplidor.Image")));
            this.LblBuscarSuplidor.Location = new System.Drawing.Point(222, 53);
            this.LblBuscarSuplidor.Name = "LblBuscarSuplidor";
            this.LblBuscarSuplidor.Size = new System.Drawing.Size(23, 20);
            this.LblBuscarSuplidor.TabIndex = 19;
            this.LblBuscarSuplidor.Click += new System.EventHandler(this.LblBuscarSuplidor_Click);
            // 
            // LblBuscarAlmacen
            // 
            this.LblBuscarAlmacen.Image = ((System.Drawing.Image)(resources.GetObject("LblBuscarAlmacen.Image")));
            this.LblBuscarAlmacen.Location = new System.Drawing.Point(569, 49);
            this.LblBuscarAlmacen.Name = "LblBuscarAlmacen";
            this.LblBuscarAlmacen.Size = new System.Drawing.Size(23, 20);
            this.LblBuscarAlmacen.TabIndex = 18;
            this.LblBuscarAlmacen.Click += new System.EventHandler(this.LblBuscarAlmacen_Click);
            // 
            // txtAlmacen
            // 
            this.txtAlmacen.Location = new System.Drawing.Point(423, 49);
            this.txtAlmacen.Name = "txtAlmacen";
            this.txtAlmacen.Size = new System.Drawing.Size(140, 20);
            this.txtAlmacen.TabIndex = 4;
            // 
            // nudDescuento
            // 
            this.nudDescuento.Location = new System.Drawing.Point(423, 78);
            this.nudDescuento.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nudDescuento.Name = "nudDescuento";
            this.nudDescuento.Size = new System.Drawing.Size(176, 20);
            this.nudDescuento.TabIndex = 5;
            this.nudDescuento.Validating += new System.ComponentModel.CancelEventHandler(this.nudDescuento_Validating);
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(423, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(142, 20);
            this.dtpFecha.TabIndex = 3;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(369, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 13);
            this.label11.TabIndex = 3;
            this.label11.Text = "Almacen";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(72, 82);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(217, 20);
            this.txtNombre.TabIndex = 2;
            // 
            // txtSuplidor
            // 
            this.txtSuplidor.Location = new System.Drawing.Point(72, 53);
            this.txtSuplidor.Name = "txtSuplidor";
            this.txtSuplidor.Size = new System.Drawing.Size(144, 20);
            this.txtSuplidor.TabIndex = 1;
            // 
            // txtNoCompra
            // 
            this.txtNoCompra.Location = new System.Drawing.Point(72, 24);
            this.txtNoCompra.Name = "txtNoCompra";
            this.txtNoCompra.Size = new System.Drawing.Size(144, 20);
            this.txtNoCompra.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(358, 85);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(59, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "Descuento";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(22, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Suplidor";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(22, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Numero";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha";
            // 
            // tbpDetail
            // 
            this.tbpDetail.Controls.Add(this.groupBox4);
            this.tbpDetail.Controls.Add(this.groupBox3);
            this.tbpDetail.Location = new System.Drawing.Point(4, 22);
            this.tbpDetail.Name = "tbpDetail";
            this.tbpDetail.Padding = new System.Windows.Forms.Padding(3);
            this.tbpDetail.Size = new System.Drawing.Size(829, 492);
            this.tbpDetail.TabIndex = 1;
            this.tbpDetail.Text = "Compras";
            this.tbpDetail.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.DGV_Compras_List);
            this.groupBox4.Location = new System.Drawing.Point(8, 97);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(727, 359);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // DGV_Compras_List
            // 
            this.DGV_Compras_List.AllowUserToAddRows = false;
            this.DGV_Compras_List.AllowUserToDeleteRows = false;
            this.DGV_Compras_List.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_Compras_List.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Numero,
            this.Suplidor,
            this.Fecha,
            this.Almacen,
            this.Descuento,
            this.SubTotal,
            this.TotalImpuesto,
            this.TotalDescuento,
            this.TotalCompra});
            this.DGV_Compras_List.Location = new System.Drawing.Point(6, 19);
            this.DGV_Compras_List.Name = "DGV_Compras_List";
            this.DGV_Compras_List.ReadOnly = true;
            this.DGV_Compras_List.Size = new System.Drawing.Size(715, 318);
            this.DGV_Compras_List.TabIndex = 0;
            this.DGV_Compras_List.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_Compras_List_CellContentDoubleClick);
            // 
            // Numero
            // 
            this.Numero.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Numero.DataPropertyName = "Numero";
            this.Numero.HeaderText = "Numero";
            this.Numero.Name = "Numero";
            this.Numero.ReadOnly = true;
            // 
            // Suplidor
            // 
            this.Suplidor.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Suplidor.DataPropertyName = "Suplidor";
            this.Suplidor.HeaderText = "Suplidor";
            this.Suplidor.Name = "Suplidor";
            this.Suplidor.ReadOnly = true;
            // 
            // Fecha
            // 
            this.Fecha.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Fecha.DataPropertyName = "Fecha";
            this.Fecha.HeaderText = "Fecha";
            this.Fecha.Name = "Fecha";
            this.Fecha.ReadOnly = true;
            // 
            // Almacen
            // 
            this.Almacen.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Almacen.DataPropertyName = "Almacen";
            this.Almacen.HeaderText = "Almacen";
            this.Almacen.Name = "Almacen";
            this.Almacen.ReadOnly = true;
            // 
            // Descuento
            // 
            this.Descuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Descuento.DataPropertyName = "Descuento";
            this.Descuento.HeaderText = "Descuento";
            this.Descuento.Name = "Descuento";
            this.Descuento.ReadOnly = true;
            // 
            // SubTotal
            // 
            this.SubTotal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.SubTotal.DataPropertyName = "SubTotal";
            this.SubTotal.HeaderText = "SubTotal";
            this.SubTotal.Name = "SubTotal";
            this.SubTotal.ReadOnly = true;
            // 
            // TotalImpuesto
            // 
            this.TotalImpuesto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalImpuesto.DataPropertyName = "TotalImpuesto";
            this.TotalImpuesto.HeaderText = "TotalImpuesto";
            this.TotalImpuesto.Name = "TotalImpuesto";
            this.TotalImpuesto.ReadOnly = true;
            // 
            // TotalDescuento
            // 
            this.TotalDescuento.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalDescuento.DataPropertyName = "TotalDescuento";
            this.TotalDescuento.HeaderText = "TotalDescuento";
            this.TotalDescuento.Name = "TotalDescuento";
            this.TotalDescuento.ReadOnly = true;
            // 
            // TotalCompra
            // 
            this.TotalCompra.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.TotalCompra.DataPropertyName = "TotalCompra";
            this.TotalCompra.HeaderText = "TotalCompra";
            this.TotalCompra.Name = "TotalCompra";
            this.TotalCompra.ReadOnly = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(8, 20);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(727, 58);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Buscar";
            // 
            // Frm_Compras
            // 
            this.AcceptButton = this.btnAgregar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(837, 543);
            this.Controls.Add(this.tabControl1);
            this.Name = "Frm_Compras";
            this.Text = "Compras";
            this.Load += new System.EventHandler(this.Frm_Compras_Load);
            this.Controls.SetChildIndex(this.tabControl1, 0);
            this.tabControl1.ResumeLayout(false);
            this.tbpMaster.ResumeLayout(false);
            this.tbpMaster.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_DetailCompra)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDescuento)).EndInit();
            this.tbpDetail.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_Compras_List)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tbpMaster;
        private System.Windows.Forms.TextBox txtTotalCompra;
        private System.Windows.Forms.TextBox txtTotalDescuento;
        private System.Windows.Forms.TextBox txtTotalImpuesto;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView DGV_DetailCompra;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAlmacen;
        private System.Windows.Forms.NumericUpDown nudDescuento;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtSuplidor;
        private System.Windows.Forms.TextBox txtNoCompra;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tbpDetail;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView DGV_Compras_List;
        private System.Windows.Forms.DataGridViewTextBoxColumn Numero;
        private System.Windows.Forms.DataGridViewTextBoxColumn Suplidor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn Almacen;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubTotal;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalImpuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalDescuento;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn Articulo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalLinea;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtArticulo;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label LblBuscarArticulo;
        private System.Windows.Forms.Label LblBuscarSuplidor;
        private System.Windows.Forms.Label LblBuscarAlmacen;

    }
}