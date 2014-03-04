using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer.CxC_Ventas
{
  public  class Enl_CotizacionesDetail
    {

        public string NoCotizacion { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalLinea { get; set; }

    }
}
