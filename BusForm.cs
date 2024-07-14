using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace PABMS
{
    public partial class BusForm : Form
    {

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private SqlDataAdapter dataAdapter;
        private DataTable busTable = new DataTable();
        DataTable driverTable = new DataTable();
        DataTable busTypeTable = new DataTable();
        DataTable saveTable = new DataTable();
        funcs funcs = new funcs();

        public BusForm()
        {
            InitializeComponent();
            funcs.info = new funcs.Info(connectionString, "tbBus", "BusID", busTable, gridBus);

            refreshGrid();

            saveTable = busTable.Clone();
            txtBusID.Text = funcs.getLatestID().ToString();
            gridBus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            driverTable = funcs.fillComboBox(cmbDriverTel, "tbDriver", "DriverTel");
            busTypeTable = funcs.fillComboBox(cmbBusTypeName, "tbBusType", "BusTypeName");
        }

        void refreshGrid()
        {
            funcs.addFirst10RowsToDataTable();
            gridBus.DataSource = busTable;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            funcs.info.id = int.Parse(txtSearch.Text);
            funcs.search();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE tbBus SET BusNumber = @BusNumber, BusTypeID = @BusTypeID, BusTypeName = @BusTypeName, TicketPrice = @TicketPrice, DriverID = @DriverID, DriverName = @DriverName, DriverTel = @DriverTel WHERE BusID = @BusID", con);
                    cmd.Parameters.AddWithValue("@BusID", txtBusID.Text);
                    cmd.Parameters.AddWithValue("@BusNumber", txtBusNo.Text);
                    cmd.Parameters.AddWithValue("@BusTypeID", txtBusTypeID.Text);
                    cmd.Parameters.AddWithValue("@BusTypeName", cmbBusTypeName.Text);
                    cmd.Parameters.AddWithValue("@TicketPrice", txtTicketPrice.Text);
                    cmd.Parameters.AddWithValue("@DriverID", txtDriverID.Text);
                    cmd.Parameters.AddWithValue("@DriverName", txtDriverName.Text);
                    cmd.Parameters.AddWithValue("@DriverTel", cmbDriverTel.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Updated");
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
            // create a new row in busTable and add the data
            DataRow row = saveTable.NewRow();
            row["BusID"] = txtBusID.Text;
            row["BusNumber"] = txtBusNo.Text;
            row["BusTypeID"] = txtBusTypeID.Text;
            row["BusTypeName"] = cmbBusTypeName.Text;
            row["TicketPrice"] = txtTicketPrice.Text;
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
            busTable.Merge(saveTable);
            gridBus.Refresh();
            try
            {
                foreach (DataRow row in saveTable.Rows)
                {
                    // insert into db
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand("INSERT INTO tbBus(BusNumber, BusTypeID, BusTypeName, TicketPrice, DriverID, DriverName, DriverTel) VALUES(@BusNumber, @BusTypeID, @BusTypeName, @TicketPrice, @DriverID, @DriverName, @DriverTel)", con);
                        cmd.Parameters.AddWithValue("@BusNumber", row["BusNumber"]);
                        cmd.Parameters.AddWithValue("@BusTypeID", row["BusTypeID"]);
                        cmd.Parameters.AddWithValue("@BusTypeName", row["BusTypeName"]);
                        cmd.Parameters.AddWithValue("@TicketPrice", row["TicketPrice"]);
                        cmd.Parameters.AddWithValue("@DriverID", row["DriverID"]);
                        cmd.Parameters.AddWithValue("@DriverName", row["DriverName"]);
                        cmd.Parameters.AddWithValue("@DriverTel", row["DriverTel"]);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        refreshGrid();
                    }
                }
            }
            catch
            {
                MessageBox.Show("Error saving data");
            }
            MessageBox.Show("Saved");
            saveTable.Clear();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtBusID.Text = funcs.getLatestID().ToString();
            txtBusNo.Text = "";
            txtBusTypeID.Text = "";
            cmbBusTypeName.Text = "";
            txtTicketPrice.Text = "";
            txtDriverID.Text = "";
            txtDriverName.Text = "";
            cmbDriverTel.Text = "";
            refreshGrid();
        }

        private void gridBus_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = gridBus.CurrentRow;
            txtBusID.Text = row.Cells[0].Value.ToString();
            txtBusNo.Text = row.Cells[1].Value.ToString();
            txtBusTypeID.Text = row.Cells[2].Value.ToString();
            cmbBusTypeName.Text = row.Cells[3].Value.ToString();
            txtTicketPrice.Text = row.Cells[4].Value.ToString();
            txtDriverID.Text = row.Cells[5].Value.ToString();
            txtDriverName.Text = row.Cells[6].Value.ToString();
            cmbDriverTel.Text = row.Cells[7].Value.ToString();
        }

        private void cmbDriverTel_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            // txtDriverID
            // txtDriverName
            DataRow[] rows = driverTable.Select($"DriverTel = '{cmbDriverTel.Text}'");
            txtDriverID.Text = rows[0].Field<int>("DriverID").ToString();
            txtDriverName.Text = rows[0].Field<string>("DriverName");
        }

        private void cmbBusTypeName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // txtBusTypeID
            DataRow[] rows = busTypeTable.Select($"BusTypeName = '{cmbBusTypeName.Text}'");
            txtBusTypeID.Text = rows[0].Field<int>("BusTypeID").ToString();
        }
    }
}
