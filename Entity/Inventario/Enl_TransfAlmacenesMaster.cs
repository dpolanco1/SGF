using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer.Inventario
{
   public  class Enl_TransfAlmacenesMaster
    {
        public string Numero { get; set; }
        public DateTime Fecha { get; set; }
        public string AlmacenSalida { get; set; }
        public string AlmacenEntrada { get; set; }

    }
}
