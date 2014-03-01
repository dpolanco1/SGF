using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer.CxP_Compras
{
   public class Enl_ComprasMaster
    {
        public string Numero { get; set; }
        public string Suplidor { get; set; }
        public DateTime Fecha { get; set; }
        public string Almacen { get; set; }
        public Decimal Descuento { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TotalImpuesto { get; set; }
        public decimal TotalDescuento { get; set; }
        public decimal TotalCompra { get; set; }

    }
}
