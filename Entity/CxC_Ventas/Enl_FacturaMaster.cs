using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer.CxC_Ventas
{
   public class Enl_FacturaMaster
    {
        public string Numero { get; set; }
        public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Almacen { get; set; }
        public string Terminos { get; set; }
        public string Tipo { get; set; }
        public Decimal Descuento { get; set; }
        public string Vendedor { get; set; }
        public string Caja { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalImpuesto { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalFactura { get; set; }
        public decimal TotalPagado { get; set; }
        public decimal BalancePendiente { get; set; }
        public decimal MontoAplicar { get; set; }
        public string Status { get; set; }


        public DateTime DesdeFecha { get; set; }
        public DateTime HastaFecha { get; set; }

       
 
    }
}
