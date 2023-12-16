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
    public partial class Material : Form
    {
        private string connectionString = "Data Source=AXEL\\SQLEXPRESS;Initial Catalog=Extracurricular;Integrated Security=True;Connect Timeout=60";

        public Material()
        {
            InitializeComponent();
        }

        private void Material_Load(object sender, EventArgs e)
        {
            txtItemName.MaxLength = 40;
            txtItemType.MaxLength = 20;
            txtQuantity.MaxLength = 20;

            dataGridView1.CellClick += dataGridView1_CellClick;

            CargarMaterialLoan();
            CargarMaterialType();
            CargarDatosAccreditationControl();

            btnModificar.Enabled = false;
        }
        private void CargarDatosAccreditationControl()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "EXEC GetMaterials";

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
        private Dictionary<int, string> MaterialLoanDictionary = new Dictionary<int, string>();
        private Dictionary<int, string> MaterialTypeDictionary = new Dictionary<int, string>();

        private void CargarMaterialLoan()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetMaterialLoans", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    cmbIdMaterialLoan.Items.Clear();
                    MaterialLoanDictionary.Clear();

                    while (reader.Read())
                    {
                        int idClub = (int)reader["idMaterialLoan"];
                        string clubName = (string)reader["article"];

                        cmbIdMaterialLoan.Items.Add(clubName);
                        MaterialLoanDictionary.Add(idClub, clubName);
                    }

                    reader.Close();
                }

                connection.Close();
            }
        }

        private void CargarMaterialType()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("GetMaterialTypes", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    SqlDataReader reader = command.ExecuteReader();

                    cmbidMaterialType.Items.Clear();
                    MaterialTypeDictionary.Clear();

                    while (reader.Read())
                    {
                        int MaterialTid = (int)reader["idMaterialType"];
                        string materialname = (string)reader["materialTypeName"];

                        cmbidMaterialType.Items.Add(materialname);
                        MaterialTypeDictionary.Add(MaterialTid, materialname);
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

                txtItemName.Text = selectedRow.Cells["itemName"].Value.ToString();
                txtItemType.Text = selectedRow.Cells["itemtype"].Value.ToString();
                txtQuantity.Text = selectedRow.Cells["quantity"].Value.ToString();

                int materialid = Convert.ToInt32(selectedRow.Cells["idMaterialLoan"].Value);
                int MaterialTid = Convert.ToInt32(selectedRow.Cells["idMaterialType"].Value);


                if (MaterialLoanDictionary.ContainsKey(materialid))
                {
                    string maname = MaterialLoanDictionary[materialid];
                    cmbIdMaterialLoan.Text = $" {maname}";
                }
                if (MaterialTypeDictionary.ContainsKey(MaterialTid))
                {
                    string studentname = MaterialTypeDictionary[MaterialTid];
                    cmbidMaterialType.Text = $" {studentname}";
                }

                btnModificar.Enabled = true;
            }
        }

        private int GetselectedAccreditationControl()
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
                return (int)selectedRow.Cells["idMaterial"].Value;
            }

            return -1;
        }

        private void btninsertar_Click(object sender, EventArgs e)
        {
            string itemName = txtItemName.Text;
            int quantity = int.Parse(txtQuantity.Text);
            string itemType = txtItemType.Text;
            int materialLoanid = MaterialLoanDictionary.FirstOrDefault(x => x.Value == cmbIdMaterialLoan.Text.Trim()).Key;
            int materialtypeid = MaterialTypeDictionary.FirstOrDefault(x => x.Value == cmbidMaterialType.Text.Trim()).Key;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("CreateMaterial", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@itemName", itemName);
                    command.Parameters.AddWithValue("@quantity", quantity);
                    command.Parameters.AddWithValue("@itemType", itemType);
                    command.Parameters.AddWithValue("@idMaterialLoan", materialLoanid);
                    command.Parameters.AddWithValue("@idMaterialType", materialtypeid);


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

        private void btnMenu_Click(object sender, EventArgs e)
        {
            MenuOpciones me = new MenuOpciones();
            me.Show();
            this.Hide();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            int Materialid = GetselectedAccreditationControl();
            string itemName = txtItemName.Text;
            int quantity = int.Parse(txtQuantity.Text);
            string itemType = txtItemType.Text;
            int materialLoanid = MaterialLoanDictionary.FirstOrDefault(x => x.Value == cmbIdMaterialLoan.Text.Trim()).Key;
            int materialtypeid = MaterialTypeDictionary.FirstOrDefault(x => x.Value == cmbidMaterialType.Text.Trim()).Key;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UpdateMaterial", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@idMaterial", Materialid);
                        command.Parameters.AddWithValue("@itemName", itemName);
                        command.Parameters.AddWithValue("@quantity", quantity);
                        command.Parameters.AddWithValue("@itemType", itemType);
                        command.Parameters.AddWithValue("@idMaterialLoan", materialLoanid);
                        command.Parameters.AddWithValue("@idMaterialType", materialtypeid);

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
                int accreditationID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["idMaterial"].Value);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DeleteMaterial", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@idMaterial", accreditationID);

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
