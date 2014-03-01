using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer.CxC_Ventas
{
  public  class Enl_Clientes
    {
        public string Codigo { get; set; }
        public string RazonSocial { get; set; }
        public string RNC { get; set; }
        public string NCF { get; set; }
        public decimal LimteCredito { get; set; }
        public string Categoria { get; set; }
        public string SubCategoria { get; set; }
        public string Direccion { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Celular { get; set; } 
        public string Fax { get; set; }
        public string Telefono { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Email { get; set; }
    }
}
