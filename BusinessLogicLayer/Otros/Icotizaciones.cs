using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Otros
{
    public  interface Icotizaciones
    {
        void CodigoTerminos(string terminos);

        void CodigoVendedor(string vendedor);

        void CodigoCliente(string codigo, string nombre);

    }
}
