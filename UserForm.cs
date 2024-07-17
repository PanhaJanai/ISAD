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
            public string StaffPosition { get; set; }

            public void fromDataTable(DataRow row)
            {
                UserID = Convert.ToInt32(row["UserID"]);
                Username = row["Username"].ToString();
                UserPassword = row["UserPassword"].ToString();
                StaffID = Convert.ToInt32(row["StaffID"]);
                StaffName = row["StaffName"].ToString();
                StaffTel = row["StaffTel"].ToString();
                StaffPosition = row["StaffPosition"].ToString();
            }
        }

        List<User> users = new List<User>();
        List<User> savedUsers = new List<User>();

        DataTable userTable = new DataTable();
        DataTable saveTable = new DataTable();

        Funcs funcs = new Funcs();

        string connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

        public UserForm()
        {
            InitializeComponent();

            funcs.info = new Funcs.Info(connectionString, "tbUser", "UserID", userTable, gridUser);

            fillCmbStaffTel();
            cmbStaffTel.SelectedIndexChanged += new EventHandler(cmbStaffTel_SelectedIndexChanged);

            btnAdd.Click += new EventHandler(btnAdd_Click);
            btnSave.Click += new EventHandler(btnSave_Click);
            btnUpdate.Click += new EventHandler(btnUpdate_Click);
            btnNew.Click += new EventHandler(btnNew_Click);

            refreshGrid();
            txtUserID.Text = funcs.getLatestID().ToString();
            saveTable = userTable.Clone();
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
                StaffTel = cmbStaffTel.Text,
                StaffPosition = txtStaffPosition.Text
            });

            MessageBox.Show("Data added successfully");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            saveTable = userToDataTable(users);

            SavingDialogue saveDialogue = new SavingDialogue(saveTable);
            saveDialogue.ShowDialog();
            saveTable = saveDialogue.save_table;

            foreach (DataRow row in saveTable.Rows)
            {
                User user = new User();
                user.fromDataTable(row);
                savedUsers.Add(user);
            }

            ExecuteSqlCommands(savedUsers, "INSERT INTO tbUser (Username, UserPassword, StaffID, StaffName, StaffTel, StaffPosition) VALUES (@Username, @UserPassword, @StaffID, @StaffName, @StaffTel, @StaffPosition)");

            userTable.Clear();
            saveTable.Clear();
            refreshGrid();

            MessageBox.Show("Data saved successfully");
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            txtUserID.Text = funcs.getLatestID().ToString();
            txtUsername.Text = "";
            txtUserPassword.Text = "";
            txtStaffID.Text = "";
            txtStaffName.Text = "";
            cmbStaffTel.Text = "";
            txtStaffPosition.Text = "";
            refreshGrid();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int userID = Convert.ToInt32(txtUserID.Text);

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "UPDATE tbUser SET Username = @Username, UserPassword = @UserPassword, StaffID = @StaffID, StaffName = @StaffName, StaffTel = @StaffTel, StaffPosition = @StaffPosition WHERE UserID = @UserID";
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Username", txtUsername.Text);
                    command.Parameters.AddWithValue("@UserPassword", txtUserPassword.Text);
                    command.Parameters.AddWithValue("@StaffID", Convert.ToInt32(txtStaffID.Text));
                    command.Parameters.AddWithValue("@StaffName", txtStaffName.Text);
                    command.Parameters.AddWithValue("@StaffTel", cmbStaffTel.Text);
                    command.Parameters.AddWithValue("@StaffPosition", txtStaffPosition.Text);
                    command.Parameters.AddWithValue("@UserID", userID);

                    command.ExecuteNonQuery();
                }
                con.Close();
            }

            userTable.Clear();
            refreshGrid();
            MessageBox.Show("Data updated successfully");
        }

        void refreshGrid()
        {
            funcs.addFirst10RowsToDataTable();
            gridUser.DataSource = userTable;
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
            table.Columns.Add("StaffPosition", typeof(string));

            foreach (User user in users)
            {
                table.Rows.Add(user.UserID, user.Username, user.UserPassword, user.StaffID, user.StaffName, user.StaffTel, user.StaffPosition);
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
                        command.Parameters.AddWithValue("@StaffPosition", user.StaffPosition);

                        command.ExecuteNonQuery();
                    }
                }
                con.Close();
            }
        }

        private void cmbStaffTel_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = cmbStaffTel.SelectedIndex;
            DataRow row = tableStaff.Rows[index];

            txtStaffID.Text = row["StaffID"].ToString();
            txtStaffName.Text = row["StaffName"].ToString();
            txtStaffPosition.Text = row["StaffPosition"].ToString();
        }

        DataTable tableStaff = new DataTable();
        private void fillCmbStaffTel()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "SELECT StaffID, StaffName, StaffTel, StaffPosition FROM tbStaff";
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
            txtStaffPosition.Text = selectedRow.Cells["StaffPosition"].Value.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            funcs.info.id = Convert.ToInt32(txtSearch.Text);
            funcs.searchByID();
        }

        private void gridUser_Scroll(object sender, ScrollEventArgs e)
        {
            funcs.addRowWhenScrollingEnds();
        }
    }
}
