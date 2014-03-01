using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer.Administracion
{
   public class Enl_Gastos

    {
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Monto { get; set; }
        public string Tipo { get; set; }
        public string Nota { get; set; }

       // Filtros

        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }



    }
}
