using System.Data.SqlClient;

namespace PABMS
{
    public partial class FormLogin : Form
    {
        SqlConnection connection;
        SqlCommand sql_command = new SqlCommand();
        SqlDataReader reader;
        public class User
        {
            public string username { get; set; }
            public string password { get; set; }
            public int staffID { get; set; }
            public string position { get; set; }
        }

        List<User> users = new List<User>();



        public User user;
        public bool isLogin = false;

        public FormLogin(SqlConnection connection)
        {
            this.connection = connection;
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            try
            {
                sql_command.CommandText = "SELECT * FROM dbo.tbUser";

                // excute this command
                sql_command.Connection = connection;
                connection.Open();
                reader = sql_command.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            while (reader.Read())
            {
                User user = new User();
                user.username = reader["Username"].ToString();
                user.password = reader["UserPassword"].ToString();
                user.staffID = Convert.ToInt32(reader["StaffID"]);
                users.Add(user);
            }
            connection.Close();
            txtUsername.Text = "panha";
            txtPassword.Text = "manager";
            btnLogin.PerformClick();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (txtUsername.Text.Equals(""))
                {
                    MessageBox.Show("Please fill in username!");
                    return;
                }
                else if (txtPassword.Text.Equals(""))
                {
                    MessageBox.Show("Please fill in password!");
                    return;
                }
                if (txtUsername.Text == users[i].username && txtPassword.Text == users[i].password)
                {
                    user = users[i];
                    isLogin = true;
                    this.Hide();
                    return;
                }
            }
            MessageBox.Show("Invalid username or password!");
        }
    }
}
