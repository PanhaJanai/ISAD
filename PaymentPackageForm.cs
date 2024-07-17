using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Drawing;

namespace PABMS
{
    public partial class PaymentPackageForm : Form
    {
        class PaymentPackage
        {
            public int PaymentPackageID { get; set; }
            public DateTime PaymentDate { get; set; }
            public double PaymentAmount { get; set; }
            public int PackageID { get; set; }
            public double PackagePrice { get; set; }
            public int CustomerID { get; set; }
            public string CustomerName { get; set; }
            public string CustomerTel { get; set; }
            public int StaffID { get; set; }
            public string StaffName { get; set; }
            public string StaffTel { get; set; }
            public string PackageName { get; set; }

            public void fromDataTable(DataRow row)
            {
                PaymentPackageID = Convert.ToInt32(row["PaymentPackageID"]);
                PaymentDate = Convert.ToDateTime(row["PaymentDate"]);
                PaymentAmount = Convert.ToDouble(row["PaymentAmount"]);
                PackageID = Convert.ToInt32(row["PackageID"]);
                PackagePrice = Convert.ToDouble(row["PackagePrice"]);
                CustomerID = Convert.ToInt32(row["CustomerID"]);
                CustomerName = row["CustomerName"].ToString();
                CustomerTel = row["CustomerTel"].ToString();
                StaffID = Convert.ToInt32(row["StaffID"]);
                StaffName = row["StaffName"].ToString();
                StaffTel = row["StaffTel"].ToString();
                PackageName = row["PackageName"].ToString();
            }
        }

        List<PaymentPackage> paymentPackages = new List<PaymentPackage>();
        List<PaymentPackage> savedPaymentPackages = new List<PaymentPackage>();

        DataTable paymentPackageTable = new DataTable();
        DataTable saveTable = new DataTable();
        DataTable tableCus = new DataTable();

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
        FormLogin.User user;
        Funcs funcs = new Funcs();

        public PaymentPackageForm()
        {
            //user = MainForm.staticUser;
            InitializeComponent();

            funcs.info = new Funcs.Info(connectionString, "tbPaymentPackage", "PaymentPackageID", paymentPackageTable, gridPaymentPackage);

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            btnNew.Click += new EventHandler(btnNew_Click);
            btnSearch.Click += new EventHandler(btnSearch_Click);

            fillCmbCusTel();

            gridPaymentPackage.CellClick += new DataGridViewCellEventHandler(gridPaymentPackage_CellClick);

            refreshGrid();
            txtPaymentPackageID.Text = funcs.getLatestID().ToString();
            saveTable = paymentPackageTable.Clone();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            paymentPackages.Add(new PaymentPackage
            {
                PaymentPackageID = Convert.ToInt32(txtPaymentPackageID.Text),
                PaymentDate = datePayment.Value,
                PaymentAmount = Convert.ToDouble(txtAmount.Text),
                PackageID = Convert.ToInt32(txtPackageID.Text),
                PackagePrice = Convert.ToDouble(txtPackagePrice.Text),
                CustomerID = Convert.ToInt32(txtCusID.Text),
                CustomerName = txtCusName.Text,
                CustomerTel = cmbCusTel.Text,
                StaffID = user.staffID,
                StaffName = user.username,
                StaffTel = user.password,
                PackageName = txtPackageName.Text
            });

            MessageBox.Show("Data added successfully");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // convert all PaymentPackage objects to DataTable
            saveTable = paymentPackageToDataTable(paymentPackages);

            // Show dialogue box to make sure the data is correct
            SavingDialogue saveDialogue = new SavingDialogue(saveTable);
            saveDialogue.ShowDialog();
            saveTable = saveDialogue.save_table;
            saveDialogue.Dispose();

            // convert all datatable row into PaymentPackage objects of savedPaymentPackages
            foreach (DataRow row in saveTable.Rows)
            {
                PaymentPackage payment = new PaymentPackage();
                payment.fromDataTable(row);
                savedPaymentPackages.Add(payment);
            }

            ExecuteSqlCommands(savedPaymentPackages, "INSERT INTO tbPaymentPackage (PaymentDate, PaymentAmount, PackageID, PackageName, PackagePrice, CustomerID, CustomerName, CustomerTel, StaffID, StaffName, StaffTel) VALUES (@PaymentDate, @PaymentAmount, @PackageID, @PackageName, @PackagePrice, @CustomerID, @CustomerName, @CustomerTel, @StaffID, @StaffName, @StaffTel)");

            paymentPackageTable.Clear();
            saveTable.Clear();
            refreshGrid();

            MessageBox.Show("Data saved successfully");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtPaymentPackageID.Text = funcs.getLatestID().ToString();
            txtAmount.Text = "";
            datePayment.Value = DateTime.Now;
            txtPackageID.Text = "";
            txtPackagePrice.Text = "";
            txtCusID.Text = "";
            txtCusName.Text = "";
            cmbCusTel.Text = "";
            txtPackageName.Text = "";
            refreshGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int paymentPackageID = Convert.ToInt32(txtPaymentPackageID.Text);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE tbPaymentPackage SET PaymentDate = @PaymentDate, PaymentAmount = @PaymentAmount, PackageID = @PackageID, PackageName = @PackageName, PackagePrice = @PackagePrice, CustomerID = @CustomerID, CustomerName = @CustomerName, CustomerTel = @CustomerTel, StaffID = @StaffID, StaffName = @StaffName, StaffTel = @StaffTel WHERE PaymentPackageID = @PaymentPackageID";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@PaymentDate", datePayment.Value);
                    command.Parameters.AddWithValue("@PaymentAmount", Convert.ToDouble(txtAmount.Text));
                    command.Parameters.AddWithValue("@PackageID", Convert.ToInt32(txtPackageID.Text));
                    command.Parameters.AddWithValue("@PackagePrice", Convert.ToDouble(txtPackagePrice.Text));
                    command.Parameters.AddWithValue("@CustomerID", Convert.ToInt32(txtCusID.Text));
                    command.Parameters.AddWithValue("@CustomerName", txtCusName.Text);
                    command.Parameters.AddWithValue("@CustomerTel", cmbCusTel.Text);
                    command.Parameters.AddWithValue("@StaffID", user.staffID);
                    command.Parameters.AddWithValue("@StaffName", user.username);
                    command.Parameters.AddWithValue("@StaffTel", user.password);
                    command.Parameters.AddWithValue("@PackageName", txtPackageName.Text);
                    command.Parameters.AddWithValue("@PaymentPackageID", paymentPackageID);

                    command.ExecuteNonQuery();
                }
                con.Close();
            }

            paymentPackageTable.Clear();
            refreshGrid();
            MessageBox.Show("Data updated successfully");
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM tbPaymentPackage WHERE PaymentPackageID = @PaymentPackageID";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@PaymentPackageID", Convert.ToInt32(txtSearch.Text));
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    using (DataTable dt = new DataTable())
                    {
                        adapter.Fill(dt);
                        gridPaymentPackage.DataSource = dt;
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

        void refreshGrid()
        {
            funcs.addFirst10RowsToDataTable();
            gridPaymentPackage.DataSource = paymentPackageTable;
        }

        private void gridPaymentPackage_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            fillControlWithGridRow(gridPaymentPackage.CurrentRow);
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


        void fillControlWithGridRow(DataGridViewRow row)
        {
            var columns = new Dictionary<string, TextBox>
            {
                { "PaymentPackageID", txtPaymentPackageID },
                { "PaymentAmount", txtAmount },
                { "PackageID", txtPackageID },
                { "PackageName", txtPackageName },
                { "PackagePrice", txtPackagePrice },
                { "CustomerID", txtCusID },
                { "CustomerName", txtCusName }
            };

            foreach (var column in columns)
            {
                column.Value.Text = row.Cells[column.Key].Value.ToString();
            }

            datePayment.Value = Convert.ToDateTime(row.Cells["PaymentDate"].Value);
            cmbCusTel.Text = row.Cells["CustomerTel"].Value.ToString();
        }

        DataTable paymentPackageToDataTable(List<PaymentPackage> payments)
        {
            DataTable table = new DataTable();
            table.Columns.Add("PaymentPackageID", typeof(int));
            table.Columns.Add("PaymentDate", typeof(DateTime));
            table.Columns.Add("PaymentAmount", typeof(double));
            table.Columns.Add("PackageID", typeof(int));
            table.Columns.Add("PackagePrice", typeof(double));
            table.Columns.Add("CustomerID", typeof(int));
            table.Columns.Add("CustomerName", typeof(string));
            table.Columns.Add("CustomerTel", typeof(string));
            table.Columns.Add("StaffID", typeof(int));
            table.Columns.Add("StaffName", typeof(string));
            table.Columns.Add("StaffTel", typeof(string));
            table.Columns.Add("PackageName", typeof(string));

            foreach (PaymentPackage payment in payments)
            {
                table.Rows.Add(payment.PaymentPackageID, payment.PaymentDate, payment.PaymentAmount, payment.PackageID, payment.PackagePrice, payment.CustomerID, payment.CustomerName, payment.CustomerTel, payment.StaffID, payment.StaffName, payment.StaffTel, payment.PackageName);
            }

            return table;
        }

        void ExecuteSqlCommands(List<PaymentPackage> payments, string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                foreach (PaymentPackage payment in payments)
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@PaymentDate", payment.PaymentDate);
                        command.Parameters.AddWithValue("@PaymentAmount", payment.PaymentAmount);
                        command.Parameters.AddWithValue("@PackageID", payment.PackageID);
                        command.Parameters.AddWithValue("@PackagePrice", payment.PackagePrice);
                        command.Parameters.AddWithValue("@CustomerID", payment.CustomerID);
                        command.Parameters.AddWithValue("@CustomerName", payment.CustomerName);
                        command.Parameters.AddWithValue("@CustomerTel", payment.CustomerTel);
                        command.Parameters.AddWithValue("@StaffID", payment.StaffID);
                        command.Parameters.AddWithValue("@StaffName", payment.StaffName);
                        command.Parameters.AddWithValue("@StaffTel", payment.StaffTel);
                        command.Parameters.AddWithValue("@PackageName", payment.PackageName);

                        command.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }

        #endregion

        private void PaymentPackageForm_Load(object sender, EventArgs e)
        {
            user = Parent.Tag as FormLogin.User;
        }
    }
}
