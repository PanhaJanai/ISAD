using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.VisualBasic;
using System.Security.Cryptography.Xml;
using System.Security.Principal;
using System.Security.Policy;
using System.Windows.Forms;
using System.CodeDom.Compiler;
using System.ComponentModel.Design.Serialization;

namespace PABMS
{
    public partial class TicketForm : Form
    {
        DataTable ticketTable = new DataTable();
        DataTable busTable = new DataTable();

        DataTable saveTable = new DataTable();
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        int offset = 0;

        public TicketForm(SqlConnection connection)
        {
            InitializeComponent();

            //fillTicketTable();
            //addNext10RowsToTicketTale();
            addFirst10RowsToTicketTale();
            fillBusTable();
            fillcmbBusNumber();

            txtTicketID.Text = getLatestID().ToString();
            ticketTable.PrimaryKey = new DataColumn[] { ticketTable.Columns["TicketID"] };
            saveTable = ticketTable.Clone();
            gridTicket.DataSource = ticketTable;

            gridTicket.CellClick += gridTicket_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnNew.Click += btnNew_Click;
        }

        void gridTicket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = gridTicket.CurrentRow;
            if (row != null)
            {
                txtBusID.Text = row.Cells["BusID"].Value.ToString();
                cmbBusNumber.Text = row.Cells["BusNumber"].Value.ToString();
                txtTicketPrice.Text = row.Cells["TicketPrice"].Value.ToString();

                txtTicketID.Text = row.Cells["TicketID"].Value.ToString();
                txtOrigin.Text = row.Cells["OriginName"].Value.ToString();
                txtDestination.Text = row.Cells["DestinationName"].Value.ToString();

                dtpPurchase.Value = Convert.ToDateTime(row.Cells["PurchaseDate"].Value);
                dtpDeparture.Value = Convert.ToDateTime(row.Cells["DepartureDate"].Value);
            }
        }
        void btnAdd_Click(object sender, EventArgs e)
        {
            DataRow row = saveTable.NewRow();

            if (!isAllFilled())
            {
                MessageBox.Show("Please fill all fields", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            row["TicketID"] = txtTicketID.Text;
            row["BusID"] = txtBusID.Text;
            row["BusNumber"] = cmbBusNumber.Text;
            row["TicketPrice"] = txtTicketPrice.Text;

            row["TicketID"] = txtTicketID.Text;
            row["OriginName"] = txtOrigin.Text;
            row["DestinationName"] = txtDestination.Text;

            row["PurchaseDate"] = dtpPurchase.Value;
            row["DepartureDate"] = dtpDeparture.Value;

            saveTable.Rows.Add(row);
            MessageBox.Show("Ticket added to save list", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            SavingDialogue dialog = new SavingDialogue(saveTable);
            dialog.ShowDialog();
            saveTable = dialog.save_table;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (DataRow row in saveTable.Rows)
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO tbTicket (PurchaseDate, DepartureDate, OriginName, DestinationName, BusID, BusNumber, TicketPrice) VALUES (@PurchaseDate, @DepartureDate, @OriginName, @DestinationName, @BusID, @BusNumber, @TicketPrice)", connection);
                        command.Parameters.AddWithValue("@PurchaseDate", row["PurchaseDate"]);
                        command.Parameters.AddWithValue("@DepartureDate", row["DepartureDate"]);
                        command.Parameters.AddWithValue("@OriginName", row["OriginName"]);
                        command.Parameters.AddWithValue("@DestinationName", row["DestinationName"]);
                        command.Parameters.AddWithValue("@BusID", row["BusID"]);
                        command.Parameters.AddWithValue("@BusNumber", row["BusNumber"]);
                        command.Parameters.AddWithValue("@TicketPrice", row["TicketPrice"]);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    MessageBox.Show("Ticket saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // after everything
            saveTable.Clear();
            refreshGridTicket();
        }

        void btnNew_Click(object sender, EventArgs e)
        {
            txtBusID.Text = "";
            cmbBusNumber.Text = "";
            txtTicketPrice.Text = "";
            txtTicketID.Text = getLatestID().ToString();
            txtOrigin.Text = "";
            txtDestination.Text = "";
            dtpPurchase.Value = DateTime.Now;
            dtpDeparture.Value = DateTime.Now;
            refreshGridTicket();
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTicketID.Text == "")
            {
                MessageBox.Show("Please select a ticket to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE tbTicket SET PurchaseDate = @PurchaseDate, DepartureDate = @DepartureDate, OriginName = @OriginName, DestinationName = @DestinationName, BusID = @BusID, BusNumber = @BusNumber, TicketPrice = @TicketPrice WHERE TicketID = @TicketID", connection);
                    command.Parameters.AddWithValue("@PurchaseDate", dtpPurchase.Value);
                    command.Parameters.AddWithValue("@DepartureDate", dtpDeparture.Value);
                    command.Parameters.AddWithValue("@OriginName", txtOrigin.Text);
                    command.Parameters.AddWithValue("@DestinationName", txtDestination.Text);
                    command.Parameters.AddWithValue("@BusID", txtBusID.Text);
                    command.Parameters.AddWithValue("@BusNumber", cmbBusNumber.Text);
                    command.Parameters.AddWithValue("@TicketPrice", txtTicketPrice.Text);
                    command.Parameters.AddWithValue("@TicketID", txtTicketID.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Ticket updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshGridTicket();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void fillBusTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM tbBus", connection);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(busTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void fillTicketTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM tbTicket", connection);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(ticketTable);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void fillcmbBusNumber()
        {
            cmbBusNumber.Items.Clear();
            foreach (DataRow row in busTable.Rows)
            {
                cmbBusNumber.Items.Add(row["BusNumber"]);
            }
        }

        void fillBusWithNumber()
        {
            foreach (DataRow row in busTable.Rows)
            {
                if (row["BusNumber"].ToString() == cmbBusNumber.Text)
                {
                    txtBusID.Text = row["BusID"].ToString();
                    txtTicketPrice.Text = row["TicketPrice"].ToString();
                    break;
                }
            }
        }

        int getLatestID()
        {
            int max = 0;
            DataRow row = ticketTable.Rows[ticketTable.Rows.Count - 1];
            max = Convert.ToInt32(row["TicketID"]);

            return max + 1;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable temp = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // execute SearchItemById with three arguments
                using (SqlCommand cmd = new SqlCommand("SearchItemById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", "tbTicket");
                    cmd.Parameters.AddWithValue("@PrimaryKeyName", "TicketID");
                    cmd.Parameters.AddWithValue("@Id", txtSearch.Text);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(temp);
                    }
                    gridTicket.DataSource = temp;
                }
            }
        }

        void refreshGridTicket()
        {
            //fillTicketTable();
            addFirst10RowsToTicketTale();
            gridTicket.DataSource = ticketTable;
        }

        private void cmbBusNumber_SelectedIndexChanged(object sender, EventArgs e)
        {
            fillBusWithNumber();
        }

        bool isAllFilled()
        {
            if (cmbBusNumber.Text == "" || txtOrigin.Text == "" || txtDestination.Text == "")
            {
                return false;
            }
            return true;
        }

        // Method to check if the user is at the end of the DataGridView
        public bool IsAtEndOfDataGridView(DataGridView dataGridView)
        {
            gridTicket.SuspendLayout();
            if (dataGridView.Rows.Count == 0)
                return false; // No rows in DataGridView.

            // Get the index of the last row that is currently displayed.
            int lastVisibleRowIndex = dataGridView.FirstDisplayedScrollingRowIndex;
            for (int i = dataGridView.FirstDisplayedScrollingRowIndex; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Displayed)
                {
                    lastVisibleRowIndex = i;
                }
                else
                {
                    break; // Exit the loop once you find the first row that is not displayed.
                }
            }
            gridTicket.ResumeLayout();
            return lastVisibleRowIndex == dataGridView.Rows.Count - 1;
        }

        void addFirst10RowsToTicketTale()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM tbTicket ORDER BY TicketID OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", connection);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(ticketTable);
                }
                connection.Close();
            }
        }
        void addNext10RowsToTicketTale()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM tbTicket ORDER BY TicketID OFFSET @offset ROWS FETCH NEXT 10 ROWS ONLY", connection);
                command.Parameters.AddWithValue("@offset", offset);
                offset += 10;
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(ticketTable);
                }
                connection.Close();
            }
        }

        // create a list of foo and give it 5 items
        private void gridTicket_Scroll(object sender, ScrollEventArgs e)
        {
            if (IsAtEndOfDataGridView(gridTicket))
            {
                
            }
        }
    }
}
