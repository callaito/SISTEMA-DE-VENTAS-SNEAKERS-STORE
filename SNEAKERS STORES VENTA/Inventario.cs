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
    public partial class Inventario : Form
    {
        private readonly string connectionString = "Data Source=RADELIN-PC;Initial Catalog=sistem_ventas;Persist Security Info=True;User ID=sa;Password=12345678;";

        public Inventario()
        {
            InitializeComponent();
            Datos();
        }



        private void Datos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id_producto, Producto,Descripcion,Stock_inicial,Entrada,Fecha_Entrada,Salida,Fecha_salida, Total FROM Inventario";

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
            string Producto = txt_producto.Text;
            string Descripcion = txt_descripcion.Text;
            string Stock_inicial = txt_stock_inicial.Text;
            string Entrada = txt_entrada.Text;
            string Fecha_Entrada = txt_fecha_entrada.Text;
            string Salida = txt_salida.Text;
            string Fecha_salida = txt_fecha_salida.Text;

            string cadena = "insert into inventario (Producto,Descripcion,Stock_inicial,Entrada,Fecha_Entrada,Salida,Fecha_salida) values ('" + Producto + "', '" + Descripcion + "', " + Stock_inicial + ", " + Entrada + "," + Fecha_Entrada + "," + Salida + ",'" + Fecha_salida + "')";


            SqlCommand comando = new SqlCommand(cadena, conexion); comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se guardaron correctamente");

            conexion.Close();
        }

        private void btn_Selet_Click_1(object sender, EventArgs e)
        {
            txt_producto.Clear();
            txt_descripcion.Clear();
            txt_stock_inicial.Clear();
            txt_entrada.Clear();
            txt_fecha_entrada.Clear();
            txt_salida.Clear();
            txt_fecha_salida.Clear();
        }

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas eliminar este producto?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Inventario WHERE Producto = @Producto";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Producto", txt_producto.Text);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Datos eliminado correctamente");
                            Datos();
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

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            string Producto = txt_producto.Text;
            string Descripcion = txt_descripcion.Text;
            string Stock_inicial = txt_stock_inicial.Text;
            string Entrada = txt_entrada.Text;
            string Fecha_Entrada = txt_fecha_entrada.Text;
            string Salida = txt_salida.Text;
            string Fecha_salida = txt_fecha_salida.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Inventario SET Producto = @Producto, Descripcion = @Descripcion, Stock_inicial = @Stock_inicial, Entrada = @Entrada, Fecha_Entrada = @Fecha_Entrada, Salida = @Salida WHERE Fecha_salida = @Fecha_salida";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Producto", Producto);
                command.Parameters.AddWithValue("@Descripcion", Descripcion);
                command.Parameters.AddWithValue("@Stock_inicial", Stock_inicial);
                command.Parameters.AddWithValue("@Entrada", Entrada);
                command.Parameters.AddWithValue("@Fecha_Entrada", Fecha_Entrada);
                command.Parameters.AddWithValue("@Salida", Salida);
                command.Parameters.AddWithValue("@Fecha_salida", Fecha_salida);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Datos actualizados correctamente");
                        Datos();
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al actualizar : " + ex.Message);
                }
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoInventario.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txt_producto.Text = dataGridView1.SelectedCells[1].Value.ToString();
            txt_descripcion.Text = dataGridView1.SelectedCells[2].Value.ToString();
            txt_stock_inicial.Text = dataGridView1.SelectedCells[3].Value.ToString();
            txt_entrada.Text = dataGridView1.SelectedCells[4].Value.ToString();
            txt_fecha_entrada.Text = dataGridView1.SelectedCells[5].Value.ToString();
            txt_salida.Text = dataGridView1.SelectedCells[6].Value.ToString();
            txt_fecha_salida.Text = dataGridView1.SelectedCells[7].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection("server=RADELIN-PC;database=sistem_ventas;integrated security=true"))
                {
                    conexion.Open();

                    string Producto = txt_producto.Text;
                    string Descripcion = txt_descripcion.Text;
                    string Stock_inicial = txt_stock_inicial.Text;
                    string Entrada = txt_entrada.Text;
                    string Fecha_Entrada = txt_fecha_entrada.Text;
                    string Salida = txt_salida.Text;
                    string Fecha_salida = txt_fecha_salida.Text;

                    // Verificación y conversión de datos
                    if (!int.TryParse(Stock_inicial, out int stockInicialParsed))
                    {
                        MessageBox.Show("El stock inicial debe ser un número válido.");
                        return;
                    }

                    if (!int.TryParse(Entrada, out int entradaParsed))
                    {
                        MessageBox.Show("La entrada debe ser un número válido.");
                        return;
                    }

                    if (!DateTime.TryParse(Fecha_Entrada, out DateTime fechaEntradaParsed))
                    {
                        MessageBox.Show("La fecha de entrada debe ser una fecha válida.");
                        return;
                    }

                    if (!int.TryParse(Salida, out int salidaParsed))
                    {
                        MessageBox.Show("La salida debe ser un número válido.");
                        return;
                    }

                    if (!DateTime.TryParse(Fecha_salida, out DateTime fechaSalidaParsed))
                    {
                        MessageBox.Show("La fecha de salida debe ser una fecha válida.");
                        return;
                    }

                    if (!int.TryParse(txtCodigoInventario.Text, out int productoId))
                    {
                        MessageBox.Show("El código del producto debe ser un número válido.");
                        return;
                    }

                    // Consulta SQL con parámetros
                    string consulta = "UPDATE inventario SET Producto = @Producto, Descripcion = @Descripcion, Stock_inicial = @Stock_inicial, Entrada = @Entrada, Fecha_Entrada = @Fecha_Entrada, Salida = @Salida, Fecha_salida = @Fecha_salida WHERE Id_producto = @Id_producto";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        // Añadir los parámetros con sus valores
                        comando.Parameters.AddWithValue("@Producto", Producto);
                        comando.Parameters.AddWithValue("@Descripcion", Descripcion);
                        comando.Parameters.AddWithValue("@Stock_inicial", stockInicialParsed);
                        comando.Parameters.AddWithValue("@Entrada", entradaParsed);
                        comando.Parameters.AddWithValue("@Fecha_Entrada", fechaEntradaParsed);
                        comando.Parameters.AddWithValue("@Salida", salidaParsed);
                        comando.Parameters.AddWithValue("@Fecha_salida", fechaSalidaParsed);
                        comando.Parameters.AddWithValue("@Id_producto", productoId);

                        // Ejecutar la consulta
                        int cant = comando.ExecuteNonQuery();
                        if (cant > 0)
                        {
                            MessageBox.Show("Registro Modificado");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el producto con el Id especificado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReporteInventario reporteInventario = new ReporteInventario();
            reporteInventario.ShowDialog();
        }
    }
}
