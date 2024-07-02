using System;
using System.Data;
using System.Data.SqlClient;
using System.IO.Packaging;
using System.Windows.Forms;

namespace PABMS
{
    public partial class PackageForm : Form
    {
        public PackageForm(SqlConnection connection)
        {
            InitializeComponent();
        }
    }
}
