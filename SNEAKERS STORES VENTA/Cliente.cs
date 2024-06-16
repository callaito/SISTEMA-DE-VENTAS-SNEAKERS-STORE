using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlTypes;
using System.Data.Common;
using System.Data.SqlClient;


namespace SNEAKERS_STORES_VENTA
{
    public partial class ClienteForm : Form
    {

        private readonly string connectionString = "Data Source=RADELIN-PC;Initial Catalog=sistem_ventas;Persist Security Info=True;User ID=sa;Password=12345678;";

        public ClienteForm()
        {
            InitializeComponent();
            cargarDatos();
        }


        private void btn_guardar_Click(object sender, EventArgs e)
        {

            


        }

        private void cargarDatos()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT id_cliente, Nombre, Apellido, Cedula, Direccion, Telefono FROM Cliente";

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

        private void btn_consultar_Click(object sender, EventArgs e)
        {
            cargarDatos();
        }


        private void btnModificar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Cliente SET Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Telefono = @Telefono WHERE Cedula = @Cedula";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", txt_nombre.Text);
                command.Parameters.AddWithValue("@Apellido", txt_apellido.Text);
                command.Parameters.AddWithValue("@Direccion", txt_direccion.Text);
                command.Parameters.AddWithValue("@Telefono", txt_telefono.Text);
                command.Parameters.AddWithValue("@Cedula", txt_cedula.Text);


            }
        }


        private void btnActualizar_Click(object sender, EventArgs e)
        {
            string cedula = txt_cedula.Text;
            string nombre = txt_nombre.Text;
            string apellido = txt_apellido.Text;
            string direccion = txt_direccion.Text;
            string telefono = txt_telefono.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Cliente SET Nombre = @Nombre, Apellido = @Apellido, Direccion = @Direccion, Telefono = @Telefono WHERE Cedula = @Cedula";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Nombre", nombre);
                command.Parameters.AddWithValue("@Apellido", apellido);
                command.Parameters.AddWithValue("@Direccion", direccion);
                command.Parameters.AddWithValue("@Telefono", telefono);
                command.Parameters.AddWithValue("@Cedula", cedula);

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

        private void btnEliminar_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Estás seguro de que deseas eliminar este cliente?", "Confirmación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM Cliente WHERE Cedula = @Cedula";

                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Cedula", txt_cedula.Text);

                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cliente eliminado correctamente");
                            cargarDatos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró ningún cliente con la cédula proporcionada");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar el cliente: " + ex.Message);
                    }
                }
            }
        }

        private void btn_guardar_Click_1(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server =RADELIN-PC ;database= sistem_ventas ; integrated security = true");
            conexion.Open();
            string Nombre = txt_nombre.Text;
            string Apellido = txt_apellido.Text;
            string Cedula = txt_cedula.Text;
            string Direccion = txt_direccion.Text;
            string Telefono = txt_telefono.Text;

            string cadena = "insert into cliente (Nombre, Apellido, Cedula, Direccion, Telefono) values('" + Nombre + "','" + Apellido + "','" + Cedula + "','" + Direccion + "','" + Telefono + "')";


            SqlCommand comando = new SqlCommand(cadena, conexion); comando.ExecuteNonQuery();
            MessageBox.Show("Los datos se guardaron correctamente");

            conexion.Close();
        }

        private void btn_Selet_Click(object sender, EventArgs e)
        {
            txt_nombre.Clear();
            txt_apellido.Clear();
            txt_cedula.Clear();
            txt_direccion.Clear();
            txt_telefono.Clear();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            SqlConnection conexion = new SqlConnection("server =RADELIN-PC ;database= sistem_ventas ; integrated security = true");
            conexion.Open();

            string Nombre = txt_nombre.Text;
            string Apellido = txt_apellido.Text;
            string Cedula = txt_cedula.Text;
            string Direccion = txt_direccion.Text;
            string Telefono = txt_telefono.Text;

            int v1;
            v1 = int.Parse(txt_telefono.Text);
            

            string consulta = "update cliente set Nombre='" + Nombre + "',Apellido='" + Apellido + "',Cedula='" + Cedula + "',Direccion='" + Direccion + "', Telefono=" + v1 + "where id_cliente=" + textcodigocliente.Text + " ";
            SqlCommand comando = new SqlCommand(consulta, conexion);
            int cant;
            cant = comando.ExecuteNonQuery();
            if (cant > 0)
            {
                MessageBox.Show("Registro Modificado");
            }
            conexion.Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textcodigocliente.Text = dataGridView1.SelectedCells[0].Value.ToString();
            txt_nombre.Text = dataGridView1.SelectedCells[1].Value.ToString();
            txt_apellido.Text = dataGridView1.SelectedCells[2].Value.ToString();
            txt_cedula.Text = dataGridView1.SelectedCells[3].Value.ToString();
            txt_direccion.Text = dataGridView1.SelectedCells[4].Value.ToString();
            txt_telefono.Text = dataGridView1.SelectedCells[5].Value.ToString();
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            ReporteCliente reporteCliente = new ReporteCliente();
            reporteCliente.ShowDialog();
        }
    }
}
