using BusinessLogicLayer.Administracion;
using EntityLayer.Administracion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace aPrestentationLayer.Comunes
{
    public partial class Frm_Buscar_Empleados : Form
    {
        //esto se utiliza para traer la lista desde el formulario padre al hijo y pasarla como variable publica
        public List<Enl_Empleados> ListadeEmpleados = new List<Enl_Empleados>();
        Enl_Empleados enlEmpleado = new Enl_Empleados();
        Bll_Empleados bllEmpleado = new Bll_Empleados();

        //entidades que seran pasadas a los formularios
        public string codigoVendedor { get; set; }
        public string nombreVendedor { get; set; }


        public Frm_Buscar_Empleados()
        {
            InitializeComponent();
        }

        private void Frm_Buscar_Empleados_Load(object sender, EventArgs e)
        {
            DGV_Vendedor.AutoGenerateColumns = false;

            //esto hace que se limpien los valores de la entidad
            enlEmpleado.Codigo =
            enlEmpleado.Nombre =
            enlEmpleado.Apellido =
            enlEmpleado.Cedula =
            enlEmpleado.Telefono =
            enlEmpleado.Direccion =
            enlEmpleado.Email =
            enlEmpleado.Estatus =
            enlEmpleado.EstadoCivil =
            enlEmpleado.Sexo =
            enlEmpleado.Nacionalidad =
            enlEmpleado.Celular =
            string.Empty;
            enlEmpleado.IsVendedor = true;
            enlEmpleado.Salario = 0.00m;
            enlEmpleado.FechaNacimiento = DateTime.Now;


            //llenamos el datagried
            DGV_Vendedor.DataSource = bllEmpleado.Search(enlEmpleado);
        }

        private void DGV_Vendedor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //esto es para tomar el valor de la fila exacta
            int indice = (Int32)DGV_Vendedor.CurrentCell.RowIndex;
            //pasamos los valores
            this.codigoVendedor = DGV_Vendedor.Rows[indice].Cells["Codigo"].Value.ToString();
            this.nombreVendedor = DGV_Vendedor.Rows[indice].Cells["Nombre"].Value.ToString();

            this.Close();
        }
    }
}
