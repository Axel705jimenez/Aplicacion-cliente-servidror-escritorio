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
    public partial class ClubStudent : Form
    {
        private string connectionString = "Data Source=AXEL\\SQLEXPRESS;Initial Catalog=Extracurricular;Integrated Security=True;Connect Timeout=60";

        public ClubStudent()
        {
            InitializeComponent();
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            int idStudent = studentDictionary.FirstOrDefault(x => x.Value == cmbidStudent.Text.Trim()).Key;
            int idClub = clubDictionary.FirstOrDefault(x => x.Value == cmbidClub.Text.Trim()).Key;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CreateClubStudent", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@idStudent", idStudent);
                    command.Parameters.AddWithValue("@idClub", idClub);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Insertado correctamente.");
                        CargarDatosClubStudent();
                    }
                    else
                    {
                        MessageBox.Show("Insertado correctamente.");
                    }
                }

                connection.Close();
            }
        }

        private void ClubStudent_Load(object sender, EventArgs e)
        {


            dataGridView1.CellClick += dataGridView1_CellClick;

            CargarClub();
            CargarDatosClubStudent();
            CargarStudent();

            btnModificar.Enabled = false;
        }
        private void CargarDatosClubStudent()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "EXEC GetClubStudents";

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
        private Dictionary<int, string> clubDictionary = new Dictionary<int, string>();
        private Dictionary<int, string> studentDictionary = new Dictionary<int, string>();

        private void CargarClub()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetClubs", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    cmbidClub.Items.Clear();
                    clubDictionary.Clear();

                    while (reader.Read())
                    {
                        int idClub = (int)reader["idClub"];
                        string clubName = (string)reader["name"];

                        cmbidClub.Items.Add(clubName);
                        clubDictionary.Add(idClub, clubName);
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
                int clubId = Convert.ToInt32(selectedRow.Cells["idClub"].Value);
                int studentid = Convert.ToInt32(selectedRow.Cells["idStudent"].Value);


                if (clubDictionary.ContainsKey(clubId))
                {
                    string clubName = clubDictionary[clubId];
                    cmbidClub.Text = $" {clubName}";
                }
                if (studentDictionary.ContainsKey(studentid))
                {
                    string studentname = studentDictionary[studentid];
                    cmbidStudent.Text = $" {studentname}";
                }
                btnModificar.Enabled = true;
            }
        }
        private int GetselectedClubStudent()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                return (int)selectedRow.Cells["idClubStudent"].Value;
            }

            return -1;
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuOpciones me = new MenuOpciones();
            me.Show();
            this.Hide();

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int idStudent = studentDictionary.FirstOrDefault(x => x.Value == cmbidStudent.Text.Trim()).Key;
            int idClub = clubDictionary.FirstOrDefault(x => x.Value == cmbidClub.Text.Trim()).Key;
            int clubstudentid = GetselectedClubStudent();


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateClubStudent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@idClubStudent", clubstudentid);
                        command.Parameters.AddWithValue("@idStudent", idStudent);
                        command.Parameters.AddWithValue("@idClub", idClub);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Acreditación modificada correctamente.");
                            CargarDatosClubStudent();
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
                int accreditationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idClubStudent"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteClubStudent", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idClubStudent", accreditationID);

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
