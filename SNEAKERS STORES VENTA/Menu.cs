using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SNEAKERS_STORES_VENTA
{
    public partial class MenuVertical : Form
    {
        public MenuVertical()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnMaximizar.Visible = false;
            btnRestaurar.Visible = true;
        }

        private void btnRestaurar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestaurar.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new MenuVertical());
        }

        private void AbrirFormEnPanel(object formhija)
        {
            if (this.panelContenedor2.Controls.Count > 0)
                this.panelContenedor2.Controls.RemoveAt(0);
            Form fh = formhija as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor2.Controls.Add(fh);
            this.panelContenedor2.Tag = fh;
            fh.Show();

        }

        private void MenuVertical_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new ClienteForm());
        }

        private void btnInventario_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Inventario());
        }

        private void btnEmpleado_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Empleado());
        }

        private void btnFacturacion_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Facturacion());
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            AbrirFormEnPanel(new Inicio());
        }
    }
}