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

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private DataTable truckTable = new DataTable();
        DataTable driverTable = new DataTable();
        DataTable saveTable;

        Funcs funcs = new Funcs();

        public TruckForm()
        {
            InitializeComponent();

            funcs.info = new Funcs.Info(connectionString, "tbTruck", "TruckID", truckTable, gridTruck);

            refreshGrid();

            // add DriverID, DriverName, DriverTel to driverTable
            driverTable.Columns.Add("DriverID");
            driverTable.Columns.Add("DriverName");
            driverTable.Columns.Add("DriverTel");

            fillCmbDriverTel();

            saveTable = truckTable.Clone();
            txtTruckID.Text = funcs.getLatestID().ToString();
            gridTruck.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            funcs.info.id = Convert.ToInt32(txtSearch.Text);
            funcs.searchByID();
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
                    refreshGrid();
                }
            }
            catch
            {
                MessageBox.Show("Error updating data");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // create a new row in trucktable and add the data
            DataRow row = saveTable.NewRow();
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
                refreshGrid();
            }
            catch
            {
                MessageBox.Show("Error saving data");
            }


            saveTable.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTruckID.Text = funcs.getLatestID().ToString();
            txtTruckNumber.Text = "";
            txtDriverID.Text = "";
            txtDriverName.Text = "";
            cmbDriverTel.Text = "";
            refreshGrid();
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

        void refreshGrid()
        {
            funcs.addFirst10RowsToDataTable();
            gridTruck.DataSource = truckTable;
        }

        private void label11_Click(object sender, EventArgs e)
        {
            txtTruckID.Text = funcs.getLatestID().ToString();
        }

        void fillCmbDriverTel()
        {
            // query DriverName, DriverName, DriverTel from tbDriver
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM tbDriver", con);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    driverTable.Rows.Add(reader["DriverID"].ToString(), reader["DriverName"].ToString(), reader["DriverTel"].ToString());
                    cmbDriverTel.Items.Add(reader["DriverTel"].ToString());
                }
                con.Close();
            }
        }

        private void cmbDriverTel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbDriverTel.SelectedIndex != -1)
            {
                txtDriverID.Text = driverTable.Rows[cmbDriverTel.SelectedIndex]["DriverID"].ToString();
                txtDriverName.Text = driverTable.Rows[cmbDriverTel.SelectedIndex]["DriverName"].ToString();
            }
        }

        private void gridTruck_Scroll(object sender, ScrollEventArgs e)
        {
            funcs.addRowWhenScrollingEnds();
        }
    }
}
