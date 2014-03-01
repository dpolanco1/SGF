using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLogicLayer.Otros
{
   public interface Iinventario
    {

       void CargarMarca(string Marca);

       void CargarCategoria(string Categoria);

       void CargarSubCategoria(string SubCategoria);

       void CargarImpuesto(string Impuesto);


    }
}
