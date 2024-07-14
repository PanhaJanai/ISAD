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

            fillPackageTable();
            txtPackageID.Text = getLatestID().ToString();
            //packageTable.PrimaryKey = new DataColumn[] { packageTable.Columns["PackageID"] };
            saveTable = packageTable.Clone();
            gridPackage.DataSource = packageTable;

            gridPackage.CellClick += gridPackage_CellClick;
            btnAdd.Click += btnAdd_Click;
            btnSave.Click += btnSave_Click;
            btnUpdate.Click += btnUpdate_Click;
            btnNew.Click += btnNew_Click;
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
            saveTable = dialog.save_table;

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

        private void fillPackageTable()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand("SELECT * FROM tbPackage", connection);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(packageTable);
                    }
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
            if (packageTable.Rows.Count > 0)
            {
                DataRow row = packageTable.Rows[packageTable.Rows.Count - 1];
                max = Convert.ToInt32(row["PackageID"]);
            }
            return max + 1;
        }

        void refreshGridPackage()
        {
            fillPackageTable();
            gridPackage.DataSource = packageTable;
        }

        bool isAllFilled()
        {
            return !string.IsNullOrEmpty(txtPackageName.Text) && !string.IsNullOrEmpty(txtPackagePrice.Text) && !string.IsNullOrEmpty(txtReceiverContact.Text) && !string.IsNullOrEmpty(txtOrigin.Text) && !string.IsNullOrEmpty(txtDestination.Text) && !string.IsNullOrEmpty(txtTruckID.Text) && !string.IsNullOrEmpty(cmbTruckNumber.Text);
        }

        private void label11_Click(object sender, EventArgs e)
        {
        }
    }
}
