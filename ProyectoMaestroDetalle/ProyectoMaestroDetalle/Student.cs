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

namespace ProyectoMaestroDetalle
{
    public partial class Student : Form
    {
        private string connectionString = "Data Source=AXEL\\SQLEXPRESS;Initial Catalog=Extracurricular;Integrated Security=True;Connect Timeout=60";

        public Student()
        {
            InitializeComponent();
        }

        private void Student_Load(object sender, EventArgs e)
        {
            

            dataGridView1.CellClick += dataGridView1_CellClick;

            CargarClub();
            CargarDatosAccreditationControl();

            btnModificar.Enabled = false;
        }
    
        private void CargarDatosAccreditationControl()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "EXEC GetStudents";
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
        private Dictionary<int, string> scholarshipDictionary = new Dictionary<int, string>();

        private void CargarClub()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetClubs", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    cmbidScholarship.Items.Clear();
                    scholarshipDictionary.Clear();

                    while (reader.Read())
                    {
                        int idClub = (int)reader["idClub"];
                        string clubName = (string)reader["name"];

                        cmbidScholarship.Items.Add(clubName);
                        scholarshipDictionary.Add(idClub, clubName);
                    }

                    reader.Close();
                }

                connection.Close();
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                txtMiddleName.Text = selectedRow.Cells["middleName"].Value.ToString();
                txtFirstName.Text = selectedRow.Cells["firstName"].Value.ToString();
                txtSpecialty.Text = selectedRow.Cells["specialty"].Value.ToString();
                txtSemester.Text = selectedRow.Cells["semester"].Value.ToString();
                txtRegistrationNumber.Text = selectedRow.Cells["registrationNumber"].Value.ToString();
                txtLastName.Text = selectedRow.Cells["lastName"].Value.ToString();

                int clubId = Convert.ToInt32(selectedRow.Cells["idScholarShip"].Value);


                if (scholarshipDictionary.ContainsKey(clubId))
                {
                    string clubName = scholarshipDictionary[clubId];
                    cmbidScholarship.Text = $" {clubName}";
                }
               
                btnModificar.Enabled = true;
            }
        }

        private int GetselectedAccreditationControl()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                return (int)selectedRow.Cells["idScholarShip"].Value;
            }

            return -1;
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            string fisrtname = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string middleName = txtMiddleName.Text;
            string registration = txtRegistrationNumber.Text;
            string semester = txtSemester.Text;
            string specialty = txtSpecialty.Text;


            int idClub = scholarshipDictionary.FirstOrDefault(x => x.Value == cmbidScholarship.Text.Trim()).Key;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CreateStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@firstName", fisrtname);
                    command.Parameters.AddWithValue("@lastName", lastName);
                    command.Parameters.AddWithValue("@middleName", middleName);
                    command.Parameters.AddWithValue("@registrationNumber", registration);
                    command.Parameters.AddWithValue("@semester", semester);
                    command.Parameters.AddWithValue("@specialty", specialty);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Insertado correctamente.");
                        CargarDatosAccreditationControl();
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
            string fisrtname = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string middleName = txtMiddleName.Text;
            string registration = txtRegistrationNumber.Text;
            string semester = txtSemester.Text;
            string specialty = txtSpecialty.Text;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateStudent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@firstName", fisrtname);
                        command.Parameters.AddWithValue("@lastName", lastName);
                        command.Parameters.AddWithValue("@middleName", middleName);
                        command.Parameters.AddWithValue("@registrationNumber", registration);
                        command.Parameters.AddWithValue("@semester", semester);
                        command.Parameters.AddWithValue("@specialty", specialty);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Acreditación modificada correctamente.");
                            CargarDatosAccreditationControl();
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
                int accreditationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idStudent"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteStudent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idStudent", accreditationID);

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
