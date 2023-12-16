using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.SqlClient;
using static ProyectoMaestroDetalle.AccreditationControl;

namespace ProyectoMaestroDetalle
{
    public partial class AttendanceRecord : Form
    {
        private string connectionString = "Data Source=AXEL\\SQLEXPRESS;Initial Catalog=Extracurricular;Integrated Security=True;Connect Timeout=60";

        public AttendanceRecord()
        {
            InitializeComponent();
        }

        private void pp_Load(object sender, EventArgs e)
        {
            txtAttended.MaxLength = 40;

            dataGridView1.CellClick += dataGridView1_CellClick;

            CargarClub();
            CargarDatosAttendanceRecord();
            CargarStudent();

            btnModificar.Enabled = false;
        }

        private void CargarDatosAttendanceRecord()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "EXEC GetAttendanceRecords";

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

                txtAttended.Text = selectedRow.Cells["Attended"].Value.ToString();
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

                dtbDate.Text = selectedRow.Cells["date"].Value.ToString();
                btnModificar.Enabled = true;
            }
        }
        private int GetselectedAtendanceRecord()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                return (int)selectedRow.Cells["AttendanceRecordId"].Value;
            }

            return -1;
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            int idStudent = studentDictionary.FirstOrDefault(x => x.Value == cmbidStudent.Text.Trim()).Key;
            int idClub = clubDictionary.FirstOrDefault(x => x.Value == cmbidClub.Text.Trim()).Key;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CreateAttendanceRecord", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@date", dtbDate.Value);
                    command.Parameters.AddWithValue("@attended", txtAttended.Text);
                    command.Parameters.AddWithValue("@idStudent", idStudent);
                    command.Parameters.AddWithValue("@idClub", idClub);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Insertado correctamente.");
                        CargarDatosAttendanceRecord();
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar.");
                    }
                }

                connection.Close();
            }

        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int attendanceRecordId = GetselectedAtendanceRecord();
            DateTime date = dtbDate.Value;
            string attended = txtAttended.Text;
            int idStudent = studentDictionary.FirstOrDefault(x => x.Value == cmbidStudent.Text.Trim()).Key;
            int idClub = clubDictionary.FirstOrDefault(x => x.Value == cmbidClub.Text.Trim()).Key;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateAttendanceRecord", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@AttendanceRecordId", attendanceRecordId);
                        command.Parameters.AddWithValue("@date", date);
                        command.Parameters.AddWithValue("@attended", attended);
                        command.Parameters.AddWithValue("@idStudent", idStudent);
                        command.Parameters.AddWithValue("@idClub", idClub);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Acreditación modificada correctamente.");
                            CargarDatosAttendanceRecord();
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
                int attendanceRecordId = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["AttendanceRecordId"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    try
                    {
                        connection.Open();

                        using (SqlCommand command = new SqlCommand("DeleteAttendanceRecord", connection))
                        {
                            command.CommandType = CommandType.StoredProcedure;
                            command.Parameters.AddWithValue("@AttendanceRecordId", attendanceRecordId);

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
            else
            {
                MessageBox.Show("Seleccione una fila para eliminar.");
            }

        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuOpciones menu = new MenuOpciones();
            menu.Show();
            this.Hide();
        }
    }
}
