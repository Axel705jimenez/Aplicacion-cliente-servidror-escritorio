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
    public partial class Facility : Form
    {
        private string connectionString = "Data Source=AXEL\\SQLEXPRESS;Initial Catalog=Extracurricular;Integrated Security=True;Connect Timeout=60";

        public Facility()
        {
            InitializeComponent();
        }

        private void Facility_Load(object sender, EventArgs e)
        {
            txtAcailability.MaxLength = 40;
            txtCapacity.MaxLength = 20;
            txtFacilityName.MaxLength = 40;
            txtLocation.MaxLength = 20;

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

                string query = "EXEC GetFacilities";

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
        private void CargarClub()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetClubs", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    cmbIdClub.Items.Clear();
                    clubDictionary.Clear();

                    while (reader.Read())
                    {
                        int idClub = (int)reader["idClub"];
                        string clubName = (string)reader["name"];

                        cmbIdClub.Items.Add(clubName);
                        clubDictionary.Add(idClub, clubName);
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

                txtAcailability.Text = selectedRow.Cells["availability"].Value.ToString();
                txtCapacity.Text = selectedRow.Cells["capacity"].Value.ToString();
                txtFacilityName.Text = selectedRow.Cells["facilityName"].Value.ToString();
                txtLocation.Text = selectedRow.Cells["location"].Value.ToString();

                int clubId = Convert.ToInt32(selectedRow.Cells["idClub"].Value);


                if (clubDictionary.ContainsKey(clubId))
                {
                    string clubName = clubDictionary[clubId];
                    cmbIdClub.Text = $" {clubName}";
                }
               
                btnModificar.Enabled = true;
            }
        }

        private int GetselectedAccreditationControl()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                return (int)selectedRow.Cells["idFacility"].Value;
            }

            return -1;
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            string facilityName = txtFacilityName.Text;
            string capacity = txtCapacity.Text;
            string location = txtLocation.Text;
            string availability = txtAcailability.Text;
            int idClub = clubDictionary.FirstOrDefault(x => x.Value == cmbIdClub.Text.Trim()).Key;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CreateFacility", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@facilityName", facilityName);
                    command.Parameters.AddWithValue("@capacity", capacity);
                    command.Parameters.AddWithValue("@location", location);
                    command.Parameters.AddWithValue("@availability", availability);
                    command.Parameters.AddWithValue("@idClub", idClub);


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
            int facilityid = GetselectedAccreditationControl();
            string facilityName = txtFacilityName.Text;
            string capacity = txtCapacity.Text;
            string location = txtLocation.Text;
            string availability = txtAcailability.Text;
            int idClub = clubDictionary.FirstOrDefault(x => x.Value == cmbIdClub.Text.Trim()).Key;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateFacility", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@idFacility", facilityid);
                        command.Parameters.AddWithValue("@facilityName", facilityName);
                        command.Parameters.AddWithValue("@capacity", capacity);
                        command.Parameters.AddWithValue("@location", location);
                        command.Parameters.AddWithValue("@availability", availability);
                        command.Parameters.AddWithValue("@idClub", idClub);

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
                int accreditationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idFacility"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteFacility", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idFacility", accreditationID);

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
