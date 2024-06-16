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
    public partial class Empleado : Form
    {
        private readonly string connectionString = "Data Source=RADELIN-PC;Initial Catalog=sistem_ventas;Persist Security Info=True;User ID=sa;Password=12345678;";

        public Empleado()
        {
            InitializeComponent();
            cargarDatos();
        }


        private void cargarDatos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id_empleado ,Nombre, Apellido, Cedula, Direccion, Telefono, Sueldo, Cargo FROM Empleado";

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


        private void btn_guardar_Click_1(object sender, EventArgs e)
        {
            string connectionString = "server=RADELIN-PC;database=sistem_ventas;integrated security=true";
            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                try
                {
                    conexion.Open();

                    // Obtención de los datos desde los controles
                    string Nombre = txt_nombre.Text;
                    string Apellido = txt_apellido.Text;
                    string Cedula = txt_cedula.Text;
                    string Direccion = txt_direccion.Text;
                    string Telefono = txt_telefono.Text;
                    string Sueldo = txt_sueldo.Text;
                    string Cargo = cb_cargo.Text;

                    // Cadena SQL usando parámetros
                    string cadena = "INSERT INTO empleado (Nombre, Apellido, Cedula, Direccion, Telefono, Sueldo, Cargo) " +
                                    "VALUES (@Nombre, @Apellido, @Cedula, @Direccion, @Telefono, @Sueldo, @Cargo)";

                    // Creación del comando con parámetros
                    using (SqlCommand comando = new SqlCommand(cadena, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", Nombre);
                        comando.Parameters.AddWithValue("@Apellido", Apellido);
                        comando.Parameters.AddWithValue("@Cedula", Cedula);
                        comando.Parameters.AddWithValue("@Direccion", Direccion);
                        comando.Parameters.AddWithValue("@Telefono", Telefono);
                        comando.Parameters.AddWithValue("@Sueldo", Sueldo);
                        comando.Parameters.AddWithValue("@Cargo", Cargo);

                        // Ejecución del comando
                        comando.ExecuteNonQuery();
                    }

                    // Mensaje de confirmación
                    MessageBox.Show("Los datos se guardaron correctamente");
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    MessageBox.Show("Ocurrió un error: " + ex.Message);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas eliminar este empleado?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Empleado WHERE Nombre = @Nombre";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Nombre", txt_nombre.Text);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Empleado eliminado correctamente");
                            cargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún empleado con la cédula proporcionada");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el empleado: " + ex.Message);
                    }
                }
            }
        }

        private void btn_Selet_Click(object sender, EventArgs e)
        {
            txt_nombre.Clear();
            txt_apellido.Clear();
            txt_cedula.Clear();
            txt_direccion.Clear();
            txt_telefono.Clear();
            txt_sueldo.Clear();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string Nombre = txt_nombre.Text;
            string Apellido = txt_apellido.Text;
            string Cedula = txt_cedula.Text;
            string Direccion = txt_direccion.Text;
            string Telefono = txt_telefono.Text;
            string Sueldo = txt_sueldo.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Empleado SET Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Telefono = @Telefono WHERE Cedula = @Cedula";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", Nombre);
                command.Parameters.AddWithValue("@Apellido", Apellido);
                command.Parameters.AddWithValue("@Cedula", Cedula);
                command.Parameters.AddWithValue("@Direccion", Direccion);
                command.Parameters.AddWithValue("@Telefono", Telefono);
                command.Parameters.AddWithValue("@Sueldo", Sueldo);

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
            
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conexion = new SqlConnection("server=RADELIN-PC;database=sistem_ventas;integrated security=true"))
                {
                    conexion.Open();

                    string Nombre = txt_nombre.Text;
                    string Apellido = txt_apellido.Text;
                    string Cedula = txt_cedula.Text;
                    string Direccion = txt_direccion.Text;
                    string Telefono = txt_telefono.Text;
                    string Sueldo = txt_sueldo.Text;

                    int telefonoParsed;
                    decimal sueldoParsed;

                    if (!int.TryParse(Telefono, out telefonoParsed))
                    {
                        MessageBox.Show("El teléfono debe ser un número válido.");
                        return;
                    }

                    if (!decimal.TryParse(Sueldo, out sueldoParsed))
                    {
                        MessageBox.Show("El sueldo debe ser un número válido.");
                        return;
                    }

                    int empleadoId;
                    if (!int.TryParse(txtCodigoEmpleado.Text, out empleadoId))
                    {
                        MessageBox.Show("El código de empleado debe ser un número válido.");
                        return;
                    }

                    string consulta = "UPDATE empleado SET Nombre = @Nombre, Apellido = @Apellido, Cedula = @Cedula, Direccion = @Direccion, Telefono = @Telefono, Sueldo = @Sueldo WHERE Id_empleado = @IdEmpleado";
                    using (SqlCommand comando = new SqlCommand(consulta, conexion))
                    {
                        comando.Parameters.AddWithValue("@Nombre", Nombre);
                        comando.Parameters.AddWithValue("@Apellido", Apellido);
                        comando.Parameters.AddWithValue("@Cedula", Cedula);
                        comando.Parameters.AddWithValue("@Direccion", Direccion);
                        comando.Parameters.AddWithValue("@Telefono", telefonoParsed);
                        comando.Parameters.AddWithValue("@Sueldo", sueldoParsed);
                        comando.Parameters.AddWithValue("@IdEmpleado", empleadoId);

                        int cant = comando.ExecuteNonQuery();
                        if (cant > 0)
                        {
                            MessageBox.Show("Registro Modificado");
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el empleado con el Id especificado.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            txtCodigoEmpleado.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txt_nombre.Text = dataGridView1.SelectedCells[1].Value.ToString();
            txt_apellido.Text = dataGridView1.SelectedCells[2].Value.ToString();
            txt_cedula.Text = dataGridView1.SelectedCells[3].Value.ToString();
            txt_direccion.Text = dataGridView1.SelectedCells[4].Value.ToString();
            txt_telefono.Text = dataGridView1.SelectedCells[5].Value.ToString();
            txt_sueldo.Text = dataGridView1.SelectedCells[6].Value.ToString();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReporteEmpleado reporteEmpleado = new ReporteEmpleado();
            reporteEmpleado.ShowDialog();
        }
    }
}
