using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer.CxP_Compras
{
  public  class Enl_ComprasDetail
    {

        public string NoCompra { get; set; }
        public string Articulo { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal Cantidad { get; set; }
        public decimal Impuesto { get; set; }
        public decimal TotalLinea { get; set; }

    }
}
