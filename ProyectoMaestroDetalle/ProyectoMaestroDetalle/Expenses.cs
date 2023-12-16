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

namespace ProyectoMaestroDetalle
{
    public partial class Expenses : Form
    {
        private string connectionString = "Data Source=AXEL\\SQLEXPRESS;Initial Catalog=Extracurricular;Integrated Security=True;Connect Timeout=60";

        public Expenses()
        {
            InitializeComponent();
        }

        private void Expenses_Load(object sender, EventArgs e)
        {
            txtAmount.MaxLength = 40;
            txtExpsnsedescription.MaxLength = 100;

            dataGridView1.CellClick += dataGridView1_CellClick;

            CargarExpenseType();
            CargarDatosExpenses();

            btnModificar.Enabled = false;
        }
        private void CargarDatosExpenses()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "EXEC GetExpenses";

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
        private void CargarExpenseType()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetExpenseTypes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    cmbIdClub.Items.Clear();
                    clubDictionary.Clear();

                    while (reader.Read())
                    {
                        int idClub = (int)reader["idExpenseType"];
                        string clubName = (string)reader["expenseTypeName"];

                        cmbIdClub.Items.Add(clubName);
                        clubDictionary.Add(idClub, clubName);
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

                txtAmount.Text = selectedRow.Cells["amount"].Value.ToString();
                txtExpsnsedescription.Text = selectedRow.Cells["expenseDescription"].Value.ToString();

                int clubId = Convert.ToInt32(selectedRow.Cells["idExpenseType"].Value);


                if (clubDictionary.ContainsKey(clubId))
                {
                    string clubName = clubDictionary[clubId];
                    cmbIdClub.Text = $" {clubName}";
                }
             
                btnModificar.Enabled = true;
            }
        }

        private int GetselectedExpensesl()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                return (int)selectedRow.Cells["idExpenses"].Value;
            }

            return -1;
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            DateTime expensedate = dtpDate.Value;
            string description = txtExpsnsedescription.Text;
            string amunt = txtAmount.Text;
            int idClub = clubDictionary.FirstOrDefault(x => x.Value == cmbIdClub.Text.Trim()).Key;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CreateExpense", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@amount", txtAmount.Text);
                    command.Parameters.AddWithValue("@expenseDescription",txtExpsnsedescription.Text);
                    command.Parameters.AddWithValue("@expenseDate", dtpDate.Value);
                    command.Parameters.AddWithValue("@idExpenseType", idClub);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Insertado correctamente.");
                        CargarDatosExpenses();
                    }
                    else
                    {
                        MessageBox.Show("Insertado correctamente.");
                    }
                }

                connection.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int expenseid = GetselectedExpensesl();
            DateTime expensedate = dtpDate.Value;
            string description = txtExpsnsedescription.Text;
            string amunt = txtAmount.Text;
            int idClub = clubDictionary.FirstOrDefault(x => x.Value == cmbIdClub.Text.Trim()).Key;


            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateExpense", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@idExpenses", expenseid);
                        command.Parameters.AddWithValue("@amount", txtAmount.Text);
                        command.Parameters.AddWithValue("@expenseDescription", txtExpsnsedescription.Text);
                        command.Parameters.AddWithValue("@expenseDate", dtpDate.Value);
                        command.Parameters.AddWithValue("@idExpenseType", idClub);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Acreditación modificada correctamente.");
                            CargarDatosExpenses();
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
                int accreditationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idExpenses"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteExpense", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idExpenses", accreditationID);

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

