using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using aPrestentationLayer.Plantillas;
using BusinessLogicLayer.Inventario;
using EntityLayer.Inventario;
using BusinessLogicLayer.Administracion;


namespace aPrestentationLayer.Inventario
{
    public partial class Frm_TransferenciaAlmacenes : Frm_Plantilla
    {

        string Estado = string.Empty;
        const string NUEVO = "Creando";
        const string EDITAR = "Editando";
        const string CONSULTA = "Consultando";

        Enl_TransfAlmacenesMaster enlTransfAlmacenesMaster = new Enl_TransfAlmacenesMaster();
        Bll_TransfAlmacenesMaster bllTransfAlmacenesMaster = new Bll_TransfAlmacenesMaster();



        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_TransferenciaAlmacenes()
        {
            InitializeComponent();
            btnNuevo.Click += btnNuevo_Click;
            btnGuardar.Click += btnGuardar_Click;
            btnEditar.Click += btnEditar_Click;
            btnCancelar.Click += btnCancelar_Click;
            btnEliminar.Click += btnEliminar_Click;
         
            
        }


        void btnNuevo_Click(object sender, EventArgs e)
        {
            Estado = NUEVO;
            if (bllNumeracion.ObtenerTipo("Tranferencia de Almacenes") == "Automatico")
            {
                txtNumero.Enabled = false;
                txtNumero.Focus();
            }
            else
            {
                txtNumero.Enabled = true;
                txtNumero.Focus();
            }

           
        }

        void btnGuardar_Click(object sender, EventArgs e)
        {
            enlTransfAlmacenesMaster.Numero = txtNumero.Text;
            enlTransfAlmacenesMaster.Fecha = dtpFecha.Value;
            enlTransfAlmacenesMaster.AlmacenSalida = txtAlmacenSalida.Text;
            enlTransfAlmacenesMaster.AlmacenEntrada = txtAlmacenEntrada.Text;


            if (Estado == "Creando")
            {
                txtNumero.Text = bllTransfAlmacenesMaster.Insert(enlTransfAlmacenesMaster);


                if (bllNumeracion.ObtenerTipo("Tranferencia de Almacenes") == "Automatico")
                {
                    bllNumeracion.ActualizarNumero(bllNumeracion.ObtenerNumero("Tranferencia de Almacenes"), "Tranferencia de Almacenes");
                }



            }
            else
            {
                if (Estado == "Editando")
                {
                    bllTransfAlmacenesMaster.Update(enlTransfAlmacenesMaster);
                    MessageBox.Show("Registro Actualizado Correctamente", "SGF");
                }
            }



        }

        void btnEditar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNumero.Text))
            {
                Estado = EDITAR;
                txtNumero.Focus();
            }
        }

        void btnCancelar_Click(object sender, EventArgs e)
        {

        }

        void btnEliminar_Click(object sender, EventArgs e)
        {

            enlTransfAlmacenesMaster.Numero = txtNumero.Text;
            bllTransfAlmacenesMaster.Delete(enlTransfAlmacenesMaster);

        }

        void btnBuscar_Click(object sender, EventArgs e)
        {

        }

      
    }
}
