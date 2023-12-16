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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace ProyectoMaestroDetalle
{
    public partial class clubSchedule : Form
    {
        private string connectionString = "Data Source=AXEL\\SQLEXPRESS;Initial Catalog=Extracurricular;Integrated Security=True;Connect Timeout=60";

        public clubSchedule()
        {
            InitializeComponent();
        }

        private void clubSchedule_Load(object sender, EventArgs e)
        {
            txtEndTime.MaxLength = 40;
            txtStartTime.MaxLength = 20;

            dataGridView1.CellClick += dataGridView1_CellClick;

            CargarClub();
            CargarDatosClubSchedule();
            CargarEmployee();

            btnModificar.Enabled = false;
           
        }
        private void CargarDatosClubSchedule()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "EXEC GetClubSchedules";

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
        private Dictionary<int, string> clubDictionary = new Dictionary<int, string>();
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
        private void CargarEmployee()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetEmployees", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    cbidEmployee.Items.Clear();
                    employeeDictionary.Clear();

                    while (reader.Read())
                    {
                        int idEmployee = (int)reader["idEmployee"];
                        string firstName = (string)reader["firstName"];

                        cbidEmployee.Items.Add(firstName);
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

                txtEndTime.Text = selectedRow.Cells["endTime"].Value.ToString();
                txtStartTime.Text = selectedRow.Cells["startTime"].Value.ToString();
                dtpDayOfWeek.Text = selectedRow.Cells["dayOfWeek"].Value.ToString();


                int clubId = Convert.ToInt32(selectedRow.Cells["idClub"].Value);
                int employeeid = Convert.ToInt32(selectedRow.Cells["idEmployee"].Value);


                if (clubDictionary.ContainsKey(clubId))
                {
                    string clubName = clubDictionary[clubId];
                    cmbidClub.Text = $" {clubName}";
                }

                if (employeeDictionary.ContainsKey(employeeid))
                {
                    string firstname = employeeDictionary[employeeid];
                    cbidEmployee.Text = $" {firstname}";
                }
                btnModificar.Enabled = true;
            }
        }
        private int GetselectedClubSchedule()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                return (int)selectedRow.Cells["idClubSchedule"].Value;
            }

            return -1;
        }

        private void btnInsertar_Click(object sender, EventArgs e)
        {
            DateTime dayofweek = dtpDayOfWeek.Value;
            TimeSpan startTime = TimeSpan.Parse(txtStartTime.Text);
            TimeSpan endTime = TimeSpan.Parse(txtEndTime.Text);
            int idEmployee = employeeDictionary.FirstOrDefault(x => x.Value == cbidEmployee.Text.Trim()).Key;
            int idClub = clubDictionary.FirstOrDefault(x => x.Value == cmbidClub.Text.Trim()).Key;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CreateClubSchedule", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@dayOfWeek", dayofweek);
                    command.Parameters.AddWithValue("@startTime", startTime);
                    command.Parameters.AddWithValue("@endTime", endTime);
                    command.Parameters.AddWithValue("@idClub", idClub);
                    command.Parameters.AddWithValue("@idEmployee", idEmployee);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Insertado correctamente.");
                        CargarDatosClubSchedule();
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
            int clubscheduleid = GetselectedClubSchedule();
            DateTime dayofweek = dtpDayOfWeek.Value;
            TimeSpan startTime = TimeSpan.Parse(txtStartTime.Text);
            TimeSpan endtime = TimeSpan.Parse(txtEndTime.Text);
            int idEmployee = employeeDictionary.FirstOrDefault(x => x.Value == cbidEmployee.Text.Trim()).Key;
            int idClub = clubDictionary.FirstOrDefault(x => x.Value == cmbidClub.Text.Trim()).Key;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateClubSchedule", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@idClubSchedule", clubscheduleid);
                        command.Parameters.AddWithValue("@dayOfWeek", dayofweek);
                        command.Parameters.AddWithValue("@startTime", startTime);
                        command.Parameters.AddWithValue("@endTime", endtime);
                        command.Parameters.AddWithValue("@idClub", idClub);
                        command.Parameters.AddWithValue("@idEmployee", idEmployee);


                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Acreditación modificada correctamente.");
                            CargarDatosClubSchedule();
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
                int accreditationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idClubSchedule"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteClubSchedule", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idClubSchedule", accreditationID);

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
