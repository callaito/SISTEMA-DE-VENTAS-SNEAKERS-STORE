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
    public partial class ReporteFacturacion : Form
    {
        public ReporteFacturacion()
        {
            InitializeComponent();
        }

        private void ReporteFacturacion_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sistem_ventasDataSet.SP_CONSULTAR_factura' Puede moverla o quitarla según sea necesario.
            this.sP_CONSULTAR_facturaTableAdapter.Fill(this.sistem_ventasDataSet.SP_CONSULTAR_factura);

            this.reportViewer1.RefreshReport();
        }
    }
}
