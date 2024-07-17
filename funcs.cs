using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;

namespace PABMS
{
    public class Funcs
    {

        public class Info
        {
            public int id {  get; set; }
            public int offset { get; set; }
            public string connectionString { get; set; }
            public string tableName { get; set; }
            public string primaryKeyName { get; set; }
            public DataTable dt { get; set; }
            public DataGridView grid { get; set; }

            public Info() { }
            public Info(string conStr, string tbName, string pKeyName, DataTable dataTable, DataGridView dgv)
            {
                this.connectionString = conStr;
                this.tableName = tbName;
                this.primaryKeyName = pKeyName;
                this.dt = dataTable;
                this.grid = dgv;
            }
        }

        public Info info = new Info();

        public int getLatestID()
        {
            int max = 0;
            // query to get the latest ID from the database
            using (SqlConnection connection = new SqlConnection(info.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT MAX({info.primaryKeyName}) FROM {info.tableName}", connection);
                max = Convert.ToInt32(command.ExecuteScalar());
                connection.Close();
            }
            return max + 1;
        }

        public bool IsAtEndOfDataGridView()
        {
            info.grid.SuspendLayout();
            if (info.grid.Rows.Count == 0)
                return false; // No rows in DataGridView.

            // Get the index of the last row that is currently displayed.
            int lastVisibleRowIndex = info.grid.FirstDisplayedScrollingRowIndex;
            for (int i = info.grid.FirstDisplayedScrollingRowIndex; i < info.grid.Rows.Count; i++)
            {
                if (info.grid.Rows[i].Displayed)
                {
                    lastVisibleRowIndex = i;
                }
                else
                {
                    break; // Exit the loop once you find the first row that is not displayed.
                }
            }
            info.grid.ResumeLayout();
            return lastVisibleRowIndex == info.grid.Rows.Count - 1;
        }

        public void addFirst10RowsToDataTable(int i=1)
        {
            info.dt.Clear();
            info.offset = 0;
            using (SqlConnection connection = new SqlConnection(info.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM {info.tableName} ORDER BY {info.primaryKeyName} OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", connection);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(info.dt);
                }
                connection.Close();
            }
        }
        public void addNext10RowsToDataTable()
        {
            using (SqlConnection connection = new SqlConnection(info.connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT * FROM {info.tableName} ORDER BY {info.primaryKeyName} OFFSET @offset ROWS FETCH NEXT 10 ROWS ONLY", connection);
                info.offset += 10;
                command.Parameters.AddWithValue("@offset", info.offset);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(info.dt);
                }
                connection.Close();
            }
        }

        public void addRowWhenScrollingEnds()
        {
            if (IsAtEndOfDataGridView())
            {
                addNext10RowsToDataTable();
                info.grid.Refresh();
            }
        }

        /// <summary>
        /// hello
        /// </summary>
        public void searchByID()
        {
            DataTable temp = new DataTable();
            using (SqlConnection con = new SqlConnection(info.connectionString))
            {
                con.Open();
                // execute SearchItemById with three arguments
                using (SqlCommand cmd = new SqlCommand("SearchItemById", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TableName", info.tableName);
                    cmd.Parameters.AddWithValue("@PrimaryKeyName", info.primaryKeyName);
                    cmd.Parameters.AddWithValue("@Id", info.id);
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(temp);
                    }
                    info.grid.DataSource = temp;
                }
                con.Close();
            }
        }
        
        public DataTable fillComboBox(ComboBox cmb, string tableName, string cmbColumn)
        {
            DataTable dt = new DataTable();
            using (SqlConnection con = new SqlConnection(info.connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand($"SELECT * FROM {tableName}", con))
                {
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
                    sqlDataAdapter.Fill(dt);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cmb.Items.Add(reader[cmbColumn].ToString());
                        }
                    }
                }
                con.Close();
                return dt;
            }
        }

    }
}
