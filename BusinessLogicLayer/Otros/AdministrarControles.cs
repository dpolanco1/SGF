using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BusinessLogicLayer.Otros
{
    public class AdministrarControles
    {

      

        // Para limpiar todos los TextBox que esten dentro del control 
        public void VaciarText(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.VaciarText(contHijo);
                if (contHijo is TextBox)
                {
                    contHijo.Text = String.Empty;
                }
            }

        }

        // Para Habilitar los TextBox que esten dentro del control
        public void HabilitarText(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.HabilitarText(contHijo);
                if (contHijo is TextBox)
                {
                    contHijo.Enabled = true;
                }
            }
        }

        // Para Deshabilitar los TextBox que esten dentro del control
        public void DeshabilitarText(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.DeshabilitarText(contHijo);
                if (contHijo is TextBox)
                {
                    contHijo.Enabled = false;
                }
            }
        }

        // Para Habilitar los DatagridView que esten dentro del Control
        public void HabilitarDGV(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.HabilitarDGV(contHijo);
                if (contHijo is DataGridView)
                {
                    contHijo.Enabled = true;
                }
            }
        }

        // Para deshabilitar los DatagridView que esten dentro del Control
        public void DeshabilitarDGV(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.DeshabilitarDGV(contHijo);
                if (contHijo is DataGridView)
                {
                    contHijo.Enabled = false;
                }
            }
        }

        // Para limpiar las celdas de un DatagridView que esten dentro del Control
        public void VaciarDGV(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.VaciarDGV(contHijo);
                if (contHijo is DataGridView)
                {
                    DataGridView DGV = new DataGridView();
                    DGV = (DataGridView)contHijo;
                    DGV.Rows.Clear();
                }
            }

        }

        // Para Pasar Color a los TextBox Dentro del Control
        public void ColorText(Control control, Color color)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.ColorText(contHijo, color);
                if (contHijo is TextBox)
                {
                    contHijo.BackColor = color;
                }
            }
        }

        // Para limpiar Los MaskTextox
        public void VaciarMaskText(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.VaciarMaskText(contHijo);
                if (contHijo is MaskedTextBox)
                {
                    contHijo.Text = String.Empty;
                }
            }

        }

        // Para Pasar Color a los MaskText Dentro del control
        public void ColorMaskText(Control control, Color color)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.ColorMaskText(contHijo, color);
                if (contHijo is MaskedTextBox)
                {
                    contHijo.BackColor = color;
                }
            }

        }

        // Para Habilitar  los MaskText Dentro del control
        public void HabilitarMaskText(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.HabilitarMaskText(contHijo);
                if (contHijo is MaskedTextBox)
                {
                    contHijo.Enabled = true;
                }
            }

        }

        // Para Deshabilitar  los MaskText Dentro del control
        public void DeshabilitarMaskText(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.DeshabilitarMaskText(contHijo);
                if (contHijo is MaskedTextBox)
                {
                    contHijo.Enabled = false;
                }
            }

        }

        public void HabilitarTodo(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.HabilitarTodo(contHijo);
                contHijo.Enabled = true;
            }

        }

        public void DeshabilitarTodo(Control control)
        {
            foreach (Control contHijo in control.Controls)
            {
                if (contHijo.HasChildren) this.DeshabilitarTodo(contHijo);
                contHijo.Enabled = true;

            }

        }

    }
}