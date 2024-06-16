using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data.Common;

namespace SNEAKERS_STORES_VENTA
{
    public partial class Facturacion : Form
    {
        private readonly string connectionString = "Data Source=RADELIN-PC;Initial Catalog=sistem_ventas;Persist Security Info=True;User ID=sa;Password=12345678;";

        public Facturacion()
        {
            InitializeComponent();
            cargarDatos();
        }

        private void cargarDatos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id_factura, Fecha_factura, Producto, Cantidad, Precio, Itbis, Total FROM Factura";

                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable table = new DataTable();

                try
                {
                    adapter.Fill(table);
                    dataGridView1.DataSource = table;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message);
                }
            }
        }

        private void btn_guardar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server =RADELIN-PC ;database= sistem_ventas ; integrated security = true");
            conexion.Open();

            string Fecha_factura = txt_fecha_factura.Text;
            string Producto = txt_producto.Text;
            string Cantidad = txtcantidad.Text;
            string Precio = txt_precio.Text;
            string itbis = txt_itbis.Text;



            string cadena = "insert into factura (Fecha_factura,Producto,Cantidad,Precio,itbis) values ('" + Fecha_factura + "', '" + Producto + "', " + Cantidad + ", " + Precio + "," + itbis + ")";


            SqlCommand comando = new SqlCommand(cadena, conexion); comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se guardaron correctamente");

            conexion.Close();
        }

        private void btn_Selet_Click(object sender, EventArgs e)
        {
            txt_fecha_factura.Clear();
            txt_producto.Clear();
            txtcantidad.Clear();
            txt_precio.Clear();
            txt_itbis.Clear();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Factura WHERE Producto = @Producto";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Producto", txt_producto.Text);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Producto eliminado correctamente");
                            cargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún producto");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el producto: " + ex.Message);
                    }
                }
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string Fecha_factura = txt_fecha_factura.Text;
            string Producto = txt_producto.Text;
            string Cantidad = txtcantidad.Text;
            string Precio = txt_precio.Text;
            string Itbis = txt_itbis.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Cliente SET Fecha_factura = @Fecha_factura, Producto = @Producto, Cantidad = @Cantidad, Precio = @Precio WHERE Itbis = @Itbis";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Fecha_factura", Fecha_factura);
                command.Parameters.AddWithValue("@Producto", Producto);
                command.Parameters.AddWithValue("@Cantidad", Cantidad);
                command.Parameters.AddWithValue("@Precio", Precio);
                command.Parameters.AddWithValue("@Itbis", Itbis);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Datos actualizados correctamente");
                        cargarDatos();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar : " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoFacturacion.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txt_fecha_factura.Text = dataGridView1.SelectedCells[1].Value.ToString();
            txt_producto.Text = dataGridView1.SelectedCells[2].Value.ToString();
            txtcantidad.Text = dataGridView1.SelectedCells[3].Value.ToString();
            txt_precio.Text = dataGridView1.SelectedCells[4].Value.ToString();
            txt_itbis.Text = dataGridView1.SelectedCells[5].Value.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txt_fecha_factura_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void txt_producto_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtcantidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server =RADELIN-PC ;database= sistem_ventas ; integrated security = true");
            conexion.Open();

            string Fecha_factura = txt_fecha_factura.Text;
            string Producto = txt_producto.Text;
            string Cantidad = txtcantidad.Text;
            string Precio = txt_precio.Text;
            string Itbis = txt_itbis.Text;


            string consulta = "update factura set Fecha_factura='" + Fecha_factura + "',Producto='" + Producto + "',Cantidad='" + Cantidad + "',Precio='" + Precio + "', Itbis=" + Itbis + "where Id_Factura=" + txtCodigoFacturacion.Text + " ";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant > 0)
            {
                MessageBox.Show("Registro Modificado");
            }
            conexion.Close();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReporteFacturacion reporteFacturacion = new ReporteFacturacion();
            reporteFacturacion.ShowDialog();
        }
    }
}