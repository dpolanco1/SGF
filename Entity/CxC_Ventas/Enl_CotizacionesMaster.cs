using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer.CxC_Ventas
{
   public class Enl_CotizacionesMaster
    {
        public string Numero { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Terminos { get; set; }
        public Decimal Descuento { get; set; }
        public string Vendedor { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalImpuesto { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalCotizacion { get; set; }

       

    }
}
