using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Otros
{
  public  interface Irecibos
    {

        void CodigoModoPago(string modopago);

        void CodigoCaja(string caja);

        void CodigoCliente(string codigo, string nombre);


    }
}
