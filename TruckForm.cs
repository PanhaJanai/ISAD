using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace PABMS
{
    public partial class TruckForm : Form
    {
        // tbTruck Schema 
        //  TruckID INT PRIMARY KEY IDENTITY(1,1),
        //      TruckNumber NVARCHAR(10),
        //DriverID INT REFERENCES tbDriver(DriverID) ON DELETE CASCADE ON UPDATE CASCADE,
        //DriverName NVARCHAR(50),
        //DriverTel NVARCHAR(20)

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private SqlDataAdapter dataAdapter;
        private DataTable truckTable;
        DataTable saveTable;

        public TruckForm()
        {
            InitializeComponent();

            fillTruckTable();

            saveTable = truckTable.Clone();
            txtTruckID.Text = getLatestTruckID().ToString();
            gridTruck.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // search for truck by truckID using truckTable and highlight the row
            foreach (DataGridViewRow row in gridTruck.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(txtSearch.Text))
                {
                    row.Selected = true;
                    gridTruck.CurrentCell = row.Cells[0];
                    break;
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE tbTruck SET TruckNumber = @TruckNumber, DriverID = @DriverID, DriverName = @DriverName, DriverTel = @DriverTel WHERE TruckID = @TruckID", con);
                    cmd.Parameters.AddWithValue("@TruckID", txtTruckID.Text);
                    cmd.Parameters.AddWithValue("@TruckNumber", txtTruckNumber.Text);
                    cmd.Parameters.AddWithValue("@DriverID", txtDriverID.Text);
                    cmd.Parameters.AddWithValue("@DriverName", txtDriverName.Text);
                    cmd.Parameters.AddWithValue("@DriverTel", cmbDriverTel.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            } catch
            {
                MessageBox.Show("Error updating data");
            }
        }

        private void cmbTruckTel_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Function body is empty
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // create a new row in trucktable and add the data
            DataRow row = saveTable.NewRow();
            row["TruckID"] = txtTruckID.Text;
            row["TruckNumber"] = txtTruckNumber.Text;
            row["DriverID"] = txtDriverID.Text;
            row["DriverName"] = txtDriverName.Text;
            row["DriverTel"] = cmbDriverTel.Text;
            saveTable.Rows.Add(row);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavingDialogue savingDialogue = new SavingDialogue(saveTable);
            savingDialogue.ShowDialog();
            saveTable = savingDialogue.save_table;
            truckTable.Merge(saveTable);
            gridTruck.Refresh();
            try
            {
                foreach (DataRow row in saveTable.Rows)
                {
                    // insert into db
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO tbTruck(TruckNumber, DriverID, DriverName, DriverTel) VALUES(@TruckNumber, @DriverID, @DriverName, @DriverTel)", con);
                        cmd.Parameters.AddWithValue("@TruckNumber", row["TruckNumber"]);
                        cmd.Parameters.AddWithValue("@DriverID", row["DriverID"]);
                        cmd.Parameters.AddWithValue("@DriverName", row["DriverName"]);
                        cmd.Parameters.AddWithValue("@DriverTel", row["DriverTel"]);
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error saving data");
            }

            
            saveTable.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTruckID.Text = getLatestTruckID().ToString();
            txtTruckNumber.Text = "";
            txtDriverID.Text = "";
            txtDriverName.Text = "";
            cmbDriverTel.Text = "";
        }

        private void gridTruck_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = gridTruck.CurrentRow;
            txtTruckID.Text = row.Cells[0].Value.ToString();
            txtTruckNumber.Text = row.Cells[1].Value.ToString();
            txtDriverID.Text = row.Cells[2].Value.ToString();
            txtDriverName.Text = row.Cells[3].Value.ToString();
            cmbDriverTel.Text = row.Cells[4].Value.ToString();

        }

        int getLatestTruckID()
        {
            return truckTable.Rows[truckTable.Rows.Count - 1].Field<int>("TruckID") + 1;
        }

        void fillTruckTable()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                dataAdapter = new SqlDataAdapter("SELECT * FROM tbTruck", con);
                truckTable = new DataTable();
                dataAdapter.Fill(truckTable);
                gridTruck.DataSource = truckTable;
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {
            txtTruckID.Text = getLatestTruckID().ToString();
        }
    }
}
