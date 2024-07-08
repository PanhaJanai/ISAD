using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PABMS
{
    public partial class TicketForm : Form
    {
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;
        SqlConnection connection;

        public TicketForm(SqlConnection connection)
        {
            InitializeComponent();
            dataAdapter = new SqlDataAdapter();
            dataTable = new DataTable();
            this.connection = connection;
            if (connection.State.Equals(ConnectionState.Closed))
            {
                this.connection.Open();
            }
        }

        private void TicketForm_Load(object sender, EventArgs e)
        {
            FillComboBusID();
            FillComboStaffID();
        }

        private void FillComboBusID()
        {
            string query = "SELECT BusID, BusNumber FROM tbBus";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbBusNumber.DisplayMember = "BusNumber";
                cmbBusNumber.ValueMember = "BusID";
                cmbBusNumber.DataSource = dt;
            }
        }

        private void FillComboStaffID()
        {
            string query = "SELECT StaffID, StaffName FROM tbStaff";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                cmbStaffName.DisplayMember = "StaffName";
                cmbStaffName.ValueMember = "StaffID";
                cmbStaffName.DataSource = dt;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string insertQuery = @"
                INSERT INTO tbTicket (PurchaseDate, DepartureDate, OriginName, DestinationName, BusID, TicketPrice)
                VALUES (@PurchaseDate, @DepartureDate, @Origin, @Destination, @BusID, @TicketPrice)";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@PurchaseDate", DateTime.Parse(dtpPurchase.Value.ToString()));
                command.Parameters.AddWithValue("@DepartureDate", DateTime.Parse(dtpDeparture.Value.ToString()));
                command.Parameters.AddWithValue("@Origin", txtOrigin.Text);
                command.Parameters.AddWithValue("@Destination", txtDestination.Text);
                command.Parameters.AddWithValue("@BusID", int.Parse(cmbBusNumber.SelectedValue.ToString()));
                command.Parameters.AddWithValue("@TicketPrice", decimal.Parse(txtTicketPrice.Text));

                int result = command.ExecuteNonQuery();
                if (result > 0)
                    MessageBox.Show("Data inserted successfully.");
                else
                    MessageBox.Show("Data insertion failed.");
            }
        }

        private void gridTicket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = gridTicket.Rows[e.RowIndex];
                txtTicketID.Text = row.Cells[0].Value.ToString();
                dtpPurchase.Value = DateTime.Parse(row.Cells[1].Value.ToString());
                dtpDeparture.Value = DateTime.Parse(row.Cells[2].Value.ToString());
                txtOrigin.Text = row.Cells[3].Value.ToString();
                txtDestination.Text = row.Cells[4].Value.ToString();
                cmbBusNumber.SelectedValue = row.Cells[5].Value;
                txtTicketPrice.Text = row.Cells[6].Value.ToString();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTicketID.Text = "";
            dtpPurchase.Value = DateTime.Now;
            dtpDeparture.Value = DateTime.Now;
            txtOrigin.Text = "";
            txtDestination.Text = "";
            cmbBusNumber.SelectedIndex = 0;
            txtTicketPrice.Text = "";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            int ticketId;
            if (int.TryParse(txtSearch.Text, out ticketId))
            {
                SearchTicket(ticketId);
            }
            else
            {
                MessageBox.Show("Please enter a valid Ticket ID.");
            }
        }

        private void SearchTicket(int ticketId)
        {
            string query = @"
                SELECT 
                    t.TicketID,
                    t.PurchaseDate,
                    t.DepartureDate,
                    t.OriginName,
                    t.DestinationName,
                    t.BusID,
                    b.BusNumber,
                    t.TicketPrice
                FROM tbTicket t
                JOIN tbBus b ON t.BusID = b.BusID
                WHERE t.TicketID = @TicketID;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TicketID", ticketId);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                gridTicket.DataSource = dt;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateQuery = @"
                UPDATE tbTicket
                SET PurchaseDate = @PurchaseDate, DepartureDate = @DepartureDate, OriginName = @Origin, DestinationName = @Destination, BusID = @BusID, TicketPrice = @TicketPrice
                WHERE TicketID = @TicketID";

            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@PurchaseDate", DateTime.Parse(dtpPurchase.Value.ToString()));
                command.Parameters.AddWithValue("@DepartureDate", DateTime.Parse(dtpDeparture.Value.ToString()));
                command.Parameters.AddWithValue("@Origin", txtOrigin.Text);
                command.Parameters.AddWithValue("@Destination", txtDestination.Text);
                command.Parameters.AddWithValue("@BusID", int.Parse(cmbBusNumber.SelectedValue.ToString()));
                command.Parameters.AddWithValue("@TicketPrice", decimal.Parse(txtTicketPrice.Text));
                command.Parameters.AddWithValue("@TicketID", int.Parse(txtTicketID.Text));

                int result = command.ExecuteNonQuery();

                if (result > 0)
                    MessageBox.Show("Data updated successfully.");
                else
                    MessageBox.Show("Data update failed.");

                SearchTicket(int.Parse(txtTicketID.Text));
            }
        }

        private void cmCusID_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tbTicket WHERE TicketID = @TicketID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TicketID", int.Parse(txtTicketID.Text));
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dtpPurchase.Value = DateTime.Parse(dt.Rows[0]["PurchaseDate"].ToString());
                    dtpDeparture.Value = DateTime.Parse(dt.Rows[0]["DepartureDate"].ToString());
                    txtOrigin.Text = dt.Rows[0]["OriginName"].ToString();
                    txtDestination.Text = dt.Rows[0]["DestinationName"].ToString();
                    cmbBusNumber.SelectedValue = dt.Rows[0]["BusID"];
                    txtTicketPrice.Text = dt.Rows[0]["TicketPrice"].ToString();
                }
            }
        }

        private void cmbStaffName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tbTicket WHERE TicketID = @TicketID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TicketID", int.Parse(txtTicketID.Text));
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dtpPurchase.Value = DateTime.Parse(dt.Rows[0]["PurchaseDate"].ToString());
                    dtpDeparture.Value = DateTime.Parse(dt.Rows[0]["DepartureDate"].ToString());
                    txtOrigin.Text = dt.Rows[0]["OriginName"].ToString();
                    txtDestination.Text = dt.Rows[0]["DestinationName"].ToString();
                    cmbBusNumber.SelectedValue = dt.Rows[0]["BusID"];
                    txtTicketPrice.Text = dt.Rows[0]["TicketPrice"].ToString();
                }
            }
        }

        private void cmBusName_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT * FROM tbTicket WHERE TicketID = @TicketID";
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TicketID", int.Parse(txtTicketID.Text));
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    dtpPurchase.Value = DateTime.Parse(dt.Rows[0]["PurchaseDate"].ToString());
                    dtpDeparture.Value = DateTime.Parse(dt.Rows[0]["DepartureDate"].ToString());
                    txtOrigin.Text = dt.Rows[0]["OriginName"].ToString();
                    txtDestination.Text = dt.Rows[0]["DestinationName"].ToString();
                    cmbBusNumber.SelectedValue = dt.Rows[0]["BusID"];
                    txtTicketPrice.Text = dt.Rows[0]["TicketPrice"].ToString();
                }
            }
        }
    }
}

/*
 using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PABMS
{
    public partial class TicketForm : Form
    {
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        SqlConnection connection;

        public TicketForm(SqlConnection connection)
        {
            this.connection = connection;
            if (connection.State.Equals(ConnectionState.Closed))
            {
                this.connection.Open();
            }
            InitializeComponent();
            btnSearch.Click += btnSearch_Click;
            gridSearch.SelectionChanged += GridSearch_SelectionChanged;
            showTickets();
        }

        private void showTickets()
        {
            string query = @"
                SELECT 
                    t.TicketID,
                    t.PurchaseDate,
                    t.DepartureDate,
                    t.OriginName,
                    t.DestinationName,
                    t.TicketPrice,
                    b.BusID,
                    b.BusNumber,
                    bt.BusTypeName,
                    d.DriverID,
                    d.DriverName,
                    d.DriverTel
                FROM tbTicket t
                JOIN tbBus b ON t.BusID = b.BusID
                JOIN tbBusType bt ON b.BusTypeID = bt.BusTypeID
                JOIN tbDriver d ON b.DriverID = d.DriverID";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                table = new DataTable();
                adapter.Fill(table);
                gridSearch.DataSource = table;
            }
        }

        private void SearchTickets(int ticketId)
        {
            string query = @"
                SELECT 
                    t.TicketID,
                    t.PurchaseDate,
                    t.DepartureDate,
                    t.OriginName,
                    t.DestinationName,
                    t.TicketPrice,
                    b.BusID,
                    b.BusNumber,
                    bt.BusTypeName,
                    d.DriverID,
                    d.DriverName,
                    d.DriverTel
                FROM tbTicket t
                JOIN tbBus b ON t.BusID = b.BusID
                JOIN tbBusType bt ON b.BusTypeID = bt.BusTypeID
                JOIN tbDriver d ON b.DriverID = d.DriverID
                WHERE t.TicketID = @TicketID;";

            using (SqlCommand command = new SqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@TicketID", ticketId);
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
            txtTicketID.Text = row.Cells["TicketID"].Value.ToString();
            datePurchase.Value = (DateTime)row.Cells["PurchaseDate"].Value;
            dateDeparture.Value = (DateTime)row.Cells["DepartureDate"].Value;
            txtOrigin.Text = row.Cells["OriginName"].Value.ToString();
            txtDestination.Text = row.Cells["DestinationName"].Value.ToString();
            txtTicketPrice.Text = row.Cells["TicketPrice"].Value.ToString();
            txtBusID.Text = row.Cells["BusID"].Value.ToString();
            txtBusNumber.Text = row.Cells["BusNumber"].Value.ToString();
            txtBusType.Text = row.Cells["BusTypeName"].Value.ToString();
            txtDriverID.Text = row.Cells["DriverID"].Value.ToString();
            txtDriverName.Text = row.Cells["DriverName"].Value.ToString();
            txtDriverTel.Text = row.Cells["DriverTel"].Value.ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string insertQuery = @"
                INSERT INTO tbTicket (PurchaseDate, DepartureDate, OriginName, DestinationName, TicketPrice, BusID)
                VALUES (@PurchaseDate, @DepartureDate, @Origin, @Destination, @TicketPrice, @BusID)";

            using (SqlCommand command = new SqlCommand(insertQuery, connection))
            {
                command.Parameters.AddWithValue("@PurchaseDate", datePurchase.Value);
                command.Parameters.AddWithValue("@DepartureDate", dateDeparture.Value);
                command.Parameters.AddWithValue("@Origin", txtOrigin.Text);
                command.Parameters.AddWithValue("@Destination", txtDestination.Text);
                command.Parameters.AddWithValue("@TicketPrice", decimal.Parse(txtTicketPrice.Text));
                command.Parameters.AddWithValue("@BusID", int.Parse(txtBusID.Text));

                int result = command.ExecuteNonQuery();
                if (result > 0)
                    MessageBox.Show("Data inserted successfully.");
                else
                    MessageBox.Show("Data insertion failed.");

                showTickets();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtSearch.Text, out int ticketId))
            {
                SearchTickets(ticketId);
            }
            else
            {
                MessageBox.Show("Please enter a valid Ticket ID.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string updateQuery = @"
                UPDATE tbTicket
                SET PurchaseDate = @PurchaseDate, DepartureDate = @DepartureDate, OriginName = @Origin, DestinationName = @Destination, TicketPrice = @TicketPrice, BusID = @BusID
                WHERE TicketID = @TicketID";

            using (SqlCommand command = new SqlCommand(updateQuery, connection))
            {
                command.Parameters.AddWithValue("@PurchaseDate", datePurchase.Value);
                command.Parameters.AddWithValue("@DepartureDate", dateDeparture.Value);
                command.Parameters.AddWithValue("@Origin", txtOrigin.Text);
                command.Parameters.AddWithValue("@Destination", txtDestination.Text);
                command.Parameters.AddWithValue("@TicketPrice", decimal.Parse(txtTicketPrice.Text));
                command.Parameters.AddWithValue("@BusID", int.Parse(txtBusID.Text));
                command.Parameters.AddWithValue("@TicketID", int.Parse(txtTicketID.Text));

                int result = command.ExecuteNonQuery();

                if (result > 0)
                    MessageBox.Show("Data updated successfully.");
                else
                    MessageBox.Show("Data update failed.");

                showTickets();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtTicketID.Text = "";
            datePurchase.Value = DateTime.Now;
            dateDeparture.Value = DateTime.Now;
            txtOrigin.Text = "";
            txtDestination.Text = "";
            txtTicketPrice.Text = "";
            txtBusID.Text = "";
            txtBusNumber.Text = "";
            txtBusType.Text = "";
            txtDriverID.Text = "";
            txtDriverName.Text = "";
            txtDriverTel.Text = "";
        }
    }
}

 */
