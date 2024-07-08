using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace PABMS
{
    public partial class CustomerForm : Form
    {
        class Customer
        {
            public int CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerTel { get; set; }
            public char CustomerSex { get; set; }

            public void fromDataTable(DataRow row)
            {
                CustomerID = Convert.ToInt32(row["CustomerID"]);
                CustomerName = row["CustomerName"].ToString();
                CustomerTel = row["CustomerTel"].ToString();
                CustomerSex = Char.Parse(row["CustomerSex"].ToString());
            }
        }

        List<Customer> customers = new List<Customer>();
        List<Customer> savedCustomers = new List<Customer>();

        DataTable tableCustomer = new DataTable();
        DataTable tableSave = new DataTable();
        DataTable tableCus = new DataTable();

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public CustomerForm()
        {
            InitializeComponent();

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            btnNew.Click += new EventHandler(btnNew_Click);

            fillGridWithNewData();
            txtCusID.Text = (tableCustomer.Rows.Count + 1).ToString();
            tableSave = tableCustomer.Clone();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            customers.Add(new Customer
            {
                CustomerID = Convert.ToInt32(txtCusID.Text),
                CustomerName = txtCustomerName.Text,
                CustomerTel = txtCusTel.Text,
                CustomerSex = cbMale.Checked ? 'M' : 'F'
            });

            MessageBox.Show("Data added successfully");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tableSave = customerToDataTable(customers);

            // Show dialogue box to make sure the data is correct
            SavingDialogue saveDialogue = new SavingDialogue(tableSave);
            saveDialogue.ShowDialog();
            tableSave = saveDialogue.save_table;
            saveDialogue.Dispose();

            foreach (DataRow row in tableSave.Rows)
            {
                Customer customer = new Customer();
                customer.fromDataTable(row);
                savedCustomers.Add(customer);
            }

            ExecuteSqlCommands(savedCustomers, "INSERT INTO tbCustomer (CustomerName, CustomerTel, CustomerSex) VALUES (@CustomerName, @CustomerTel, @CustomerSex)");

            tableCustomer.Clear();
            tableSave.Clear();
            fillGridWithNewData();

            MessageBox.Show("Data saved successfully");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtCusID.Text = (tableCustomer.Rows.Count + 1).ToString();
            txtCustomerName.Text = "";
            txtCusTel.Text = "";
            cbMale.Checked = false;
            cbFemale.Checked = false;
            gridCustomer.DataSource = tableCustomer;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int customerID = Convert.ToInt32(txtCusID.Text);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE tbCustomer SET CustomerName = @CustomerName, CustomerTel = @CustomerTel, CustomerSex = @CustomerSex WHERE CustomerID = @CustomerID";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@CustomerName", txtCustomerName.Text);
                    command.Parameters.AddWithValue("@CustomerTel", txtCusTel.Text);
                    command.Parameters.AddWithValue("@CustomerSex", cbMale.Checked ? 'M' : 'F');
                    command.Parameters.AddWithValue("@CustomerID", customerID);

                    command.ExecuteNonQuery();
                }
                con.Close();
            }

            tableCustomer.Clear();
            fillGridWithNewData();
            MessageBox.Show("Data updated successfully");
        }

        private void fillGridWithNewData()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT * FROM tbCustomer";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.Fill(tableCustomer);
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
            }
            gridCustomer.DataSource = tableCustomer;
        }

        DataTable customerToDataTable(List<Customer> customers)
        {
            DataTable table = new DataTable();
            table.Columns.Add("CustomerID", typeof(int));
            table.Columns.Add("CustomerName", typeof(string));
            table.Columns.Add("CustomerTel", typeof(string));
            table.Columns.Add("CustomerSex", typeof(string));

            foreach (Customer customer in customers)
            {
                table.Rows.Add(customer.CustomerID, customer.CustomerName, customer.CustomerTel, customer.CustomerSex);
            }

            return table;
        }

        void ExecuteSqlCommands(List<Customer> customers, string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                foreach (Customer customer in customers)
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                        command.Parameters.AddWithValue("@CustomerTel", customer.CustomerTel);
                        command.Parameters.AddWithValue("@CustomerSex", customer.CustomerSex);

                        command.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }

        private void gridCustomer_CellClick(object sender, EventArgs e)
        {
            DataGridViewRow selectedRow = gridCustomer.CurrentRow;

            txtCusID.Text = selectedRow.Cells["CustomerID"].Value.ToString();
            txtCustomerName.Text = selectedRow.Cells["CustomerName"].Value.ToString();
            txtCusTel.Text = selectedRow.Cells["CustomerTel"].Value.ToString();
            if (selectedRow.Cells["CustomerSex"].Value.ToString() == "M")
            {
                cbMale.Checked = true;
                cbFemale.Checked = false;
            }
            else
            {
                cbMale.Checked = false;
                cbFemale.Checked = true;
            }
        }
    }
}
