using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BusinessLogicLayer.Otros
{
    public class Helper
    {
        public static ArrayList CalcularGrid(DataGridView gridView, decimal descuento)
        {
            decimal subTotal;
            decimal totalDescuento;
            decimal total;
            ArrayList valores = new ArrayList();

            decimal totalLinea = 0;
            decimal totalImpuesto = 0;


            foreach (DataGridViewRow row in gridView.Rows)
            {
                totalLinea += Convert.ToDecimal(row.Cells["TotalLineaCotizaciong"].Value);
                totalImpuesto += Convert.ToDecimal(row.Cells["ImpuestoCotizacion"].Value);
            }
            //Subtotal
            valores.Add(subTotal = totalLinea - totalImpuesto);
            //Impuesto
            valores.Add(totalImpuesto);
            //TotalDescuento
            valores.Add(totalDescuento = subTotal * descuento);
            //Total
            valores.Add(total = subTotal + totalImpuesto - totalDescuento);

            return valores;

        }

        public static decimal ConvertirANumero(string Valor)
        {
            decimal _valorNew = 0.00m;

            while (true)
            {
                if (Valor.Contains("RD$") == true)
                {
                    _valorNew = Convert.ToDecimal(Valor.Replace("RD$", ""));
                }
                else if (Valor.Contains(",") == true)
                {
                    _valorNew = Convert.ToDecimal(Valor.Replace("RD$", ""));
                }
                else
                {
                    _valorNew = Convert.ToDecimal(Valor);
                }
                return _valorNew;
            }
        }
    }
}
