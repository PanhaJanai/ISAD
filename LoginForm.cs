using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Microsoft.Data.Sqlite;
using SQLitePCL;

namespace PABMS
{
    public partial class FormLogin : Form
    {
        string projectPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
        private string connectionString;
        //private string connectionString = @"Data Source=C:\Users\User\Desktop\PABMS\database\ISAD.sqlite;";

        public class User
        {
            public int id;
            public string username;
            public string password;
            public string connectionString;
        }

        List<User> users = new List<User>();
        public User user;
        public bool isLogin = false;

        public FormLogin()
        {
            connectionString = @$"Data Source={projectPath}\database\ISAD.sqlite;";
            InitializeComponent();
            SQLitePCL.Batteries.Init();

            try
            {
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();
                    Console.WriteLine("SQLite connection opened successfully!");

                    string query = "SELECT * FROM tbUser";
                    using (var command = new SqliteCommand(query, connection))
                    {
                        //command.ExecuteNonQuery();
                        SqliteDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            User u = new User();
                            u.id = reader.GetInt32(0);
                            u.username = reader.GetString(1);
                            u.password = reader.GetString(2);

                            try
                            {
                                u.connectionString = reader.GetString(4);
                            }
                            catch (Exception ex)
                            {

                            }
                            users.Add(u);
                        }
                    }

                    connection.Close();
                    Console.WriteLine("SQLite connection closed.");
                }
            }
            catch (SqliteException ex)
            {
                MessageBox.Show($"SQLite Error: {ex.Message}", "SQLite Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < users.Count; i++)
            {
                if (txtUsername.Text == users[i].username && txtPassword.Text == users[i].password)
                {
                    user = users[i];
                    isLogin = true;

                    this.Hide();
                    break;
                }
            }
        }
    }
}
