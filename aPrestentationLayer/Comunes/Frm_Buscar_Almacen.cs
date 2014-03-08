using BusinessLogicLayer.Inventario;
using EntityLayer.Inventario;
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
    public partial class Frm_Buscar_Almacen : Form
    {
        //esto se utiliza para traer la lista desde el formulario padre al hijo y pasarla como variable publica
        public List<Enl_Almacen> ListadeAlmacenes = new List<Enl_Almacen>();
        Enl_Almacen enlAlmacen = new Enl_Almacen();
        Bll_Almacen bllAlmacen = new Bll_Almacen();

        //entidades que seran pasadas a los formularios
        public string codigoAlmacen { get; set; }
        public string nombreAlmacen { get; set; }

        public Frm_Buscar_Almacen()
        {
            InitializeComponent();
        }

        private void Frm_Buscar_Almacen_Load(object sender, EventArgs e)
        {
            DGV_Almacen.AutoGenerateColumns = false;

            //esto hace que se limpien los valores de la entidad
            enlAlmacen.Codigo =
            enlAlmacen.Nombre =
            enlAlmacen.Direccion=
            enlAlmacen.Encargado=
            enlAlmacen.Telefono=
            enlAlmacen.Nota=
            string.Empty;

            //llenamos el datagried
            DGV_Almacen.DataSource = bllAlmacen.Search(enlAlmacen);
        }

        private void DGV_Almacen_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //esto es para tomar el valor de la fila exacta
            int indice = (Int32)DGV_Almacen.CurrentCell.RowIndex;
            //pasamos los valores
            this.codigoAlmacen = DGV_Almacen.Rows[indice].Cells["Codigo"].Value.ToString();
            this.nombreAlmacen = DGV_Almacen.Rows[indice].Cells["Nombre"].Value.ToString();

            this.Close();
        }

    }
}
