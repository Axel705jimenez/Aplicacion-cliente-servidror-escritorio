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
    public partial class MaterialLoan : Form
    {
        private string connectionString = "Data Source=AXEL\\SQLEXPRESS;Initial Catalog=Extracurricular;Integrated Security=True;Connect Timeout=60";

        public MaterialLoan()
        {
            InitializeComponent();
        }

        private void MaterialLoan_Load(object sender, EventArgs e)
        {
            

            dataGridView1.CellClick += dataGridView1_CellClick;

            CargarDatosAccreditationControl();
            CargarStudent();
            cargarEmployee();
            btnModificar.Enabled = false;
        }
    
        private void CargarDatosAccreditationControl()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "EXEC GetMaterialLoans";

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
        private Dictionary<int, string> EmployeeDicitionary = new Dictionary<int, string>();
        private Dictionary<int, string> studentDictionary = new Dictionary<int, string>();
        private void cargarEmployee()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetEmployees", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    cmbidEmployee.Items.Clear();
                    EmployeeDicitionary.Clear();

                    while (reader.Read())
                    {
                        int idClub = (int)reader["idEmployee"];
                        string clubName = (string)reader["firstName"];

                        cmbidEmployee.Items.Add(clubName);
                        EmployeeDicitionary.Add(idClub, clubName);
                    }

                    reader.Close();
                }

                connection.Close();
            }
        }

        private void CargarStudent()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetStudents", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    cmbidStudent.Items.Clear();
                    studentDictionary.Clear();

                    while (reader.Read())
                    {
                        int idStudent = (int)reader["idStudent"];
                        string studentName = (string)reader["firstName"];

                        cmbidStudent.Items.Add(studentName);
                        studentDictionary.Add(idStudent, studentName);
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
                txtMaterialstatus.Text = selectedRow.Cells["materialStatus"].Value.ToString();
                txtArticle.Text = selectedRow.Cells["article"].Value.ToString();
                dtpentryDate.Text = selectedRow.Cells["entryDate"].Value.ToString();
                dtpExitDate.Text = selectedRow.Cells["exitDate"].Value.ToString();
                txtSpecialty.Text = selectedRow.Cells["specialty"].Value.ToString();

                int clubId = Convert.ToInt32(selectedRow.Cells["idEmployee"].Value);
                int studentid = Convert.ToInt32(selectedRow.Cells["idStudent"].Value);


                if (EmployeeDicitionary.ContainsKey(clubId))
                {
                    string clubName = EmployeeDicitionary[clubId];
                    cmbidEmployee.Text = $" {clubName}";
                }
                if (studentDictionary.ContainsKey(studentid))
                {
                    string studentname = studentDictionary[studentid];
                    cmbidStudent.Text = $" {studentname}";
                }

                btnModificar.Enabled = true;
            }
        }

        private int GetselectedAccreditationControl()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                return (int)selectedRow.Cells["idMaterialLoan"].Value;
            }

            return -1;
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            string materialStatus = txtMaterialstatus.Text;
            string specialty = txtSpecialty.Text;
            string article = txtArticle.Text;
            DateTime entrydate = dtpentryDate.Value;
            DateTime exitdate = dtpExitDate.Value;

            int idStudent = studentDictionary.FirstOrDefault(x => x.Value == cmbidStudent.Text.Trim()).Key;
            int idEmployee = EmployeeDicitionary.FirstOrDefault(x => x.Value == cmbidEmployee.Text.Trim()).Key;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CreateMaterialLoan", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@specialty", specialty);
                    command.Parameters.AddWithValue("@article", article);
                    command.Parameters.AddWithValue("@entryDate", entrydate);
                    command.Parameters.AddWithValue("@exitDate", exitdate);
                    command.Parameters.AddWithValue("@idStudent", idStudent);
                    command.Parameters.AddWithValue("@idEmployee", idEmployee);
                    command.Parameters.AddWithValue("@materialStatus", materialStatus);

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

            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            string materialStatus = txtMaterialstatus.Text;
            string specialty = txtSpecialty.Text;
            string article = txtArticle.Text;
            DateTime entrydate = dtpentryDate.Value;
            DateTime exitdate = dtpExitDate.Value;
            int MaterialLoanID = GetselectedAccreditationControl();
            int idStudent = studentDictionary.FirstOrDefault(x => x.Value == cmbidStudent.Text.Trim()).Key;
            int idEmployee = EmployeeDicitionary.FirstOrDefault(x => x.Value == cmbidEmployee.Text.Trim()).Key;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateMaterialLoan", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idMaterialLoan", MaterialLoanID);

                        command.Parameters.AddWithValue("@specialty", specialty);
                        command.Parameters.AddWithValue("@article", article);
                        command.Parameters.AddWithValue("@entryDate", entrydate);
                        command.Parameters.AddWithValue("@exitDate", exitdate);
                        command.Parameters.AddWithValue("@idStudent", idStudent);
                        command.Parameters.AddWithValue("@idEmployee", idEmployee);
                        command.Parameters.AddWithValue("@materialStatus", materialStatus);


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
                int accreditationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idMaterialLoan"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteMaterialLoan", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idMaterialLoan", accreditationID);

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
