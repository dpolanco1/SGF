using BusinessLogicLayer.CxC_Ventas;
using EntityLayer.CxC_Ventas;
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
    public partial class Frm_Buscar_Clientes : Form
    {
        //esto se utiliza para traer la lista desde el formulario padre al hijo y pasarla como variable publica
        public List<Enl_Clientes> ListadeClientes = new List<Enl_Clientes>();
        Enl_Clientes enlClientes = new Enl_Clientes();
        Bll_Clientes bllClientes = new Bll_Clientes();

        //entidades que seran pasadas a los formularios
        public string codigoCliente { get; set; }
        public string mombreCliente { get; set; }
 
        public Frm_Buscar_Clientes()
        {
            InitializeComponent();
        }

        private void Frm_Buscar_Clientes_Load(object sender, EventArgs e)
        {
            DGV_Clientes.AutoGenerateColumns = false;

            //esto hace que se limpien los valores de la entidad
            enlClientes.Codigo =
            enlClientes.RazonSocial =
            enlClientes.RNC = 
            enlClientes.Nombre =
            enlClientes.Apellido =
            enlClientes.Cedula =
            enlClientes.Direccion =
            enlClientes.Email =
            enlClientes.Fax =
            enlClientes.Telefono = 
            enlClientes.SubCategoria =
            enlClientes.Categoria =
            string.Empty;
            enlClientes.FechaNacimiento = DateTime.Now;
            enlClientes.LimteCredito = 0.00m;
            
            

            //llenamos el datagried
            DGV_Clientes.DataSource = bllClientes.Search(enlClientes);
        }

        private void DGV_Clientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //esto es para tomar el valor de la fila exacta
            int indice = (Int32)DGV_Clientes.CurrentCell.RowIndex;
            //pasamos los valores
            this.codigoCliente = DGV_Clientes.Rows[indice].Cells["Codigo"].Value.ToString();
            this.mombreCliente = DGV_Clientes.Rows[indice].Cells["Nombre"].Value.ToString();

            this.Close();
        }
    }
}
