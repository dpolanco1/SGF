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
    public partial class Frm_Buscar_Caja : Form
    {

        //esto se utiliza para traer la lista desde el formulario padre al hijo y pasarla como variable publica
        public List<Enl_Caja> ListadeCajas = new List<Enl_Caja>();
        Enl_Caja enlCaja = new Enl_Caja();
        Bll_Caja bllCaja = new Bll_Caja();

        //entidades que seran pasadas a los formularios
        public string codigoCaja { get; set; }
        public string nombreCaja { get; set; }

        public Frm_Buscar_Caja()
        {
            InitializeComponent();
        }

        private void Frm_Buscar_Caja_Load(object sender, EventArgs e)
        {
            DGV_Caja.AutoGenerateColumns = false;

            //esto hace que se limpien los valores de la entidad
            enlCaja.Codigo =
            enlCaja.Nombre =
            enlCaja.Nota =
            enlCaja.Custodio =
            string.Empty;
            enlCaja.Saldo = 0.00m;


            //llenamos el datagried
            DGV_Caja.DataSource = bllCaja.Search(enlCaja);
        }

        private void DGV_Caja_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //esto es para tomar el valor de la fila exacta
            int indice = (Int32)DGV_Caja.CurrentCell.RowIndex;
            //pasamos los valores
            this.codigoCaja = DGV_Caja.Rows[indice].Cells["Codigo"].Value.ToString();
            this.nombreCaja = DGV_Caja.Rows[indice].Cells["Nombre"].Value.ToString();

            this.Close();
        }
    }
}
