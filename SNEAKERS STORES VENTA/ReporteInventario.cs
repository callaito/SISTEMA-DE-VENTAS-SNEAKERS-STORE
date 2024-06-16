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
    public partial class ReporteInventario : Form
    {
        public ReporteInventario()
        {
            InitializeComponent();
        }

        private void ReporteInventario_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sistem_ventasDataSet.SP_CONSULTAR_inventario' Puede moverla o quitarla según sea necesario.
            this.sP_CONSULTAR_inventarioTableAdapter.Fill(this.sistem_ventasDataSet.SP_CONSULTAR_inventario);

            this.reportViewer1.RefreshReport();
        }
    }
}
