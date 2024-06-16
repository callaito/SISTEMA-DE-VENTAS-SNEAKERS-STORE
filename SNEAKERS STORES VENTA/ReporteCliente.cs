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
    public partial class ReporteCliente : Form
    {
        public ReporteCliente()
        {
            InitializeComponent();
        }

        private void ReporteCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sistem_ventasDataSet.SP_CONSULTAR_cliente' Puede moverla o quitarla según sea necesario.
            this.sP_CONSULTAR_clienteTableAdapter.Fill(this.sistem_ventasDataSet.SP_CONSULTAR_cliente);

            this.reportViewer1.RefreshReport();
        }
    }
}
