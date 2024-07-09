using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PABMS
{
    public partial class PackageForm : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlConnection connection;
        public PackageForm(SqlConnection connection)
        {
            this.connection = connection;
            if (connection.State.Equals(ConnectionState.Closed))
            {
                this.connection.Open();
            }
            InitializeComponent();
            btnSearch.Click += btnSearch_Click;
            gridSearch.SelectionChanged += GridSearch_SelectionChanged;
            showPackages();
        }

        private void showPackages()
        {
            string query = @"
                SELECT 
                    p.PackageID,
                    p.PackageName,
                    p.PackagePrice,
                    p.DeliveryDate,
                    p.DepartureDate,
                    p.ReceiverContactInformation,
                    p.OriginName,
                    p.DestinationName,
                    t.TruckID,
                    t.TruckNumber,
                    t.DriverName,
                    t.DriverTel
                FROM tbPackage p
                JOIN tbTruck t ON p.TruckID = t.TruckID
                ";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                gridSearch.DataSource = table;
            }
        }

        private void SearchPackages(int packageId)
        {
            string query = @"
                SELECT 
                    p.PackageID,
                    p.PackageName,
                    p.PackagePrice,
                    p.DeliveryDate,
                    p.DepartureDate,
                    p.ReceiverContactInformation,
                    p.OriginName,
                    p.DestinationName,
                    t.TruckID,
                    t.TruckNumber,
                    t.DriverName,
                    t.DriverTel
                FROM tbPackage p
                JOIN tbTruck t ON p.TruckID = t.TruckID
                WHERE p.PackageID = @PackageID;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@PackageID", packageId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridSearch.DataSource = dt;
            }
        }

        private void GridSearch_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewRow row = gridSearch.CurrentRow;
            if (row != null)
            {
                DisplaySelectedRowData(row);
            }
        }

        private void DisplaySelectedRowData(DataGridViewRow row)
        {
            txtPackageID.Text = row.Cells["PackageID"].Value.ToString();
            txtPackageName.Text = row.Cells["PackageName"].Value.ToString();
            txtPackagePrice.Text = row.Cells["PackagePrice"].Value.ToString();
            txtReciverContact.Text = row.Cells["ReceiverContactInformation"].Value.ToString();
            txtOrigin.Text = row.Cells["OriginName"].Value.ToString();
            txtDestination.Text = row.Cells["DestinationName"].Value.ToString();

            txtTruckID.Text = row.Cells["TruckID"].Value.ToString();
            txtTruckNo.Text = row.Cells["TruckNumber"].Value.ToString();

            dateDeparture.Value = (DateTime)row.Cells["DepartureDate"].Value;
            dateDelivery.Value = (DateTime)row.Cells["DeliveryDate"].Value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string insertQuery = @"
                INSERT INTO tbPackage (PackageName, PackagePrice, DeliveryDate, DepartureDate, ReceiverContactInformation, OriginName, DestinationName, TruckID)
                VALUES (@PackageName, @PackagePrice, @DeliveryDate, @DepartureDate, @ReceiverContact, @Origin, @Destination, @TruckID)";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@PackageName", txtPackageName.Text);
                command.Parameters.AddWithValue("@PackagePrice", decimal.Parse(txtPackagePrice.Text));
                command.Parameters.AddWithValue("@DeliveryDate", DateTime.Parse(dateDelivery.Value.ToString()));
                command.Parameters.AddWithValue("@DepartureDate", DateTime.Parse(dateDeparture.Value.ToString()));
                command.Parameters.AddWithValue("@ReceiverContact", txtReciverContact.Text);
                command.Parameters.AddWithValue("@Origin", txtOrigin.Text);
                command.Parameters.AddWithValue("@Destination", txtDestination.Text);
                command.Parameters.AddWithValue("@TruckID", int.Parse(txtTruckID.Text));

                int result = command.ExecuteNonQuery();
                if (result > 0)
                    MessageBox.Show("Data inserted successfully.");
                else
                    MessageBox.Show("Data insertion failed.");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearch.Text, out int packageId))
            {
                SearchPackages(packageId);
            }
            else
            {
                MessageBox.Show("Please enter a valid Package ID.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateQuery = @"
                UPDATE tbPackage
                SET PackageName = @PackageName, PackagePrice = @PackagePrice, DeliveryDate = @DeliveryDate, DepartureDate = @DepartureDate, ReceiverContactInformation = @ReceiverContact, OriginName = @Origin, DestinationName = @Destination, TruckID = @TruckID
                WHERE PackageID = @PackageID";

            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@PackageName", txtPackageName.Text);
                command.Parameters.AddWithValue("@PackagePrice", decimal.Parse(txtPackagePrice.Text));
                command.Parameters.AddWithValue("@DeliveryDate", DateTime.Parse(dateDelivery.Value.ToString()));
                command.Parameters.AddWithValue("@DepartureDate", DateTime.Parse(dateDeparture.Value.ToString()));
                command.Parameters.AddWithValue("@ReceiverContact", txtReciverContact.Text);
                command.Parameters.AddWithValue("@Origin", txtOrigin.Text);
                command.Parameters.AddWithValue("@Destination", txtDestination.Text);
                command.Parameters.AddWithValue("@TruckID", int.Parse(txtTruckID.Text));
                command.Parameters.AddWithValue("@PackageID", int.Parse(txtPackageID.Text));

                int result = command.ExecuteNonQuery();

                if (result > 0)
                    MessageBox.Show("Data updated successfully.");
                else
                    MessageBox.Show("Data update failed.");
                
                showPackages();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtPackageID.Text = "";
            txtPackageName.Text = "";
            txtPackagePrice.Text = "";
            txtReciverContact.Text = "";
            txtOrigin.Text = "";
            txtDestination.Text = "";
            txtTruckID.Text = "";
            txtTruckNo.Text = "";
            dateDeparture.Value = DateTime.Now;
            dateDelivery.Value = DateTime.Now;
        }
    }
}
