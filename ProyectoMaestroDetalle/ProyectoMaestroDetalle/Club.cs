using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoMaestroDetalle
{
    public partial class Club : Form
    {
        private string connectionString = "Data Source=AXEL\\SQLEXPRESS;Initial Catalog=Extracurricular;Integrated Security=True;Connect Timeout=60";

        public Club()
        {
            InitializeComponent();
        }

        private void Club_Load(object sender, EventArgs e)
        {
            txtName.MaxLength = 40;
            txtClassification.MaxLength = 20;

            dataGridView1.CellClick += dataGridView1_CellClick;

            CargarEmployee();
            cargarDatosClub();

            btnModificar.Enabled = false;
        }
        private void cargarDatosClub()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "EXEC GetClubs";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    dataGridView1.DataSource = dataTable;
                }

                connection.Close();
            }
        }
        private Dictionary<int, string> employeeDictionary = new Dictionary<int, string>();

        private void CargarEmployee()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetEmployees", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    cmbidEmployee.Items.Clear();
                    employeeDictionary.Clear();

                    while (reader.Read())
                    {
                        int idEmployee = (int)reader["idEmployee"];
                        string firstName = (string)reader["firstName"];

                        cmbidEmployee.Items.Add(firstName);
                        employeeDictionary.Add(idEmployee, firstName);
                    }

                    reader.Close();
                }

                connection.Close();
            }
        }
        public class ListItem
        {
            public int Value { get; set; }
            public string Text { get; set; }

            public ListItem(int value, string text)
            {
                Value = value;
                Text = text;
            }

            public override string ToString()
            {
                return Text;
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                txtClassification.Text = selectedRow.Cells["classification"].Value.ToString();
                txtName.Text = selectedRow.Cells["name"].Value.ToString();
                int employeeid = Convert.ToInt32(selectedRow.Cells["idEmployee"].Value);

                if (employeeDictionary.ContainsKey(employeeid))
                {
                    string firstname = employeeDictionary[employeeid];
                    cmbidEmployee.Text = $" {firstname}";
                }

                btnModificar.Enabled = true;
            }
        }
        private int GetselectedClub()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                return (int)selectedRow.Cells["idClub"].Value;
            }

            return -1;
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                int idEmployee = employeeDictionary.FirstOrDefault(x => x.Value == cmbidEmployee.Text.Trim()).Key;

                connection.Open();

                using (SqlCommand command = new SqlCommand("InsertClub", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@name", txtName.Text);
                    command.Parameters.AddWithValue("@classification", txtClassification.Text);
                    command.Parameters.AddWithValue("@idEmployee", idEmployee);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Insertado correctamente.");
                        cargarDatosClub();
                    }
                    else
                    {
                        MessageBox.Show("Insertado correctamente.");
                    }
                }

                connection.Close();
            }
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuOpciones me = new MenuOpciones();
            me.Show();
            this.Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idClub = GetselectedClub();
            string name = txtName.Text;
            string classification = txtClassification.Text;
            int idEmployee = employeeDictionary.FirstOrDefault(x => x.Value == cmbidEmployee.Text.Trim()).Key;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateClub", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@idClub", idClub);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@classification", classification);
                        command.Parameters.AddWithValue("@idEmployee", idEmployee);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Acreditación modificada correctamente.");
                            cargarDatosClub();
                        }
                        else
                        {
                            MessageBox.Show("Error al modificar la acreditación.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int accreditationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idClub"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteClub", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idClub", accreditationID);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                            MessageBox.Show("Registro eliminado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show("Error al eliminar el registro.");
                        }
                    }

                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }
        }
    }
}
