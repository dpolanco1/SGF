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
        public static ArrayList CalcularGrid(DataGridView gridView, decimal descuento, string nombreTotalLinea, string nombreImpuestoLinea)
        {
            decimal subTotal;
            decimal totalDescuento;
            decimal total;
            ArrayList valores = new ArrayList();

            // Estos valores nunca pueden venir nulos desde la BD, deben de hacerse las validaciones de lugar
            decimal totalLinea = 0;
            decimal totalImpuesto = 0;
            
            foreach (DataGridViewRow row in gridView.Rows)
            {
                try
                {
                    totalLinea += Convert.ToDecimal(row.Cells[nombreTotalLinea].Value);
                    totalImpuesto += Convert.ToDecimal(row.Cells[nombreImpuestoLinea].Value);
                }
                catch (Exception)
                {

                }
                    
            
            }
            //Subtotal
            valores.Add(subTotal = totalLinea);
            //Impuesto
            valores.Add(totalImpuesto);
            //TotalDescuento
            valores.Add(totalDescuento = subTotal * descuento);
            //Total
            valores.Add(total = subTotal + totalImpuesto - totalDescuento);

            return valores;

        }

        public static decimal ConvertirANumero(string valor)
        {
            decimal _valorNew = 0.00m;

            while (true)
            {
                if (valor.Contains("RD$") == true)
                {
                    _valorNew = Convert.ToDecimal(valor.Replace("RD$", ""));
                }
                else if (valor.Contains(",") == true)
                {
                    _valorNew = Convert.ToDecimal(valor.Replace("RD$", ""));
                }
                else if (valor.Contains("%") == true) 
                {
                    _valorNew = Convert.ToDecimal(valor.Replace("%", ""));
                }
                else if (string.IsNullOrEmpty(valor))
                {
                    _valorNew = 0.00m;
                }
                else
                {
                    _valorNew = Convert.ToDecimal(valor);
                }
                return _valorNew;
            }
        }

        //estado del sistema definidos
        public enum EstadoSystema
        {
            Consultando,
            Editando,
            Creando
        }

        public static void ConvertiraPorcentaje(TextBox text)
        {
            Double value;
            if (Double.TryParse(text.Text, out value))
                text.Text = String.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:P02}", value / 100);
            /*  else if(
                  text.Text = String.Empty;*/
        }
    }
}
