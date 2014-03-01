using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EntityLayer.Administracion
{
  public   class Enl_Empleados
    {

        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Email { get; set; }
        public string Estatus { get; set; }
        public string EstadoCivil { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public decimal Salario { get; set; }
        public string Nacionalidad { get; set; }
        public bool IsVendedor { get; set; }
        public string Celular { get; set; }


    }
}
