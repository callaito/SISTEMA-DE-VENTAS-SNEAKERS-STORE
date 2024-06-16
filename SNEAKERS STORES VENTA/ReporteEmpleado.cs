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
    public partial class ReporteEmpleado : Form
    {
        public ReporteEmpleado()
        {
            InitializeComponent();
        }

        private void ReporteEmpleado_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'sistem_ventasDataSet.SP_CONSULTAR_empleado' Puede moverla o quitarla según sea necesario.
            this.sP_CONSULTAR_empleadoTableAdapter.Fill(this.sistem_ventasDataSet.SP_CONSULTAR_empleado);

            this.reportViewer1.RefreshReport();
        }
    }
}
