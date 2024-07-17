using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace PABMS
{
    public partial class PaymentTicketForm : Form
    {
        class PaymentTicket
        {
            public int PaymentTicketID { get; set; }
            public DateTime PaymentDate { get; set; }
            public double PaymentAmount { get; set; }
            public int TicketID { get; set; }
            public double TicketPrice { get; set; }
            public int CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerTel { get; set; }
            public int StaffID { get; set; }
            public string StaffName { get; set; }
            public string StaffTel { get; set; }

            public void fromDataTable(DataRow row)
            {
                PaymentTicketID = Convert.ToInt32(row["PaymentTicketID"]);
                PaymentDate = Convert.ToDateTime(row["PaymentDate"]);
                PaymentAmount = Convert.ToDouble(row["PaymentAmount"]);
                TicketID = Convert.ToInt32(row["TicketID"]);
                TicketPrice = Convert.ToDouble(row["TicketPrice"]);
                CustomerID = Convert.ToInt32(row["CustomerID"]);
                CustomerName = row["CustomerName"].ToString();
                CustomerTel = row["CustomerTel"].ToString();
                StaffID = Convert.ToInt32(row["StaffID"]);
                StaffName = row["StaffName"].ToString();
                StaffTel = row["StaffTel"].ToString();
            }
        }

        List<PaymentTicket> paymentTickets = new List<PaymentTicket>();
        List<PaymentTicket> savedPaymentTickets = new List<PaymentTicket>();

        DataTable paymentTicketTable = new DataTable();
        DataTable saveTable = new DataTable();
        DataTable tableCus = new DataTable();

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        FormLogin.User user;
        Funcs funcs = new Funcs();

        public PaymentTicketForm()
        {
            InitializeComponent();
            funcs.info = new Funcs.Info(connectionString, "tbPaymentTicket", "PaymentTicketID", paymentTicketTable, gridPaymentTicket);

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            btnNew.Click += new EventHandler(btnNew_Click);
            btnSearch.Click += new EventHandler(btnSearch_Click);

            fillCmbCusTel();

            gridPaymentTicket.CellClick += new DataGridViewCellEventHandler(gridPaymentTicket_CellClick);

            refreshGrid();
            txtPaymentTicketID.Text = funcs.getLatestID().ToString();
            saveTable = paymentTicketTable.Clone();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            paymentTickets.Add(new PaymentTicket
            {
                PaymentTicketID = Convert.ToInt32(txtPaymentTicketID.Text),
                PaymentDate = datePayment.Value,
                PaymentAmount = Convert.ToDouble(txtAmount.Text),
                TicketID = Convert.ToInt32(txtTicketID.Text),
                TicketPrice = Convert.ToDouble(txtTicketPrice.Text),
                CustomerID = Convert.ToInt32(txtCusID.Text),
                CustomerName = txtCusName.Text,
                CustomerTel = cmbCusTel.Text,
                StaffID = user.staffID,
                StaffName = user.username,
                StaffTel = user.password
            });

            MessageBox.Show("Data added successfully");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveTable = paymentTicketToDataTable(paymentTickets);

            SavingDialogue saveDialogue = new SavingDialogue(saveTable);
            saveDialogue.ShowDialog();
            saveTable = saveDialogue.save_table;
            saveDialogue.Dispose();

            foreach (DataRow row in saveTable.Rows)
            {
                PaymentTicket payment = new PaymentTicket();
                payment.fromDataTable(row);
                savedPaymentTickets.Add(payment);
            }

            ExecuteSqlCommands(savedPaymentTickets, "INSERT INTO tbPaymentTicket (PaymentDate, PaymentAmount, TicketID, TicketPrice, CustomerID, CustomerName, CustomerTel, StaffID, StaffName, StaffTel) VALUES (@PaymentDate, @PaymentAmount, @TicketID, @TicketPrice, @CustomerID, @CustomerName, @CustomerTel, @StaffID, @StaffName, @StaffTel)");

            paymentTicketTable.Clear();
            saveTable.Clear();
            refreshGrid();

            MessageBox.Show("Data saved successfully");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtPaymentTicketID.Text = funcs.getLatestID().ToString();
            txtAmount.Text = "";
            datePayment.Value = DateTime.Now;
            txtTicketID.Text = "";
            txtTicketPrice.Text = "";
            txtCusID.Text = "";
            txtCusName.Text = "";
            cmbCusTel.Text = "";
            refreshGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int paymentTicketID = Convert.ToInt32(txtPaymentTicketID.Text);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE tbPaymentTicket SET PaymentDate = @PaymentDate, PaymentAmount = @PaymentAmount, TicketID = @TicketID, TicketPrice = @TicketPrice, CustomerID = @CustomerID, CustomerName = @CustomerName, CustomerTel = @CustomerTel, StaffID = @StaffID, StaffName = @StaffName, StaffTel = @StaffTel WHERE PaymentTicketID = @PaymentTicketID";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@PaymentDate", datePayment.Value);
                    command.Parameters.AddWithValue("@PaymentAmount", Convert.ToDouble(txtAmount.Text));
                    command.Parameters.AddWithValue("@TicketID", Convert.ToInt32(txtTicketID.Text));
                    command.Parameters.AddWithValue("@TicketPrice", Convert.ToDouble(txtTicketPrice.Text));
                    command.Parameters.AddWithValue("@CustomerID", Convert.ToInt32(txtCusID.Text));
                    command.Parameters.AddWithValue("@CustomerName", txtCusName.Text);
                    command.Parameters.AddWithValue("@CustomerTel", cmbCusTel.Text);
                    command.Parameters.AddWithValue("@StaffID", user.staffID);
                    command.Parameters.AddWithValue("@StaffName", user.username);
                    command.Parameters.AddWithValue("@StaffTel", user.password);
                    command.Parameters.AddWithValue("@PaymentTicketID", paymentTicketID);

                    command.ExecuteNonQuery();
                }
                con.Close();
            }

            paymentTicketTable.Clear();
            refreshGrid();
            MessageBox.Show("Data updated successfully");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM tbPaymentTicket WHERE PaymentTicketID = @PaymentTicketID";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@PaymentTicketID", Convert.ToInt32(txtSearch.Text));
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    using (DataTable dt = new DataTable())
                    {
                        adapter.Fill(dt);
                        gridPaymentTicket.DataSource = dt;
                    }
                }
                con.Close();
            }
        }

        private void cmbCusTel_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (DataRow row in tableCus.Rows)
            {
                if (row["CustomerTel"].ToString() == cmbCusTel.Text)
                {
                    txtCusID.Text = row["CustomerID"].ToString();
                    txtCusName.Text = row["CustomerName"].ToString();
                }
            }
        }

        private void gridPaymentTicket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillControlWithGridRow(gridPaymentTicket.CurrentRow);
        }

        #region User generated functions

        void fillCmbCusTel()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM tbCustomer";
                SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                adapter.Fill(tableCus);
                con.Close();
            }

            foreach (DataRow row in tableCus.Rows)
            {
                cmbCusTel.Items.Add(row["CustomerTel"].ToString());
            }
        }

        void refreshGrid()
        {
            funcs.addFirst10RowsToDataTable();
            gridPaymentTicket.DataSource = paymentTicketTable;
        }

        void fillControlWithGridRow(DataGridViewRow row)
        {
            var columns = new Dictionary<string, TextBox>
            {
                { "PaymentTicketID", txtPaymentTicketID },
                { "PaymentAmount", txtAmount },
                { "TicketID", txtTicketID },
                { "TicketPrice", txtTicketPrice },
                { "CustomerID", txtCusID },
                { "CustomerName", txtCusName }
            };

            foreach (var column in columns)
            {
                try
                {
                    column.Value.Text = row.Cells[column.Key].Value.ToString();
                }
                catch
                {
                    continue;
                }
            }

            datePayment.Value = Convert.ToDateTime(row.Cells["PaymentDate"].Value.ToString());
            cmbCusTel.Text = row.Cells["CustomerTel"].Value.ToString();
        }

        DataTable paymentTicketToDataTable(List<PaymentTicket> payments)
        {
            DataTable table = new DataTable();
            table.Columns.Add("PaymentTicketID", typeof(int));
            table.Columns.Add("PaymentDate", typeof(DateTime));
            table.Columns.Add("PaymentAmount", typeof(double));
            table.Columns.Add("TicketID", typeof(int));
            table.Columns.Add("TicketPrice", typeof(double));
            table.Columns.Add("CustomerID", typeof(int));
            table.Columns.Add("CustomerName", typeof(string));
            table.Columns.Add("CustomerTel", typeof(string));
            table.Columns.Add("StaffID", typeof(int));
            table.Columns.Add("StaffName", typeof(string));
            table.Columns.Add("StaffTel", typeof(string));

            foreach (PaymentTicket payment in payments)
            {
                table.Rows.Add(payment.PaymentTicketID, payment.PaymentDate, payment.PaymentAmount, payment.TicketID, payment.TicketPrice, payment.CustomerID, payment.CustomerName, payment.CustomerTel, payment.StaffID, payment.StaffName, payment.StaffTel);
            }

            return table;
        }

        void ExecuteSqlCommands(List<PaymentTicket> payments, string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                foreach (PaymentTicket payment in payments)
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                        command.Parameters.AddWithValue("@PaymentAmount", payment.PaymentAmount);
                        command.Parameters.AddWithValue("@TicketID", payment.TicketID);
                        command.Parameters.AddWithValue("@TicketPrice", payment.TicketPrice);
                        command.Parameters.AddWithValue("@CustomerID", payment.CustomerID);
                        command.Parameters.AddWithValue("@CustomerName", payment.CustomerName);
                        command.Parameters.AddWithValue("@CustomerTel", payment.CustomerTel);
                        command.Parameters.AddWithValue("@StaffID", payment.StaffID);
                        command.Parameters.AddWithValue("@StaffName", payment.StaffName);
                        command.Parameters.AddWithValue("@StaffTel", payment.StaffTel);

                        command.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }

        #endregion

        private void PaymentTicketForm_Load(object sender, EventArgs e)
        {
            user = Parent.Tag as FormLogin.User;
        }

        private void gridPaymentTicket_Scroll(object sender, ScrollEventArgs e)
        {
            funcs.addRowWhenScrollingEnds();
        }
    }
}
