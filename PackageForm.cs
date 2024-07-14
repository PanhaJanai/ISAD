using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace PABMS
{
    public partial class PackageForm : Form
    {
        DataTable packageTable = new DataTable();
        DataTable saveTable = new DataTable();
        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public PackageForm()
        {
            InitializeComponent();

            addFirst10RowsToDataTable(packageTable, "tbPackage", "PackageID");
            //txtPackageID.Text = getLatestID().ToString();
            //packageTable.PrimaryKey = new DataColumn[] { packageTable.Columns["PackageID"] };
            saveTable = packageTable.Clone();
            gridPackage.DataSource = packageTable;

            gridPackage.Scroll += gridPackage_Scroll;

        }

        void gridPackage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = gridPackage.CurrentRow;
            if (row != null)
            {
                txtPackageID.Text = row.Cells["PackageID"].Value.ToString();
                txtPackageName.Text = row.Cells["PackageName"].Value.ToString();
                txtPackagePrice.Text = row.Cells["PackagePrice"].Value.ToString();
                dtpDeliveryDate.Value = Convert.ToDateTime(row.Cells["DeliveryDate"].Value);
                dtpDepartureDate.Value = Convert.ToDateTime(row.Cells["DepartureDate"].Value);
                txtReceiverContact.Text = row.Cells["ReceiverContactInformation"].Value.ToString();
                txtOrigin.Text = row.Cells["OriginName"].Value.ToString();
                txtDestination.Text = row.Cells["DestinationName"].Value.ToString();
                txtTruckID.Text = row.Cells["TruckID"].Value.ToString();
                cmbTruckNumber.Text = row.Cells["DriverNumber"].Value.ToString();
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

            row["PackageName"] = txtPackageName.Text;
            row["PackagePrice"] = txtPackagePrice.Text;
            row["DeliveryDate"] = dtpDeliveryDate.Value;
            row["DepartureDate"] = dtpDepartureDate.Value;
            row["ReceiverContactInformation"] = txtReceiverContact.Text;
            row["OriginName"] = txtOrigin.Text;
            row["DestinationName"] = txtDestination.Text;
            row["TruckID"] = txtTruckID.Text;
            row["DriverNumber"] = cmbTruckNumber.Text;

            saveTable.Rows.Add(row);
            MessageBox.Show("Package added to save list", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            SavingDialogue dialog = new SavingDialogue(saveTable);
            dialog.ShowDialog();
            saveTable = dialog.save_table.Copy();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    foreach (DataRow row in saveTable.Rows)
                    {
                        SqlCommand command = new SqlCommand("INSERT INTO tbPackage (PackageName, PackagePrice, DeliveryDate, DepartureDate, ReceiverContactInformation, OriginName, DestinationName, TruckID, DriverNumber) VALUES (@PackageName, @PackagePrice, @DeliveryDate, @DepartureDate, @ReceiverContactInformation, @OriginName, @DestinationName, @TruckID, @DriverNumber)", connection);
                        command.Parameters.AddWithValue("@PackageName", row["PackageName"]);
                        command.Parameters.AddWithValue("@PackagePrice", row["PackagePrice"]);
                        command.Parameters.AddWithValue("@DeliveryDate", row["DeliveryDate"]);
                        command.Parameters.AddWithValue("@DepartureDate", row["DepartureDate"]);
                        command.Parameters.AddWithValue("@ReceiverContactInformation", row["ReceiverContactInformation"]);
                        command.Parameters.AddWithValue("@OriginName", row["OriginName"]);
                        command.Parameters.AddWithValue("@DestinationName", row["DestinationName"]);
                        command.Parameters.AddWithValue("@TruckID", row["TruckID"]);
                        command.Parameters.AddWithValue("@DriverNumber", row["DriverNumber"]);
                        command.ExecuteNonQuery();
                    }
                    connection.Close();
                    MessageBox.Show("Package saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            saveTable.Clear();
            refreshGridPackage();
        }

        void btnNew_Click(object sender, EventArgs e)
        {
            txtPackageID.Text = getLatestID().ToString();
            txtPackageName.Text = "";
            txtPackagePrice.Text = "";
            dtpDeliveryDate.Value = DateTime.Now;
            dtpDepartureDate.Value = DateTime.Now;
            txtReceiverContact.Text = "";
            txtOrigin.Text = "";
            txtDestination.Text = "";
            txtTruckID.Text = "";
            cmbTruckNumber.Text = "";
            refreshGridPackage();
        }

        void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPackageID.Text == "")
            {
                MessageBox.Show("Please select a package to update", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("UPDATE tbPackage SET PackageName = @PackageName, PackagePrice = @PackagePrice, DeliveryDate = @DeliveryDate, DepartureDate = @DepartureDate, ReceiverContactInformation = @ReceiverContactInformation, OriginName = @OriginName, DestinationName = @DestinationName, TruckID = @TruckID, DriverNumber = @DriverNumber WHERE PackageID = @PackageID", connection);
                    command.Parameters.AddWithValue("@PackageName", txtPackageName.Text);
                    command.Parameters.AddWithValue("@PackagePrice", txtPackagePrice.Text);
                    command.Parameters.AddWithValue("@DeliveryDate", dtpDeliveryDate.Value);
                    command.Parameters.AddWithValue("@DepartureDate", dtpDepartureDate.Value);
                    command.Parameters.AddWithValue("@ReceiverContactInformation", txtReceiverContact.Text);
                    command.Parameters.AddWithValue("@OriginName", txtOrigin.Text);
                    command.Parameters.AddWithValue("@DestinationName", txtDestination.Text);
                    command.Parameters.AddWithValue("@TruckID", txtTruckID.Text);
                    command.Parameters.AddWithValue("@DriverNumber", cmbTruckNumber.Text);
                    command.Parameters.AddWithValue("@PackageID", txtPackageID.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Package updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    refreshGridPackage();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        int getLatestID()
        {
            int max = 0;
            // query to get the latest ID from the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT MAX(PackageID) FROM tbPackage", connection);
                max = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
            }
            return max + 1;
        }

        void refreshGridPackage()
        {
            addFirst10RowsToDataTable(packageTable, "tbPackage", "PackageID");
            gridPackage.DataSource = packageTable;
        }

        bool isAllFilled()
        {
            return !string.IsNullOrEmpty(txtPackageName.Text) && !string.IsNullOrEmpty(txtPackagePrice.Text) && !string.IsNullOrEmpty(txtReceiverContact.Text) && !string.IsNullOrEmpty(txtOrigin.Text) && !string.IsNullOrEmpty(txtDestination.Text) && !string.IsNullOrEmpty(txtTruckID.Text) && !string.IsNullOrEmpty(cmbTruckNumber.Text);
        }

        int offset = 0;
        public bool IsAtEndOfDataGridView(DataGridView dataGridView)
        {
            gridPackage.SuspendLayout();
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
            gridPackage.ResumeLayout();
            return lastVisibleRowIndex == dataGridView.Rows.Count - 1;
        }

        void addFirst10RowsToDataTable(DataTable dt, string tableName, string tablePrimaryID)
        {
            dt.Clear();
            offset = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM {tableName} ORDER BY {tablePrimaryID} OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", connection);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(packageTable);
                }
                connection.Close();
            }
        }
        void addNext10RowsToDataTable(DataTable dt, string tableName, string tablePrimaryID)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM {tableName} ORDER BY {tablePrimaryID} OFFSET @offset ROWS FETCH NEXT 10 ROWS ONLY", connection);
                offset += 10;
                command.Parameters.AddWithValue("@offset", offset);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(packageTable);
                }
                connection.Close();
            }
        }

        void addRowWhenScrollingEnds(DataGridView grid, string tableName, string primaryKeyName)
        {
            if (IsAtEndOfDataGridView(grid))
            {
                addNext10RowsToDataTable(packageTable, tableName, primaryKeyName);
                grid.Refresh();
            }
        }

        void search(string tableName, string primaryKeyName, string id, DataGridView grid)
        {
            DataTable temp = new DataTable();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                // execute SearchItemById with three arguments
                using (SqlCommand cmd = new SqlCommand("SearchItemById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", tableName);
                    cmd.Parameters.AddWithValue("@PrimaryKeyName", primaryKeyName);
                    cmd.Parameters.AddWithValue("@Id", id);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(temp);
                    }
                    grid.DataSource = temp;
                }
            }
        }

        private void gridPackage_Scroll(object sender, ScrollEventArgs e)
        {
            addRowWhenScrollingEnds(gridPackage, "tbTicket", "TicketID");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            search("tbPackage", "PackageID", txtSearch.Text, gridPackage);
        }
    }
}
