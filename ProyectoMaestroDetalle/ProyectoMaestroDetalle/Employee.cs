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
using System.Xml.Linq;

namespace ProyectoMaestroDetalle
{
    public partial class Employee : Form
    {
        private string connectionString = "Data Source=AXEL\\SQLEXPRESS;Initial Catalog=Extracurricular;Integrated Security=True;Connect Timeout=60";

        public Employee()
        {
            InitializeComponent();
        }

        private void Employee_Load(object sender, EventArgs e)
        {
            txtSpecialty.MaxLength = 40;
            txtmiddleName.MaxLength = 20;
            txtfirstName.MaxLength = 40;
            txtLastName.MaxLength = 20;

            dataGridView1.CellClick += dataGridView1_CellClick;

            CargarDatosEmployee();
       

            btnModificar.Enabled = false;
        }
        private void CargarDatosEmployee()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "EXEC GetEmployees";

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

                txtfirstName.Text = selectedRow.Cells["firstName"].Value.ToString();
                txtLastName.Text = selectedRow.Cells["lastName"].Value.ToString();
                txtmiddleName.Text = selectedRow.Cells["middleName"].Value.ToString();
                txtSpecialty.Text = selectedRow.Cells["specialty"].Value.ToString();

                btnModificar.Enabled = true;
            }
        }
        private int GetselectedEmployee()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                return (int)selectedRow.Cells["idEmployee"].Value;
            }

            return -1;
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            string firstname = txtfirstName.Text;
            string lastname = txtLastName.Text;
            string specialty = txtSpecialty.Text;
            string middlename = txtmiddleName.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CreateEmployee", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@firstName", firstname);
                    command.Parameters.AddWithValue("@lastName", lastname);
                    command.Parameters.AddWithValue("@specialty", specialty);
                    command.Parameters.AddWithValue("@middleName", middlename);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Insertado correctamente.");
                        CargarDatosEmployee();
                    }
                    else
                    {
                        MessageBox.Show("Insertado correctamente.");
                    }
                }

                connection.Close();
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int employeeid = GetselectedEmployee();
            string firstname = txtfirstName.Text;
            string lastname = txtLastName.Text;
            string specialty = txtSpecialty.Text;
            string middlename = txtmiddleName.Text;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@idEmployee", employeeid);
                        command.Parameters.AddWithValue("@firstName", firstname);
                        command.Parameters.AddWithValue("@lastName", lastname);
                        command.Parameters.AddWithValue("@specialty", specialty);
                        command.Parameters.AddWithValue("@middleName", middlename);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Acreditación modificada correctamente.");
                            CargarDatosEmployee();
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
                int accreditationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idEmployee"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteEmployee", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idEmployee", accreditationID);

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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuOpciones me = new MenuOpciones();
            me.Show();
            this.Hide();
        }
    }
}
