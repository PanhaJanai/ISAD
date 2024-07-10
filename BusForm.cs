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
        // tbBus Schema 
        //  BusID INT PRIMARY KEY IDENTITY(1,1),
        //  BusNumber NVARCHAR(10),
        //  BusTypeID INT REFERENCES tbBusType(BusTypeID) ON DELETE CASCADE ON UPDATE CASCADE,
        //  BusTypeName NVARCHAR(50),
        //  TicketPrice MONEY,
        //  DriverID INT REFERENCES tbDriver(DriverID) ON DELETE CASCADE ON UPDATE CASCADE,
        //  DriverName NVARCHAR(50),
        //  DriverTel NVARCHAR(20)

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        private SqlDataAdapter dataAdapter;
        private DataTable busTable;
        DataTable saveTable;

        public BusForm()
        {
            InitializeComponent();

            fillBusTable();

            saveTable = busTable.Clone();
            txtBusID.Text = getLatestBusID().ToString();
            gridBus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // search for bus by busID using busTable and highlight the row
            foreach (DataGridViewRow row in gridBus.Rows)
            {
                if (row.Cells[0].Value.ToString().Equals(txtSearch.Text))
                {
                    row.Selected = true;
                    gridBus.CurrentCell = row.Cells[0];
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
                }
            }
            catch
            {
                MessageBox.Show("Error updating data");
            }
        }

        private void cmbDriverTel_SelectedIndexChanged(object sender, EventArgs e)
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
            txtBusID.Text = getLatestBusID().ToString();
            txtBusNo.Text = "";
            txtBusTypeID.Text = "";
            cmbBusTypeName.Text = "";
            txtTicketPrice.Text = "";
            txtDriverID.Text = "";
            txtDriverName.Text = "";
            cmbDriverTel.Text = "";
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

        int getLatestBusID()
        {
            return busTable.Rows[busTable.Rows.Count - 1].Field<int>("BusID") + 1;
        }

        void fillBusTable()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                dataAdapter = new SqlDataAdapter("SELECT * FROM tbBus", con);
                busTable = new DataTable();
                dataAdapter.Fill(busTable);
                gridBus.DataSource = busTable;
            }
        }
    }
}
