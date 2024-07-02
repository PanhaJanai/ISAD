using System.Data.SqlClient;
using System.Data;

namespace PABMS
{
    public partial class StaffForm : Form
    {
        public StaffForm(SqlConnection connection)
        {
            InitializeComponent();
        }
    }
}
