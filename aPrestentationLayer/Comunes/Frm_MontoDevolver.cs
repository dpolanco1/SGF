using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace aPrestentationLayer.Comunes
{
    public partial class Frm_MontoDevolver : Form
    {

        Decimal TotalFactura = 0;

        public Frm_MontoDevolver(Decimal MontoFactura)
        {
            InitializeComponent();
            TotalFactura = MontoFactura;
            txtMontoCobrado.Focus();
        }


        private void btnAceptar_Click(object sender, EventArgs e)
        {
            CalcularMontoDevolver();
        }

        private void Frm_MontoDevolver_Load(object sender, EventArgs e)
        {

            txtMontoFactura.Text = Convert.ToString(TotalFactura);
            txtMontoCobrado.Focus();

        }      

        private void txtMontoCobrado_Validated(object sender, EventArgs e)
        {
            CalcularMontoDevolver();
        }

        private void CalcularMontoDevolver()
        {
            Decimal MontoCobrado = 0;
            Decimal MontoDevolver = 0;


            if (!string.IsNullOrEmpty(txtMontoCobrado.Text))
            {
                MontoCobrado = Convert.ToDecimal(txtMontoCobrado.Text);

                MontoDevolver = MontoCobrado - TotalFactura;

                txtMontoDevolver.Text = Convert.ToString(MontoDevolver);

                if (MontoDevolver < 0)
                {
                    lblMontoDevolver.ForeColor = Color.Red;
                }
                else
                {
                    lblMontoDevolver.ForeColor = Color.Black;
                }
            }
        }

        private void txtMontoCobrado_KeyPress(object sender, KeyPressEventArgs e)
        {
            //int isNumber = 0;
            //e.Handled = !int.TryParse(e.KeyChar.ToString(), out isNumber);
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != '.')
                e.Handled = true; 
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            CalcularMontoDevolver();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Frm_MontoDevolver_Activated(object sender, EventArgs e)
        {
            txtMontoCobrado.Focus();
        }

    }
}
