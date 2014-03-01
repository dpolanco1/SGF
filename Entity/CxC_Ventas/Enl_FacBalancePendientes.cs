using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer.CxC_Ventas
{
  public   class Enl_FacBalancePendientes
    {
         public string Cliente { get; set; }
        public DateTime Fecha { get; set; }
        public string Numero { get; set; }
        public Decimal TotalFacturado { get; set; }
        public Decimal TotalPagado { get; set; }
        public Decimal BalancePendiente { get; set; }
        public Decimal Monto { get; set; }

    }
}
