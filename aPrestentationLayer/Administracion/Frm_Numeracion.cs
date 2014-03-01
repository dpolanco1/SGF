using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EntityLayer.Administracion;
using BusinessLogicLayer.Administracion;
using BusinessLogicLayer.Otros;
using System.Transactions;

namespace aPrestentationLayer.Administracion
{
    public partial class Frm_Numeracion : Form
    {


        Enl_Numeracion enlNumeracion = new Enl_Numeracion();
        Bll_Numeracion bllNumeracion = new Bll_Numeracion();


        public Frm_Numeracion()
        {
            InitializeComponent();

            this.DGV_Numeracion.AutoGenerateColumns = false;
        }

        private void Frm_Numeracion_Load(object sender, EventArgs e)
        {
  
            enlNumeracion.Modulo = String.Empty;

            DGV_Numeracion.DataSource = bllNumeracion.Search(enlNumeracion);
        
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

             using (TransactionScope ts = new TransactionScope())
          
             {

            try
            {
                
                bllNumeracion.Delete(enlNumeracion);

                for (int a = 0; a < DGV_Numeracion.RowCount; a++)
                {
                
                    enlNumeracion.Modulo = DGV_Numeracion[0, a].Value.ToString();
                    enlNumeracion.Transaccion = DGV_Numeracion[1, a].Value.ToString();
                    enlNumeracion.Numero = Convert.ToInt32(DGV_Numeracion[2, a].Value);
                    enlNumeracion.Prefijo = DGV_Numeracion[3, a].Value.ToString();
                    enlNumeracion.Longitud = Convert.ToInt32(DGV_Numeracion[4, a].Value);
                    enlNumeracion.Tipo = DGV_Numeracion[5, a].Value.ToString();


                    bllNumeracion.Insert(enlNumeracion);
  
                }


                ts.Complete();
                
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex + "Error");
            }

            ts.Dispose();
                 //MessageBox.Show("Error al guardar el registro, intente nuevamente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
             Close();

     }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}
