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
    public partial class Frm_Buscar_Terminos : Form
    {

        //esto se utiliza para traer la lista desde el formulario padre al hijo y pasarla como variable publica
        public List<Enl_Termino> ListadeTerminos = new List<Enl_Termino>();
        Enl_Termino enlTermino = new Enl_Termino();
        Bll_Terminos bllTermino = new Bll_Terminos();

        //entidades que seran pasadas a los formularios
        public string codigoTermino { get; set; }
        public string nombreTermino { get; set; }

        public Frm_Buscar_Terminos()
        {
            InitializeComponent();
        }

        private void Frm_Buscar_Terminos_Load(object sender, EventArgs e)
        {
            DGV_Terminos.AutoGenerateColumns = false;

            //esto hace que se limpien los valores de la entidad
            enlTermino.Codigo =
            enlTermino.Nombre =
            enlTermino.Nota =
            string.Empty;
            enlTermino.Dias = 0.00m;

            //llenamos el datagried
            DGV_Terminos.DataSource = bllTermino.Search(enlTermino);
        }

        private void DGV_Terminos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //esto es para tomar el valor de la fila exacta
            int indice = (Int32)DGV_Terminos.CurrentCell.RowIndex;
            //pasamos los valores
            this.codigoTermino = DGV_Terminos.Rows[indice].Cells["Codigo"].Value.ToString();
            this.nombreTermino = DGV_Terminos.Rows[indice].Cells["Nombre"].Value.ToString();

            this.Close();
        }
    }
}
