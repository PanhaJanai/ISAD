using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PABMS
{

    public partial class BusForm : Form
    {
        DataTable table_bus = new DataTable();
        SqlConnection connection_bus;
        SqlDataAdapter adapter_bus = new SqlDataAdapter();
        
        public BusForm(SqlConnection connection)
        {
            InitializeComponent();
            connection_bus = connection;
            adapter_bus.SelectCommand = new SqlCommand("SELECT * FROM tbBus", connection_bus);
            adapter_bus.Fill(table_bus);
        }

        #region User generated Functions

        void refreshGrid()
        {
            
        }

        #endregion
    }
}
