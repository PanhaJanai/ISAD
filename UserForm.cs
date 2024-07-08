using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;

namespace PABMS
{
    public partial class UserForm : Form
    {
        class User
        {
            public int UserID { get; set; }
            public string Username { get; set; }
            public string UserPassword { get; set; }
            public int StaffID { get; set; }
            public string StaffName { get; set; }
            public string StaffTel { get; set; }

            public void fromDataTable(DataRow row)
            {
                UserID = Convert.ToInt32(row["UserID"]);
                Username = row["Username"].ToString();
                UserPassword = row["UserPassword"].ToString();
                StaffID = Convert.ToInt32(row["StaffID"]);
                StaffName = row["StaffName"].ToString();
                StaffTel = row["StaffTel"].ToString();
            }
        }

        List<User> users = new List<User>();
        List<User> savedUsers = new List<User>();

        DataTable tableUser = new DataTable();
        DataTable tableSave = new DataTable();
        DataTable tableUsr = new DataTable();

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public UserForm()
        {
            InitializeComponent();

            fillCmbStaffTel();
            cmbStaffTel.SelectedIndexChanged += new EventHandler(cmbStaffTel_SelectedIndexChanged);

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            btnNew.Click += new EventHandler(btnNew_Click);

            fillGridWithNewData();
            txtUserID.Text = (tableUser.Rows.Count + 1).ToString();
            tableSave = tableUser.Clone();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            users.Add(new User
            {
                UserID = Convert.ToInt32(txtUserID.Text),
                Username = txtUsername.Text,
                UserPassword = txtUserPassword.Text,
                StaffID = Convert.ToInt32(txtStaffID.Text),
                StaffName = txtStaffName.Text,
                StaffTel = cmbStaffTel.Text
            });

            MessageBox.Show("Data added successfully");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            tableSave = userToDataTable(users);

            // Show dialogue box to make sure the data is correct
            SavingDialogue saveDialogue = new SavingDialogue(tableSave);
            saveDialogue.ShowDialog();
            tableSave = saveDialogue.save_table;
            saveDialogue.Dispose();

            foreach (DataRow row in tableSave.Rows)
            {
                User user = new User();
                user.fromDataTable(row);
                savedUsers.Add(user);
            }

            ExecuteSqlCommands(savedUsers, "INSERT INTO tbUser (Username, UserPassword, StaffID, StaffName, StaffTel) VALUES (@Username, @UserPassword, @StaffID, @StaffName, @StaffTel)");

            tableUser.Clear();
            tableSave.Clear();
            fillGridWithNewData();

            MessageBox.Show("Data saved successfully");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtUserID.Text = (tableUser.Rows.Count + 1).ToString();
            txtUsername.Text = "";
            txtUserPassword.Text = "";
            txtStaffID.Text = "";
            txtStaffName.Text = "";
            cmbStaffTel.Text = "";
            gridUser.DataSource = tableUser;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(txtUserID.Text);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE tbUser SET Username = @Username, UserPassword = @UserPassword, StaffID = @StaffID, StaffName = @StaffName, StaffTel = @StaffTel WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Username", txtUsername.Text);
                    command.Parameters.AddWithValue("@UserPassword", txtUserPassword.Text);
                    command.Parameters.AddWithValue("@StaffID", Convert.ToInt32(txtStaffID.Text));
                    command.Parameters.AddWithValue("@StaffName", txtStaffName.Text);
                    command.Parameters.AddWithValue("@StaffTel", cmbStaffTel.Text);
                    command.Parameters.AddWithValue("@UserID", userID);

                    command.ExecuteNonQuery();
                }
                con.Close();
            }

            tableUser.Clear();
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
                    string query = "SELECT * FROM tbUser";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.Fill(tableUser);
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
            }
            gridUser.DataSource = tableUser;
        }

        DataTable userToDataTable(List<User> users)
        {
            DataTable table = new DataTable();
            table.Columns.Add("UserID", typeof(int));
            table.Columns.Add("Username", typeof(string));
            table.Columns.Add("UserPassword", typeof(string));
            table.Columns.Add("StaffID", typeof(int));
            table.Columns.Add("StaffName", typeof(string));
            table.Columns.Add("StaffTel", typeof(string));

            foreach (User user in users)
            {
                table.Rows.Add(user.UserID, user.Username, user.UserPassword, user.StaffID, user.StaffName, user.StaffTel);
            }

            return table;
        }

        void ExecuteSqlCommands(List<User> users, string query)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                foreach (User user in users)
                {
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.Parameters.AddWithValue("@Username", user.Username);
                        command.Parameters.AddWithValue("@UserPassword", user.UserPassword);
                        command.Parameters.AddWithValue("@StaffID", user.StaffID);
                        command.Parameters.AddWithValue("@StaffName", user.StaffName);
                        command.Parameters.AddWithValue("@StaffTel", user.StaffTel);

                        command.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }

        private void gridUser_CellClick(object sender, EventArgs e)
        {
            int index = gridUser.SelectedCells[0].RowIndex;
            DataGridViewRow selectedRow = gridUser.Rows[index];

            txtUserID.Text = selectedRow.Cells["UserID"].Value.ToString();
            txtUsername.Text = selectedRow.Cells["Username"].Value.ToString();
            txtUserPassword.Text = selectedRow.Cells["UserPassword"].Value.ToString();
            txtStaffID.Text = selectedRow.Cells["StaffID"].Value.ToString();
            txtStaffName.Text = selectedRow.Cells["StaffName"].Value.ToString();
            cmbStaffTel.Text = selectedRow.Cells["StaffTel"].Value.ToString();
        }

        private void cmbStaffTel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbStaffTel.SelectedIndex;
            DataRow row = tableStaff.Rows[index];

            txtStaffID.Text = row["StaffID"].ToString();
            txtStaffName.Text = row["StaffName"].ToString();
        }

        DataTable tableStaff = new DataTable();
        private void fillCmbStaffTel()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT StaffID, StaffName, StaffTel FROM tbStaff";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, con);
                    adapter.Fill(tableStaff);
                    con.Close();
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Error connecting to the database: {ex.Message}");
            }

            foreach (DataRow row in tableStaff.Rows)
            {
                cmbStaffTel.Items.Add(row["StaffTel"].ToString());
            }
        }

        private void gridUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = gridUser.CurrentRow;

            txtUserID.Text = selectedRow.Cells["UserID"].Value.ToString();
            txtUsername.Text = selectedRow.Cells["Username"].Value.ToString();
            txtUserPassword.Text = selectedRow.Cells["UserPassword"].Value.ToString();
            txtStaffID.Text = selectedRow.Cells["StaffID"].Value.ToString();
            txtStaffName.Text = selectedRow.Cells["StaffName"].Value.ToString();
            cmbStaffTel.Text = selectedRow.Cells["StaffTel"].Value.ToString();
        }
    }
}
