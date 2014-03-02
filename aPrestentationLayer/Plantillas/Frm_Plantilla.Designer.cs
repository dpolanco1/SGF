namespace aPrestentationLayer.Plantillas
{
    partial class Frm_Plantilla
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
            this.toolBarsPrincipal = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnGuardar = new System.Windows.Forms.ToolStripButton();
            this.btnEditar = new System.Windows.Forms.ToolStripButton();
            this.btnCancelar = new System.Windows.Forms.ToolStripButton();
            this.btnEliminar = new System.Windows.Forms.ToolStripButton();
            this.btnVista = new System.Windows.Forms.ToolStripButton();
            this.btnImprimir = new System.Windows.Forms.ToolStripButton();
            this.toolBarsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBarsPrincipal
            // 
            this.toolBarsPrincipal.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolBarsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnGuardar,
            this.btnEditar,
            this.btnCancelar,
            this.btnEliminar,
            this.btnVista,
            this.btnImprimir});
            this.toolBarsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.toolBarsPrincipal.Name = "toolBarsPrincipal";
            this.toolBarsPrincipal.Size = new System.Drawing.Size(723, 39);
            this.toolBarsPrincipal.TabIndex = 2;
            this.toolBarsPrincipal.Text = "toolStrip1";
            this.toolBarsPrincipal.KeyDown += new System.Windows.Forms.KeyEventHandler(this.toolBarsPrincipal_KeyDown);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::aPrestentationLayer.Properties.Resources.add;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(78, 36);
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::aPrestentationLayer.Properties.Resources.save;
            this.btnGuardar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(85, 36);
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Image = global::aPrestentationLayer.Properties.Resources.Edit;
            this.btnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(73, 36);
            this.btnEditar.Text = "Editar";
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Image = global::aPrestentationLayer.Properties.Resources.Cancel;
            this.btnCancelar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(89, 36);
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Image = global::aPrestentationLayer.Properties.Resources.Delete;
            this.btnEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 36);
            this.btnEliminar.Text = "Eliminar";
            // 
            // btnVista
            // 
            this.btnVista.Image = global::aPrestentationLayer.Properties.Resources.Search2;
            this.btnVista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVista.Name = "btnVista";
            this.btnVista.Size = new System.Drawing.Size(68, 36);
            this.btnVista.Text = "Vista";
            this.btnVista.Click += new System.EventHandler(this.btnVista_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Image = global::aPrestentationLayer.Properties.Resources.print;
            this.btnImprimir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(89, 36);
            this.btnImprimir.Text = "Imprimir";
            // 
            // Frm_Plantilla
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(723, 341);
            this.Controls.Add(this.toolBarsPrincipal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Frm_Plantilla";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Frm_Plantilla";
            this.Load += new System.EventHandler(this.Frm_Plantilla_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Frm_Plantilla_KeyDown);
            this.toolBarsPrincipal.ResumeLayout(false);
            this.toolBarsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected System.Windows.Forms.ToolStripButton btnNuevo;
        protected System.Windows.Forms.ToolStripButton btnGuardar;
        protected System.Windows.Forms.ToolStripButton btnEditar;
        protected System.Windows.Forms.ToolStripButton btnCancelar;
        protected System.Windows.Forms.ToolStripButton btnEliminar;
        protected System.Windows.Forms.ToolStripButton btnVista;
        protected System.Windows.Forms.ToolStripButton btnImprimir;
        protected System.Windows.Forms.ToolStrip toolBarsPrincipal;
    }
}