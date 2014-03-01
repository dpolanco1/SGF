using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer.CxC_Ventas;
using BusinessLogicLayer.CxC_Ventas;

namespace aPrestentationLayer.Comunes
{
    public partial class Frm_Buscar_Cotizacion : Form
    {

        Enl_FacturaMaster enlFacturaMaster = new Enl_FacturaMaster();
        Bll_FacturaMaster bllFacturaMaster = new Bll_FacturaMaster();


        Enl_CotizacionesMaster enlCotizacionMaster = new Enl_CotizacionesMaster();
        Bll_CotizacionesMaster bllCotizacionMaster = new Bll_CotizacionesMaster ();
        public List<Enl_CotizacionesMaster> ListaCotizaciones = new List<Enl_CotizacionesMaster>();
       
       
        string numeroCliente = string.Empty;

        public Frm_Buscar_Cotizacion(string cliente)
        {
            InitializeComponent();
            DGV_Buscar_Cotizaciones.AutoGenerateColumns = false;
            this.numeroCliente = cliente;
           // Data.AutoGenerateColumns = false;
       
        }

        private void Frm_Buscar_Cotizacion_Load(object sender, EventArgs e)
        {

            //tabControl1.TabPages.Remove(tbpMaster);

            enlCotizacionMaster.Numero = string.Empty;
            enlCotizacionMaster.Cliente = this.numeroCliente;
            enlCotizacionMaster.Terminos = string.Empty;
            enlCotizacionMaster.Vendedor = string.Empty;

            DGV_Buscar_Cotizaciones.DataSource = bllCotizacionMaster.Search(enlCotizacionMaster);

        }

        private void DGV_Buscar_Cotizaciones_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
            ch1 = (DataGridViewCheckBoxCell)DGV_Buscar_Cotizaciones.Rows[DGV_Buscar_Cotizaciones.CurrentRow.Index].Cells[0];

            if (ch1.Value == null)
                ch1.Value = false;
            switch (ch1.Value.ToString())
            {
                case "True":
                    ch1.Value = false;
                    break;
                case "False":
                    ch1.Value = true;
                    break;
               
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

    for (int a = 0; a < DGV_Buscar_Cotizaciones.RowCount; a++)
            {
                if (DGV_Buscar_Cotizaciones[0, a].Value != null)
                {
                    // Verificar si el Check Box esta True
                    if ((bool)(DGV_Buscar_Cotizaciones[0, a].Value) == true)
                    {
  
                        ListaCotizaciones.Add(new Enl_CotizacionesMaster
                        {
                            Numero = DGV_Buscar_Cotizaciones[1, a].Value.ToString(),
                            Fecha = Convert.ToDateTime(DGV_Buscar_Cotizaciones[2, a].Value),
                            TotalCotizacion = Convert.ToDecimal(DGV_Buscar_Cotizaciones[3, a].Value)

                        });
                    }
                }
            }

            
                 Close();

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {


            Close();
        }
    }
}
