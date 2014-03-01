using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Otros
{
  public  interface Icompras
    {
        void CargarSuplidor(string Marca, string Nombre);

        void CargarAlmacen(string Categoria);

    }
}
